using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BryanPorter.PasswordManager.WpfUi
{
    public static class ItemSelectedCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command", typeof (ICommand), typeof (ItemSelectedCommand), new PropertyMetadata(null, OnCommandPropertyChanged));

        public static void SetCommand(DependencyObject element, ICommand value)
        {
            element.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject element)
        {
            return (ICommand) element.GetValue(CommandProperty);
        }

        private static void OnCommandPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as ListView;

            if (control != null)
            {
                control.SelectionChanged += (o, args) =>
                {
                    var command = GetCommand(control);

                    if (command != null)
                    {
                        // TODO: add support for multiple selections
                        if (args.AddedItems.Count > 0 && command.CanExecute(args.AddedItems[0]))
                        {
                            command.Execute(args.AddedItems[0]);
                        }
                        else
                        {
                            command.Execute(null);
                        }
                    }
                };
            }
        }
    }
}
