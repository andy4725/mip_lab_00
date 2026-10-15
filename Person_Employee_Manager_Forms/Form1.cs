using PersonEmployeeManager;
using System.Globalization;

namespace Person_Employee_Manager_Forms
{
    public partial class Form1 : Form
    {
        private readonly IUserStore store = new UserStore();

        public Form1()
        {
            InitializeComponent();
            passwordTextbox.UseSystemPasswordChar = true;
            AcceptButton = signinButton;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person? person = store.FindByUsername(usernameTextbox.Text.Trim());
            if (person is null || !Person.VerifyPassword(passwordTextbox.Text, person.EncodedPassword))
            {
                MessageBox.Show("Username or password is incorrect.", "Sign in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Welcome, {person.Name}!\nPosition: {person.Position}\nAge: {person.Age}\nSalary: {person.Salary.ToString("0.00", CultureInfo.CurrentCulture)}",
                "Signed in", MessageBoxButtons.OK, MessageBoxIcon.Information);
            passwordTextbox.Clear();

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            using var signupForm = new SignupForm(store);
            signupForm.ShowDialog();
        }
    }
}
