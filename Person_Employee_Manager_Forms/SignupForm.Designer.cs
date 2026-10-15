namespace Person_Employee_Manager_Forms
{
    partial class SignupForm
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
            lblUsername = new Label();
            lblPosition = new Label();
            lblName = new Label();
            lblAge = new Label();
            lblPassword = new Label();
            lblSalary = new Label();
            btnCreateAccount = new Button();
            txtUsername = new TextBox();
            txtName = new TextBox();
            cboPosition = new ComboBox();
            txtSalary = new TextBox();
            txtAge = new TextBox();
            txtPassword = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 13F);
            lblUsername.Location = new Point(37, 36);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(91, 25);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Font = new Font("Segoe UI", 13F);
            lblPosition.Location = new Point(37, 274);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(75, 25);
            lblPosition.TabIndex = 1;
            lblPosition.Text = "Position";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13F);
            lblName.Location = new Point(37, 212);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 13F);
            lblAge.Location = new Point(37, 153);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(44, 25);
            lblAge.TabIndex = 3;
            lblAge.Text = "Age";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 13F);
            lblPassword.Location = new Point(37, 93);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(87, 25);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 13F);
            lblSalary.Location = new Point(37, 336);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(59, 25);
            lblSalary.TabIndex = 5;
            lblSalary.Text = "Salary";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.AutoSize = true;
            btnCreateAccount.Font = new Font("Segoe UI", 13F);
            btnCreateAccount.Location = new Point(578, 38);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(142, 35);
            btnCreateAccount.TabIndex = 6;
            btnCreateAccount.Text = "Create Account";
            btnCreateAccount.UseVisualStyleBackColor = true;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(153, 38);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(266, 23);
            txtUsername.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(153, 214);
            txtName.Name = "txtName";
            txtName.Size = new Size(266, 23);
            txtName.TabIndex = 9;
            // 
            // txtPosition
            // 
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPosition.Items.AddRange(new object[] { "Employee", "Manager" });
            cboPosition.Location = new Point(153, 276);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(266, 23);
            cboPosition.TabIndex = 10;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(153, 338);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(266, 23);
            txtSalary.TabIndex = 11;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(153, 155);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(266, 23);
            txtAge.TabIndex = 12;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(153, 95);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(266, 23);
            txtPassword.TabIndex = 13;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Font = new Font("Segoe UI", 13F);
            btnCancel.Location = new Point(578, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(142, 35);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(txtPassword);
            Controls.Add(txtAge);
            Controls.Add(txtSalary);
            Controls.Add(cboPosition);
            Controls.Add(txtName);
            Controls.Add(txtUsername);
            Controls.Add(btnCreateAccount);
            Controls.Add(lblSalary);
            Controls.Add(lblPassword);
            Controls.Add(lblAge);
            Controls.Add(lblName);
            Controls.Add(lblPosition);
            Controls.Add(lblUsername);
            Name = "SignupForm";
            Text = "SignupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblPosition;
        private Label lblName;
        private Label lblAge;
        private Label lblPassword;
        private Label lblSalary;
        private Button btnCreateAccount;
        private TextBox txtUsername;
        private TextBox txtName;
        private ComboBox cboPosition;
        private TextBox txtSalary;
        private TextBox txtAge;
        private TextBox txtPassword;
        private Button btnCancel;
    }
}
