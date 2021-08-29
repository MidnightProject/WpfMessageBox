using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows;
using WpfMessageBoxLibrary;

namespace Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            CultureInfo culture = CultureInfo.CreateSpecificCulture("pl-PL");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ResourceManager rm = new ResourceManager("Demo.WpfMessageBoxLanguage", Assembly.GetExecutingAssembly());
            //var resVal = test.ResourceManager.GetString("String1");

            //WpfMessageBox messageBox = new WpfMessageBox(WpfMessageBoxButton.OKCancel);
            //WpfMessageBox messageBox = new WpfMessageBox("Error", "", WpfMessageBoxButton.OKCancel, MessageBoxImage.Error, rm);
            WpfMessageBox messageBox = new WpfMessageBox("Error", "", WpfMessageBoxButton.OKCancel, MessageBoxImage.Error, new WpfMessageBoxProperties() {
                Details = "test details",
                IsTextBoxVisible = true,
                TextBoxMaxLength = 0,
            });
            messageBox.ShowDialog();

            //messageBox = new WpfMessageBox("message", WpfMessageBoxButton.OK);
            //messageBox.ShowDialog();
            //WpfMessageBoxResult result = messageBox.Result;

            this.Close();
        }
    }
}
