using System.Windows;
using TPDev.MailInterface.Models;
using TPDev.SmsFactory;
using TPDev.SmsInterface.Models;
using MailFactory = TPDev.MailFactory.MailFactory;

namespace TestApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SmsFactory m_smsFactory { get; set; }
        MailFactory m_mailFactory { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;

            #region SMS
            var connectionData = new SmsConnectionData();

            ////WebSMS
            connectionData.User = "";
            connectionData.Password = "";

            m_smsFactory = new SmsFactory(SmsType.WebSMS, connectionData);

            ////SmsApi
            //connectionData.User = "";
            //connectionData.Password = ""; //You can get your MD5 Passwort @SmsApi Account Page

            //m_smsFactory = new SmsFactory(SmsType.SmsApi, connectionData);
            #endregion

            #region EMail
            var mailConnectionData = new ProviderConnectionData();

            ////GMail
            mailConnectionData.DefaultUser = "";
            mailConnectionData.DefaultPassword = "";
            mailConnectionData.DefaultEnableSsl = true;

            m_mailFactory = new MailFactory(MailProviderTypes.GMail, mailConnectionData);

            ////GMX
            //mailConnectionData.DefaultUser = "";
            //mailConnectionData.DefaultPassword = "";
            //mailConnectionData.DefaultEnableSsl = true;

            //m_mailFactory = new MailFactory(MailProviderTypes.GMX, mailConnectionData);

            ////Custom
            //mailConnectionData.DefaultUser = "";
            //mailConnectionData.DefaultPassword = "";
            //mailConnectionData.DefaultEnableSsl = true;

            //m_mailFactory = new MailFactory(MailProviderTypes.Custom, mailConnectionData);
            #endregion
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "This is a test sms from TPDev.MessageFactory!";

            lblMailFrom.Content = "from Account: " + m_mailFactory.Provider.Data.MailFrom;
            txtSubject.Text = "Test Mail";
            txtMailMessage.Text = "This is a test mail from TPDev.MessageFactory!";
        }

        private void OnSendSmsClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNr.Text)) return;
            if (string.IsNullOrEmpty(txtMessage.Text)) return;

            long phoneNum = 0;
            long.TryParse(txtPhoneNr.Text, out phoneNum);

            var result = m_smsFactory.Send.Send(phoneNum, txtMessage.Text, 0, true);
            lblResponse.Content = result ? "Ok" : "Fehler";
        }

        private void OnSendMailClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEMail.Text)) return;
            if (string.IsNullOrEmpty(txtSubject.Text)) return;
            if (string.IsNullOrEmpty(txtMailMessage.Text)) return;

            var result = m_mailFactory.Sender.Send(txtEMail.Text, txtSubject.Text, txtMailMessage.Text);
            lblMailResponse.Content = result ? "Ok" : "Fehler";
        }
    }
}
