using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SQLiteDatabaseApp
{
    using SQLiteDatabaseApp.DataBase.Manager;
    using SQLiteDatabaseApp.DataBase.Tables;
    using SQLiteDatabaseApp.windows;
    using System.Data.SQLite;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

    public partial class AuthorizationWindow : Form
    {
        private Label lbErrorMessage;

        public static DataTable modesDataTable;

        private static DataGridWindow dataGridWindow;

        public AuthorizationWindow()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void lbSignUp_Click(object sender, EventArgs e)
        {
            pnlSignUp.BringToFront();
        }

        private void lbGoBackToLogin_Click(object sender, EventArgs e)
        {
            pnlLogin.BringToFront();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (CheckLoginDataErrors())
                return;

            Users user = DatabaseManager.GetInstance().GetUserByUsername(tbLoginUsername.Text);

            if (user == null)
            {
                DisplayError("*invalid username", lbUsername.Right + 10, lbUsername.Top, pnlLogin);
                return;
            }
            if (!user.Password.Equals(DatabaseManager.GetInstance().HashPassword(tbLoginPassword.Text)))
            {
                DisplayError("*invalid password", lbPassword.Right + 10, lbPassword.Top, pnlLogin);
                return;
            }
            modesDataTable = DatabaseManager.GetInstance().GetDataTable("Users");
            dataGridWindow = new DataGridWindow();
            dataGridWindow.MyDataGridView.DataSource = modesDataTable;
            foreach (DataGridViewColumn column in dataGridWindow.MyDataGridView.Columns)
            {
                if (column.Name == "ID")
                {
                    column.ReadOnly = true;
                    break;
                }
            }
            dataGridWindow.Show();
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            if (CheckRegistrationDataForErrors())
                return;

            // Add a user to the database
            Users user = new Users();
            if (tbUsernameSignUp.Text.ToString().Equals("admin"))
            {
                user.Role = "Administrator";
            }
            else
            {
                user.Role = "User";
            }

            user.Username = tbUsernameSignUp.Text;
            user.Password = DatabaseManager.GetInstance().HashPassword(tbPasswordSignUp.Text);
            DatabaseManager.GetInstance().AddNewEntity(user);
            //MessageBox.Show("Success");
        }

        private bool CheckLoginDataErrors()
        {
            string username = tbLoginUsername.Text;
            if (username.Equals(""))
            {
                DisplayError("*empty field", lbUsername.Right + 10, lbUsername.Top, pnlLogin);
                return true;
            }
            string password = tbLoginPassword.Text;
            if (password.Equals(""))
            {
                DisplayError("*empty field", lbPassword.Right + 10, lbPassword.Top, pnlLogin);
                return true;
            }
            string err;
            if ((err = CheckPassword(password)) != null)
            {
                DisplayError("invalid password", lbPassword.Right + 10, lbPassword.Top, pnlLogin);
                return true;
            }
            return false;
        }

        private bool CheckRegistrationDataForErrors()
        {
            // Check Username
            string username = tbUsernameSignUp.Text;
            if (username.Equals(""))
            {
                DisplayError("*empty field", lbUserNameSignUp.Right + 10, lbUserNameSignUp.Top, pnlSignUp);
                return true;
            }
            Users user = DatabaseManager.GetInstance().GetUserByUsername(username);
            if (user != null)
            {
                DisplayError("*already exists", lbUserNameSignUp.Right + 10, lbUserNameSignUp.Top, pnlSignUp);
                return true;
            }

            // Check password
            string password = tbPasswordSignUp.Text;
            if (password.Equals(""))
            {
                DisplayError("*empty field", lbPasswordSignUp.Right + 10, lbPasswordSignUp.Top, pnlSignUp);
                return true;
            }
            string err;
            if ((err = CheckPassword(password)) != null)
            {
                DisplayError(err, lbPasswordSignUp.Right + 10, lbPasswordSignUp.Top, pnlSignUp);
                return true;
            }

            // Confirm password
            string confPassword = tbConfirmPassword.Text;
            if (confPassword.Equals(""))
            {
                DisplayError("*empty field", lbConfPasswordSignUp.Right + 10, lbConfPasswordSignUp.Top, pnlSignUp);
                return true;
            }
            if (!password.Equals(confPassword))
            {
                DisplayError("*passwords don't match", lbConfPasswordSignUp.Right + 10, lbConfPasswordSignUp.Top, pnlSignUp);
                return true;
            }

            return false;
        }

        private string CheckPassword(string password)
        {
            if (password.Length < 6)
                return "*length < 6";

            string pattern = @"^(?=.*[A-Za-z])(?=.*\d).+$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(password))
                return "*missing letters or numbers";
            return null;
        }

        private void DisplayError(string strErrorMessage, int x, int y, Control targetControl)
        {
            if (lbErrorMessage != null)
                lbErrorMessage.Text = "";
            lbErrorMessage = new Label();
            lbErrorMessage.Text = strErrorMessage;
            lbErrorMessage.ForeColor = Color.Red;
            lbErrorMessage.AutoSize = true;
            lbErrorMessage.Location = new Point(x, y);
            targetControl.Controls.Add(lbErrorMessage);
            targetControl.Controls.SetChildIndex(lbErrorMessage, 0);
        }

        private void tbLoginUsername_Click(object sender, EventArgs e)
        {
            if (lbErrorMessage != null)
                lbErrorMessage.Text = "";
        }

        private void tbLoginPassword_Click(object sender, EventArgs e)
        {
            if (lbErrorMessage != null)
                lbErrorMessage.Text = "";
        }

        private void lbGoToSignUp_MouseEnter(object sender, EventArgs e)
        {
            lbGoToSignUp.ForeColor = Color.FromArgb(66, 103, 178);
        }

        private void lbGoToSignUp_MouseLeave(object sender, EventArgs e)
        {
            lbGoToSignUp.ForeColor = SystemColors.ControlText;
        }

        private void lbGoBackToLogin_MouseEnter(object sender, EventArgs e)
        {
            lbGoBackToLogin.ForeColor = Color.FromArgb(66, 103, 178);
        }

        private void lbGoBackToLogin_MouseLeave(object sender, EventArgs e)
        {
            lbGoBackToLogin.ForeColor = SystemColors.ControlText;
        }
    }
}
