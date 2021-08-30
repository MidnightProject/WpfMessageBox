using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfMessageBoxLibrary
{
    public class WpfMessageBoxProperties
    {
        public string ButtonCancelText { get; set; }
        public string ButtonNoText { get; set; }
        public string ButtonOkText { get; set; }
        public string ButtonYesText { get; set; }
        public string ButtonRetryText { get; set; }
        public string ButtonIgnoreText { get; set; }
        public string ButtonAbortText { get; set; }

        public string CheckBoxText { get; set; }
        public bool IsCheckBoxChecked { get; set; }
        public bool IsCheckBoxVisible { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }
        public MessageBoxImage ImageFooter { get; set; }

        public string Details { get; set; }

        public bool IsTextBoxVisible { get; set; }
        public string TextBoxText { get; set; }
        public int TextBoxMaxLength { get; set; }
        public Validation TextValidationRule { get; set; }

        public WpfMessageBoxProperties()
        {
            ButtonCancelText = "Cancel";
            ButtonNoText = "No";
            ButtonOkText = "OK";
            ButtonYesText = "Yes";
            ButtonAbortText = "Abort";
            ButtonIgnoreText = "Ignore";
            ButtonRetryText = "Retry";

            CheckBoxText = String.Empty;
            IsCheckBoxChecked = false;
            IsCheckBoxVisible = false;

            Header = String.Empty;
            
            IsTextBoxVisible = false;
            TextBoxText = String.Empty;
            TextBoxMaxLength = 0;
            TextValidationRule = new Validation();

            Footer = String.Empty;
            ImageFooter = MessageBoxImage.None;

            Details = String.Empty;
        }
    }
}
