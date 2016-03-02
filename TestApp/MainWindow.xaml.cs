using System.Windows;
using TPDev.SmsFactory;
using TPDev.SmsInterface.Models;

namespace TestApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SmsFactory m_smsFactory { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;

            var connectionData = new SmsConnectionData();

            //WebSMS
            //connectionData.User = "";
            //connectionData.Password = "";

            //m_smsFactory = new SmsFactory(SmsType.WebSMS, connectionData);

            //SmsApi
            connectionData.User = "";
            connectionData.Password = ""; //You can get your MD5 Passwort @SmsApi Account Page

            m_smsFactory = new SmsFactory(SmsType.SmsApi, connectionData);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "This is a test sms from TPDev.MessageFactory!";
        }

        private void OnSendSmsClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNr.Text)) return;
            if (string.IsNullOrEmpty(txtMessage.Text)) return;

            long phoneNum = 0;
            long.TryParse(txtPhoneNr.Text, out phoneNum);

            var result = m_smsFactory.Send.Send(phoneNum, txtMessage.Text, 0, true);
        }
    }
}
