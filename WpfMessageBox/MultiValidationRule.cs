using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
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

                if (Wrapper.Validation.Rule.StringIsEmpty)
                {
                    if (String.IsNullOrEmpty(text))
                    {
                        return new ValidationResult(false, $"Field is empty");
                    }
                }

                if (Wrapper.Validation.Rule.StringIsWhiteSpace)
                {
                    if (String.IsNullOrWhiteSpace(text))
                    {
                        return new ValidationResult(false, $"Field contains only white space");
                    }
                }

                if (Wrapper.Validation.Rule.StringIsEmail)
                {
                    string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                    var regex = new Regex(pattern, RegexOptions.IgnoreCase);

                    if (regex.IsMatch(text))
                    {

                    }
                    else
                    {
                        return new ValidationResult(false, $"Invalid email address");
                    }
                }

                if (Wrapper.Validation.Rule.StringIsExcluded)
                {
                    foreach(string s in Wrapper.Validation.TextExclusionList)
                    {
                        if (Wrapper.Validation.Rule.IgnoreCase)
                        {
                            if (text.ToUpper() == s.ToUpper())
                            {
                                return new ValidationResult(false, $"The string is excluded");
                            }
                        }
                        else
                        {
                            if (text == s)
                            {
                                return new ValidationResult(false, $"The string is excluded");
                            }
                        }
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

        public List<string> TextExclusionList { get; set; }

        public Validation()
        {
            Rule = new Rule();

            TextExclusionList = null;
        }
    }

    public class Rule
    {
        public Boolean StringIsEmail { get; set; }
        public Boolean StringIsEmpty { get; set; }
        public Boolean StringIsWhiteSpace { get; set; }
        public Boolean StringIsExcluded { get; set; }
        public Boolean IgnoreCase { get; set; }

        public Rule()
        {
            StringIsEmpty = false;
            StringIsWhiteSpace = false;
            StringIsEmail = false;
            StringIsExcluded = false;
            IgnoreCase = true;
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
