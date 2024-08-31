using LauncherClient.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

            var messages = (ObservableCollection<String>)MessagesListView.ItemsSource;
            messages.CollectionChanged += Messages_CollectionChanged;
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
            var textBox = sender as TextBox;

            if(e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Shift)
            {
                var cIndex = textBox.CaretIndex;
                textBox.Text = textBox.Text.Insert(cIndex, Environment.NewLine);
                textBox.CaretIndex = cIndex + Environment.NewLine.Length;
                e.Handled = true; //This prevents the default behaviour.
            }
            else if (e.Key == Key.Enter)
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
        private void MessagesListView_Loaded(object sender, RoutedEventArgs e)
        {
            if (MessagesListView.Items.Count > 0)
            {
                var lastItem = MessagesListView.Items[MessagesListView.Items.Count - 1];
                MessagesListView.ScrollIntoView(lastItem);
            }
        }
        #endregion
        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Scroll to the last item when the collection changes
            if (e.Action == NotifyCollectionChangedAction.Add && MessagesListView.Items.Count > 0)
            {
                var lastItem = MessagesListView.Items[MessagesListView.Items.Count - 1];
                MessagesListView.ScrollIntoView(lastItem);
            }
        }

    }

}
