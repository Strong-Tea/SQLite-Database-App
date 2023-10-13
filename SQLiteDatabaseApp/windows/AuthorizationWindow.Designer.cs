namespace SQLiteDatabaseApp
{
    partial class AuthorizationWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lbLogin = new System.Windows.Forms.Label();
            tbLoginUsername = new System.Windows.Forms.TextBox();
            tbLoginPassword = new System.Windows.Forms.TextBox();
            lbGoToSignUp = new System.Windows.Forms.Label();
            lbUsername = new System.Windows.Forms.Label();
            lbPassword = new System.Windows.Forms.Label();
            pnlLogin = new System.Windows.Forms.Panel();
            btLogin = new System.Windows.Forms.Button();
            pnlSignUp = new System.Windows.Forms.Panel();
            tbConfirmPassword = new System.Windows.Forms.TextBox();
            lbConfPasswordSignUp = new System.Windows.Forms.Label();
            lbPasswordSignUp = new System.Windows.Forms.Label();
            tbPasswordSignUp = new System.Windows.Forms.TextBox();
            btSignUp = new System.Windows.Forms.Button();
            lbGoBackToLogin = new System.Windows.Forms.Label();
            lbUserNameSignUp = new System.Windows.Forms.Label();
            tbUsernameSignUp = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            pnlLogin.SuspendLayout();
            pnlSignUp.SuspendLayout();
            SuspendLayout();
            // 
            // lbLogin
            // 
            lbLogin.BackColor = System.Drawing.Color.White;
            lbLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            lbLogin.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbLogin.Location = new System.Drawing.Point(0, 0);
            lbLogin.Name = "lbLogin";
            lbLogin.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            lbLogin.Size = new System.Drawing.Size(440, 450);
            lbLogin.TabIndex = 1;
            lbLogin.Text = "Login";
            lbLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbLoginUsername
            // 
            tbLoginUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            tbLoginUsername.Location = new System.Drawing.Point(117, 163);
            tbLoginUsername.Name = "tbLoginUsername";
            tbLoginUsername.Size = new System.Drawing.Size(203, 27);
            tbLoginUsername.TabIndex = 2;
            tbLoginUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            tbLoginUsername.Click += tbLoginUsername_Click;
            // 
            // tbLoginPassword
            // 
            tbLoginPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            tbLoginPassword.Location = new System.Drawing.Point(117, 216);
            tbLoginPassword.Name = "tbLoginPassword";
            tbLoginPassword.Size = new System.Drawing.Size(203, 27);
            tbLoginPassword.TabIndex = 3;
            tbLoginPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            tbLoginPassword.Click += tbLoginPassword_Click;
            // 
            // lbGoToSignUp
            // 
            lbGoToSignUp.AutoSize = true;
            lbGoToSignUp.BackColor = System.Drawing.Color.White;
            lbGoToSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbGoToSignUp.Location = new System.Drawing.Point(343, 9);
            lbGoToSignUp.Name = "lbGoToSignUp";
            lbGoToSignUp.Size = new System.Drawing.Size(85, 28);
            lbGoToSignUp.TabIndex = 5;
            lbGoToSignUp.Text = "Sign Up";
            lbGoToSignUp.Click += lbSignUp_Click;
            lbGoToSignUp.MouseEnter += lbGoToSignUp_MouseEnter;
            lbGoToSignUp.MouseLeave += lbGoToSignUp_MouseLeave;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.BackColor = System.Drawing.Color.White;
            lbUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbUsername.Location = new System.Drawing.Point(117, 140);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new System.Drawing.Size(80, 20);
            lbUsername.TabIndex = 6;
            lbUsername.Text = "Username";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.BackColor = System.Drawing.Color.White;
            lbPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbPassword.Location = new System.Drawing.Point(117, 193);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new System.Drawing.Size(76, 20);
            lbPassword.TabIndex = 7;
            lbPassword.Text = "Password";
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = System.Drawing.Color.White;
            pnlLogin.Controls.Add(btLogin);
            pnlLogin.Controls.Add(lbGoToSignUp);
            pnlLogin.Controls.Add(lbUsername);
            pnlLogin.Controls.Add(lbPassword);
            pnlLogin.Controls.Add(tbLoginUsername);
            pnlLogin.Controls.Add(tbLoginPassword);
            pnlLogin.Controls.Add(lbLogin);
            pnlLogin.Location = new System.Drawing.Point(0, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new System.Drawing.Size(440, 450);
            pnlLogin.TabIndex = 8;
            // 
            // btLogin
            // 
            btLogin.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            btLogin.FlatAppearance.BorderSize = 0;
            btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btLogin.Location = new System.Drawing.Point(117, 269);
            btLogin.Name = "btLogin";
            btLogin.Size = new System.Drawing.Size(203, 41);
            btLogin.TabIndex = 8;
            btLogin.Text = "Login";
            btLogin.UseVisualStyleBackColor = false;
            btLogin.Click += btLogin_Click;
            // 
            // pnlSignUp
            // 
            pnlSignUp.BackColor = System.Drawing.Color.White;
            pnlSignUp.Controls.Add(tbConfirmPassword);
            pnlSignUp.Controls.Add(lbConfPasswordSignUp);
            pnlSignUp.Controls.Add(lbPasswordSignUp);
            pnlSignUp.Controls.Add(tbPasswordSignUp);
            pnlSignUp.Controls.Add(btSignUp);
            pnlSignUp.Controls.Add(lbGoBackToLogin);
            pnlSignUp.Controls.Add(lbUserNameSignUp);
            pnlSignUp.Controls.Add(tbUsernameSignUp);
            pnlSignUp.Controls.Add(label4);
            pnlSignUp.Location = new System.Drawing.Point(0, 0);
            pnlSignUp.Name = "pnlSignUp";
            pnlSignUp.Size = new System.Drawing.Size(440, 450);
            pnlSignUp.TabIndex = 9;
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            tbConfirmPassword.Location = new System.Drawing.Point(117, 269);
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.Size = new System.Drawing.Size(203, 27);
            tbConfirmPassword.TabIndex = 4;
            tbConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbConfPasswordSignUp
            // 
            lbConfPasswordSignUp.AutoSize = true;
            lbConfPasswordSignUp.BackColor = System.Drawing.Color.White;
            lbConfPasswordSignUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbConfPasswordSignUp.Location = new System.Drawing.Point(117, 246);
            lbConfPasswordSignUp.Name = "lbConfPasswordSignUp";
            lbConfPasswordSignUp.Size = new System.Drawing.Size(137, 20);
            lbConfPasswordSignUp.TabIndex = 11;
            lbConfPasswordSignUp.Text = "Confirm Password";
            // 
            // lbPasswordSignUp
            // 
            lbPasswordSignUp.AutoSize = true;
            lbPasswordSignUp.BackColor = System.Drawing.Color.White;
            lbPasswordSignUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbPasswordSignUp.Location = new System.Drawing.Point(117, 193);
            lbPasswordSignUp.Name = "lbPasswordSignUp";
            lbPasswordSignUp.Size = new System.Drawing.Size(76, 20);
            lbPasswordSignUp.TabIndex = 10;
            lbPasswordSignUp.Text = "Password";
            // 
            // tbPasswordSignUp
            // 
            tbPasswordSignUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            tbPasswordSignUp.Location = new System.Drawing.Point(117, 216);
            tbPasswordSignUp.Name = "tbPasswordSignUp";
            tbPasswordSignUp.Size = new System.Drawing.Size(203, 27);
            tbPasswordSignUp.TabIndex = 3;
            tbPasswordSignUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btSignUp
            // 
            btSignUp.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            btSignUp.FlatAppearance.BorderSize = 0;
            btSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btSignUp.Location = new System.Drawing.Point(117, 316);
            btSignUp.Name = "btSignUp";
            btSignUp.Size = new System.Drawing.Size(203, 41);
            btSignUp.TabIndex = 8;
            btSignUp.Text = "Sign Up";
            btSignUp.UseVisualStyleBackColor = false;
            btSignUp.Click += btSignUp_Click;
            // 
            // lbGoBackToLogin
            // 
            lbGoBackToLogin.AutoSize = true;
            lbGoBackToLogin.BackColor = System.Drawing.Color.White;
            lbGoBackToLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbGoBackToLogin.Location = new System.Drawing.Point(343, 9);
            lbGoBackToLogin.Name = "lbGoBackToLogin";
            lbGoBackToLogin.Size = new System.Drawing.Size(64, 28);
            lbGoBackToLogin.TabIndex = 5;
            lbGoBackToLogin.Text = "Login";
            lbGoBackToLogin.Click += lbGoBackToLogin_Click;
            lbGoBackToLogin.MouseEnter += lbGoBackToLogin_MouseEnter;
            lbGoBackToLogin.MouseLeave += lbGoBackToLogin_MouseLeave;
            // 
            // lbUserNameSignUp
            // 
            lbUserNameSignUp.AutoSize = true;
            lbUserNameSignUp.BackColor = System.Drawing.Color.White;
            lbUserNameSignUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbUserNameSignUp.Location = new System.Drawing.Point(117, 140);
            lbUserNameSignUp.Name = "lbUserNameSignUp";
            lbUserNameSignUp.Size = new System.Drawing.Size(80, 20);
            lbUserNameSignUp.TabIndex = 6;
            lbUserNameSignUp.Text = "Username";
            // 
            // tbUsernameSignUp
            // 
            tbUsernameSignUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            tbUsernameSignUp.Location = new System.Drawing.Point(117, 163);
            tbUsernameSignUp.Name = "tbUsernameSignUp";
            tbUsernameSignUp.Size = new System.Drawing.Size(203, 27);
            tbUsernameSignUp.TabIndex = 1;
            tbUsernameSignUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.BackColor = System.Drawing.Color.White;
            label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(0, 0);
            label4.Name = "label4";
            label4.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            label4.Size = new System.Drawing.Size(440, 450);
            label4.TabIndex = 1;
            label4.Text = "Sign Up";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AuthorizationWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(440, 450);
            Controls.Add(pnlLogin);
            Controls.Add(pnlSignUp);
            Location = new System.Drawing.Point(10, 10);
            Name = "AuthorizationWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Database App";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlSignUp.ResumeLayout(false);
            pnlSignUp.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.TextBox tbLoginUsername;
        private System.Windows.Forms.TextBox tbLoginPassword;
        private System.Windows.Forms.Label lbGoToSignUp;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Panel pnlSignUp;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lbConfPasswordSignUp;
        private System.Windows.Forms.Label lbPasswordSignUp;
        private System.Windows.Forms.TextBox tbPasswordSignUp;
        private System.Windows.Forms.Button btSignUp;
        private System.Windows.Forms.Label lbGoBackToLogin;
        private System.Windows.Forms.Label lbUserNameSignUp;
        private System.Windows.Forms.TextBox tbUsernameSignUp;
        private System.Windows.Forms.Label label4;
    }
}
