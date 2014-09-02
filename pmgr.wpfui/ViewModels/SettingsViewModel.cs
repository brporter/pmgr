using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BryanPorter.PasswordManager.Data;

namespace BryanPorter.PasswordManager.WpfUi.ViewModels
{
    public class SettingsViewModel
        : DependencyObject
    {
        private readonly ISettingsContext _settingsContext;

        public static readonly DependencyProperty SettingsProperty = DependencyProperty.Register(
            "Settings", typeof (Settings), typeof (SettingsViewModel), new PropertyMetadata(default(Settings)));

        public static readonly DependencyProperty IsUsingIsolatedStorageProperty = DependencyProperty.Register(
            "IsUsingIsolatedStorage", typeof(bool), typeof(SettingsViewModel), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty IsNotUsingIsolatedStorageProperty = DependencyProperty.Register(
            "IsNotUsingIsolatedStorage", typeof(bool), typeof(SettingsViewModel), new PropertyMetadata(default(bool)));

        public bool IsNotUsingIsolatedStorage
        {
            get { return (bool) GetValue(IsNotUsingIsolatedStorageProperty); }
            set { SetValue(IsNotUsingIsolatedStorageProperty, value); }
        }

        public bool IsUsingIsolatedStorage
        {
            get { return (bool) GetValue(IsUsingIsolatedStorageProperty); }
            set
            {
                SetValue(IsUsingIsolatedStorageProperty, value);
            }
        }

        public Settings Settings
        {
            get { return (Settings) GetValue(SettingsProperty); }
            set { SetValue(SettingsProperty, value); }
        }

        public SettingsViewModel(ISettingsContext settingsContext)
        {
            _settingsContext = settingsContext;

            Settings = _settingsContext.Settings;
            IsUsingIsolatedStorage = string.IsNullOrWhiteSpace(_settingsContext.Settings.FilePath);

            OkCommand = new SimpleCommand<Settings>()
            {
                ExecuteAction = settings =>
                {
                    if (IsUsingIsolatedStorage)
                        _settingsContext.Settings.FilePath = string.Empty;

                    _settingsContext.Commit();
                }
            };

            CancelCommand = new SimpleCommand<Settings>()
            {
                ExecuteAction = settings => _settingsContext.Initialize()
            };
        }

        public ICommand IsolatedStorageCheckChangeCommand { get; private set; }
        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
    }
}
