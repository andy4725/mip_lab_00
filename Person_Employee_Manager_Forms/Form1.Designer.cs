namespace Person_Employee_Manager_Forms
{
    partial class Form1
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
            Username = new Label();
            PasswordLabel = new Label();
            usernameTextbox = new TextBox();
            passwordTextbox = new TextBox();
            signinButton = new Button();
            signupButton = new Button();
            SuspendLayout();
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Segoe UI", 13F);
            Username.Location = new Point(34, 173);
            Username.Name = "Username";
            Username.Size = new Size(91, 25);
            Username.TabIndex = 0;
            Username.Text = "Username";
            Username.Click += label1_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 13F);
            PasswordLabel.Location = new Point(34, 235);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(87, 25);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "Password";
            PasswordLabel.Click += label1_Click_1;
            // 
            // usernameTextbox
            // 
            usernameTextbox.Location = new Point(151, 175);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.Size = new Size(228, 23);
            usernameTextbox.TabIndex = 2;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(151, 235);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.Size = new Size(228, 23);
            passwordTextbox.TabIndex = 3;
            // 
            // signinButton
            // 
            signinButton.Location = new Point(34, 313);
            signinButton.Name = "signinButton";
            signinButton.Size = new Size(75, 23);
            signinButton.TabIndex = 4;
            signinButton.Text = "Sign In";
            signinButton.UseVisualStyleBackColor = true;
            signinButton.Click += button1_Click;
            // 
            // signupButton
            // 
            signupButton.Location = new Point(34, 360);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(75, 23);
            signupButton.TabIndex = 5;
            signupButton.Text = "Sign Up";
            signupButton.UseVisualStyleBackColor = true;
            signupButton.Click += signupButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(signupButton);
            Controls.Add(signinButton);
            Controls.Add(passwordTextbox);
            Controls.Add(usernameTextbox);
            Controls.Add(PasswordLabel);
            Controls.Add(Username);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Username;
        private Label PasswordLabel;
        private TextBox usernameTextbox;
        private TextBox passwordTextbox;
        private Button signinButton;
        private Button signupButton;
    }
}
