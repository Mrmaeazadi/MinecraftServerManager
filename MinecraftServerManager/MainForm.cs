using Aeat;
using BotManager;
using DiscordRPC;
using System.Management;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using System.IO.Compression;

namespace MinecraftServerManager;

public partial class MainForm : Form
{
    private string currentFile;
    private Process _serverProcess;
    private DiscordRpcClient _client;
    private string _currentDirectory;
    private FileSystemWatcher fileWatcher;
    FontDialog fontDialog = new FontDialog();
    private MrContextMenuStrip fileContextMenu;
    private PerformanceCounter _ramUsageCounter;
    ColorDialog colorDialog = new ColorDialog();
    private MrContextMenuStrip playerContextMenu;
    private MrContextMenuStrip pluginContextMenu;
    ColorDialog textColorDialog = new ColorDialog();
    private System.Windows.Forms.Timer _updateTimer;
    private List<string> playerList = new List<string>();
    ColorDialog changeHoverCardColorDialog = new ColorDialog();
    ColorDialog changeBackgroundColorDialog = new ColorDialog();

    public MainForm()
    {
        InitializeComponent();
        InitializeDiscordRPC();
        InitializeFileWatcher();
        InitializePlayerListMenu();
        InitializeFileContextMenu();
        InitializeCustomComponents();
    }

    //***********************************************************************************
    // Minecraft Right Click Options
    //***********************************************************************************
    private void KickPlayer()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"kick {playerName}");
        }
    }

    private void BanPlayer()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"ban {playerName}");
        }
    }

    private void GiveHunger()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"effect give {playerName} minecraft:hunger 10 255 true");
        }
    }

    private void HealPlayer()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"effect give {playerName} minecraft:instant_health 1 2 true");
        }
    }

    private void FillSaturation()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"effect give {playerName} minecraft:saturation 2 255 true");
        }
    }

    private void OP()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"op {playerName}");
        }
    }

    private void Deop()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"deop {playerName}");
        }
    }

    private void SayHello()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"say Hello, {playerName}!");
        }
    }

    private void TeleportPlayer(string fromPlayer, string toPlayer)
    {
        if (playerListBox.SelectedItem != null)
        {
            SendCommandToServer($"tp {fromPlayer} {toPlayer}");
        }
    }

    private void GivePlayerGoldenApple()
    {
        if (playerListBox.SelectedItem != null)
        {
            string playerName = playerListBox.SelectedItem.ToString();
            SendCommandToServer($"give {playerName} golden_apple 1");
        }
    }

    //***********************************************************************************
    // Right Click Menus
    //***********************************************************************************

    private void InitializePlayerListMenu()
    {
        playerContextMenu = new MrContextMenuStrip();

        playerContextMenu.Items.Add("Kick", null, (s, e) => KickPlayer());
        playerContextMenu.Items.Add("Ban", null, (s, e) => BanPlayer());
        playerContextMenu.Items.Add("Fill Saturation", null, (s, e) => FillSaturation());
        playerContextMenu.Items.Add("OP", null, (s, e) => OP());
        playerContextMenu.Items.Add("Deop", null, (s, e) => Deop());
        playerContextMenu.Items.Add("Heal", null, (s, e) => HealPlayer());
        playerContextMenu.Items.Add("Hunger", null, (s, e) => GiveHunger());
        playerContextMenu.Items.Add("Say Hello", null, (s, e) => SayHello());
        playerContextMenu.Items.Add("Give Them Golder Apple", null, (s, e) => GivePlayerGoldenApple());

        ToolStripMenuItem teleportMenuItem = new ToolStripMenuItem("Teleport");
        teleportMenuItem.ForeColor = playerContextMenu.ForeColor;
        teleportMenuItem.BackColor = playerContextMenu.BackColor;

        teleportMenuItem.DropDownOpening += (s, e) => PopulateTeleportMenu(teleportMenuItem);
        playerContextMenu.Items.Add(teleportMenuItem);
    }

    private void PopulateTeleportMenu(ToolStripMenuItem teleportMenuItem)
    {
        teleportMenuItem.DropDownItems.Clear();

        if (playerListBox.SelectedItem == null)
            return;

        string selectedPlayer = playerListBox.SelectedItem.ToString();

        foreach (string player in playerList)
        {
            if (player != selectedPlayer)
            {
                ToolStripMenuItem playerItem = new ToolStripMenuItem(player);
                playerItem.ForeColor = playerContextMenu.ForeColor;
                playerItem.BackColor = playerContextMenu.BackColor;

                playerItem.Click += (s, e) => TeleportPlayer(selectedPlayer, player);
                teleportMenuItem.DropDownItems.Add(playerItem);
            }
        }
    }

    private void InitializeFileContextMenu()
    {
        fileContextMenu = new MrContextMenuStrip();

        fileContextMenu.Items.Add("Copy", null, (s, e) => CopyFileOrFolder());
        fileContextMenu.Items.Add("Cut", null, (s, e) => CutFileOrFolder());
        fileContextMenu.Items.Add("Refresh", null, (s, e) => UpdateFileListBox(_currentDirectory));
        fileContextMenu.Items.Add("Rename", null, (s, e) => Rename());
        fileContextMenu.Items.Add("New File", null, (s, e) => NewFile());
        fileContextMenu.Items.Add("New Folder", null, (s, e) => NewFolder());
        fileContextMenu.Items.Add("Upload File Or Folder", null, (s, e) => UploadFileOrFolder());
        fileContextMenu.Items.Add("Delete", null, (s, e) => DeleteFile());
        fileContextMenu.Items.Add("Paste", null, (s, e) => PasteFileOrFolder());
    }

    //***********************************************************************************
    // Discord RPC
    //***********************************************************************************

    public void InitializeDiscordRPC()
    {
        _client = new DiscordRpcClient("1339575393451114506");

        _client.Initialize();

        _client.SetPresence(new RichPresence()
        {
            Details = "MCServerManager Started!",
            State = "Ready To Start!",
            Assets = new Assets()
            {
                LargeImageKey = "blockywrenches",
                LargeImageText = "MCServerManager",
            }
        });
    }

    public void UpdateDiscordActivity(string state, string details, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText)
    {
        if (_client != null)
        {
            _client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImageKey,
                    SmallImageText = smallImageText,
                }
            });
        }
    }

    //***********************************************************************************
    // Minecraft Server Stuff
    //***********************************************************************************

    private void StartMrButton_Click(object sender, EventArgs e)
    {
        serverStartTime = DateTime.Now;
        StartDashboardUpdateLoop();

        if (_serverProcess != null && !_serverProcess.HasExited)
        {
            consoleRichTextBox.AppendText("Server is already running.\n");
            return;
        }

        try
        {
            string serverName = serverFileNameTextBox.Text;
            string minMem = minRAMTextBox.Text;
            string maxMem = maxRAMTextBox.Text;
            if (serverName == null || serverName == "" && minMem == null || minMem == "" && maxMem == null || maxMem == "")
            {
                MessageBox.Show("Set the required stuff!");
            }
            else
            {
                _serverProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "java",
                        Arguments = $"-Xms{minMem}M -Xmx{maxMem}M --add-modules=jdk.incubator.vector -XX:+UseG1GC -XX:+ParallelRefProcEnabled -XX:MaxGCPauseMillis=200 -XX:+UnlockExperimentalVMOptions -XX:+DisableExplicitGC -XX:+AlwaysPreTouch -XX:G1HeapWastePercent=5 -XX:G1MixedGCCountTarget=4 -XX:InitiatingHeapOccupancyPercent=15 -XX:G1MixedGCLiveThresholdPercent=90 -XX:G1RSetUpdatingPauseTimePercent=5 -XX:SurvivorRatio=32 -XX:+PerfDisableSharedMem -XX:MaxTenuringThreshold=1 -Dusing.aikars.flags=https://mcflags.emc.gs -Daikars.new.flags=true -XX:G1NewSizePercent=30 -XX:G1MaxNewSizePercent=40 -XX:G1HeapRegionSize=8M -XX:G1ReservePercent=20 -jar {serverName}.jar nogui",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                _serverProcess.OutputDataReceived += (s, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        if (statusLabel.Text != "ONLINE")
                        {
                            this.Invoke(new Action(() =>
                            {
                                statusLabel.Text = "ONLINE";
                                statusLabel.ForeColor = Color.FromArgb(0, 255, 0);
                            }));
                        }
                    }
                };


                _serverProcess.OutputDataReceived += (s, ev) => ProcessServerOutput(ev.Data);
                _serverProcess.ErrorDataReceived += (s, ev) => AppendTextToConsole(ev.Data);

                _serverProcess.Start();
                _serverProcess.BeginOutputReadLine();
                _serverProcess.BeginErrorReadLine();

                consoleRichTextBox.AppendText("Minecraft Server started.\n");
                serverStatusLogLabel.Text = "Server Online";
                serverStatusLogLabel.ForeColor = Color.FromArgb(0, 255, 0);
                //statusLabel.Text = "ONLINE";
                //statusLabel.ForeColor = Color.FromArgb(0, 255, 0);
            }
        }
        catch (Exception ex)
        {
            consoleRichTextBox.AppendText($"Error: {ex.Message}\n");
        }
    }

    private void Start()
    {
        serverStartTime = DateTime.Now;
        StartDashboardUpdateLoop();

        if (_serverProcess != null && !_serverProcess.HasExited)
        {
            consoleRichTextBox.AppendText("Server is already running.\n");
            return;
        }

        try
        {
            string serverName = serverFileNameTextBox.Text;
            string minMem = minRAMTextBox.Text;
            string maxMem = maxRAMTextBox.Text;
            if (serverName == null || serverName == "" && minMem == null || minMem == "" && maxMem == null || maxMem == "")
            {
                MessageBox.Show("Set the required stuff!");
            }
            else
            {
                _serverProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "java",
                        Arguments = $"-Xms{minMem}M -Xmx{maxMem}M --add-modules=jdk.incubator.vector -XX:+UseG1GC -XX:+ParallelRefProcEnabled -XX:MaxGCPauseMillis=200 -XX:+UnlockExperimentalVMOptions -XX:+DisableExplicitGC -XX:+AlwaysPreTouch -XX:G1HeapWastePercent=5 -XX:G1MixedGCCountTarget=4 -XX:InitiatingHeapOccupancyPercent=15 -XX:G1MixedGCLiveThresholdPercent=90 -XX:G1RSetUpdatingPauseTimePercent=5 -XX:SurvivorRatio=32 -XX:+PerfDisableSharedMem -XX:MaxTenuringThreshold=1 -Dusing.aikars.flags=https://mcflags.emc.gs -Daikars.new.flags=true -XX:G1NewSizePercent=30 -XX:G1MaxNewSizePercent=40 -XX:G1HeapRegionSize=8M -XX:G1ReservePercent=20 -jar {serverName}.jar nogui",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                _serverProcess.OutputDataReceived += (s, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        //AppendTextToConsole(text: args.Data);

                        if (statusLabel.Text != "ONLINE")
                        {
                            this.Invoke(new Action(() =>
                            {
                                statusLabel.Text = "ONLINE";
                                statusLabel.ForeColor = Color.FromArgb(0, 255, 0);
                            }));
                        }
                    }
                };

                _serverProcess.OutputDataReceived += (s, ev) => ProcessServerOutput(ev.Data);
                _serverProcess.ErrorDataReceived += (s, ev) => AppendTextToConsole(ev.Data);

                _serverProcess.Start();
                _serverProcess.BeginOutputReadLine();
                _serverProcess.BeginErrorReadLine();

                consoleRichTextBox.AppendText("Minecraft Server started.\n");
                serverStatusLogLabel.Text = "Server Online";
                serverStatusLogLabel.ForeColor = Color.FromArgb(0, 255, 0);
                //statusLabel.Text = "ONLINE";
                //statusLabel.ForeColor = Color.FromArgb(0, 255, 0);
            }
        }
        catch (Exception ex)
        {
            consoleRichTextBox.AppendText($"Error: {ex.Message}\n");
        }
    }

    private void StopMrButton_Click(object sender, EventArgs e)
    {
        serverStartTime = null;
        dashboardUpdateToken.Cancel();
        serverUptimeTimeLabel.Text = "Off";

        if (_serverProcess == null || _serverProcess.HasExited)
        {
            consoleRichTextBox.AppendText("Server is not running.\n");
            return;
        }

        try
        {
            SendCommandToServer("stop");
            Task.Delay(5000).Wait();
            _serverProcess.Kill();
            _serverProcess.Dispose();
            _serverProcess = null;
            consoleRichTextBox.AppendText("Minecraft Server stopped.\n");
            serverStatusLogLabel.Text = "Server Offline";
            serverStatusLogLabel.ForeColor = Color.FromArgb(255, 0, 0);
            statusLabel.Text = "OFFLINE";
            statusLabel.ForeColor = Color.FromArgb(255, 0, 0);
            playerListBox.Items.Clear();
        }
        catch (Exception ex)
        {
            consoleRichTextBox.AppendText($"Error stopping server: {ex.Message}\n");
        }
    }

    private void Stop()
    {
        serverStartTime = null;
        dashboardUpdateToken.Cancel();
        serverUptimeTimeLabel.Text = "Off";

        if (_serverProcess == null || _serverProcess.HasExited)
        {
            consoleRichTextBox.AppendText("Server is not running.\n");
            return;
        }

        try
        {
            SendCommandToServer("stop");
            Task.Delay(5000).Wait();
            _serverProcess.Kill();
            _serverProcess.Dispose();
            _serverProcess = null;
            consoleRichTextBox.AppendText("Minecraft Server stopped.\n");
            serverStatusLogLabel.Text = "Server Offline";
            serverStatusLogLabel.ForeColor = Color.FromArgb(255, 0, 0);
            statusLabel.Text = "OFFLINE";
            statusLabel.ForeColor = Color.FromArgb(255, 0, 0);
            playerListBox.Items.Clear();
        }
        catch (Exception ex)
        {
            consoleRichTextBox.AppendText($"Error stopping server: {ex.Message}\n");
        }
    }

    private void AppendTextToConsole(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            consoleRichTextBox.Invoke(new Action(() =>
            {
                consoleRichTextBox.AppendText(text + "\n");
                consoleRichTextBox.ScrollToCaret();
            }));
        }
    }

    private void ProcessServerOutput(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            consoleRichTextBox.Invoke(new Action(() =>
            {
                consoleRichTextBox.AppendText(text + "\n");
                consoleRichTextBox.ScrollToCaret();
            }));

            Match match = Regex.Match(text, @"(\w+) joined the game");
            if (match.Success)
            {
                string playerName = match.Groups[1].Value;
                if (!playerList.Contains(playerName))
                {
                    playerList.Add(playerName);
                    playerListBox.Invoke(new Action(() => playerListBox.Items.Add(playerName)));
                }
            }

            Match leaveMatch = Regex.Match(text, @"(\w+) left the game");
            if (leaveMatch.Success)
            {
                string playerName = leaveMatch.Groups[1].Value;
                if (playerList.Contains(playerName))
                {
                    playerList.Remove(playerName);
                    playerListBox.Invoke(new Action(() => playerListBox.Items.Remove(playerName)));
                }
            }
        }
    }

    private void SendCommandToServer(string command)
    {
        if (_serverProcess == null || _serverProcess.HasExited)
        {
            consoleRichTextBox.AppendText("Server is not running.\n");
            return;
        }

        if (!string.IsNullOrWhiteSpace(command))
        {
            try
            {
                _serverProcess.StandardInput.WriteLine(command);
                _serverProcess.StandardInput.Flush();
                consoleRichTextBox.AppendText($"> {command}\n");
            }
            catch (Exception ex)
            {
                consoleRichTextBox.AppendText($"Error sending command: {ex.Message}\n");
            }
        }

        sendCommandTextBox.Clear();
    }

    //***********************************************************************************
    // App Stats
    //***********************************************************************************

    private DateTime? serverStartTime = null;
    private CancellationTokenSource dashboardUpdateToken = new CancellationTokenSource();

    private void InitializeCustomComponents()
    {
        _currentDirectory = Directory.GetCurrentDirectory();
        _ramUsageCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

        _updateTimer = new System.Windows.Forms.Timer
        {
            Interval = 1000,
        };

        _updateTimer.Tick += (sender, e) => UpdateDashboardAsync();
        _updateTimer.Start();
    }

    private async void StartDashboardUpdateLoop()
    {
        dashboardUpdateToken.Cancel();
        dashboardUpdateToken = new CancellationTokenSource();

        try
        {
            while (!dashboardUpdateToken.Token.IsCancellationRequested)
            {
                UpdateDashboardAsync();
                await Task.Delay(1000, dashboardUpdateToken.Token);
            }
        }
        catch (TaskCanceledException)
        {

        }
    }

    private async void UpdateDashboardAsync()
    {
        await Task.Run(() =>
        {
            var cpuUsage = GetCPUUsage();
            var ramUsage = GetRAMUsage();
            Invoke((MethodInvoker)delegate
            {
                if (serverStartTime.HasValue)
                {
                    var uptime = (int)(DateTime.Now - serverStartTime.Value).TotalSeconds;
                    serverUptimeTimeLabel.Text = $"{uptime} Seconds";
                }
                else
                {
                    serverUptimeTimeLabel.Text = "Off";
                }

                CPUUsagePercentageLabel.Text = $"{cpuUsage}%";
                RAMUsagePercentageLabel.Text = $"{ramUsage}%";
            });
        });
    }

    private string GetCPUUsage()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("select * from Win32_Processor");
            var query = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            return query?["LoadPercentage"].ToString() ?? "0";
        }
        catch
        {
            return "0";
        }
    }

    private string GetRAMUsage()
    {
        try
        {
            return _ramUsageCounter.NextValue().ToString("F0");
        }
        catch
        {
            return "0";
        }
    }

    //***********************************************************************************
    // Form Stuff
    //***********************************************************************************

    private Point mouseLocation;

    private void NavigationBarMrPanel_MouseDown(object sender, MouseEventArgs e)
    {
        mouseLocation = new Point(-e.X, -e.Y);
    }

    private void NavigationBarMrPanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Point mousePose = Control.MousePosition;
            mousePose.Offset(mouseLocation.X, mouseLocation.Y);
            Location = mousePose;
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        CheckForUpdates();

        textColorDialog.Color = Color.White;
        colorDialog.Color = Color.FromArgb(5, 222, 5);

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length > 1)
            {
                try
                {
                    int argb = int.Parse(lines[3]);
                    colorDialog.Color = Color.FromArgb(argb);

                    TransparencyKey = Color.FromArgb(254, 204, 245);
                    dashboardMrPanel.BringToFront();
                    dashboardTabLabel.ForeColor = colorDialog.Color;
                    dashboardUnderTabPanel.BackColor = colorDialog.Color;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(text: $"Error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, defaultButton: MessageBoxDefaultButton.Button1, icon: MessageBoxIcon.Error);
                }
            }
        }

        LoadCustomized();
        TransparencyKey = Color.FromArgb(254, 204, 245);
        dashboardMrPanel.BringToFront();
        dashboardTabLabel.ForeColor = colorDialog.Color;
        dashboardUnderTabPanel.BackColor = colorDialog.Color;

        serverNameLabel.Font = new Font("Segoe Print", 9.75f, FontStyle.Bold);
        dotJarLabel.Font = new Font("Segoe Print", 9.75f, FontStyle.Bold);
        minRAMLabel.Font = new Font("Segoe Print", 9.75f, FontStyle.Bold);
        minRAMMBLabel.Font = new Font("Segoe Print", 9.75f, FontStyle.Bold);
        maxRAMLabel.Font = new Font("Segoe Print", 9.75f, FontStyle.Bold);
        maxRAMMBLabel.Font = new Font("Segoe Print", 9.75f, FontStyle.Bold);

        customizeTabLabel.ForeColor = Color.White;
        customizeUnderTabPanel.Visible = false;
        DashboardTabLabel_Click(sender, e);

        UpdateFileListBox(_currentDirectory);
        InitializeFileWatcher();
    }

    private void ClosePictureBox_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void ConsoleTabLabel_Click(object sender, EventArgs e)
    {
        consoleMrPanel.BringToFront();
        consoleUnderTabPanel.Visible = true;
        consoleTabLabel.ForeColor = colorDialog.Color;
        consoleUnderTabPanel.BackColor = colorDialog.Color;
        UpdateDiscordActivity("Executing Commands!", "In Console", "blockywrenches", "MCServerManager", "console", "Console");

        fileManagerUnderTabPanel.Visible = false;
        fileManagerTabLabel.ForeColor = Color.White;
        dashboardUnderTabPanel.Visible = false;
        dashboardTabLabel.ForeColor = Color.White;
        customizeUnderTabPanel.Visible = false;
        customizeTabLabel.ForeColor = Color.White;
    }

    private void DashboardTabLabel_Click(object sender, EventArgs e)
    {
        dashboardMrPanel.BringToFront();
        dashboardUnderTabPanel.Visible = true;
        dashboardTabLabel.ForeColor = colorDialog.Color;
        dashboardUnderTabPanel.BackColor = colorDialog.Color;
        UpdateDiscordActivity("Viewing The Stats!", "On Dashboard", "blockywrenches", "MCServerManager", "dashboard", "Dashboard");

        fileManagerUnderTabPanel.Visible = false;
        fileManagerTabLabel.ForeColor = Color.White;
        consoleUnderTabPanel.Visible = false;
        consoleTabLabel.ForeColor = Color.White;
        customizeUnderTabPanel.Visible = false;
        customizeTabLabel.ForeColor = Color.White;
    }

    private void FileManagerTabLabel_Click(object sender, EventArgs e)
    {
        fileManagerMrPanel.BringToFront();
        fileManagerUnderTabPanel.Visible = true;
        fileManagerTabLabel.ForeColor = colorDialog.Color;
        fileManagerUnderTabPanel.BackColor = colorDialog.Color;
        UpdateDiscordActivity("Editing Files!", "Viewing Files", "blockywrenches", "MCServerManager", "file", "File Manager");

        dashboardUnderTabPanel.Visible = false;
        dashboardTabLabel.ForeColor = Color.White;
        consoleUnderTabPanel.Visible = false;
        consoleTabLabel.ForeColor = Color.White;
        customizeUnderTabPanel.Visible = false;
        customizeTabLabel.ForeColor = Color.White;
    }

    private void CustomizeTabLabel_Click(object sender, EventArgs e)
    {
        customizeMrPanel.BringToFront();
        customizeUnderTabPanel.Visible = true;
        customizeTabLabel.ForeColor = colorDialog.Color;
        customizeUnderTabPanel.BackColor = colorDialog.Color;
        UpdateDiscordActivity("Changing Their App Decoration!", "Customizing The App", "blockywrenches", "MCServerManager", "paint", "Customizing...");

        dashboardUnderTabPanel.Visible = false;
        dashboardTabLabel.ForeColor = Color.White;
        consoleUnderTabPanel.Visible = false;
        consoleTabLabel.ForeColor = Color.White;
        fileManagerUnderTabPanel.Visible = false;
        fileManagerTabLabel.ForeColor = Color.White;
    }

    private void MinRAMAndmaxRAMTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        {
            e.Handled = true;
        }

        if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        {
            e.Handled = true;
        }
    }

    private void RestartMrButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_serverProcess != null)
            {
                Stop();
                Task.Delay(5000).Wait();
                Start();
            }
            else
            {
                consoleRichTextBox.AppendText("Server is not running.\n");
                return;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void SendCommandTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (!string.IsNullOrWhiteSpace(sendCommandTextBox.Text))
            {
                SendCommandToServer(sendCommandTextBox.Text);

                sendCommandTextBox.Clear();
            }
            e.SuppressKeyPress = true;
        }
    }

    private void SendPictureBox_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(sendCommandTextBox.Text))
        {
            SendCommandToServer(sendCommandTextBox.Text);

            sendCommandTextBox.Clear();
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Stop();
    }

    private void TopMostMrCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (topMostMrCheckBox.Checked)
        {
            TopMost = true;
        }
        else
        {
            TopMost = false;
        }
    }

    //***********************************************************************************
    // File Manager
    //***********************************************************************************
    private void LoadFiles_Click()
    {
        try
        {
            fileListBox.Items.Clear();
            var files = Directory.GetFileSystemEntries(_currentDirectory);
            foreach (var file in files)
            {
                fileListBox.Items.Add(Path.GetFileName(file));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Failed To Load Files: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void FileListBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0)
        {
            return;
        }

        string itemText = fileListBox.Items[e.Index].ToString();
        string fullPath = Path.Combine(_currentDirectory, itemText);

        bool isDirectory = Directory.Exists(fullPath);
        Color backColor = isDirectory ? colorDialog.Color : changeHoverCardColorDialog.Color;

        e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
        using (SolidBrush textBrush = new SolidBrush(textColorDialog.Color))
        {
            e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);
        }

        e.DrawFocusRectangle();
    }


    //private void MyNameLabel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        ProcessStartInfo processStartInfo = new ProcessStartInfo
    //        {
    //            FileName = "https://mr-maeazadi.mcexe.ir/",
    //            UseShellExecute = true,
    //        };

    //        Process.Start(processStartInfo);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(text: $"Failed To Open Link: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
    //    }
    //}

    private void FileListBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.XButton1)
        {
            BackButton_Click(sender, e);
        }

        if (e.Button == MouseButtons.Right)
        {
            int index = fileListBox.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                fileListBox.SelectedIndex = index;
            }
            else
            {
                fileListBox.ClearSelected();
            }

            fileContextMenu.Renderer = new ToolStripProfessionalRenderer(new DarkColorTable(colorDialog.Color));

            fileContextMenu.Show(fileListBox, e.Location);
        }
    }

    private void DeleteSelectedItem()
    {
        try
        {
            if (fileListBox.SelectedItem == null)
            {
                MessageBox.Show(text: "Please Select A File Or Folder To Delete.", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
                return;
            }

            string selectedItem = fileListBox.SelectedItem.ToString();
            string fullPath = Path.Combine(_currentDirectory, selectedItem);

            DialogResult result = MessageBox.Show(text: $"Are You Sure That You Want To Delete {selectedItem}?", caption: "Confirmation", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, true);
                }
                else if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                else
                {
                    MessageBox.Show(text: "Nothing Found!", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }

                UpdateFileListBox(_currentDirectory);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Failed To Delete File Or Folder: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void DeleteFile()
    {
        if (fileListBox.SelectedItem != null)
        {
            string fileName = fileListBox.SelectedItem.ToString();
            DeleteSelectedItem();
        }
    }

    private string clipboardPath = string.Empty;
    private bool isCutOperation = false;

    private void CopyFileOrFolder()
    {
        if (fileListBox.SelectedItem != null)
        {
            clipboardPath = Path.Combine(_currentDirectory, fileListBox.SelectedItem.ToString());
            isCutOperation = false;
        }
    }

    private void CutFileOrFolder()
    {
        if (fileListBox.SelectedItem != null)
        {
            clipboardPath = Path.Combine(_currentDirectory, fileListBox.SelectedItem.ToString());
            isCutOperation = true;
        }
    }

    private void PasteFileOrFolder()
    {
        if (string.IsNullOrEmpty(clipboardPath))
        {
            MessageBox.Show(text: "Couldn't Find Any Other File(s) Or Folder(s) To Paste", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
            return;
        }

        string destinationPath = Path.Combine(_currentDirectory, Path.GetFileName(clipboardPath));

        try
        {
            if (File.Exists(clipboardPath))
            {
                if (isCutOperation)
                {
                    File.Move(clipboardPath, destinationPath);
                }
                else
                {
                    File.Copy(clipboardPath, destinationPath, true);
                }
            }
            else if (Directory.Exists(clipboardPath))
            {
                if (isCutOperation)
                {
                    Directory.Move(clipboardPath, destinationPath);
                }
                else
                {
                    DirectoryCopy(clipboardPath, destinationPath, true);
                }
            }
            else
            {
                MessageBox.Show(text: "Couldn't Find The Selected File(s) Or Folder(s)!", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }

            LoadFiles_Click();

            if (isCutOperation)
            {
                clipboardPath = string.Empty;
                isCutOperation = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private static void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDir);
        DirectoryInfo[] dirs = dir.GetDirectories();

        Directory.CreateDirectory(destDir);

        foreach (FileInfo file in dir.GetFiles())
        {
            string tempPath = Path.Combine(destDir, file.Name);
            file.CopyTo(tempPath, true);
        }

        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDir, subdir.Name);
                DirectoryCopy(subdir.FullName, tempPath, true);
            }
        }
    }

    private void CreateNewFolder()
    {
        try
        {
            string newFolderName = "New Folder";
            string newFolderPath = Path.Combine(_currentDirectory, newFolderName);

            int counter = 1;
            while (Directory.Exists(newFolderPath))
            {
                newFolderName = $"New Folder ({counter})";
                newFolderPath = Path.Combine(_currentDirectory, newFolderName);
                counter++;
            }

            Directory.CreateDirectory(newFolderPath);

            UpdateFileListBox(_currentDirectory);
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Error While Creating A New Folder: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void CreateNewFile()
    {
        try
        {
            string newFileName = "New File.txt";
            string newFilePath = Path.Combine(_currentDirectory, newFileName);

            int counter = 1;
            while (File.Exists(newFilePath))
            {
                newFileName = $"New File ({counter}).txt";
                newFilePath = Path.Combine(_currentDirectory, newFileName);
                counter++;
            }

            File.WriteAllText(newFilePath, "");

            UpdateFileListBox(_currentDirectory);
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Error While Creating A New File: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void NewFolder()
    {
        if (fileListBox.SelectedItem != null)
        {
            string fileName = fileListBox.SelectedItem.ToString();
        }

        CreateNewFolder();
    }

    public void Rename()
    {
        if (fileListBox.SelectedItem != null)
        {
            string oldName = fileListBox.SelectedItem.ToString();
            string oldPath = Path.Combine(_currentDirectory, oldName);

            using (RenameForm renameForm = new RenameForm(oldName))
            {
                if (renameForm.ShowDialog() == DialogResult.OK)
                {
                    string newName = renameForm.Tag as string;

                    if (!string.IsNullOrEmpty(newName))
                    {
                        try
                        {
                            string newPath = Path.Combine(_currentDirectory, newName);

                            if (Directory.Exists(oldPath))
                            {
                                Directory.Move(oldPath, newPath);
                            }
                            else if (File.Exists(oldPath))
                            {
                                File.Move(oldPath, newPath);
                            }

                            UpdateFileListBox(_currentDirectory);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(text: "Error: " + ex.Message, caption: "Error While Renaming", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        else
        {
            MessageBox.Show(text: "Please Select A File Or Folder To Rename.", caption: "Rename", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
        }
    }

    private void NewFile()
    {
        if (fileListBox.SelectedItem != null)
        {
            string fileName = fileListBox.SelectedItem.ToString();
        }

        CreateNewFile();
    }
    private void SaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(currentFile))
            {
                if (fileEditorRichTextBox.Text == "")
                {
                    MessageBox.Show(text: $"You Can't Save An Empty File!", caption: "Error", buttons: MessageBoxButtons.OK, defaultButton: MessageBoxDefaultButton.Button1, icon: MessageBoxIcon.Error);

                    var selectedFile = fileListBox.SelectedItem.ToString();
                    var fullPath = Path.Combine(_currentDirectory, selectedFile);
                    currentFile = fullPath;
                    fileEditorRichTextBox.Text = File.ReadAllText(fullPath);

                    //MessageBox.Show(text: $"Do You Want To Save An Empty File?", caption: "Confirmation", buttons: MessageBoxButtons.YesNo, defaultButton: MessageBoxDefaultButton.Button2, icon: MessageBoxIcon.Question);

                    //if (DialogResult == DialogResult.Yes)
                    //{
                    //    File.WriteAllText(currentFile, fileEditorRichTextBox.Text);
                    //    MessageBox.Show(text: "File Saved!", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                    //}
                }
                else
                {
                    File.WriteAllText(currentFile, fileEditorRichTextBox.Text);
                    MessageBox.Show(text: "File Saved!", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Failed To Save The File: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        _currentDirectory = Directory.GetParent(_currentDirectory)?.FullName ?? _currentDirectory;
        LoadFiles_Click();
    }

    private void FileListBox_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (fileListBox.SelectedItem == null)
        {
            return;
        }

        var selectedFile = fileListBox.SelectedItem.ToString();

        if (string.IsNullOrEmpty(selectedFile))
        {
            return;
        }

        var fullPath = Path.Combine(_currentDirectory, selectedFile);

        try
        {
            if (Directory.Exists(fullPath))
            {
                _currentDirectory = fullPath;
                LoadFiles_Click();
            }
            else if (File.Exists(fullPath))
            {
                currentFile = fullPath;
                fileEditorRichTextBox.Text = File.ReadAllText(fullPath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Failed To Open File Or Folder: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        fileEditorRichTextBox.Clear();
    }

    private void UploadFileOrFolder()
    {
        using (var ofd = new OpenFileDialog())
        {
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;
            ofd.Title = "Please Select A File Or Cancel To Select A Folder To Upload...";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CopyFile(ofd.FileName);
                return;
            }
        }

        using (var fbd = new FolderBrowserDialog())
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                CopyFolder(fbd.SelectedPath);
            }
        }
    }

    private void CopyFile(string filePath)
    {
        string mainDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string fileName = Path.GetFileName(filePath);
        string destinationPath = Path.Combine(mainDirectory, fileName);

        try
        {
            File.Copy(filePath, destinationPath, true);
            fileListBox.Items.Add(destinationPath);
            MessageBox.Show(text: "File Uploaded Successfully!", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Failed To Upload File: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void CopyFolder(string sourceFolder)
    {
        string mainDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string folderName = Path.GetFileName(sourceFolder);
        string destinationFolder = Path.Combine(mainDirectory, folderName);

        try
        {
            DirectoryCopy(sourceFolder, destinationFolder, true);
            fileListBox.Items.Add(destinationFolder);
            MessageBox.Show(text: "Folder Uploaded Successfully", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Failed To Upload Folder: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private void Upload_Click(object sender, EventArgs e)
    {
        UploadFileOrFolder();
    }

    private void InitializeFileWatcher()
    {
        if (fileWatcher != null)
        {
            fileWatcher.Dispose();
        }

        fileWatcher = new FileSystemWatcher
        {
            Path = _currentDirectory,
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite,
            Filter = "*.*",
            //EnableRaisingEvents = false,
            IncludeSubdirectories = false,
        };

        fileWatcher.Changed += OnFileSystemChanged;
        fileWatcher.Created += OnFileSystemChanged;
        fileWatcher.Deleted += OnFileSystemChanged;
        fileWatcher.Renamed += OnFileSystemRenamed;
    }

    private void OnFileSystemChanged(object sender, FileSystemEventArgs e)
    {
        Invoke(new Action(() => UpdateFileListBox(_currentDirectory)));
    }

    private void OnFileSystemRenamed(object sender, RenamedEventArgs e)
    {
        Invoke(new Action(() => UpdateFileListBox(_currentDirectory)));
    }


    private void UpdateFileListBox(string directoryPath)
    {
        try
        {
            fileListBox.Items.Clear();
            var files = Directory.GetFileSystemEntries(directoryPath);
            foreach (var file in files)
            {
                fileListBox.Items.Add(Path.GetFileName(file));
            }

            _currentDirectory = directoryPath;

            InitializeFileWatcher();
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    //***********************************************************************************
    // App Update
    //***********************************************************************************.

    private const string updateUrl = "https://csharp.mcexe.ir/MCSM/updates/";
    private const string versionFile = "version.txt";
    private const string updateFile = "MCSM.zip";
    private const string currentVersion = "1.0.0";

    private void CheckForUpdates()
    {
        try
        {
#pragma warning disable
            using (WebClient client = new())
            {
                string latestVersion = client.DownloadString(updateUrl + versionFile).Trim();
                string currentVersion = GetCurrentVersion();

                if (currentVersion != latestVersion)
                {
                    var result = MessageBox.Show(text: $"New Update Is Available! {latestVersion}" + Environment.NewLine + $"Do You Want To Update?", caption: "Update", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Information, defaultButton: MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        DownloadAndUpdate(client, latestVersion);
                        UpdateLocalVersion(latestVersion);
                    }
                }
            }
#pragma warning restore
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    private string GetCurrentVersion()
    {
        string versionFilePath = Path.Combine(Application.StartupPath, versionFile);

        if (File.Exists(versionFilePath))
        {
            return File.ReadAllText(versionFilePath).Trim();
        }

        return currentVersion;
    }

    private void UpdateLocalVersion(string latestVersion)
    {
        string versionFilePath = Path.Combine(Application.StartupPath, versionFile);
        File.WriteAllText(versionFilePath, latestVersion);
    }

    private void DownloadAndUpdate(WebClient client, string latestVersion)
    {
        try
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), "update.zip");
            string extractPath = Path.Combine(Path.GetTempPath(), "update_extract");
            string updaterScriptPath = Path.Combine(Path.GetTempPath(), "update_script.bat");

            client.DownloadFile(updateUrl + updateFile, tempFilePath);
            MessageBox.Show(text: "The Update File Was Downloaded Successfully", caption: "Downloaded", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);

            if (Directory.Exists(extractPath))
            {
                Directory.Delete(extractPath, true);
            }

            Directory.CreateDirectory(extractPath);
            ZipFile.ExtractToDirectory(tempFilePath, extractPath);
            File.Delete(tempFilePath);
            MessageBox.Show(text: "The Files Were Extracted Successfully", caption: "Extracted", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);

            File.WriteAllText(updaterScriptPath, $@"
@echo off
timeout /t 2 >nul
xcopy /s /y ""{extractPath}\*"" ""{Application.StartupPath}\""
start """" ""{Path.Combine(Application.StartupPath, Path.GetFileName(Application.ExecutablePath))}""
del /f /q ""%~f0""
rmdir /s /q ""{extractPath}""
exit
");

            MessageBox.Show(text: "The Update Script Was Successfully Created", caption: "Script Created", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);

            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c \"{updaterScriptPath}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
            });

            UpdateLocalVersion(latestVersion);

            Application.Exit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(text: $"Error: {ex.Message}", caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }
    }

    //***********************************************************************************
    // Customization
    //***********************************************************************************

    private void ChangeColorMrButton_Click(object sender, EventArgs e)
    {
        colorDialog.ShowDialog();
        dashboardMrPanel.BorderColor = colorDialog.Color;
        changeColorMrButton.BorderColor = colorDialog.Color;
        customizeMrPanel.BorderColor = colorDialog.Color;
        mainMrPanel.BorderColor = colorDialog.Color;
        navigationBarMrPanel.BorderColor = colorDialog.Color;
        fileEditorMrPanel.BorderColor = colorDialog.Color;
        fileListMrPanel.BorderColor = colorDialog.Color;
        fileManagerMrPanel.BorderColor = colorDialog.Color;
        consoleMrPanel.BorderColor = colorDialog.Color;
        CPUUsageMrPanel.BorderColor = colorDialog.Color;
        memoryUsageMrPanel.BorderColor = colorDialog.Color;
        serverStatusMrPanel.BorderColor = colorDialog.Color;
        serverUpTimeMrPanel.BorderColor = colorDialog.Color;
        playerListBoxMrPanel.BorderColor = colorDialog.Color;
        startMrButton.BorderColor = colorDialog.Color;
        stopMrButton.BorderColor = colorDialog.Color;
        restartMrButton.BorderColor = colorDialog.Color;
        CPUUsageUnderMrPanel.BorderColor = colorDialog.Color;
        memoryUsageUnderMrPanel.BorderColor = colorDialog.Color;
        serverUpTimeUnderMrPanel.BorderColor = colorDialog.Color;
        serverStatusUnderMrPanel.BorderColor = colorDialog.Color;
        customizeTabLabel.ForeColor = colorDialog.Color;
        customizeUnderTabPanel.BackColor = colorDialog.Color;
        topMostMrCheckBox.BorderColor = colorDialog.Color;
        topMostMrCheckBox.CheckColor = colorDialog.Color;
        changeFontMrButton.BorderColor = colorDialog.Color;
        loadMrButton.BorderColor = colorDialog.Color;
        saveMrButton.BorderColor = colorDialog.Color;
        changeHoverCardColorMrButton.BorderColor = colorDialog.Color;
        changeBackgroundColorMrButton.BorderColor = colorDialog.Color;
    }

    private void SetBorderColor()
    {
        changeColorMrButton.BorderColor = colorDialog.Color;
        customizeMrPanel.BorderColor = colorDialog.Color;
        mainMrPanel.BorderColor = colorDialog.Color;
        navigationBarMrPanel.BorderColor = colorDialog.Color;
        fileEditorMrPanel.BorderColor = colorDialog.Color;
        fileListMrPanel.BorderColor = colorDialog.Color;
        fileManagerMrPanel.BorderColor = colorDialog.Color;
        consoleMrPanel.BorderColor = colorDialog.Color;
        dashboardMrPanel.BorderColor = colorDialog.Color;
        CPUUsageMrPanel.BorderColor = colorDialog.Color;
        memoryUsageMrPanel.BorderColor = colorDialog.Color;
        serverStatusMrPanel.BorderColor = colorDialog.Color;
        serverUpTimeMrPanel.BorderColor = colorDialog.Color;
        playerListBoxMrPanel.BorderColor = colorDialog.Color;
        startMrButton.BorderColor = colorDialog.Color;
        stopMrButton.BorderColor = colorDialog.Color;
        restartMrButton.BorderColor = colorDialog.Color;
        CPUUsageUnderMrPanel.BorderColor = colorDialog.Color;
        memoryUsageUnderMrPanel.BorderColor = colorDialog.Color;
        serverUpTimeUnderMrPanel.BorderColor = colorDialog.Color;
        serverStatusUnderMrPanel.BorderColor = colorDialog.Color;
        customizeTabLabel.ForeColor = colorDialog.Color;
        customizeUnderTabPanel.BackColor = colorDialog.Color;
        topMostMrCheckBox.BorderColor = colorDialog.Color;
        topMostMrCheckBox.CheckColor = colorDialog.Color;
        changeFontMrButton.BorderColor = colorDialog.Color;
        loadMrButton.BorderColor = colorDialog.Color;
        saveMrButton.BorderColor = colorDialog.Color;
        changeHoverCardColorMrButton.BorderColor = colorDialog.Color;
        changeBackgroundColorMrButton.BorderColor = colorDialog.Color;
    }

    private void ChangeColorPictureBox_Click(object sender, EventArgs e)
    {
        textColorDialog.ShowDialog();
        fileListBox.Invalidate();
        fileEditorRichTextBox.ForeColor = textColorDialog.Color;
    }

    private void PlayerListBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            int index = playerListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                playerListBox.SelectedIndex = index;
                playerContextMenu.Renderer = new ToolStripProfessionalRenderer(new DarkColorTable(colorDialog.Color));
                playerContextMenu.Show(playerListBox, e.Location);
            }
        }
    }

    private void MinimizePictureBox_Click(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Minimized;
    }

    private void ChangeFontMrButton_Click(object sender, EventArgs e)
    {
        fontDialog.ShowDialog();
        dashboardTabLabel.Font = fontDialog.Font;
        dashboardUnderTabPanel.Width = dashboardTabLabel.Width - 7;
        consoleTabLabel.Font = fontDialog.Font;
        consoleUnderTabPanel.Width = consoleTabLabel.Width - 7;
        fileManagerTabLabel.Font = fontDialog.Font;
        fileManagerUnderTabPanel.Width = fileManagerTabLabel.Width - 10;
        customizeTabLabel.Font = fontDialog.Font;
        customizeUnderTabPanel.Width = customizeTabLabel.Width - 7;
        topMostMrCheckBox.Font = fontDialog.Font;
        versionLabel.Font = fontDialog.Font;
        CPUUsageLabel.Font = fontDialog.Font;
        CPUUsagePercentageLabel.Font = fontDialog.Font;
        RAMUsageLabel.Font = fontDialog.Font;
        RAMUsagePercentageLabel.Font = fontDialog.Font;
        serverUptimeNameLabel.Font = fontDialog.Font;
        serverUptimeTimeLabel.Font = fontDialog.Font;
        serverStatusLabel.Font = fontDialog.Font;
        serverStatusLogLabel.Font = fontDialog.Font;
        playerListLabel.Font = fontDialog.Font;
        startMrButton.Font = fontDialog.Font;
        stopMrButton.Font = fontDialog.Font;
        restartMrButton.Font = fontDialog.Font;
        //statusLabel.Font = fontDialog.Font;
        //serverNameLabel.Font = fontDialog.Font;
        //dotJarLabel.Font = fontDialog.Font;
        //minRAMLabel.Font = fontDialog.Font;
        //minRAMMBLabel.Font = fontDialog.Font;
        //maxRAMLabel.Font = fontDialog.Font;
        //maxRAMMBLabel.Font = fontDialog.Font;
        //consoleRichTextBox.Font = fontDialog.Font;
        changeBorderColorLabel.Font = fontDialog.Font;
        changeFontLabel.Font = fontDialog.Font;
        changeFontMrButton.Font = fontDialog.Font;
        changeColorMrButton.Font = fontDialog.Font;
        saveMrButton.Font = fontDialog.Font;
        loadMrButton.Font = fontDialog.Font;
        changeAppsBackgroundColorLabel.Font = fontDialog.Font;
        changeAppsHoverCardSLabel.Font = fontDialog.Font;
        changeBackgroundColorMrButton.Font = fontDialog.Font;
        changeHoverCardColorMrButton.Font = fontDialog.Font;
    }

    private void SetFont()
    {
        dashboardTabLabel.Font = fontDialog.Font;
        dashboardUnderTabPanel.Width = dashboardTabLabel.Width - 7;
        consoleTabLabel.Font = fontDialog.Font;
        consoleUnderTabPanel.Width = consoleTabLabel.Width - 7;
        fileManagerTabLabel.Font = fontDialog.Font;
        fileManagerUnderTabPanel.Width = fileManagerTabLabel.Width - 10;
        customizeTabLabel.Font = fontDialog.Font;
        customizeUnderTabPanel.Width = customizeTabLabel.Width - 7;
        topMostMrCheckBox.Font = fontDialog.Font;
        versionLabel.Font = fontDialog.Font;
        CPUUsageLabel.Font = fontDialog.Font;
        CPUUsagePercentageLabel.Font = fontDialog.Font;
        RAMUsageLabel.Font = fontDialog.Font;
        RAMUsagePercentageLabel.Font = fontDialog.Font;
        serverUptimeNameLabel.Font = fontDialog.Font;
        serverUptimeTimeLabel.Font = fontDialog.Font;
        serverStatusLabel.Font = fontDialog.Font;
        serverStatusLogLabel.Font = fontDialog.Font;
        playerListLabel.Font = fontDialog.Font;
        startMrButton.Font = fontDialog.Font;
        stopMrButton.Font = fontDialog.Font;
        restartMrButton.Font = fontDialog.Font;
        //statusLabel.Font = fontDialog.Font;
        //serverNameLabel.Font = fontDialog.Font;
        //dotJarLabel.Font = fontDialog.Font;
        //minRAMLabel.Font = fontDialog.Font;
        //minRAMMBLabel.Font = fontDialog.Font;
        //maxRAMLabel.Font = fontDialog.Font;
        //maxRAMMBLabel.Font = fontDialog.Font;
        //consoleRichTextBox.Font = fontDialog.Font;
        changeBorderColorLabel.Font = fontDialog.Font;
        changeFontLabel.Font = fontDialog.Font;
        changeFontMrButton.Font = fontDialog.Font;
        changeColorMrButton.Font = fontDialog.Font;
        saveMrButton.Font = fontDialog.Font;
        loadMrButton.Font = fontDialog.Font;
    }

    private void ChangeBackgroundColorMrButton_Click(object sender, EventArgs e)
    {
        changeBackgroundColorDialog.ShowDialog();
        navigationBarMrPanel.BackColor = changeBackgroundColorDialog.Color;
        dashboardMrPanel.BackColor = changeBackgroundColorDialog.Color;

        topMostMrCheckBox.BackColor = changeBackgroundColorDialog.Color;
        consoleMrPanel.BackColor = changeBackgroundColorDialog.Color;
        startMrButton.BackColor = changeBackgroundColorDialog.Color;
        stopMrButton.BackColor = changeBackgroundColorDialog.Color;
        restartMrButton.BackColor = changeBackgroundColorDialog.Color;
        fileManagerMrPanel.BackColor = changeBackgroundColorDialog.Color;
        customizeMrPanel.BackColor = changeBackgroundColorDialog.Color;

        mainMrPanel.BackColor = changeBackgroundColorDialog.Color;
    }

    private void SetBackgroundColor()
    {
        navigationBarMrPanel.BackColor = changeBackgroundColorDialog.Color;
        dashboardMrPanel.BackColor = changeBackgroundColorDialog.Color;

        topMostMrCheckBox.BackColor = changeBackgroundColorDialog.Color;
        consoleMrPanel.BackColor = changeBackgroundColorDialog.Color;
        startMrButton.BackColor = changeBackgroundColorDialog.Color;
        stopMrButton.BackColor = changeBackgroundColorDialog.Color;
        restartMrButton.BackColor = changeBackgroundColorDialog.Color;
        fileManagerMrPanel.BackColor = changeBackgroundColorDialog.Color;
        customizeMrPanel.BackColor = changeBackgroundColorDialog.Color;

        mainMrPanel.BackColor = changeBackgroundColorDialog.Color;
    }

    private void ChangeHoverCardColorMrButton_Click(object sender, EventArgs e)
    {
        changeHoverCardColorDialog.ShowDialog();
        CPUUsageMrPanel.BackColor = changeHoverCardColorDialog.Color;
        memoryUsageMrPanel.BackColor = changeHoverCardColorDialog.Color;
        serverUpTimeMrPanel.BackColor = changeHoverCardColorDialog.Color;
        serverStatusMrPanel.BackColor = changeHoverCardColorDialog.Color;

        playerListBoxMrPanel.BackColor = changeHoverCardColorDialog.Color;
        playerListBox.BackColor = changeHoverCardColorDialog.Color;
        fileEditorMrPanel.BackColor = changeHoverCardColorDialog.Color;
        fileEditorRichTextBox.BackColor = changeHoverCardColorDialog.Color;
        fileListMrPanel.BackColor = changeHoverCardColorDialog.Color;
        fileListBox.BackColor = changeHoverCardColorDialog.Color;
    }

    private void SetHoverCardsColor()
    {
        CPUUsageMrPanel.BackColor = changeHoverCardColorDialog.Color;
        memoryUsageMrPanel.BackColor = changeHoverCardColorDialog.Color;
        serverUpTimeMrPanel.BackColor = changeHoverCardColorDialog.Color;
        serverStatusMrPanel.BackColor = changeHoverCardColorDialog.Color;

        playerListBoxMrPanel.BackColor = changeHoverCardColorDialog.Color;
        playerListBox.BackColor = changeHoverCardColorDialog.Color;
        fileEditorMrPanel.BackColor = changeHoverCardColorDialog.Color;
        fileEditorRichTextBox.BackColor = changeHoverCardColorDialog.Color;
        fileListMrPanel.BackColor = changeHoverCardColorDialog.Color;
        fileListBox.BackColor = changeHoverCardColorDialog.Color;
    }

    private const string filePath = "customize.mcsm";

    private void SaveMrButton_Click(object sender, EventArgs e)
    {
        string fontName = $"{fontDialog.Font.Name}";
        string fontStyle = $"{fontDialog.Font.Style}";
        string fontSize = $"{fontDialog.Font.Size}";
        string borderColor = colorDialog.Color.ToArgb().ToString();
        string backgroundColor = changeBackgroundColorDialog.Color.ToArgb().ToString();
        string hoverCardColor = changeHoverCardColorDialog.Color.ToArgb().ToString();

        if (string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(fontStyle) || string.IsNullOrEmpty(fontSize) || string.IsNullOrEmpty(borderColor) || string.IsNullOrEmpty(backgroundColor) || string.IsNullOrEmpty(hoverCardColor))
        {
            MessageBox.Show(text: $"Please Fill All The Required Stuff!", caption: "Error", buttons: MessageBoxButtons.OK, defaultButton: MessageBoxDefaultButton.Button1, icon: MessageBoxIcon.Error);
            return;
        }

        File.WriteAllLines(filePath, new[] { fontName, fontStyle, fontSize, borderColor, backgroundColor, hoverCardColor });
        MessageBox.Show(text: "Saved Successfully!", caption: "Success", buttons: MessageBoxButtons.OK, defaultButton: MessageBoxDefaultButton.Button1, icon: MessageBoxIcon.Information);
    }

    private void LoadMrButton_Click(object sender, EventArgs e)
    {
        LoadCustomized();
    }

    private void LoadCustomized()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            try
            {
                string fontName = lines[0]/*.Split(' ')[0]*/;
                string fontStyleString = lines[1];
                float fontSize = float.Parse(lines[2]);

                FontStyle fontStyle = FontStyle.Regular;
                if (fontStyleString.Equals("Bold", StringComparison.OrdinalIgnoreCase))
                    fontStyle = FontStyle.Bold;
                else if (fontStyleString.Equals("Italic", StringComparison.OrdinalIgnoreCase))
                    fontStyle = FontStyle.Italic;
                else if (fontStyleString.Equals("Underline", StringComparison.OrdinalIgnoreCase))
                    fontStyle = FontStyle.Underline;
                else if (fontStyleString.Equals("Strikeout", StringComparison.OrdinalIgnoreCase))
                    fontStyle = FontStyle.Strikeout;

                Font font = new Font(fontName, fontSize, fontStyle);
                fontDialog.Font = font;
                SetFont();

                int borderColorArgb = int.Parse(lines[3]);
                Color borderColor = Color.FromArgb(borderColorArgb);
                colorDialog.Color = borderColor;
                SetBorderColor();

                int backgroundColorArgb = int.Parse(lines[4]);
                Color backgroundColor = Color.FromArgb(backgroundColorArgb);
                changeBackgroundColorDialog.Color = backgroundColor;
                SetBackgroundColor();

                int hoverCardsColorArgb = int.Parse(lines[5]);
                Color hoverCardsColor = Color.FromArgb(hoverCardsColorArgb);
                changeHoverCardColorDialog.Color = hoverCardsColor;
                SetHoverCardsColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show(text: $"{filePath} Could Not Be Found!", caption: "Error", buttons: MessageBoxButtons.OK, defaultButton: MessageBoxDefaultButton.Button1, icon: MessageBoxIcon.Error);
        }
    }
}