using PersonEmployeeManager;
using System.Globalization;

namespace Person_Employee_Manager_Forms
{
    public partial class SignupForm : Form
    {
        private readonly IUserStore store;

        public SignupForm(IUserStore store)
        {
            this.store = store;
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            cboPosition.SelectedIndex = 0;
            btnCreateAccount.Click += btnCreateAccount_Click;
            btnCancel.Click += btnCancel_Click;
            AcceptButton = btnCreateAccount;
            CancelButton = btnCancel;
        }

        private void btnCreateAccount_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string name = txtName.Text.Trim();
            if (username.Length == 0 || password.Length == 0 || name.Length == 0)
            {
                ShowValidation("Enter a username, password, and name.");
                return;
            }
            if (!int.TryParse(txtAge.Text, out int age) || age < 0)
            {
                ShowValidation("Enter a valid non-negative age.");
                txtAge.Focus();
                return;
            }
            if (!decimal.TryParse(txtSalary.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal salary) || salary < 0)
            {
                ShowValidation("Enter a valid non-negative salary.");
                txtSalary.Focus();
                return;
            }

            Person person = cboPosition.SelectedIndex == 1
                ? new Manager(username, Person.EncodePassword(password), name, age, salary)
                : new Employee(username, Person.EncodePassword(password), name, age, salary);
            if (!store.Create(person))
            {
                ShowValidation("That username is already in use.");
                txtUsername.Focus();
                return;
            }

            MessageBox.Show("Account created successfully.", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowValidation(string message) =>
            MessageBox.Show(message, "Check account details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
