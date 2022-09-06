using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();

            DoubleAnimation btnAnim = new DoubleAnimation();
            btnAnim.From = 100;
            btnAnim.To = 450;
            btnAnim.Duration = TimeSpan.FromSeconds(3);
            regBtn.BeginAnimation(Button.WidthProperty, btnAnim);
        }

        private void BtnRegClick(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();
            string chaeckPassword = CheckPassword.Password.Trim();
            string email = Email.Text.Trim();

            int check = 0;

            if (login.Length < 5)
            {
                Login.ToolTip = "Слишком короткий логин!";
                Login.Background = Brushes.DarkRed;
            } else
            {
                Login.ToolTip = "";
                Login.Background = Brushes.Transparent;
                check++;
            }
            
            if (password.Length < 5)
            {
                Password.ToolTip = "Слишком короткий пароль!";
                Password.Background = Brushes.DarkRed;
            } else
            {
                Password.ToolTip = "";
                Password.Background = Brushes.Transparent;
                check++;
            }
            
            if (password != chaeckPassword)
            {
                CheckPassword.ToolTip = "Пароли не совпали!";
                CheckPassword.Background = Brushes.DarkRed;
            } else
            {
                CheckPassword.ToolTip = "";
                CheckPassword.Background = Brushes.Transparent;
                check++;
            }
            
            if (email.Length < 5 || !email.Contains("@") || !email.Contains(".")) 
            {
                Email.ToolTip = "Почта введена некорректно!";
                Email.Background = Brushes.DarkRed;
            } else
            {
                Email.ToolTip = "";
                Email.Background = Brushes.Transparent;
                check++;
            }

            if (check == 4)
            {
                MessageBox.Show("Регистрация прошла успешно!");
                User newUser = new User(login, password, email);
                db.Users.Add(newUser);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();
            }
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }
    }
}
