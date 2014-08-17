using System.Collections.ObjectModel;
using System.Windows;
using BryanPorter.PasswordManager.Data;
using MahApps.Metro.Controls;

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

            this.Loaded += (sender, args) =>
            {
                var dataContextViewSource =
                    ((System.Windows.Data.CollectionViewSource) (this.FindResource("dataContextViewSource")));
                // Load data by setting the CollectionViewSource.Source property:

                var ctx = new DataContext(null);

                for (int i = 0; i < 100; i++)
                {
                    var g = new Group()
                    {
                        Name = string.Format("Name {0}", i),
                        Description = string.Format("Description {0}", i),
                        Entries = new ObservableCollection<Entry>()
                        {
                            new Entry()
                            {
                                Name = string.Format("Name {0}", i),
                                Key = "Key",
                                Username = "Username",
                                Password = "Password",
                                Type = EntryType.Generic
                            },
                            new Entry()
                            {
                                Name = string.Format("Name {0}", i),
                                Key = "Key",
                                Username = "Username",
                                Password = "Password",
                                Type = EntryType.UsernamePassword
                            },
                            new Entry()
                            {
                                Name = string.Format("Name {0}", i),
                                Key = "Key",
                                Username = "Username",
                                Password = "Password",
                                Type = EntryType.WindowsUsernamePassword
                            }
                        }
                    };

                    ctx.Groups.Add(g);
                }

                dataContextViewSource.Source = ctx.Groups;
            };
        }

        private void Flyout_OnClick(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[0] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}
