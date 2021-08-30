using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WpfMessageBoxLibrary
{
    public class MultiValidationRule : ValidationRule
    {
        public MultiValidationRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                string text = (string)value;

                if (Wrapper.Validation.Rule.StringIsEmail)
                {
                    try
                    {
                        new System.Net.Mail.MailAddress((string)value);
                    }
                    catch
                    {
                        return new ValidationResult(false, $"Invalid email address");
                    }
                }
            }

            return ValidationResult.ValidResult;
        }

        public Wrapper Wrapper { get; set; }
    }

    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty ValidationProperty =
             DependencyProperty.Register("Validation", typeof(Validation),
             typeof(Wrapper), new FrameworkPropertyMetadata(new Validation()));

        public Validation Validation
        {
            get { return (Validation)GetValue(ValidationProperty); }
            set { SetValue(ValidationProperty, value); }
        }
    }

    public class Validation
    {
        public Rule Rule { get; set; }

        public List<string> ListContainsText { get; set; }
        public List<string> ListExcludedText { get; set; }

        public Validation()
        {
            Rule = new Rule();

            ListContainsText = new List<string>();
            ListExcludedText = new List<string>();
        }
    }

    public class Rule
    {
        public Boolean StringIsEmail { get; set; }

        public Rule()
        {
            StringIsEmail = false;
        }
    }

    public class BindingProxy : System.Windows.Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));
    }
}
