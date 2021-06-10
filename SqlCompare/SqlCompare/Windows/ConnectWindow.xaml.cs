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

namespace SqlCompare.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window
    {
        public Connection Connection { get; set; }

        public delegate void ConnectionDelegate(Connection connection);

        public event ConnectionDelegate PassConnection;


        public TextBlock status;

        public ConnectWindow()
        {
            InitializeComponent();
            status = ((TextBlock)FindName("tblStatus"));
        }

        private Connection CollectUserInfo()
        {
            string host = ((TextBox)FindName("tbHost")).Text.Trim();
            if (string.IsNullOrEmpty(host))
            {
                MessageBox.Show(
                    "Введите имя хоста!",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return null;
            }

            string dbName = ((TextBox)FindName("tbDbName")).Text.Trim();
            if (string.IsNullOrEmpty(dbName))
            {
                MessageBox.Show(
                    "Введите имя базы данных!",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return null;
            }

            string user = ((TextBox)FindName("tbUser")).Text.Trim();
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show(
                    "Введите имя пользователя!",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return null;
            }

            string password = ((PasswordBox)FindName("tbPassword")).Password.Trim();
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Введите пароль!",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return null;
            }

            string planTableName = ((TextBox)FindName("tbPlanTableName")).Text.Trim();
            if (string.IsNullOrEmpty(planTableName))
            {
                MessageBox.Show(
                    "Введите имя таблицы с планами!",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return null;
            }

            string port = ((TextBox)FindName("tbPort")).Text.Trim();
            if (string.IsNullOrEmpty(port))
            {
                MessageBox.Show(
                    "Введите номер порта!",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return null;
            }

            if(!int.TryParse(port, out _))
            {
                MessageBox.Show(
                    "Номер порта не может содержать пробелы и должен быть числом!",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return null;
            }

            return new Connection(host, port, dbName, user, password, planTableName);
        }

        private void Connect(bool createPlanTable)
        {
            var conn = CollectUserInfo();
            if (conn != null)
            {
                string message;
                if (createPlanTable)
                {
                    message = conn.Connect(conn.planTable.Trim().CompareTo("PLAN_TABLE") != 0);
                }
                else
                {
                    message = conn.Connect(false);
                }
                if (conn.IsValid)
                {
                    this.status.Foreground = Brushes.Green;
                    this.Connection = conn;
                }
                else
                {
                    this.status.Foreground = Brushes.Red;
                    this.Connection = null;
                }
                status.Text = message;
            }
        }


        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            Connect(false);
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            Connect(true);
            if(this.Connection != null && this.Connection.IsValid)
            {
                PassConnection?.Invoke(Connection);
                this.Close();
            }

        }
    }
}
