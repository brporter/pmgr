using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BryanPorter.PasswordManager.Data;
using MahApps.Metro.Controls.Dialogs;

namespace BryanPorter.PasswordManager.WpfUi.ViewModels
{
    public class MainWindowViewModel
        : DependencyObject
    {
        private readonly IDataContext _dataContext;
        private readonly ISettingsContext _settingContext;

        public static readonly DependencyProperty SelectedGroupProperty = DependencyProperty.Register("SelectedGroup", 
            typeof (Group), 
            typeof (MainWindowViewModel), 
            new UIPropertyMetadata(null));

        public static readonly DependencyProperty SelectedEntryProperty = DependencyProperty.Register("SelectedEntry",
            typeof (Entry),
            typeof (MainWindowViewModel),
            new UIPropertyMetadata(null));

        public static readonly DependencyProperty KeyVisibilityProperty = DependencyProperty.Register("KeyVisibility", 
            typeof (Visibility), 
            typeof (MainWindowViewModel), 
            new PropertyMetadata(default(Visibility)));


        public static readonly DependencyProperty UsernameVisibilityProperty = DependencyProperty.Register("UsernameVisibility", 
            typeof (Visibility), 
            typeof (MainWindowViewModel), 
            new PropertyMetadata(default(Visibility)));


        public static readonly DependencyProperty PasswordVisibilityProperty = DependencyProperty.Register("PasswordVisibility", 
            typeof (Visibility), 
            typeof (MainWindowViewModel), 
            new PropertyMetadata(default(Visibility)));

        public MainWindowViewModel(IDataContext dataContext, ISettingsContext settingsContext)
        {
            _dataContext = dataContext;
            _settingContext = settingsContext;

            for (int i = 0; i < 100; i++)
            {
                var g = new Group()
                {
                    Name = string.Format("Name {0}", i),
                    Description = string.Format("Description {0}", i),
                    Entries = new ObservableCollection<Entry>()
                };

                for (int j = 0; j < 100; j++)
                {
                    g.Entries.Add(
                        new Entry()
                        {
                            Name = string.Format("Name {0}", j),
                            Key = "Key",
                            Username = "Username",
                            Password = "Password",
                            Type = EntryType.UsernamePassword
                        });
                }

                _dataContext.Groups.Add(g);
            }

            GroupModels = new ObservableCollection<Group>(_dataContext.Groups);
            EntryModels = new ObservableCollection<Entry>();

            SelectGroup = new SimpleCommand<Group>()
            {
                ExecuteAction = g =>
                {
                    SelectedGroup = g;

                    EntryModels.Clear();

                    foreach (var entry in g.Entries)
                        EntryModels.Add(entry);
                }
            };

            SelectEntry = new SimpleCommand<Entry>()
            {
                ExecuteAction = e =>
                {
                    SelectedEntry = e;

                    if (e.Type == EntryType.Generic)
                    {
                        KeyVisibility = Visibility.Visible;
                        UsernameVisibility = PasswordVisibility = Visibility.Collapsed;
                    }
                    else
                    {
                        KeyVisibility = Visibility.Collapsed;
                        UsernameVisibility = PasswordVisibility = Visibility.Visible;
                    }
                }
            };
        }

        public Group SelectedGroup
        {
            get { return (Group) GetValue(SelectedGroupProperty); }
            set { SetValue(SelectedGroupProperty, value); }
        }

        public Entry SelectedEntry
        {
            get { return (Entry) GetValue(SelectedEntryProperty); }
            set { SetValue(SelectedEntryProperty, value); }
        }

        public Visibility KeyVisibility
        {
            get { return (Visibility)GetValue(KeyVisibilityProperty); }
            set { SetValue(KeyVisibilityProperty, value); }
        }

        public Visibility UsernameVisibility
        {
            get { return (Visibility)GetValue(UsernameVisibilityProperty); }
            set { SetValue(UsernameVisibilityProperty, value); }
        }

        public Visibility PasswordVisibility
        {
            get { return (Visibility)GetValue(PasswordVisibilityProperty); }
            set { SetValue(PasswordVisibilityProperty, value); }
        }

        public ICommand SelectGroup { get; private set; }
        public ICommand SelectEntry { get; private set; }

        public ObservableCollection<Group> GroupModels { get; private set; }
        public ObservableCollection<Entry> EntryModels { get; private set; }
    }
}
