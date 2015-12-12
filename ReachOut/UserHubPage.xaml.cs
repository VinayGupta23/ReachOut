using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System.Text;
using System.Linq;
using ReachOut.Managers;
using ReachOut.UIControls;

namespace ReachOut
{

    public sealed partial class UserHubPage : Page, IManageable, INotifyPropertyChanged
    {

        private StatusBar _statusBar;
        private MenuControl _menu;
        private bool _isMenuOpen;
        private bool _isIdle;
        private bool _isContentAvailable;
        private bool _isCached = false;

        public bool IsIdle
        {
            get { return _isIdle; }
            private set
            {
                _isIdle = value;
                NotifyPropertyChanged();
            }
        }
        private bool IsMenuOpen
        {
            get { return _isMenuOpen; }
            set
            {
                _isMenuOpen = value;
                NotifyPropertyChanged("TitleText");
            }
        }
        public bool IsContentAvailable
        {
            get { return _isContentAvailable; }
            set
            {
                _isContentAvailable = value;
                NotifyPropertyChanged();
            }
        }

        public UserHubPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            _menu = new MenuControl();

            _statusBar = StatusBar.GetForCurrentView();
            _statusBar.BackgroundColor = (Application.Current.Resources["AlternateDarkBrush"] as SolidColorBrush).Color;
            _statusBar.ForegroundColor = Colors.LightGray;
            _statusBar.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PageManager.RegisterPage(this);
        }

        public Dictionary<string, object> SaveState()
        {
            return null;
        }

        public void LoadState(Dictionary<string, object> lastState)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Navigation and ActionRequest Handlers

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsMenuOpen)
                menuPresenter.Content = null;
            else
                menuPresenter.Content = _menu;
            IsMenuOpen = !IsMenuOpen;
        }

        #endregion


        public bool AllowAppExit()
        {
            return true;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
