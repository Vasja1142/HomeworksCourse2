using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            userNameField.Text = "Введите имя";
            userNameField.ForeColor = Color.Gray;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Gray;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
        }

        Point lastPoint;

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите имя";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string loginUser = loginField.Text;
            string passUser = passField.Text;

            if (string.IsNullOrEmpty(loginUser) || loginUser.Length > 100 || !loginUser.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Неверный формат логина.");
                return;
            }

            if (string.IsNullOrEmpty(loginUser) || string.IsNullOrEmpty(passUser))
            {
                MessageBox.Show("Поля не могут быть пустыми.");
                return;
            }


            using (ApplicationContext db = new ApplicationContext())
            {
                //  СОХРАНЕНИЕ ПАРОЛЯ В ОТКРЫТОМ ВИДЕ (НЕБЕЗОПАСНО!)
                User newUser = new User { Login = loginUser, Password = passUser }; // Обратите внимание: свойство Password, а не PasswordHash
                db.Users.Add(newUser);

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно зарегистрирован! (НЕБЕЗОПАСНО)");
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Ошибка при добавлении пользователя: {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        errorMessage += $"\nInner Exception: {ex.InnerException.Message}";
                    }
                    MessageBox.Show(errorMessage);
                }
            }
        }



        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
