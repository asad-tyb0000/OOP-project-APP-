namespace chorBZRwf
{
    partial class SignPage
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.roleCombo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.passwordText = new Guna.UI2.WinForms.Guna2TextBox();
            this.nameText = new Guna.UI2.WinForms.Guna2TextBox();
            this.nextClick = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel2.BackgroundImage = global::chorBZRwf.Properties.Resources.market_4856748_1280;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 450);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(482, 371);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(71, 25);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Log In";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Already have an account !";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.nextClick);
            this.panel3.Controls.Add(this.nameText);
            this.panel3.Controls.Add(this.passwordText);
            this.panel3.Controls.Add(this.roleCombo);
            this.panel3.Location = new System.Drawing.Point(227, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 307);
            this.panel3.TabIndex = 8;
            // 
            // roleCombo
            // 
            this.roleCombo.AutoRoundedCorners = true;
            this.roleCombo.BackColor = System.Drawing.Color.Transparent;
            this.roleCombo.BorderColor = System.Drawing.Color.Aquamarine;
            this.roleCombo.BorderRadius = 17;
            this.roleCombo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.roleCombo.BorderThickness = 4;
            this.roleCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.roleCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleCombo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roleCombo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roleCombo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.roleCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.roleCombo.ItemHeight = 30;
            this.roleCombo.Location = new System.Drawing.Point(91, 193);
            this.roleCombo.Name = "roleCombo";
            this.roleCombo.Size = new System.Drawing.Size(163, 36);
            this.roleCombo.TabIndex = 2;
            this.roleCombo.SelectedIndexChanged += new System.EventHandler(this.roleCombo_SelectedIndexChanged);
            // 
            // passwordText
            // 
            this.passwordText.AutoRoundedCorners = true;
            this.passwordText.BorderRadius = 18;
            this.passwordText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordText.DefaultText = "";
            this.passwordText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.passwordText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.passwordText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.passwordText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passwordText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.passwordText.Location = new System.Drawing.Point(92, 134);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '\0';
            this.passwordText.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.passwordText.PlaceholderText = "Password";
            this.passwordText.SelectedText = "";
            this.passwordText.Size = new System.Drawing.Size(163, 39);
            this.passwordText.TabIndex = 3;
            // 
            // nameText
            // 
            this.nameText.AutoRoundedCorners = true;
            this.nameText.BorderRadius = 18;
            this.nameText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameText.DefaultText = "";
            this.nameText.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameText.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nameText.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameText.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameText.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nameText.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nameText.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameText.Location = new System.Drawing.Point(92, 79);
            this.nameText.Name = "nameText";
            this.nameText.PasswordChar = '\0';
            this.nameText.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.nameText.PlaceholderText = "Name";
            this.nameText.SelectedText = "";
            this.nameText.Size = new System.Drawing.Size(163, 39);
            this.nameText.TabIndex = 1;
            this.nameText.TextChanged += new System.EventHandler(this.nameText_TextChanged);
            // 
            // nextClick
            // 
            this.nextClick.Animated = true;
            this.nextClick.AutoRoundedCorners = true;
            this.nextClick.BackColor = System.Drawing.Color.Transparent;
            this.nextClick.BorderRadius = 17;
            this.nextClick.DefaultAutoSize = true;
            this.nextClick.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.nextClick.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.nextClick.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.nextClick.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.nextClick.FillColor = System.Drawing.Color.CadetBlue;
            this.nextClick.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.nextClick.ForeColor = System.Drawing.Color.Maroon;
            this.nextClick.Location = new System.Drawing.Point(143, 252);
            this.nextClick.Name = "nextClick";
            this.nextClick.Size = new System.Drawing.Size(72, 37);
            this.nextClick.TabIndex = 5;
            this.nextClick.Text = "Next";
            this.nextClick.UseTransparentBackground = true;
            this.nextClick.Click += new System.EventHandler(this.nextClick_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Aquamarine;
            this.label1.Location = new System.Drawing.Point(89, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign UP";
            // 
            // SignPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button nextClick;
        private Guna.UI2.WinForms.Guna2TextBox nameText;
        private Guna.UI2.WinForms.Guna2TextBox passwordText;
        private Guna.UI2.WinForms.Guna2ComboBox roleCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}