using LauncherClient.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LauncherClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button DiscordButton;
        public ComboBox VersionSelector;
        public WebBrowser UpdateBoard;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Initializers
        private void OnClickDiscordInit(object sender, EventArgs e) => DiscordButton = (Button)sender;
        private void ComboBoxInit(object sender, EventArgs e) => VersionSelector = (ComboBox)sender;
        private void WebBrowserInit(object sender, EventArgs e) => UpdateBoard = (WebBrowser)sender;
        
        #endregion
        #region OnClickEvents
        private void OnClickDiscord(object sender, RoutedEventArgs e)
        {

        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var viewModel = DataContext as MainViewModel;
                if (viewModel?.SendMessageCommand?.CanExecute(null) == true)
                {
                    viewModel.SendMessageCommand.Execute(null);
                }
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
