namespace MinecraftServerManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMrPanel = new Aeat.MrPanel();
            consoleMrPanel = new Aeat.MrPanel();
            statusLabel = new Label();
            maxRAMMBLabel = new Label();
            minRAMMBLabel = new Label();
            dotJarLabel = new Label();
            maxRAMLabel = new Label();
            minRAMLabel = new Label();
            serverNameLabel = new Label();
            maxRAMTextBox = new TextBox();
            minRAMTextBox = new TextBox();
            sendPictureBox = new PictureBox();
            serverFileNameTextBox = new TextBox();
            sendCommandTextBox = new TextBox();
            stopMrButton = new Aeat.MrButton();
            restartMrButton = new Aeat.MrButton();
            startMrButton = new Aeat.MrButton();
            consoleRichTextBox = new RichTextBox();
            customizeMrPanel = new Aeat.MrPanel();
            loadMrButton = new Aeat.MrButton();
            saveMrButton = new Aeat.MrButton();
            changeFontLabel = new Label();
            changeColorLabel = new Label();
            changeFontMrButton = new Aeat.MrButton();
            changeColorMrButton = new Aeat.MrButton();
            fileManagerMrPanel = new Aeat.MrPanel();
            fileListMrPanel = new Aeat.MrPanel();
            changeColorPictureBox = new PictureBox();
            backPictureBox = new PictureBox();
            fileListBox = new ListBox();
            fileEditorMrPanel = new Aeat.MrPanel();
            savePictureBox = new PictureBox();
            clearPictureBox = new PictureBox();
            fileEditorRichTextBox = new RichTextBox();
            dashboardMrPanel = new Aeat.MrPanel();
            playerListLabel = new Label();
            playerListBoxMrPanel = new Aeat.MrPanel();
            playerListBox = new ListBox();
            serverUpTimeMrPanel = new Aeat.MrPanel();
            serverUptimeTimeLabel = new Label();
            serverUptimeNameLabel = new Label();
            serverUpTimeUnderMrPanel = new Aeat.MrPanel();
            memoryUsageMrPanel = new Aeat.MrPanel();
            RAMUsagePercentageLabel = new Label();
            memoryUsageUnderMrPanel = new Aeat.MrPanel();
            RAMUsageLabel = new Label();
            CPUUsageMrPanel = new Aeat.MrPanel();
            CPUUsagePercentageLabel = new Label();
            CPUUsageLabel = new Label();
            CPUUsageUnderMrPanel = new Aeat.MrPanel();
            serverStatusMrPanel = new Aeat.MrPanel();
            serverStatusLogLabel = new Label();
            serverStatusLabel = new Label();
            serverStatusUnderMrPanel = new Aeat.MrPanel();
            versionLabel = new Label();
            topMostMrCheckBox = new Aeat.MrCheckBox();
            navigationBarMrPanel = new Aeat.MrPanel();
            appNameLabel = new Label();
            consoleUnderTabPanel = new Panel();
            customizeUnderTabPanel = new Panel();
            fileManagerUnderTabPanel = new Panel();
            dashboardUnderTabPanel = new Panel();
            consoleTabLabel = new Label();
            customizeTabLabel = new Label();
            fileManagerTabLabel = new Label();
            dashboardTabLabel = new Label();
            minimizePictureBox = new PictureBox();
            closePictureBox = new PictureBox();
            mainMrPanel.SuspendLayout();
            consoleMrPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sendPictureBox).BeginInit();
            customizeMrPanel.SuspendLayout();
            fileManagerMrPanel.SuspendLayout();
            fileListMrPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)changeColorPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backPictureBox).BeginInit();
            fileEditorMrPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)savePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clearPictureBox).BeginInit();
            dashboardMrPanel.SuspendLayout();
            playerListBoxMrPanel.SuspendLayout();
            serverUpTimeMrPanel.SuspendLayout();
            memoryUsageMrPanel.SuspendLayout();
            CPUUsageMrPanel.SuspendLayout();
            serverStatusMrPanel.SuspendLayout();
            navigationBarMrPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).BeginInit();
            SuspendLayout();
            // 
            // mainMrPanel
            // 
            mainMrPanel.BackColor = Color.FromArgb(23, 23, 23);
            mainMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            mainMrPanel.BorderThickness = 2;
            mainMrPanel.Controls.Add(consoleMrPanel);
            mainMrPanel.Controls.Add(customizeMrPanel);
            mainMrPanel.Controls.Add(fileManagerMrPanel);
            mainMrPanel.Controls.Add(dashboardMrPanel);
            mainMrPanel.Controls.Add(versionLabel);
            mainMrPanel.Controls.Add(topMostMrCheckBox);
            mainMrPanel.Controls.Add(navigationBarMrPanel);
            mainMrPanel.CornerBorder = 20;
            mainMrPanel.Dock = DockStyle.Fill;
            mainMrPanel.Location = new Point(0, 0);
            mainMrPanel.Name = "mainMrPanel";
            mainMrPanel.Size = new Size(900, 580);
            mainMrPanel.TabIndex = 0;
            // 
            // consoleMrPanel
            // 
            consoleMrPanel.BackColor = Color.FromArgb(20, 20, 20);
            consoleMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            consoleMrPanel.BorderThickness = 2;
            consoleMrPanel.Controls.Add(statusLabel);
            consoleMrPanel.Controls.Add(maxRAMMBLabel);
            consoleMrPanel.Controls.Add(minRAMMBLabel);
            consoleMrPanel.Controls.Add(dotJarLabel);
            consoleMrPanel.Controls.Add(maxRAMLabel);
            consoleMrPanel.Controls.Add(minRAMLabel);
            consoleMrPanel.Controls.Add(serverNameLabel);
            consoleMrPanel.Controls.Add(maxRAMTextBox);
            consoleMrPanel.Controls.Add(minRAMTextBox);
            consoleMrPanel.Controls.Add(sendPictureBox);
            consoleMrPanel.Controls.Add(serverFileNameTextBox);
            consoleMrPanel.Controls.Add(sendCommandTextBox);
            consoleMrPanel.Controls.Add(stopMrButton);
            consoleMrPanel.Controls.Add(restartMrButton);
            consoleMrPanel.Controls.Add(startMrButton);
            consoleMrPanel.Controls.Add(consoleRichTextBox);
            consoleMrPanel.CornerBorder = 20;
            consoleMrPanel.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            consoleMrPanel.Location = new Point(12, 63);
            consoleMrPanel.Name = "consoleMrPanel";
            consoleMrPanel.Size = new Size(876, 475);
            consoleMrPanel.TabIndex = 6;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = Color.Red;
            statusLabel.Location = new Point(288, 410);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(67, 23);
            statusLabel.TabIndex = 6;
            statusLabel.Text = "OFFLINE";
            // 
            // maxRAMMBLabel
            // 
            maxRAMMBLabel.AutoSize = true;
            maxRAMMBLabel.ForeColor = Color.White;
            maxRAMMBLabel.Location = new Point(341, 441);
            maxRAMMBLabel.Name = "maxRAMMBLabel";
            maxRAMMBLabel.Size = new Size(32, 23);
            maxRAMMBLabel.TabIndex = 5;
            maxRAMMBLabel.Text = "MB";
            // 
            // minRAMMBLabel
            // 
            minRAMMBLabel.AutoSize = true;
            minRAMMBLabel.ForeColor = Color.White;
            minRAMMBLabel.Location = new Point(152, 441);
            minRAMMBLabel.Name = "minRAMMBLabel";
            minRAMMBLabel.Size = new Size(32, 23);
            minRAMMBLabel.TabIndex = 5;
            minRAMMBLabel.Text = "MB";
            // 
            // dotJarLabel
            // 
            dotJarLabel.AutoSize = true;
            dotJarLabel.ForeColor = Color.White;
            dotJarLabel.Location = new Point(237, 411);
            dotJarLabel.Name = "dotJarLabel";
            dotJarLabel.Size = new Size(32, 23);
            dotJarLabel.TabIndex = 5;
            dotJarLabel.Text = ".jar";
            // 
            // maxRAMLabel
            // 
            maxRAMLabel.AutoSize = true;
            maxRAMLabel.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            maxRAMLabel.ForeColor = Color.White;
            maxRAMLabel.Location = new Point(202, 440);
            maxRAMLabel.Name = "maxRAMLabel";
            maxRAMLabel.Size = new Size(77, 23);
            maxRAMLabel.TabIndex = 4;
            maxRAMLabel.Text = "Max RAM:";
            // 
            // minRAMLabel
            // 
            minRAMLabel.AutoSize = true;
            minRAMLabel.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            minRAMLabel.ForeColor = Color.White;
            minRAMLabel.Location = new Point(13, 440);
            minRAMLabel.Name = "minRAMLabel";
            minRAMLabel.Size = new Size(75, 23);
            minRAMLabel.TabIndex = 4;
            minRAMLabel.Text = "Min RAM:";
            // 
            // serverNameLabel
            // 
            serverNameLabel.AutoSize = true;
            serverNameLabel.BackColor = Color.Transparent;
            serverNameLabel.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverNameLabel.ForeColor = Color.White;
            serverNameLabel.Location = new Point(13, 410);
            serverNameLabel.Name = "serverNameLabel";
            serverNameLabel.Size = new Size(100, 23);
            serverNameLabel.TabIndex = 4;
            serverNameLabel.Text = "Server Name:";
            // 
            // maxRAMTextBox
            // 
            maxRAMTextBox.BackColor = Color.FromArgb(20, 20, 20);
            maxRAMTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maxRAMTextBox.ForeColor = Color.White;
            maxRAMTextBox.Location = new Point(283, 442);
            maxRAMTextBox.MaxLength = 6;
            maxRAMTextBox.Name = "maxRAMTextBox";
            maxRAMTextBox.Size = new Size(55, 23);
            maxRAMTextBox.TabIndex = 2;
            maxRAMTextBox.KeyPress += MinRAMAndmaxRAMTextBox_KeyPress;
            // 
            // minRAMTextBox
            // 
            minRAMTextBox.BackColor = Color.FromArgb(20, 20, 20);
            minRAMTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            minRAMTextBox.ForeColor = Color.White;
            minRAMTextBox.Location = new Point(94, 442);
            minRAMTextBox.MaxLength = 6;
            minRAMTextBox.Name = "minRAMTextBox";
            minRAMTextBox.Size = new Size(55, 23);
            minRAMTextBox.TabIndex = 2;
            minRAMTextBox.KeyPress += MinRAMAndmaxRAMTextBox_KeyPress;
            // 
            // sendPictureBox
            // 
            sendPictureBox.Image = Properties.Resources.paper_plane_30px;
            sendPictureBox.Location = new Point(842, 376);
            sendPictureBox.Name = "sendPictureBox";
            sendPictureBox.Size = new Size(24, 24);
            sendPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            sendPictureBox.TabIndex = 3;
            sendPictureBox.TabStop = false;
            sendPictureBox.Click += SendPictureBox_Click;
            // 
            // serverFileNameTextBox
            // 
            serverFileNameTextBox.BackColor = Color.FromArgb(20, 20, 20);
            serverFileNameTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            serverFileNameTextBox.ForeColor = Color.White;
            serverFileNameTextBox.Location = new Point(119, 412);
            serverFileNameTextBox.Name = "serverFileNameTextBox";
            serverFileNameTextBox.Size = new Size(116, 23);
            serverFileNameTextBox.TabIndex = 2;
            // 
            // sendCommandTextBox
            // 
            sendCommandTextBox.BackColor = Color.FromArgb(20, 20, 20);
            sendCommandTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sendCommandTextBox.ForeColor = Color.White;
            sendCommandTextBox.Location = new Point(13, 376);
            sendCommandTextBox.Name = "sendCommandTextBox";
            sendCommandTextBox.Size = new Size(823, 23);
            sendCommandTextBox.TabIndex = 2;
            sendCommandTextBox.KeyDown += SendCommandTextBox_KeyDown;
            // 
            // stopMrButton
            // 
            stopMrButton.BackColor = Color.FromArgb(20, 20, 20);
            stopMrButton.BackgroundColor = Color.FromArgb(20, 20, 20);
            stopMrButton.BorderColor = Color.FromArgb(5, 222, 5);
            stopMrButton.BorderThickness = 2;
            stopMrButton.ClickColor = Color.FromArgb(50, 50, 50);
            stopMrButton.CornerRadius = 20;
            stopMrButton.FlatAppearance.BorderSize = 0;
            stopMrButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            stopMrButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            stopMrButton.FlatStyle = FlatStyle.Flat;
            stopMrButton.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stopMrButton.ForeColor = Color.White;
            stopMrButton.Location = new Point(564, 410);
            stopMrButton.Name = "stopMrButton";
            stopMrButton.Size = new Size(148, 53);
            stopMrButton.TabIndex = 1;
            stopMrButton.Text = "Stop";
            stopMrButton.UseVisualStyleBackColor = false;
            stopMrButton.Click += StopMrButton_Click;
            // 
            // restartMrButton
            // 
            restartMrButton.BackColor = Color.FromArgb(20, 20, 20);
            restartMrButton.BackgroundColor = Color.FromArgb(20, 20, 20);
            restartMrButton.BorderColor = Color.FromArgb(5, 222, 5);
            restartMrButton.BorderThickness = 2;
            restartMrButton.ClickColor = Color.FromArgb(50, 50, 50);
            restartMrButton.CornerRadius = 20;
            restartMrButton.FlatAppearance.BorderSize = 0;
            restartMrButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            restartMrButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            restartMrButton.FlatStyle = FlatStyle.Flat;
            restartMrButton.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            restartMrButton.ForeColor = Color.White;
            restartMrButton.Location = new Point(410, 410);
            restartMrButton.Name = "restartMrButton";
            restartMrButton.Size = new Size(148, 53);
            restartMrButton.TabIndex = 1;
            restartMrButton.Text = "Restart";
            restartMrButton.UseVisualStyleBackColor = false;
            restartMrButton.Click += RestartMrButton_Click;
            // 
            // startMrButton
            // 
            startMrButton.BackColor = Color.FromArgb(20, 20, 20);
            startMrButton.BackgroundColor = Color.FromArgb(20, 20, 20);
            startMrButton.BorderColor = Color.FromArgb(5, 222, 5);
            startMrButton.BorderThickness = 2;
            startMrButton.ClickColor = Color.FromArgb(50, 50, 50);
            startMrButton.CornerRadius = 20;
            startMrButton.FlatAppearance.BorderSize = 0;
            startMrButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            startMrButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            startMrButton.FlatStyle = FlatStyle.Flat;
            startMrButton.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startMrButton.ForeColor = Color.White;
            startMrButton.Location = new Point(718, 410);
            startMrButton.Name = "startMrButton";
            startMrButton.Size = new Size(148, 53);
            startMrButton.TabIndex = 1;
            startMrButton.Text = "Start";
            startMrButton.UseVisualStyleBackColor = false;
            startMrButton.Click += StartMrButton_Click;
            // 
            // consoleRichTextBox
            // 
            consoleRichTextBox.BackColor = Color.FromArgb(20, 20, 20);
            consoleRichTextBox.ForeColor = Color.White;
            consoleRichTextBox.Location = new Point(13, 14);
            consoleRichTextBox.Name = "consoleRichTextBox";
            consoleRichTextBox.Size = new Size(853, 356);
            consoleRichTextBox.TabIndex = 0;
            consoleRichTextBox.Text = "";
            // 
            // customizeMrPanel
            // 
            customizeMrPanel.BackColor = Color.FromArgb(20, 20, 20);
            customizeMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            customizeMrPanel.BorderThickness = 2;
            customizeMrPanel.Controls.Add(loadMrButton);
            customizeMrPanel.Controls.Add(saveMrButton);
            customizeMrPanel.Controls.Add(changeFontLabel);
            customizeMrPanel.Controls.Add(changeColorLabel);
            customizeMrPanel.Controls.Add(changeFontMrButton);
            customizeMrPanel.Controls.Add(changeColorMrButton);
            customizeMrPanel.CornerBorder = 20;
            customizeMrPanel.Location = new Point(12, 63);
            customizeMrPanel.Name = "customizeMrPanel";
            customizeMrPanel.Size = new Size(876, 475);
            customizeMrPanel.TabIndex = 8;
            // 
            // loadMrButton
            // 
            loadMrButton.BackColor = Color.FromArgb(20, 20, 20);
            loadMrButton.BackgroundColor = Color.FromArgb(20, 20, 20);
            loadMrButton.BorderColor = Color.FromArgb(5, 222, 5);
            loadMrButton.BorderThickness = 2;
            loadMrButton.ClickColor = Color.FromArgb(50, 50, 50);
            loadMrButton.CornerRadius = 20;
            loadMrButton.FlatAppearance.BorderSize = 0;
            loadMrButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            loadMrButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            loadMrButton.FlatStyle = FlatStyle.Flat;
            loadMrButton.Font = new Font("Segoe Print", 12F, FontStyle.Bold);
            loadMrButton.ForeColor = Color.White;
            loadMrButton.Location = new Point(702, 410);
            loadMrButton.Name = "loadMrButton";
            loadMrButton.Size = new Size(75, 42);
            loadMrButton.TabIndex = 3;
            loadMrButton.Text = "Load";
            loadMrButton.UseVisualStyleBackColor = false;
            loadMrButton.Click += LoadMrButton_Click;
            // 
            // saveMrButton
            // 
            saveMrButton.BackColor = Color.FromArgb(20, 20, 20);
            saveMrButton.BackgroundColor = Color.FromArgb(20, 20, 20);
            saveMrButton.BorderColor = Color.FromArgb(5, 222, 5);
            saveMrButton.BorderThickness = 2;
            saveMrButton.ClickColor = Color.FromArgb(50, 50, 50);
            saveMrButton.CornerRadius = 20;
            saveMrButton.FlatAppearance.BorderSize = 0;
            saveMrButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            saveMrButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            saveMrButton.FlatStyle = FlatStyle.Flat;
            saveMrButton.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveMrButton.ForeColor = Color.White;
            saveMrButton.Location = new Point(783, 410);
            saveMrButton.Name = "saveMrButton";
            saveMrButton.Size = new Size(75, 42);
            saveMrButton.TabIndex = 3;
            saveMrButton.Text = "Save";
            saveMrButton.UseVisualStyleBackColor = false;
            saveMrButton.Click += SaveMrButton_Click;
            // 
            // changeFontLabel
            // 
            changeFontLabel.AutoSize = true;
            changeFontLabel.BackColor = Color.Transparent;
            changeFontLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeFontLabel.ForeColor = Color.White;
            changeFontLabel.Location = new Point(14, 71);
            changeFontLabel.Name = "changeFontLabel";
            changeFontLabel.Size = new Size(337, 28);
            changeFontLabel.TabIndex = 2;
            changeFontLabel.Text = "Change App's Font (Not Recommended):";
            // 
            // changeColorLabel
            // 
            changeColorLabel.AutoSize = true;
            changeColorLabel.BackColor = Color.Transparent;
            changeColorLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeColorLabel.ForeColor = Color.White;
            changeColorLabel.Location = new Point(13, 17);
            changeColorLabel.Name = "changeColorLabel";
            changeColorLabel.Size = new Size(172, 28);
            changeColorLabel.TabIndex = 2;
            changeColorLabel.Text = "Change App's Color:";
            // 
            // changeFontMrButton
            // 
            changeFontMrButton.BackColor = Color.FromArgb(20, 20, 20);
            changeFontMrButton.BackgroundColor = Color.FromArgb(20, 20, 20);
            changeFontMrButton.BorderColor = Color.FromArgb(5, 222, 5);
            changeFontMrButton.BorderThickness = 2;
            changeFontMrButton.ClickColor = Color.FromArgb(50, 50, 50);
            changeFontMrButton.CornerRadius = 20;
            changeFontMrButton.FlatAppearance.BorderSize = 0;
            changeFontMrButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            changeFontMrButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            changeFontMrButton.FlatStyle = FlatStyle.Flat;
            changeFontMrButton.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeFontMrButton.ForeColor = Color.White;
            changeFontMrButton.Location = new Point(729, 62);
            changeFontMrButton.Name = "changeFontMrButton";
            changeFontMrButton.Size = new Size(129, 46);
            changeFontMrButton.TabIndex = 1;
            changeFontMrButton.Text = "Change Font";
            changeFontMrButton.UseVisualStyleBackColor = false;
            changeFontMrButton.Click += ChangeFontMrButton_Click;
            // 
            // changeColorMrButton
            // 
            changeColorMrButton.BackColor = Color.FromArgb(20, 20, 20);
            changeColorMrButton.BackgroundColor = Color.FromArgb(20, 20, 20);
            changeColorMrButton.BorderColor = Color.FromArgb(5, 222, 5);
            changeColorMrButton.BorderThickness = 2;
            changeColorMrButton.ClickColor = Color.FromArgb(50, 50, 50);
            changeColorMrButton.CornerRadius = 20;
            changeColorMrButton.FlatAppearance.BorderSize = 0;
            changeColorMrButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            changeColorMrButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            changeColorMrButton.FlatStyle = FlatStyle.Flat;
            changeColorMrButton.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            changeColorMrButton.ForeColor = Color.White;
            changeColorMrButton.Location = new Point(729, 9);
            changeColorMrButton.Name = "changeColorMrButton";
            changeColorMrButton.Size = new Size(129, 46);
            changeColorMrButton.TabIndex = 0;
            changeColorMrButton.Text = "Change Color";
            changeColorMrButton.UseVisualStyleBackColor = false;
            changeColorMrButton.Click += ChangeColorMrButton_Click;
            // 
            // fileManagerMrPanel
            // 
            fileManagerMrPanel.BackColor = Color.FromArgb(20, 20, 20);
            fileManagerMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            fileManagerMrPanel.BorderThickness = 2;
            fileManagerMrPanel.Controls.Add(fileListMrPanel);
            fileManagerMrPanel.Controls.Add(fileEditorMrPanel);
            fileManagerMrPanel.CornerBorder = 20;
            fileManagerMrPanel.Location = new Point(12, 63);
            fileManagerMrPanel.Name = "fileManagerMrPanel";
            fileManagerMrPanel.Size = new Size(876, 475);
            fileManagerMrPanel.TabIndex = 7;
            // 
            // fileListMrPanel
            // 
            fileListMrPanel.BackColor = Color.FromArgb(20, 20, 20);
            fileListMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            fileListMrPanel.BorderThickness = 2;
            fileListMrPanel.Controls.Add(changeColorPictureBox);
            fileListMrPanel.Controls.Add(backPictureBox);
            fileListMrPanel.Controls.Add(fileListBox);
            fileListMrPanel.CornerBorder = 20;
            fileListMrPanel.Location = new Point(483, 11);
            fileListMrPanel.Name = "fileListMrPanel";
            fileListMrPanel.Size = new Size(383, 454);
            fileListMrPanel.TabIndex = 0;
            // 
            // changeColorPictureBox
            // 
            changeColorPictureBox.BackColor = Color.Transparent;
            changeColorPictureBox.Image = Properties.Resources.Paint_Palette_512px;
            changeColorPictureBox.Location = new Point(358, 424);
            changeColorPictureBox.Name = "changeColorPictureBox";
            changeColorPictureBox.Size = new Size(17, 17);
            changeColorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            changeColorPictureBox.TabIndex = 1;
            changeColorPictureBox.TabStop = false;
            changeColorPictureBox.Click += ChangeColorPictureBox_Click;
            // 
            // backPictureBox
            // 
            backPictureBox.BackColor = Color.Transparent;
            backPictureBox.Image = Properties.Resources.arrow_50px;
            backPictureBox.Location = new Point(357, 6);
            backPictureBox.Name = "backPictureBox";
            backPictureBox.Size = new Size(18, 20);
            backPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            backPictureBox.TabIndex = 1;
            backPictureBox.TabStop = false;
            backPictureBox.Click += BackButton_Click;
            // 
            // fileListBox
            // 
            fileListBox.BackColor = Color.FromArgb(20, 20, 20);
            fileListBox.BorderStyle = BorderStyle.None;
            fileListBox.DrawMode = DrawMode.OwnerDrawFixed;
            fileListBox.ForeColor = Color.White;
            fileListBox.FormattingEnabled = true;
            fileListBox.Location = new Point(9, 6);
            fileListBox.Name = "fileListBox";
            fileListBox.Size = new Size(366, 432);
            fileListBox.TabIndex = 0;
            fileListBox.DrawItem += FileListBox_DrawItem;
            fileListBox.MouseDoubleClick += FileListBox_MouseDoubleClick;
            fileListBox.MouseDown += FileListBox_MouseDown;
            // 
            // fileEditorMrPanel
            // 
            fileEditorMrPanel.BackColor = Color.FromArgb(20, 20, 20);
            fileEditorMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            fileEditorMrPanel.BorderThickness = 2;
            fileEditorMrPanel.Controls.Add(savePictureBox);
            fileEditorMrPanel.Controls.Add(clearPictureBox);
            fileEditorMrPanel.Controls.Add(fileEditorRichTextBox);
            fileEditorMrPanel.CornerBorder = 20;
            fileEditorMrPanel.Location = new Point(10, 11);
            fileEditorMrPanel.Name = "fileEditorMrPanel";
            fileEditorMrPanel.Size = new Size(464, 454);
            fileEditorMrPanel.TabIndex = 0;
            // 
            // savePictureBox
            // 
            savePictureBox.Image = Properties.Resources.save_30px;
            savePictureBox.Location = new Point(417, 430);
            savePictureBox.Name = "savePictureBox";
            savePictureBox.Size = new Size(16, 16);
            savePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            savePictureBox.TabIndex = 1;
            savePictureBox.TabStop = false;
            savePictureBox.Click += SaveFile_Click;
            // 
            // clearPictureBox
            // 
            clearPictureBox.Image = Properties.Resources.close_26px;
            clearPictureBox.Location = new Point(439, 430);
            clearPictureBox.Name = "clearPictureBox";
            clearPictureBox.Size = new Size(16, 16);
            clearPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            clearPictureBox.TabIndex = 1;
            clearPictureBox.TabStop = false;
            clearPictureBox.Click += ClearButton_Click;
            // 
            // fileEditorRichTextBox
            // 
            fileEditorRichTextBox.BackColor = Color.FromArgb(20, 20, 20);
            fileEditorRichTextBox.BorderStyle = BorderStyle.None;
            fileEditorRichTextBox.ForeColor = Color.White;
            fileEditorRichTextBox.Location = new Point(10, 7);
            fileEditorRichTextBox.Name = "fileEditorRichTextBox";
            fileEditorRichTextBox.Size = new Size(445, 441);
            fileEditorRichTextBox.TabIndex = 0;
            fileEditorRichTextBox.Text = "";
            // 
            // dashboardMrPanel
            // 
            dashboardMrPanel.BackColor = Color.FromArgb(20, 20, 20);
            dashboardMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            dashboardMrPanel.BorderThickness = 2;
            dashboardMrPanel.Controls.Add(playerListLabel);
            dashboardMrPanel.Controls.Add(playerListBoxMrPanel);
            dashboardMrPanel.Controls.Add(serverUpTimeMrPanel);
            dashboardMrPanel.Controls.Add(memoryUsageMrPanel);
            dashboardMrPanel.Controls.Add(CPUUsageMrPanel);
            dashboardMrPanel.Controls.Add(serverStatusMrPanel);
            dashboardMrPanel.CornerBorder = 20;
            dashboardMrPanel.Location = new Point(12, 63);
            dashboardMrPanel.Name = "dashboardMrPanel";
            dashboardMrPanel.Size = new Size(876, 475);
            dashboardMrPanel.TabIndex = 5;
            // 
            // playerListLabel
            // 
            playerListLabel.AutoSize = true;
            playerListLabel.Font = new Font("Segoe Print", 10.75F, FontStyle.Bold);
            playerListLabel.ForeColor = Color.White;
            playerListLabel.Location = new Point(13, 211);
            playerListLabel.Name = "playerListLabel";
            playerListLabel.Size = new Size(86, 26);
            playerListLabel.TabIndex = 6;
            playerListLabel.Text = "Playerlist:";
            // 
            // playerListBoxMrPanel
            // 
            playerListBoxMrPanel.BackColor = Color.FromArgb(20, 20, 20);
            playerListBoxMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            playerListBoxMrPanel.BorderThickness = 2;
            playerListBoxMrPanel.Controls.Add(playerListBox);
            playerListBoxMrPanel.CornerBorder = 20;
            playerListBoxMrPanel.Location = new Point(13, 240);
            playerListBoxMrPanel.Name = "playerListBoxMrPanel";
            playerListBoxMrPanel.Size = new Size(853, 223);
            playerListBoxMrPanel.TabIndex = 5;
            // 
            // playerListBox
            // 
            playerListBox.BackColor = Color.FromArgb(20, 20, 20);
            playerListBox.BorderStyle = BorderStyle.None;
            playerListBox.ForeColor = Color.White;
            playerListBox.FormattingEnabled = true;
            playerListBox.Location = new Point(12, 7);
            playerListBox.Name = "playerListBox";
            playerListBox.Size = new Size(830, 210);
            playerListBox.TabIndex = 0;
            playerListBox.MouseDown += PlayerListBox_MouseDown;
            // 
            // serverUpTimeMrPanel
            // 
            serverUpTimeMrPanel.BackColor = Color.FromArgb(37, 37, 37);
            serverUpTimeMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            serverUpTimeMrPanel.BorderThickness = 2;
            serverUpTimeMrPanel.Controls.Add(serverUptimeTimeLabel);
            serverUpTimeMrPanel.Controls.Add(serverUptimeNameLabel);
            serverUpTimeMrPanel.Controls.Add(serverUpTimeUnderMrPanel);
            serverUpTimeMrPanel.CornerBorder = 20;
            serverUpTimeMrPanel.Location = new Point(248, 14);
            serverUpTimeMrPanel.Name = "serverUpTimeMrPanel";
            serverUpTimeMrPanel.Size = new Size(151, 174);
            serverUpTimeMrPanel.TabIndex = 3;
            // 
            // serverUptimeTimeLabel
            // 
            serverUptimeTimeLabel.AutoSize = true;
            serverUptimeTimeLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverUptimeTimeLabel.ForeColor = Color.White;
            serverUptimeTimeLabel.Location = new Point(22, 56);
            serverUptimeTimeLabel.Name = "serverUptimeTimeLabel";
            serverUptimeTimeLabel.Size = new Size(24, 28);
            serverUptimeTimeLabel.TabIndex = 3;
            serverUptimeTimeLabel.Text = "0";
            // 
            // serverUptimeNameLabel
            // 
            serverUptimeNameLabel.AutoSize = true;
            serverUptimeNameLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverUptimeNameLabel.ForeColor = Color.White;
            serverUptimeNameLabel.Location = new Point(11, 27);
            serverUptimeNameLabel.Name = "serverUptimeNameLabel";
            serverUptimeNameLabel.Size = new Size(132, 28);
            serverUptimeNameLabel.TabIndex = 2;
            serverUptimeNameLabel.Text = "Server Uptime:";
            // 
            // serverUpTimeUnderMrPanel
            // 
            serverUpTimeUnderMrPanel.BackColor = Color.FromArgb(5, 222, 5);
            serverUpTimeUnderMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            serverUpTimeUnderMrPanel.BorderThickness = 2;
            serverUpTimeUnderMrPanel.CornerBorder = 20;
            serverUpTimeUnderMrPanel.ForeColor = Color.FromArgb(5, 222, 5);
            serverUpTimeUnderMrPanel.Location = new Point(3, 87);
            serverUpTimeUnderMrPanel.Name = "serverUpTimeUnderMrPanel";
            serverUpTimeUnderMrPanel.Size = new Size(145, 1);
            serverUpTimeUnderMrPanel.TabIndex = 1;
            // 
            // memoryUsageMrPanel
            // 
            memoryUsageMrPanel.BackColor = Color.FromArgb(37, 37, 37);
            memoryUsageMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            memoryUsageMrPanel.BorderThickness = 2;
            memoryUsageMrPanel.Controls.Add(RAMUsagePercentageLabel);
            memoryUsageMrPanel.Controls.Add(memoryUsageUnderMrPanel);
            memoryUsageMrPanel.Controls.Add(RAMUsageLabel);
            memoryUsageMrPanel.CornerBorder = 20;
            memoryUsageMrPanel.Location = new Point(477, 14);
            memoryUsageMrPanel.Name = "memoryUsageMrPanel";
            memoryUsageMrPanel.Size = new Size(151, 174);
            memoryUsageMrPanel.TabIndex = 2;
            // 
            // RAMUsagePercentageLabel
            // 
            RAMUsagePercentageLabel.AutoSize = true;
            RAMUsagePercentageLabel.BackColor = Color.Transparent;
            RAMUsagePercentageLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RAMUsagePercentageLabel.ForeColor = Color.White;
            RAMUsagePercentageLabel.Location = new Point(105, 56);
            RAMUsagePercentageLabel.Name = "RAMUsagePercentageLabel";
            RAMUsagePercentageLabel.Size = new Size(36, 28);
            RAMUsagePercentageLabel.TabIndex = 2;
            RAMUsagePercentageLabel.Text = "0%";
            // 
            // memoryUsageUnderMrPanel
            // 
            memoryUsageUnderMrPanel.BackColor = Color.FromArgb(5, 222, 5);
            memoryUsageUnderMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            memoryUsageUnderMrPanel.BorderThickness = 2;
            memoryUsageUnderMrPanel.CornerBorder = 20;
            memoryUsageUnderMrPanel.ForeColor = Color.FromArgb(5, 222, 5);
            memoryUsageUnderMrPanel.Location = new Point(3, 87);
            memoryUsageUnderMrPanel.Name = "memoryUsageUnderMrPanel";
            memoryUsageUnderMrPanel.Size = new Size(145, 1);
            memoryUsageUnderMrPanel.TabIndex = 1;
            // 
            // RAMUsageLabel
            // 
            RAMUsageLabel.AutoSize = true;
            RAMUsageLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RAMUsageLabel.ForeColor = Color.White;
            RAMUsageLabel.Location = new Point(3, 56);
            RAMUsageLabel.Name = "RAMUsageLabel";
            RAMUsageLabel.Size = new Size(107, 28);
            RAMUsageLabel.TabIndex = 1;
            RAMUsageLabel.Text = "RAM Usage:";
            // 
            // CPUUsageMrPanel
            // 
            CPUUsageMrPanel.BackColor = Color.FromArgb(37, 37, 37);
            CPUUsageMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            CPUUsageMrPanel.BorderThickness = 2;
            CPUUsageMrPanel.Controls.Add(CPUUsagePercentageLabel);
            CPUUsageMrPanel.Controls.Add(CPUUsageLabel);
            CPUUsageMrPanel.Controls.Add(CPUUsageUnderMrPanel);
            CPUUsageMrPanel.CornerBorder = 20;
            CPUUsageMrPanel.Location = new Point(715, 14);
            CPUUsageMrPanel.Name = "CPUUsageMrPanel";
            CPUUsageMrPanel.Size = new Size(151, 174);
            CPUUsageMrPanel.TabIndex = 1;
            // 
            // CPUUsagePercentageLabel
            // 
            CPUUsagePercentageLabel.AutoSize = true;
            CPUUsagePercentageLabel.BackColor = Color.Transparent;
            CPUUsagePercentageLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CPUUsagePercentageLabel.ForeColor = Color.White;
            CPUUsagePercentageLabel.Location = new Point(104, 56);
            CPUUsagePercentageLabel.Name = "CPUUsagePercentageLabel";
            CPUUsagePercentageLabel.Size = new Size(36, 28);
            CPUUsagePercentageLabel.TabIndex = 2;
            CPUUsagePercentageLabel.Text = "0%";
            // 
            // CPUUsageLabel
            // 
            CPUUsageLabel.AutoSize = true;
            CPUUsageLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CPUUsageLabel.ForeColor = Color.White;
            CPUUsageLabel.Location = new Point(3, 56);
            CPUUsageLabel.Name = "CPUUsageLabel";
            CPUUsageLabel.Size = new Size(102, 28);
            CPUUsageLabel.TabIndex = 1;
            CPUUsageLabel.Text = "CPU Usage:";
            // 
            // CPUUsageUnderMrPanel
            // 
            CPUUsageUnderMrPanel.BackColor = Color.FromArgb(5, 222, 5);
            CPUUsageUnderMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            CPUUsageUnderMrPanel.BorderThickness = 2;
            CPUUsageUnderMrPanel.CornerBorder = 20;
            CPUUsageUnderMrPanel.ForeColor = Color.FromArgb(5, 222, 5);
            CPUUsageUnderMrPanel.Location = new Point(3, 87);
            CPUUsageUnderMrPanel.Name = "CPUUsageUnderMrPanel";
            CPUUsageUnderMrPanel.Size = new Size(145, 1);
            CPUUsageUnderMrPanel.TabIndex = 0;
            // 
            // serverStatusMrPanel
            // 
            serverStatusMrPanel.BackColor = Color.FromArgb(37, 37, 37);
            serverStatusMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            serverStatusMrPanel.BorderThickness = 2;
            serverStatusMrPanel.Controls.Add(serverStatusLogLabel);
            serverStatusMrPanel.Controls.Add(serverStatusLabel);
            serverStatusMrPanel.Controls.Add(serverStatusUnderMrPanel);
            serverStatusMrPanel.CornerBorder = 20;
            serverStatusMrPanel.Location = new Point(10, 14);
            serverStatusMrPanel.Name = "serverStatusMrPanel";
            serverStatusMrPanel.Size = new Size(151, 174);
            serverStatusMrPanel.TabIndex = 4;
            // 
            // serverStatusLogLabel
            // 
            serverStatusLogLabel.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverStatusLogLabel.ForeColor = Color.Red;
            serverStatusLogLabel.Location = new Point(15, 100);
            serverStatusLogLabel.Name = "serverStatusLogLabel";
            serverStatusLogLabel.Size = new Size(124, 64);
            serverStatusLogLabel.TabIndex = 3;
            serverStatusLogLabel.Text = "Server Offline";
            serverStatusLogLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // serverStatusLabel
            // 
            serverStatusLabel.AutoSize = true;
            serverStatusLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverStatusLabel.ForeColor = Color.White;
            serverStatusLabel.Location = new Point(15, 27);
            serverStatusLabel.Name = "serverStatusLabel";
            serverStatusLabel.Size = new Size(124, 28);
            serverStatusLabel.TabIndex = 2;
            serverStatusLabel.Text = "Server Status:";
            // 
            // serverStatusUnderMrPanel
            // 
            serverStatusUnderMrPanel.BackColor = Color.FromArgb(5, 222, 5);
            serverStatusUnderMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            serverStatusUnderMrPanel.BorderThickness = 2;
            serverStatusUnderMrPanel.CornerBorder = 20;
            serverStatusUnderMrPanel.ForeColor = Color.FromArgb(5, 222, 5);
            serverStatusUnderMrPanel.Location = new Point(3, 87);
            serverStatusUnderMrPanel.Name = "serverStatusUnderMrPanel";
            serverStatusUnderMrPanel.Size = new Size(145, 1);
            serverStatusUnderMrPanel.TabIndex = 1;
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            versionLabel.ForeColor = Color.White;
            versionLabel.Location = new Point(832, 545);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(56, 28);
            versionLabel.TabIndex = 9;
            versionLabel.Text = "2.0.8";
            // 
            // topMostMrCheckBox
            // 
            topMostMrCheckBox.Appearance = Appearance.Button;
            topMostMrCheckBox.BackColor = Color.Transparent;
            topMostMrCheckBox.BackgroundColor = Color.FromArgb(20, 20, 20);
            topMostMrCheckBox.BorderColor = Color.FromArgb(5, 222, 5);
            topMostMrCheckBox.BorderThickness = 2;
            topMostMrCheckBox.CheckColor = Color.FromArgb(5, 222, 5);
            topMostMrCheckBox.CornerRadius = 10;
            topMostMrCheckBox.FlatStyle = FlatStyle.Flat;
            topMostMrCheckBox.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topMostMrCheckBox.ForeColor = Color.White;
            topMostMrCheckBox.Location = new Point(12, 544);
            topMostMrCheckBox.MinimumSize = new Size(8, 8);
            topMostMrCheckBox.Name = "topMostMrCheckBox";
            topMostMrCheckBox.Size = new Size(180, 30);
            topMostMrCheckBox.TabIndex = 1;
            topMostMrCheckBox.Text = "Always On Top";
            topMostMrCheckBox.UseVisualStyleBackColor = false;
            topMostMrCheckBox.CheckedChanged += TopMostMrCheckBox_CheckedChanged;
            // 
            // navigationBarMrPanel
            // 
            navigationBarMrPanel.BackColor = Color.FromArgb(17, 17, 17);
            navigationBarMrPanel.BorderColor = Color.FromArgb(5, 222, 5);
            navigationBarMrPanel.BorderThickness = 2;
            navigationBarMrPanel.Controls.Add(appNameLabel);
            navigationBarMrPanel.Controls.Add(consoleUnderTabPanel);
            navigationBarMrPanel.Controls.Add(customizeUnderTabPanel);
            navigationBarMrPanel.Controls.Add(fileManagerUnderTabPanel);
            navigationBarMrPanel.Controls.Add(dashboardUnderTabPanel);
            navigationBarMrPanel.Controls.Add(consoleTabLabel);
            navigationBarMrPanel.Controls.Add(customizeTabLabel);
            navigationBarMrPanel.Controls.Add(fileManagerTabLabel);
            navigationBarMrPanel.Controls.Add(dashboardTabLabel);
            navigationBarMrPanel.Controls.Add(minimizePictureBox);
            navigationBarMrPanel.Controls.Add(closePictureBox);
            navigationBarMrPanel.CornerBorder = 20;
            navigationBarMrPanel.Location = new Point(12, 12);
            navigationBarMrPanel.Name = "navigationBarMrPanel";
            navigationBarMrPanel.Size = new Size(876, 45);
            navigationBarMrPanel.TabIndex = 0;
            navigationBarMrPanel.MouseDown += NavigationBarMrPanel_MouseDown;
            navigationBarMrPanel.MouseMove += NavigationBarMrPanel_MouseMove;
            // 
            // appNameLabel
            // 
            appNameLabel.AutoSize = true;
            appNameLabel.Font = new Font("Segoe Script", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appNameLabel.ForeColor = Color.White;
            appNameLabel.Location = new Point(13, 9);
            appNameLabel.Name = "appNameLabel";
            appNameLabel.Size = new Size(167, 27);
            appNameLabel.TabIndex = 3;
            appNameLabel.Text = "MCServerManager";
            // 
            // consoleUnderTabPanel
            // 
            consoleUnderTabPanel.Location = new Point(604, 36);
            consoleUnderTabPanel.Name = "consoleUnderTabPanel";
            consoleUnderTabPanel.Size = new Size(69, 2);
            consoleUnderTabPanel.TabIndex = 2;
            // 
            // customizeUnderTabPanel
            // 
            customizeUnderTabPanel.Location = new Point(389, 36);
            customizeUnderTabPanel.Name = "customizeUnderTabPanel";
            customizeUnderTabPanel.Size = new Size(85, 2);
            customizeUnderTabPanel.TabIndex = 2;
            // 
            // fileManagerUnderTabPanel
            // 
            fileManagerUnderTabPanel.Location = new Point(486, 36);
            fileManagerUnderTabPanel.Name = "fileManagerUnderTabPanel";
            fileManagerUnderTabPanel.Size = new Size(104, 2);
            fileManagerUnderTabPanel.TabIndex = 2;
            // 
            // dashboardUnderTabPanel
            // 
            dashboardUnderTabPanel.Location = new Point(687, 36);
            dashboardUnderTabPanel.Name = "dashboardUnderTabPanel";
            dashboardUnderTabPanel.Size = new Size(90, 2);
            dashboardUnderTabPanel.TabIndex = 2;
            // 
            // consoleTabLabel
            // 
            consoleTabLabel.AutoSize = true;
            consoleTabLabel.BackColor = Color.Transparent;
            consoleTabLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            consoleTabLabel.ForeColor = Color.White;
            consoleTabLabel.Location = new Point(601, 8);
            consoleTabLabel.Name = "consoleTabLabel";
            consoleTabLabel.Size = new Size(72, 28);
            consoleTabLabel.TabIndex = 1;
            consoleTabLabel.Text = "Console";
            consoleTabLabel.Click += ConsoleTabLabel_Click;
            // 
            // customizeTabLabel
            // 
            customizeTabLabel.AutoSize = true;
            customizeTabLabel.BackColor = Color.Transparent;
            customizeTabLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customizeTabLabel.ForeColor = Color.White;
            customizeTabLabel.Location = new Point(385, 8);
            customizeTabLabel.Name = "customizeTabLabel";
            customizeTabLabel.Size = new Size(93, 28);
            customizeTabLabel.TabIndex = 1;
            customizeTabLabel.Text = "Customize";
            customizeTabLabel.Click += CustomizeTabLabel_Click;
            // 
            // fileManagerTabLabel
            // 
            fileManagerTabLabel.AutoSize = true;
            fileManagerTabLabel.BackColor = Color.Transparent;
            fileManagerTabLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fileManagerTabLabel.ForeColor = Color.White;
            fileManagerTabLabel.Location = new Point(481, 8);
            fileManagerTabLabel.Name = "fileManagerTabLabel";
            fileManagerTabLabel.Size = new Size(114, 28);
            fileManagerTabLabel.TabIndex = 1;
            fileManagerTabLabel.Text = "File Manager";
            fileManagerTabLabel.Click += FileManagerTabLabel_Click;
            // 
            // dashboardTabLabel
            // 
            dashboardTabLabel.AutoSize = true;
            dashboardTabLabel.BackColor = Color.Transparent;
            dashboardTabLabel.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardTabLabel.ForeColor = Color.White;
            dashboardTabLabel.Location = new Point(683, 8);
            dashboardTabLabel.Name = "dashboardTabLabel";
            dashboardTabLabel.Size = new Size(97, 28);
            dashboardTabLabel.TabIndex = 1;
            dashboardTabLabel.Text = "Dashboard";
            dashboardTabLabel.Click += DashboardTabLabel_Click;
            // 
            // minimizePictureBox
            // 
            minimizePictureBox.Image = Properties.Resources.close_window_2ww6px;
            minimizePictureBox.Location = new Point(786, 7);
            minimizePictureBox.Name = "minimizePictureBox";
            minimizePictureBox.Size = new Size(32, 32);
            minimizePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            minimizePictureBox.TabIndex = 0;
            minimizePictureBox.TabStop = false;
            minimizePictureBox.Click += MinimizePictureBox_Click;
            // 
            // closePictureBox
            // 
            closePictureBox.Image = Properties.Resources.close_window_26px;
            closePictureBox.Location = new Point(824, 7);
            closePictureBox.Name = "closePictureBox";
            closePictureBox.Size = new Size(32, 32);
            closePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            closePictureBox.TabIndex = 0;
            closePictureBox.TabStop = false;
            closePictureBox.Click += ClosePictureBox_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 204, 245);
            ClientSize = new Size(900, 580);
            ControlBox = false;
            Controls.Add(mainMrPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minecraft Server Manager";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            mainMrPanel.ResumeLayout(false);
            mainMrPanel.PerformLayout();
            consoleMrPanel.ResumeLayout(false);
            consoleMrPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sendPictureBox).EndInit();
            customizeMrPanel.ResumeLayout(false);
            customizeMrPanel.PerformLayout();
            fileManagerMrPanel.ResumeLayout(false);
            fileListMrPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)changeColorPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)backPictureBox).EndInit();
            fileEditorMrPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)savePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)clearPictureBox).EndInit();
            dashboardMrPanel.ResumeLayout(false);
            dashboardMrPanel.PerformLayout();
            playerListBoxMrPanel.ResumeLayout(false);
            serverUpTimeMrPanel.ResumeLayout(false);
            serverUpTimeMrPanel.PerformLayout();
            memoryUsageMrPanel.ResumeLayout(false);
            memoryUsageMrPanel.PerformLayout();
            CPUUsageMrPanel.ResumeLayout(false);
            CPUUsageMrPanel.PerformLayout();
            serverStatusMrPanel.ResumeLayout(false);
            serverStatusMrPanel.PerformLayout();
            navigationBarMrPanel.ResumeLayout(false);
            navigationBarMrPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)minimizePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)closePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Aeat.MrPanel mainMrPanel;
        private Aeat.MrPanel navigationBarMrPanel;
        private Aeat.MrPanel CPUUsageMrPanel;
        private Aeat.MrPanel serverStatusMrPanel;
        private Aeat.MrPanel serverUpTimeMrPanel;
        private Aeat.MrPanel memoryUsageMrPanel;
        private PictureBox closePictureBox;
        private Aeat.MrPanel CPUUsageUnderMrPanel;
        private Aeat.MrPanel memoryUsageUnderMrPanel;
        private Aeat.MrPanel serverUpTimeUnderMrPanel;
        private Aeat.MrPanel serverStatusUnderMrPanel;
        private Label CPUUsagePercentageLabel;
        private Label CPUUsageLabel;
        private Label RAMUsagePercentageLabel;
        private Label RAMUsageLabel;
        private Label serverUptimeNameLabel;
        private Label serverUptimeTimeLabel;
        private Label serverStatusLabel;
        private Label serverStatusLogLabel;
        private Aeat.MrPanel dashboardMrPanel;
        private Panel dashboardUnderTabPanel;
        private Label dashboardTabLabel;
        private Aeat.MrPanel playerListBoxMrPanel;
        private ListBox playerListBox;
        private Label playerListLabel;
        private Panel consoleUnderTabPanel;
        private Label consoleTabLabel;
        private Aeat.MrPanel consoleMrPanel;
        private RichTextBox consoleRichTextBox;
        private Aeat.MrButton startMrButton;
        private Aeat.MrButton stopMrButton;
        private Aeat.MrButton restartMrButton;
        private Label serverNameLabel;
        private PictureBox sendPictureBox;
        private Label dotJarLabel;
        private TextBox serverFileNameTextBox;
        private TextBox sendCommandTextBox;
        private Label minRAMMBLabel;
        private Label minRAMLabel;
        private TextBox minRAMTextBox;
        private Label maxRAMMBLabel;
        private Label maxRAMLabel;
        private TextBox maxRAMTextBox;
        private Label statusLabel;
        private Panel fileManagerUnderTabPanel;
        private Label fileManagerTabLabel;
        private Aeat.MrPanel fileManagerMrPanel;
        private Aeat.MrPanel fileEditorMrPanel;
        private Aeat.MrPanel fileListMrPanel;
        private ListBox fileListBox;
        private RichTextBox fileEditorRichTextBox;
        private PictureBox backPictureBox;
        private PictureBox clearPictureBox;
        private PictureBox savePictureBox;
        private Panel customizeUnderTabPanel;
        private Label customizeTabLabel;
        private Aeat.MrPanel customizeMrPanel;
        private Aeat.MrButton changeColorMrButton;
        private PictureBox changeColorPictureBox;
        private Aeat.MrCheckBox topMostMrCheckBox;
        private Label appNameLabel;
        private Label versionLabel;
        private PictureBox minimizePictureBox;
        private Aeat.MrButton changeFontMrButton;
        private Label changeColorLabel;
        private Label changeFontLabel;
        private Aeat.MrButton saveMrButton;
        private Aeat.MrButton loadMrButton;
    }
}
