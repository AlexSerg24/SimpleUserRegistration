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
using System.Windows.Shapes;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnAuthClick(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();

            int check = 0;

            if (login.Length < 5)
            {
                Login.ToolTip = "Слишком короткий логин!";
                Login.Background = Brushes.DarkRed;
            }
            else
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

            if (check == 2)
            {
                User authUser = null;
                using (AppContext context = new AppContext())
                {
                    authUser = context.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }

                if (authUser != null)
                {
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Введены некорректные данные!");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
