using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System;
using System.Resources;
using System.Runtime.InteropServices;

namespace WpfMessageBoxLibrary
{
    public partial class WpfMessageBox : Window
    {
        private const string defaultCancelButtonText = "Cancel";
        public string ButtonCancelText
        {
            get { return buttonCancel.Content.ToString(); }
            set { buttonCancel.Content = value; }
        }

        private const string defaultOkButtonText = "OK";
        public string ButtonOkText
        {
            get { return buttonOk.Content.ToString(); }
            set { buttonOk.Content = value; }
        }

        private const string defaultYesButtonText = "Yes";
        public string ButtonYesText
        {
            get { return buttonYes.Content.ToString(); }
            set { buttonYes.Content = value; }
        }

        private const string defaultNoButtonText = "No";
        public string ButtonNoText
        {
            get { return buttonNo.Content.ToString(); }
            set { buttonNo.Content = value; }
        }

        private const string defaultRetryButtonText = "Retry";
        public string ButtonRetryText
        {
            get { return buttonRetry.Content.ToString(); }
            set { buttonRetry.Content = value; }
        }

        private const string defaultIgnoreButtonText = "Ignore";
        public string ButtonIgnoreText
        {
            get { return buttonIgnore.Content.ToString(); }
            set { buttonIgnore.Content = value; }
        }

        private const string defaultAbortButtonText = "Abort";
        public string ButtonAbortText
        {
            get { return buttonAbort.Content.ToString(); }
            set { buttonAbort.Content = value; }
        }

        public string TextBoxText
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public bool IsTextBoxVisible
        {
            get { return textBox.Visibility == Visibility.Visible; }
            set { textBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string CheckBoxText
        {
            get { return checkBox.Content.ToString(); }
            set { checkBox.Content = value; }
        }

        public bool IsCheckBoxChecked
        {
            get { return checkBox.IsChecked ?? false; }
            set { checkBox.IsChecked = value; }
        }

        public bool IsCheckBoxVisible
        {
            get { return checkBox.Visibility == Visibility.Visible; }
            set { checkBox.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string Message
        {
            get
            {
                return textBlockMessage.Text;
            }
            set
            {
                textBlockMessage.Text = value;

                if (String.IsNullOrWhiteSpace(Message))
                {
                    IsMessageVisible = false;
                }
                else
                {
                    IsMessageVisible = true;
                }
            }
        }

        public bool IsMessageVisible
        {
            get { return textBlockMessage.Visibility == Visibility.Visible; }
            set { textBlockMessage.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string Header
        {
            get
            {
                return textBlockHeader.Text;
            }
            set
            {
                textBlockHeader.Text = value;

                if (String.IsNullOrWhiteSpace(Header))
                {
                    IsHeaderVisible = false;
                }
                else
                {
                    IsHeaderVisible = true;
                }
            }
        }

        public bool IsHeaderVisible
        {
            get { return textBlockHeader.Visibility == Visibility.Visible; }
            set { textBlockHeader.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string Details
        {
            get
            {
                return textBlockDetails.Text;
            }
            set
            {
                textBlockDetails.Text = value;

                if (String.IsNullOrWhiteSpace(Details))
                {
                    IsDetailsVisible = false;
                }
                else
                {
                    IsDetailsVisible = true;
                }
            }
        }

        public bool IsDetailsVisible
        {
            get { return details.Visibility == Visibility.Visible; }
            set { details.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public string Footer
        {
            get
            {
                return textBlockFooter.Text;
            }
            set
            {
                textBlockFooter.Text = value;

                if (String.IsNullOrWhiteSpace(Footer))
                {
                    IsFooterVisible = false;
                }
                else
                {
                    IsFooterVisible = true;
                }
            }
        }

        public bool IsFooterVisible
        {
            get { return footer.Visibility == Visibility.Visible; }
            set
            {
                footer.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }


        public WpfMessageBox(String message, WpfMessageBoxButton button)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayButtons(button);

            Message = message;
        }

        public WpfMessageBox(String message, WpfMessageBoxButton button, MessageBoxImage imageMain)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayButtons(button);

            DisplayImage(imageMain);

            Message = message;
        }

        public WpfMessageBox(String message, MessageBoxButton button, MessageBoxImage imageMain)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayButtons((WpfMessageBoxButton)button);

            DisplayImage(imageMain);

            Message = message;
        }

        public WpfMessageBox(String title, String message, WpfMessageBoxButton button, MessageBoxImage imageMain)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayButtons(button);

            Title = title;
            Message = message;
        }

        public WpfMessageBox(String title, String message, MessageBoxButton button, MessageBoxImage imageMain)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayButtons((WpfMessageBoxButton)button);

            DisplayImage(imageMain);

            Title = title;
            Message = message;
        }

        public WpfMessageBox(String title, String message, WpfMessageBoxButton button, MessageBoxImage imageMain, WpfMessageBoxProperties properties)
        {
            InitializeComponent();

            CheckBoxText = properties.CheckBoxText;
            IsCheckBoxChecked = properties.IsCheckBoxChecked;
            IsCheckBoxVisible = properties.IsCheckBoxVisible;

            Header = properties.Header;

            IsTextBoxVisible = properties.IsTextBoxVisible;
            TextBoxText = properties.TextBoxText;

            Footer = properties.Footer;
            DisplayImageFooter(properties.ImageFooter);

            Details = properties.Details;

            DisplayImage(imageMain);

            ButtonAbortText = properties.ButtonAbortText;
            ButtonCancelText = properties.ButtonCancelText;
            ButtonIgnoreText = properties.ButtonIgnoreText;
            ButtonNoText = properties.ButtonNoText;
            ButtonYesText = properties.ButtonYesText;
            ButtonOkText = properties.ButtonOkText;
            ButtonRetryText = properties.ButtonRetryText;
            ButtonYesText = properties.ButtonYesText;
            DisplayButtons(button);

            Title = title;
            Message = message;
        }

        public WpfMessageBox(String title, String message, MessageBoxButton button, MessageBoxImage imageMain, WpfMessageBoxProperties properties)
        {
            InitializeComponent();

            CheckBoxText = properties.CheckBoxText;
            IsCheckBoxChecked = properties.IsCheckBoxChecked;
            IsCheckBoxVisible = properties.IsCheckBoxVisible;

            Header = properties.Header;

            IsTextBoxVisible = properties.IsTextBoxVisible;
            TextBoxText = properties.TextBoxText;

            Footer = properties.Footer;
            DisplayImageFooter(properties.ImageFooter);

            Details = properties.Details;

            DisplayImage(imageMain);

            ButtonAbortText = properties.ButtonAbortText;
            ButtonCancelText = properties.ButtonCancelText;
            ButtonIgnoreText = properties.ButtonIgnoreText;
            ButtonNoText = properties.ButtonNoText;
            ButtonYesText = properties.ButtonYesText;
            ButtonOkText = properties.ButtonOkText;
            ButtonRetryText = properties.ButtonRetryText;
            ButtonYesText = properties.ButtonYesText;
            DisplayButtons((WpfMessageBoxButton)button);

            Title = title;
            Message = message;
        }

        public WpfMessageBox(String message, WpfMessageBoxButton button, MessageBoxImage imageMain, ResourceManager buttonText)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayImage(imageMain);

            SetButtonText(buttonText);
            DisplayButtons(button);

            Message = message;
        }

        public WpfMessageBox(String message, MessageBoxButton button, MessageBoxImage imageMain, ResourceManager buttonText)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayImage(imageMain);

            SetButtonText(buttonText);
            DisplayButtons((WpfMessageBoxButton)button);

            Message = message;
        }

        public WpfMessageBox(String title, String message, WpfMessageBoxButton button, MessageBoxImage imageMain, ResourceManager buttonText)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayImage(imageMain);

            SetButtonText(buttonText);
            DisplayButtons(button);

            Title = title;
            Message = message;
        }

        public WpfMessageBox(String title, String message, MessageBoxButton button, MessageBoxImage imageMain, ResourceManager buttonText)
        {
            InitializeComponent();
            DefaultSettings();

            DisplayImage(imageMain);

            SetButtonText(buttonText);
            DisplayButtons((WpfMessageBoxButton)button);

            Title = title;
            Message = message;
        }

        public WpfMessageBox(String title, String message, WpfMessageBoxButton button, MessageBoxImage imageMain, ResourceManager buttonText, WpfMessageBoxProperties properties)
        {
            InitializeComponent();

            CheckBoxText = properties.CheckBoxText;
            IsCheckBoxChecked = properties.IsCheckBoxChecked;
            IsCheckBoxVisible = properties.IsCheckBoxVisible;

            Header = properties.Header;

            IsTextBoxVisible = properties.IsTextBoxVisible;
            TextBoxText = properties.TextBoxText;

            Footer = properties.Footer;
            DisplayImageFooter(properties.ImageFooter);

            Details = properties.Details;

            DisplayImage(imageMain);

            SetButtonText(buttonText);
            DisplayButtons(button);

            Title = title;
            Message = message;
        }

        public WpfMessageBox(String title, String message, MessageBoxButton button, MessageBoxImage imageMain, ResourceManager buttonText, WpfMessageBoxProperties properties)
        {
            InitializeComponent();

            CheckBoxText = properties.CheckBoxText;
            IsCheckBoxChecked = properties.IsCheckBoxChecked;
            IsCheckBoxVisible = properties.IsCheckBoxVisible;

            Header = properties.Header;

            IsTextBoxVisible = properties.IsTextBoxVisible;
            TextBoxText = properties.TextBoxText;

            Footer = properties.Footer;
            DisplayImageFooter(properties.ImageFooter);

            Details = properties.Details;

            DisplayImage(imageMain);

            SetButtonText(buttonText);
            DisplayButtons((WpfMessageBoxButton)button);

            Title = title;
            Message = message;
        }

        private void DefaultSettings()
        {
            IsTextBoxVisible = false;
            TextBoxText = String.Empty;

            IsCheckBoxChecked = false;
            IsCheckBoxVisible = false;

            Title = String.Empty;
            Header = String.Empty;
            Details = String.Empty;
            Footer = String.Empty;
        }

        private void DisplayImageFooter(MessageBoxImage image)
        {
            switch (image)
            {
                case MessageBoxImage.Information:
                    imageFooter.Source = SystemIcons.Information.ToImageSource();
                    break;
                case MessageBoxImage.Error:
                    imageFooter.Source = SystemIcons.Error.ToImageSource();
                    break;
                case MessageBoxImage.Warning:
                    imageFooter.Source = SystemIcons.Warning.ToImageSource();
                    break;
                case MessageBoxImage.Question:
                    imageFooter.Source = SystemIcons.Question.ToImageSource();
                    break;
                default:
                    imageFooter.Source = null;
                    break;
            }
        }

        private void DisplayImage(MessageBoxImage image)
        {
            switch (image)
            {
                case MessageBoxImage.Information:
                    imageIcon.Source = SystemIcons.Information.ToImageSource();
                    break;
                case MessageBoxImage.Error:
                    imageIcon.Source = SystemIcons.Error.ToImageSource();
                    break;
                case MessageBoxImage.Warning:
                    imageIcon.Source = SystemIcons.Warning.ToImageSource();
                    break;
                case MessageBoxImage.Question:
                    imageIcon.Source = SystemIcons.Question.ToImageSource();
                    break;
                default:
                    imageIcon.Source = null;
                    break;
            }

            imageIcon.Visibility = imageIcon.Source == null ? Visibility.Collapsed : Visibility.Visible;
        }

        private void DisplayButtons(WpfMessageBoxButton button)
        {
            switch (button)
            {
                case WpfMessageBoxButton.OK:
                    buttonCancel.Visibility = Visibility.Collapsed;
                    buttonNo.Visibility = Visibility.Collapsed;
                    buttonOk.Visibility = Visibility.Visible;
                    buttonYes.Visibility = Visibility.Collapsed;
                    buttonAbort.Visibility = Visibility.Collapsed;
                    buttonRetry.Visibility = Visibility.Collapsed;
                    buttonIgnore.Visibility = Visibility.Collapsed;
                    break;
                case WpfMessageBoxButton.OKCancel:
                    buttonCancel.Visibility = Visibility.Visible;
                    buttonNo.Visibility = Visibility.Collapsed;
                    buttonOk.Visibility = Visibility.Visible;
                    buttonYes.Visibility = Visibility.Collapsed;
                    buttonAbort.Visibility = Visibility.Collapsed;
                    buttonRetry.Visibility = Visibility.Collapsed;
                    buttonIgnore.Visibility = Visibility.Collapsed;
                    break;
                case WpfMessageBoxButton.YesNo:
                    buttonCancel.Visibility = Visibility.Collapsed;
                    buttonNo.Visibility = Visibility.Visible;
                    buttonOk.Visibility = Visibility.Collapsed;
                    buttonYes.Visibility = Visibility.Visible;
                    buttonAbort.Visibility = Visibility.Collapsed;
                    buttonRetry.Visibility = Visibility.Collapsed;
                    buttonIgnore.Visibility = Visibility.Collapsed;
                    break;
                case WpfMessageBoxButton.YesNoCancel:
                    buttonCancel.Visibility = Visibility.Visible;
                    buttonNo.Visibility = Visibility.Visible;
                    buttonOk.Visibility = Visibility.Collapsed;
                    buttonYes.Visibility = Visibility.Visible;
                    buttonAbort.Visibility = Visibility.Collapsed;
                    buttonRetry.Visibility = Visibility.Collapsed;
                    buttonIgnore.Visibility = Visibility.Collapsed;
                    break;
                case WpfMessageBoxButton.RetryCancel:
                    buttonCancel.Visibility = Visibility.Visible;
                    buttonNo.Visibility = Visibility.Collapsed;
                    buttonOk.Visibility = Visibility.Collapsed;
                    buttonYes.Visibility = Visibility.Collapsed;
                    buttonAbort.Visibility = Visibility.Collapsed;
                    buttonRetry.Visibility = Visibility.Visible;
                    buttonIgnore.Visibility = Visibility.Collapsed;
                    break;
                case WpfMessageBoxButton.AbortRetryIgnore:
                    buttonCancel.Visibility = Visibility.Collapsed;
                    buttonNo.Visibility = Visibility.Collapsed;
                    buttonOk.Visibility = Visibility.Collapsed;
                    buttonYes.Visibility = Visibility.Collapsed;
                    buttonAbort.Visibility = Visibility.Visible;
                    buttonRetry.Visibility = Visibility.Visible;
                    buttonIgnore.Visibility = Visibility.Visible;
                    break;
                default:
                    buttonCancel.Visibility = Visibility.Collapsed;
                    buttonNo.Visibility = Visibility.Collapsed;
                    buttonOk.Visibility = Visibility.Collapsed;
                    buttonYes.Visibility = Visibility.Collapsed;
                    buttonAbort.Visibility = Visibility.Collapsed;
                    buttonRetry.Visibility = Visibility.Collapsed;
                    buttonIgnore.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void SetButtonText(ResourceManager buttonText)
        {
            string content = String.Empty;

            content = buttonText.GetString("ButtonOk");
            if (String.IsNullOrEmpty(content))
            {
                ButtonOkText = defaultOkButtonText;
            }
            else
            {
                ButtonOkText = content;
            }

            content = buttonText.GetString("ButtonCancel");
            if (String.IsNullOrEmpty(content))
            {
                ButtonCancelText = defaultCancelButtonText;
            }
            else
            {
                ButtonCancelText = content;
            }

            content = buttonText.GetString("ButtonYes");
            if (String.IsNullOrEmpty(content))
            {
                ButtonYesText = defaultYesButtonText;
            }
            else
            {
                ButtonYesText = content;
            }

            content = buttonText.GetString("ButtonAbort");
            if (String.IsNullOrEmpty(content))
            {
                ButtonAbortText = defaultAbortButtonText;
            }
            else
            {
                ButtonAbortText = content;
            }

            content = buttonText.GetString("ButtonIgnore");
            if (String.IsNullOrEmpty(content))
            {
                ButtonIgnoreText = defaultIgnoreButtonText;
            }
            else
            {
                ButtonIgnoreText = content;
            }

            content = buttonText.GetString("ButtonNo");
            if (String.IsNullOrEmpty(content))
            {
                ButtonNoText = defaultNoButtonText;
            }
            else
            {
                ButtonNoText = content;
            }

            content = buttonText.GetString("ButtonRetry");
            if (String.IsNullOrEmpty(content))
            {
                ButtonRetryText = defaultRetryButtonText;
            }
            else
            {
                ButtonRetryText = content;
            }
        }

        public WpfMessageBoxResult Result { get; set; }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.Cancel;
            Close();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.No;
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.OK;
            Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.Yes;
            Close();
        }

        private void ButtonIgnore_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.Ignore;
            Close();
        }

        private void ButtonRetry_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.Retry;
            Close();
        }

        private void ButtonAbort_Click(object sender, RoutedEventArgs e)
        {
            Result = WpfMessageBoxResult.Abord;
            Close();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            this.RemoveIconAndCloseButtons();
            base.OnSourceInitialized(e);
        }

        private void Details_Expanded(object sender, RoutedEventArgs e)
        {
            details.Header = "Hide details";
        }

        private void Details_Collapsed(object sender, RoutedEventArgs e)
        {
            details.Header = "See details";
        }
    }

    internal static class Extensions
    {
        public static ImageSource ToImageSource(this Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return imageSource;
        }
    }

    internal static class WindowHelper
    {
        private const int GWL_STYLE = -16;
        private const uint WS_SYSMENU = 0x80000;

        public static void RemoveIconAndCloseButtons(this Window window)
        {
            // Get window's handle
            IntPtr hwnd = new WindowInteropHelper(window).Handle;

            // Change the extended window style to not show a window icon and close button
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & (0xFFFFFFFF ^ WS_SYSMENU)); ;
        }

        [DllImport("user32.dll")]
        private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    }
}
