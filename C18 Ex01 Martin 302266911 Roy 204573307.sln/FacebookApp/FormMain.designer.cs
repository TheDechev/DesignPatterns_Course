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
            this.picture_smallPictureBox = new System.Windows.Forms.PictureBox();
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
            this.listBoxCommonEvents = new System.Windows.Forms.ListBox();
            this.listBoxCommonPages = new System.Windows.Forms.ListBox();
            this.labelCommonEvents = new System.Windows.Forms.Label();
            this.labelCommonPages = new System.Windows.Forms.Label();
            this.labelFriendsList = new System.Windows.Forms.Label();
            this.comboBoxFriends = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkCityWikipedia = new System.Windows.Forms.LinkLabel();
            this.labelCityWikipedia = new System.Windows.Forms.Label();
            this.listBoxCityWeather = new System.Windows.Forms.ListBox();
            this.labelCityInfo = new System.Windows.Forms.Label();
            this.labelFriendsFromSelectedCity = new System.Windows.Forms.Label();
            this.listBoxFriendsFromSelectedCity = new System.Windows.Forms.ListBox();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.cityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture_smallPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture_smallPictureBox
            // 
            this.picture_smallPictureBox.Location = new System.Drawing.Point(252, 59);
            this.picture_smallPictureBox.Name = "picture_smallPictureBox";
            this.picture_smallPictureBox.Size = new System.Drawing.Size(130, 130);
            this.picture_smallPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_smallPictureBox.TabIndex = 41;
            this.picture_smallPictureBox.TabStop = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.White;
            this.buttonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Location = new System.Drawing.Point(252, 210);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(130, 24);
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
            this.tabPage1.Controls.Add(this.picture_smallPictureBox);
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
            this.buttonFetchInfo.Location = new System.Drawing.Point(272, 240);
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
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.userNameLabel.Location = new System.Drawing.Point(231, 22);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(0, 20);
            this.userNameLabel.TabIndex = 48;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.White;
            this.buttonLogout.Enabled = false;
            this.buttonLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(252, 210);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(130, 24);
            this.buttonLogout.TabIndex = 47;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage2.Controls.Add(this.listBoxCommonEvents);
            this.tabPage2.Controls.Add(this.listBoxCommonPages);
            this.tabPage2.Controls.Add(this.labelCommonEvents);
            this.tabPage2.Controls.Add(this.labelCommonPages);
            this.tabPage2.Controls.Add(this.labelFriendsList);
            this.tabPage2.Controls.Add(this.comboBoxFriends);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 348);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Common Info With A Friend";
            // 
            // listBoxCommonEvents
            // 
            this.listBoxCommonEvents.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxCommonEvents.Enabled = false;
            this.listBoxCommonEvents.FormattingEnabled = true;
            this.listBoxCommonEvents.Location = new System.Drawing.Point(397, 37);
            this.listBoxCommonEvents.Name = "listBoxCommonEvents";
            this.listBoxCommonEvents.Size = new System.Drawing.Size(202, 264);
            this.listBoxCommonEvents.TabIndex = 6;
            // 
            // listBoxCommonPages
            // 
            this.listBoxCommonPages.BackColor = System.Drawing.Color.AliceBlue;
            this.listBoxCommonPages.Enabled = false;
            this.listBoxCommonPages.FormattingEnabled = true;
            this.listBoxCommonPages.Location = new System.Drawing.Point(158, 37);
            this.listBoxCommonPages.Name = "listBoxCommonPages";
            this.listBoxCommonPages.Size = new System.Drawing.Size(202, 264);
            this.listBoxCommonPages.TabIndex = 5;
            // 
            // labelCommonEvents
            // 
            this.labelCommonEvents.AutoSize = true;
            this.labelCommonEvents.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommonEvents.ForeColor = System.Drawing.Color.White;
            this.labelCommonEvents.Location = new System.Drawing.Point(393, 13);
            this.labelCommonEvents.Name = "labelCommonEvents";
            this.labelCommonEvents.Size = new System.Drawing.Size(163, 21);
            this.labelCommonEvents.TabIndex = 4;
            this.labelCommonEvents.Text = "Common Events:";
            // 
            // labelCommonPages
            // 
            this.labelCommonPages.AutoSize = true;
            this.labelCommonPages.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommonPages.ForeColor = System.Drawing.Color.White;
            this.labelCommonPages.Location = new System.Drawing.Point(154, 13);
            this.labelCommonPages.Name = "labelCommonPages";
            this.labelCommonPages.Size = new System.Drawing.Size(156, 21);
            this.labelCommonPages.TabIndex = 2;
            this.labelCommonPages.Text = "Common Pages:";
            // 
            // labelFriendsList
            // 
            this.labelFriendsList.AutoSize = true;
            this.labelFriendsList.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendsList.ForeColor = System.Drawing.Color.White;
            this.labelFriendsList.Location = new System.Drawing.Point(8, 13);
            this.labelFriendsList.Name = "labelFriendsList";
            this.labelFriendsList.Size = new System.Drawing.Size(120, 21);
            this.labelFriendsList.TabIndex = 1;
            this.labelFriendsList.Text = "Friends List:";
            // 
            // comboBoxFriends
            // 
            this.comboBoxFriends.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxFriends.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFriends.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.comboBoxFriends.FormattingEnabled = true;
            this.comboBoxFriends.Location = new System.Drawing.Point(12, 37);
            this.comboBoxFriends.Name = "comboBoxFriends";
            this.comboBoxFriends.Size = new System.Drawing.Size(121, 23);
            this.comboBoxFriends.TabIndex = 0;
            this.comboBoxFriends.Text = "Select a friend";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.SteelBlue;
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
            ((System.ComponentModel.ISupportInitialize)(this.picture_smallPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picture_smallPictureBox;
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
        private System.Windows.Forms.ComboBox comboBoxFriends;
        private System.Windows.Forms.Label labelFriendsList;
        private System.Windows.Forms.Button buttonFetchInfo;
        private System.Windows.Forms.Label labelCommonPages;
        private System.Windows.Forms.Label labelCommonEvents;
        private System.Windows.Forms.ListBox listBoxCommonEvents;
        private System.Windows.Forms.ListBox listBoxCommonPages;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label labelFriendsFromSelectedCity;
        private System.Windows.Forms.ListBox listBoxFriendsFromSelectedCity;
        private System.Windows.Forms.Label labelCityInfo;
        private System.Windows.Forms.ListBox listBoxCityWeather;
        private System.Windows.Forms.Label labelCityWikipedia;
        private System.Windows.Forms.LinkLabel linkCityWikipedia;
    }
}
