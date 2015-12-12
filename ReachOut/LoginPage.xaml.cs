using Parse;
using ReachOut.DataModel;
using ReachOut.Managers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace ReachOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page, IManageable
    {
        private string _email;
        private string _password;

        public string Email
        {
            get
            { return _email; }
            set
            {
                if (value != null)
                    _email = value.ToLower().Trim();
                UpdateLoginButtonState();
            }
        }
        public string Password
        {
            get
            { return _password; }
            set
            {
                if (value != null)
                    _password = value;
                UpdateLoginButtonState();
            }
        }

        public LoginPage()
        {
            this.InitializeComponent();

            SetState(true);
            this.DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PageManager.RegisterPage(this);
        }

        private void UpdateLoginButtonState()
        {
            loginButton.IsEnabled =
                Password != null && Email != null 
                && Password.Length * Email.Length != 0;
        }

        private void SetState(bool isIdle)
        {
            emailBox.IsEnabled = isIdle;
            passwordBox.IsEnabled = isIdle;
            
            if (isIdle)
            {
                progressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                statusBlock.Text = "Login to get started";
                UpdateLoginButtonState();
            }
            else
            {
                progressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                statusBlock.Text = "Logging in";
                loginButton.IsEnabled = false;
            }
        }

        public Dictionary<string, object> SaveState()
        {
            return null;
        }
        public void LoadState(Dictionary<string, object> lastState)
        { }


        private void TextBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
        }

        public bool AllowAppExit()
        {
            return true;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            SetState(false);
            var query = new ParseQuery<User>().Where((User u) => u.email == Email && u.password == Password);
            try
            {
                var user = await query.FirstAsync();
                PageManager.NavigateTo(typeof(FeedPage), null, NavigationType.Default);
            }
            catch
            {
                new MessageDialog("Incorrect password or email combination.", "Invalid Credentials").ShowAsync();
                SetState(true);
            }
        }

    }


}
