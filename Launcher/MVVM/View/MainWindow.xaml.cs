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

namespace Launcher
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
        #endregion
    }
}
