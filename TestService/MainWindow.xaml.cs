using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace TestService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            User user = new User()
            {
                Login = TextBoxLogin.Text,
                Pass = TextBoxPass.Text,
                Exists = false
            };
            string request = JsonConvert.SerializeObject(user);
            string response = client.GetData(request);
            user = JsonConvert.DeserializeObject<User>(response);
            if (user.Exists)
                TextBlockResult.Text = $"Добро пожаловать, {user.Login}!";
            else
                TextBlockResult.Text = "Пользователь не найден :(";
        }
    }
}
