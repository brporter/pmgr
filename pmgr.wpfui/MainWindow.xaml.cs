using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using BryanPorter.PasswordManager.Data;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace BryanPorter.PasswordManager.WpfUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransitioningControl.ReloadTransition();
        }

        private void EntryItem_Click(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[0] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
        }

        private async void displaySettingsDialog(object sender, RoutedEventArgs e)
        {
            var dialog = (BaseMetroDialog) this.Resources["SettingsDialog"];
            await this.ShowMetroDialogAsync(dialog);
        }

        private async void closeSettingsDialog(object sender, RoutedEventArgs e)
        {
            var dialog = (BaseMetroDialog) this.Resources["SettingsDialog"];
            await this.HideMetroDialogAsync(dialog);
        }
    }
}
