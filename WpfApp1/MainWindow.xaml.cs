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
using WpfApp1.model;

namespace WpfApp1
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

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Письмо отправлено");
            string message = "";
            bool resultSend =
                SendMail.SendMaiL(tbxTo.Text,
                                  tbxCopy.Text,
                                  tbxSubj.Text,
                                  tbxMessageBody.Text,
                                  out message);
            lblMessage.Content = message;
            if (resultSend)
            {
                lblMessage.Foreground =
                    new SolidColorBrush(Colors.Green);
            }
            else
                lblMessage.Foreground = new SolidColorBrush(Colors.Red);
        }
    }
}
