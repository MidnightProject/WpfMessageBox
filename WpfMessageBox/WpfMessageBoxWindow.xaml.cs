using System.Windows;

namespace WpfMessageBoxLibrary
{
    public partial class WpfMessageBoxWindow : Window
    {
        public WpfMessageBoxWindow()
        {
            InitializeComponent();
        }

        public MessageBoxResult Result { get; set; }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            Close();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            Close();
        }
    }
}
