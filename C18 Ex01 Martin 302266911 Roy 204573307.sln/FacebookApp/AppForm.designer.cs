namespace FacebookApp
{
    internal partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.postStatusLabel = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.buttonSetStatus = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonFetchInfo = new System.Windows.Forms.Button();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBoxFriends = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCheckYear = new System.Windows.Forms.Button();
            this.comboBoxCommonLanguage = new System.Windows.Forms.ComboBox();
            this.radioButtonSameMonth = new System.Windows.Forms.RadioButton();
            this.numericUpDownYearsRange = new System.Windows.Forms.NumericUpDown();
            this.radioButtonYears = new System.Windows.Forms.RadioButton();
            this.radioButtonLanguage = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.listBoxFilteredFriends = new System.Windows.Forms.ListBox();
            this.labelCommonEvents = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBoxCityFriend = new System.Windows.Forms.PictureBox();
            this.linkCityWikipedia = new System.Windows.Forms.LinkLabel();
            this.labelCityWikipedia = new System.Windows.Forms.Label();
            this.listBoxCityWeather = new System.Windows.Forms.ListBox();
            this.labelCityInfo = new System.Windows.Forms.Label();
            this.labelFriendsFromSelectedCity = new System.Windows.Forms.Label();
            this.listBoxFriendsFromSelectedCity = new System.Windows.Forms.ListBox();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.cityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriends)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearsRange)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCityFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::FacebookApp.Resource.EmptyPicture;
            this.pictureBoxProfile.Location = new System.Drawing.Point(235, 65);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 41;
            this.pictureBoxProfile.TabStop = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.White;
            this.buttonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Location = new System.Drawing.Point(235, 221);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(150, 24);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // postStatusLabel
            // 
            this.postStatusLabel.AutoSize = true;
            this.postStatusLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postStatusLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.postStatusLabel.Location = new System.Drawing.Point(6, 297);
            this.postStatusLabel.Name = "postStatusLabel";
            this.postStatusLabel.Size = new System.Drawing.Size(73, 14);
            this.postStatusLabel.TabIndex = 44;
            this.postStatusLabel.Text = "Post Status:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.Location = new System.Drawing.Point(82, 291);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(489, 26);
            this.textBoxStatus.TabIndex = 45;
            // 
            // buttonSetStatus
            // 
            this.buttonSetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetStatus.BackColor = System.Drawing.Color.White;
            this.buttonSetStatus.Enabled = false;
            this.buttonSetStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonSetStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetStatus.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetStatus.Location = new System.Drawing.Point(577, 290);
            this.buttonSetStatus.Name = "buttonSetStatus";
            this.buttonSetStatus.Size = new System.Drawing.Size(56, 27);
            this.buttonSetStatus.TabIndex = 46;
            this.buttonSetStatus.Text = "Post";
            this.buttonSetStatus.UseVisualStyleBackColor = false;
            this.buttonSetStatus.Click += new System.EventHandler(this.buttonSetStatus_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 374);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage1.Controls.Add(this.buttonFetchInfo);
            this.tabPage1.Controls.Add(this.userNameLabel);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Controls.Add(this.buttonSetStatus);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxStatus);
            this.tabPage1.Controls.Add(this.postStatusLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 348);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Main";
            // 
            // buttonFetchInfo
            // 
            this.buttonFetchInfo.BackColor = System.Drawing.Color.White;
            this.buttonFetchInfo.Enabled = false;
            this.buttonFetchInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonFetchInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFetchInfo.Location = new System.Drawing.Point(266, 251);
            this.buttonFetchInfo.Name = "buttonFetchInfo";
            this.buttonFetchInfo.Size = new System.Drawing.Size(90, 23);
            this.buttonFetchInfo.TabIndex = 49;
            this.buttonFetchInfo.Text = "Fetch Info";
            this.buttonFetchInfo.UseVisualStyleBackColor = false;
            this.buttonFetchInfo.Visible = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userNameLabel.Location = new System.Drawing.Point(208, 26);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(0, 25);
            this.userNameLabel.TabIndex = 48;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.White;
            this.buttonLogout.Enabled = false;
            this.buttonLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(235, 221);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(150, 24);
            this.buttonLogout.TabIndex = 47;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage2.Controls.Add(this.pictureBoxFriends);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.listBoxFilteredFriends);
            this.tabPage2.Controls.Add(this.labelCommonEvents);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 348);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Friends Filter";
            // 
            // pictureBoxFriends
            // 
            this.pictureBoxFriends.Image = global::FacebookApp.Resource.EmptyPicture;
            this.pictureBoxFriends.Location = new System.Drawing.Point(499, 118);
            this.pictureBoxFriends.Name = "pictureBoxFriends";
            this.pictureBoxFriends.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxFriends.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFriends.TabIndex = 8;
            this.pictureBoxFriends.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCheckYear);
            this.groupBox1.Controls.Add(this.comboBoxCommonLanguage);
            this.groupBox1.Controls.Add(this.radioButtonSameMonth);
            this.groupBox1.Controls.Add(this.numericUpDownYearsRange);
            this.groupBox1.Controls.Add(this.radioButtonYears);
            this.groupBox1.Controls.Add(this.radioButtonLanguage);
            this.groupBox1.Controls.Add(this.radioButtonFemale);
            this.groupBox1.Controls.Add(this.radioButtonMale);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 231);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose a friends filter:";
            // 
            // buttonCheckYear
            // 
            this.buttonCheckYear.BackColor = System.Drawing.Color.White;
            this.buttonCheckYear.Enabled = false;
            this.buttonCheckYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckYear.Font = new System.Drawing.Font("Arial", 8.259F);
            this.buttonCheckYear.ForeColor = System.Drawing.Color.Black;
            this.buttonCheckYear.Location = new System.Drawing.Point(126, 105);
            this.buttonCheckYear.Name = "buttonCheckYear";
            this.buttonCheckYear.Size = new System.Drawing.Size(53, 25);
            this.buttonCheckYear.TabIndex = 11;
            this.buttonCheckYear.Text = "Check";
            this.buttonCheckYear.UseVisualStyleBackColor = false;
            this.buttonCheckYear.Click += new System.EventHandler(this.buttonCheckYear_Click);
            // 
            // comboBoxCommonLanguage
            // 
            this.comboBoxCommonLanguage.Enabled = false;
            this.comboBoxCommonLanguage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCommonLanguage.FormattingEnabled = true;
            this.comboBoxCommonLanguage.Location = new System.Drawing.Point(56, 185);
            this.comboBoxCommonLanguage.Name = "comboBoxCommonLanguage";
            this.comboBoxCommonLanguage.Size = new System.Drawing.Size(160, 23);
            this.comboBoxCommonLanguage.TabIndex = 10;
            this.comboBoxCommonLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxCommonLanguage_SelectedIndexChanged);
            // 
            // radioButtonSameMonth
            // 
            this.radioButtonSameMonth.AutoSize = true;
            this.radioButtonSameMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSameMonth.Location = new System.Drawing.Point(13, 131);
            this.radioButtonSameMonth.Name = "radioButtonSameMonth";
            this.radioButtonSameMonth.Size = new System.Drawing.Size(141, 21);
            this.radioButtonSameMonth.TabIndex = 9;
            this.radioButtonSameMonth.TabStop = true;
            this.radioButtonSameMonth.Text = "Born same month ";
            this.radioButtonSameMonth.UseVisualStyleBackColor = true;
            this.radioButtonSameMonth.CheckedChanged += new System.EventHandler(this.radioButtonSameMonth_CheckedChanged);
            // 
            // numericUpDownYearsRange
            // 
            this.numericUpDownYearsRange.Enabled = false;
            this.numericUpDownYearsRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownYearsRange.Location = new System.Drawing.Point(56, 106);
            this.numericUpDownYearsRange.Name = "numericUpDownYearsRange";
            this.numericUpDownYearsRange.Size = new System.Drawing.Size(64, 21);
            this.numericUpDownYearsRange.TabIndex = 8;
            // 
            // radioButtonYears
            // 
            this.radioButtonYears.AutoSize = true;
            this.radioButtonYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonYears.Location = new System.Drawing.Point(13, 79);
            this.radioButtonYears.Name = "radioButtonYears";
            this.radioButtonYears.Size = new System.Drawing.Size(203, 21);
            this.radioButtonYears.TabIndex = 3;
            this.radioButtonYears.TabStop = true;
            this.radioButtonYears.Text = "Born Within X Years Range:";
            this.radioButtonYears.UseVisualStyleBackColor = true;
            this.radioButtonYears.CheckedChanged += new System.EventHandler(this.radioButtonYears_CheckedChanged);
            // 
            // radioButtonLanguage
            // 
            this.radioButtonLanguage.AutoSize = true;
            this.radioButtonLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLanguage.Location = new System.Drawing.Point(13, 158);
            this.radioButtonLanguage.Name = "radioButtonLanguage";
            this.radioButtonLanguage.Size = new System.Drawing.Size(216, 21);
            this.radioButtonLanguage.TabIndex = 2;
            this.radioButtonLanguage.TabStop = true;
            this.radioButtonLanguage.Text = "Speaking Common Language:";
            this.radioButtonLanguage.UseVisualStyleBackColor = true;
            this.radioButtonLanguage.CheckedChanged += new System.EventHandler(this.radioButtonLanguage_CheckedChanged);
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFemale.Location = new System.Drawing.Point(13, 51);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(123, 21);
            this.radioButtonFemale.TabIndex = 1;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female Friends";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            this.radioButtonFemale.CheckedChanged += new System.EventHandler(this.radioButtonFemale_CheckedChanged);
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMale.Location = new System.Drawing.Point(13, 26);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(107, 21);
            this.radioButtonMale.TabIndex = 0;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male Friends";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            this.radioButtonMale.CheckedChanged += new System.EventHandler(this.radioButtonMale_CheckedChanged);
            // 
            // listBoxFilteredFriends
            // 
            this.listBoxFilteredFriends.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxFilteredFriends.Enabled = false;
            this.listBoxFilteredFriends.FormattingEnabled = true;
            this.listBoxFilteredFriends.HorizontalExtent = 15;
            this.listBoxFilteredFriends.HorizontalScrollbar = true;
            this.listBoxFilteredFriends.Location = new System.Drawing.Point(246, 50);
            this.listBoxFilteredFriends.Name = "listBoxFilteredFriends";
            this.listBoxFilteredFriends.Size = new System.Drawing.Size(234, 264);
            this.listBoxFilteredFriends.TabIndex = 6;
            this.listBoxFilteredFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFilteredFriends_SelectedIndexChanged);
            // 
            // labelCommonEvents
            // 
            this.labelCommonEvents.AutoSize = true;
            this.labelCommonEvents.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommonEvents.ForeColor = System.Drawing.Color.White;
            this.labelCommonEvents.Location = new System.Drawing.Point(306, 26);
            this.labelCommonEvents.Name = "labelCommonEvents";
            this.labelCommonEvents.Size = new System.Drawing.Size(107, 21);
            this.labelCommonEvents.TabIndex = 4;
            this.labelCommonEvents.Text = "Friends list";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage3.Controls.Add(this.pictureBoxCityFriend);
            this.tabPage3.Controls.Add(this.linkCityWikipedia);
            this.tabPage3.Controls.Add(this.labelCityWikipedia);
            this.tabPage3.Controls.Add(this.listBoxCityWeather);
            this.tabPage3.Controls.Add(this.labelCityInfo);
            this.tabPage3.Controls.Add(this.labelFriendsFromSelectedCity);
            this.tabPage3.Controls.Add(this.listBoxFriendsFromSelectedCity);
            this.tabPage3.Controls.Add(this.comboBoxCity);
            this.tabPage3.Controls.Add(this.cityLabel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 348);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "City Advisor";
            // 
            // pictureBoxCityFriend
            // 
            this.pictureBoxCityFriend.Image = global::FacebookApp.Resource.EmptyPicture;
            this.pictureBoxCityFriend.Location = new System.Drawing.Point(13, 79);
            this.pictureBoxCityFriend.Name = "pictureBoxCityFriend";
            this.pictureBoxCityFriend.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxCityFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCityFriend.TabIndex = 13;
            this.pictureBoxCityFriend.TabStop = false;
            // 
            // linkCityWikipedia
            // 
            this.linkCityWikipedia.AutoSize = true;
            this.linkCityWikipedia.Enabled = false;
            this.linkCityWikipedia.Location = new System.Drawing.Point(394, 288);
            this.linkCityWikipedia.Name = "linkCityWikipedia";
            this.linkCityWikipedia.Size = new System.Drawing.Size(141, 13);
            this.linkCityWikipedia.TabIndex = 12;
            this.linkCityWikipedia.TabStop = true;
            this.linkCityWikipedia.Text = "click here for city information";
            this.linkCityWikipedia.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCityWikipedia_LinkClicked);
            // 
            // labelCityWikipedia
            // 
            this.labelCityWikipedia.AutoSize = true;
            this.labelCityWikipedia.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCityWikipedia.ForeColor = System.Drawing.Color.White;
            this.labelCityWikipedia.Location = new System.Drawing.Point(393, 267);
            this.labelCityWikipedia.Name = "labelCityWikipedia";
            this.labelCityWikipedia.Size = new System.Drawing.Size(102, 21);
            this.labelCityWikipedia.TabIndex = 10;
            this.labelCityWikipedia.Text = "Wikipedia:";
            // 
            // listBoxCityWeather
            // 
            this.listBoxCityWeather.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxCityWeather.Enabled = false;
            this.listBoxCityWeather.FormattingEnabled = true;
            this.listBoxCityWeather.Location = new System.Drawing.Point(397, 37);
            this.listBoxCityWeather.Name = "listBoxCityWeather";
            this.listBoxCityWeather.Size = new System.Drawing.Size(202, 212);
            this.listBoxCityWeather.TabIndex = 9;
            // 
            // labelCityInfo
            // 
            this.labelCityInfo.AutoSize = true;
            this.labelCityInfo.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCityInfo.ForeColor = System.Drawing.Color.White;
            this.labelCityInfo.Location = new System.Drawing.Point(393, 13);
            this.labelCityInfo.Name = "labelCityInfo";
            this.labelCityInfo.Size = new System.Drawing.Size(90, 21);
            this.labelCityInfo.TabIndex = 8;
            this.labelCityInfo.Text = "Weather:";
            // 
            // labelFriendsFromSelectedCity
            // 
            this.labelFriendsFromSelectedCity.AutoSize = true;
            this.labelFriendsFromSelectedCity.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendsFromSelectedCity.ForeColor = System.Drawing.Color.White;
            this.labelFriendsFromSelectedCity.Location = new System.Drawing.Point(155, 13);
            this.labelFriendsFromSelectedCity.Name = "labelFriendsFromSelectedCity";
            this.labelFriendsFromSelectedCity.Size = new System.Drawing.Size(83, 21);
            this.labelFriendsFromSelectedCity.TabIndex = 7;
            this.labelFriendsFromSelectedCity.Text = "Friends:";
            // 
            // listBoxFriendsFromSelectedCity
            // 
            this.listBoxFriendsFromSelectedCity.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxFriendsFromSelectedCity.Enabled = false;
            this.listBoxFriendsFromSelectedCity.FormattingEnabled = true;
            this.listBoxFriendsFromSelectedCity.Location = new System.Drawing.Point(159, 37);
            this.listBoxFriendsFromSelectedCity.Name = "listBoxFriendsFromSelectedCity";
            this.listBoxFriendsFromSelectedCity.Size = new System.Drawing.Size(202, 264);
            this.listBoxFriendsFromSelectedCity.TabIndex = 6;
            this.listBoxFriendsFromSelectedCity.SelectedIndexChanged += new System.EventHandler(this.listBoxFriendsFromSelectedCity_SelectedIndexChanged);
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCity.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCity.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(12, 37);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(121, 23);
            this.comboBoxCity.TabIndex = 5;
            this.comboBoxCity.Text = "Select City";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.ForeColor = System.Drawing.Color.White;
            this.cityLabel.Location = new System.Drawing.Point(8, 13);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(52, 21);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 374);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriends)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearsRange)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCityFriend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label postStatusLabel;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button buttonSetStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button buttonFetchInfo;
        private System.Windows.Forms.Label labelCommonEvents;
        private System.Windows.Forms.ListBox listBoxFilteredFriends;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label labelFriendsFromSelectedCity;
        private System.Windows.Forms.ListBox listBoxFriendsFromSelectedCity;
        private System.Windows.Forms.Label labelCityInfo;
        private System.Windows.Forms.ListBox listBoxCityWeather;
        private System.Windows.Forms.Label labelCityWikipedia;
        private System.Windows.Forms.LinkLabel linkCityWikipedia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonYears;
        private System.Windows.Forms.RadioButton radioButtonLanguage;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.NumericUpDown numericUpDownYearsRange;
        private System.Windows.Forms.PictureBox pictureBoxFriends;
        private System.Windows.Forms.RadioButton radioButtonSameMonth;
        private System.Windows.Forms.ComboBox comboBoxCommonLanguage;
        private System.Windows.Forms.Button buttonCheckYear;
        private System.Windows.Forms.PictureBox pictureBoxCityFriend;
    }
}
