using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practical_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mlogin = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            int a = 1;

            if (mlogin.Length < 5)
            {
                textBoxLogin.ToolTip = "Це поле введено невірно!";
                textBoxLogin.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
            }

            if (pass.Length < 5)
            {
                passBox.ToolTip = "Це поле введено невірно!";
                passBox.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
            }

            if (pass != pass_2)
            {
                passBox2.ToolTip = "Паролі не співпадають!";
                passBox2.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Це поле введено невірно!";
                textBoxEmail.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
            }

            if (a == 1)
                MessageBox.Show("Все добре!");
        }
    }
}
