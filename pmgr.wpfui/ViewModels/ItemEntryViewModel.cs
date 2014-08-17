using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BryanPorter.PasswordManager.Data;

namespace BryanPorter.PasswordManager.WpfUi.ViewModels
{
    public class ItemEntryViewModel
        : DependencyObject
    {
        public static readonly DependencyProperty SelectedGroupProperty = DependencyProperty.Register("SelectedGroup", 
            typeof (Group), 
            typeof (ItemEntryViewModel), 
            new UIPropertyMetadata(null));

        public static readonly DependencyProperty SelectedEntryProperty = DependencyProperty.Register("SelectedEntry",
            typeof (Entry),
            typeof (ItemEntryViewModel),
            new UIPropertyMetadata(null));

        private readonly DataContext _dataContext;

        public ItemEntryViewModel()
        {
            _dataContext = new DataContext(null);

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
                            Type = EntryType.Generic
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
                ExecuteAction = e => SelectedEntry = e
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

        public ICommand SelectGroup { get; private set; }
        public ICommand SelectEntry { get; private set; }
        public ObservableCollection<Group> GroupModels { get; private set; }
        public ObservableCollection<Entry> EntryModels { get; private set; }
    }
}
