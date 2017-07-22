using System;
using System.Linq;
using System.Collections.Generic;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using NeuOldDriver.Global;

namespace NeuOldDriver.Controls {

    public sealed partial class Login : UserControl {
        /// <summary>
        /// Fired when click on "确认" button
        /// </summary>
        public event EventHandler Submit;

        /// <summary>
        /// Fired when click on captcha image
        /// </summary>
        public event EventHandler Refresh;

        /// <summary>
        /// Username from user's input
        /// </summary>
        public string UserName {
            get { return username.Text; }
        }

        /// <summary>
        /// Password from user's input
        /// </summary>
        public string Password {
            get { return password.Password; }
        }

        /// <summary>
        /// Save password when true
        /// </summary>
        public bool RememberMe {
            get { return remember.IsChecked ?? false; }
        }

        /// <summary>
        /// Captcha string from user's input. Use only when <c>CaptchaRequired</c> is true.
        /// </summary>
        public string Captcha {
            get { return captchaText.Text; }
        }

        private ICollection<string> names;

        public Login() {
            this.InitializeComponent();
            this.Loaded += (sender, e) => {
                string username, password;
                Globals.Settings.ActiveUser(UsedFor, out username, out password);
                names = Globals.Settings.Users(UsedFor);
                this.username.Text = username ?? "";
                this.username.ItemsSource = names;
                this.password.Password = password ?? "";
            };
            
            okButton.Click += (sender, args) => {
                Submit?.Invoke(this, new EventArgs());
            };

            captchaContainer.Click += (sender, e) => {
                Refresh?.Invoke(this, new EventArgs());
            };

            username.TextChanged += (sender, e) => {
                if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput) {
                    sender.ItemsSource = names.Where((item) => {
                        return item.StartsWith(sender.Text);
                    });
                    remember.IsChecked = false;
                }
            };

            username.SuggestionChosen += (sender, e) => {
                var item = e.SelectedItem as string;
                password.Password = Globals.Settings.GetPassword(UsedFor, item);
                remember.IsChecked = true;
            };
        }

        /// <summary>
        /// true if login requires captcha verification
        /// </summary>
        public bool CaptchaRequired {
            get {
                return (bool)GetValue(CaptchaRequiredProperty);
            }
            set {
                SetValue(CaptchaRequiredProperty, value);
            }
        }

        public static readonly DependencyProperty CaptchaRequiredProperty =
            DependencyProperty.RegisterAttached(nameof(CaptchaRequired), typeof(bool), typeof(Login), new PropertyMetadata(false));
        
        /// <summary>
        /// Source of captcha image
        /// </summary>
        public string ImageSource {
            get {
                return (string)GetValue(ImageSourceProperty);
            }
            set {
                SetValue(ImageSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.RegisterAttached(nameof(ImageSource), typeof(string), typeof(Login), new PropertyMetadata(" "));

        /// <summary>
        /// Identifying this login control is used for which page
        /// </summary>
        public string UsedFor {
            get {
                return (string)GetValue(UsedForProperty);
            }
            set {
                SetValue(UsedForProperty, value);
            }
        }

        public static readonly DependencyProperty UsedForProperty =
            DependencyProperty.RegisterAttached(nameof(UsedFor), typeof(string), typeof(Login), null);
    }
}
