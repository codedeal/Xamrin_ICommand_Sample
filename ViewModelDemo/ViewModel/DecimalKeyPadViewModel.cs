using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ViewModelDemo.ViewModel
{
    public class DecimalKeyPadViewModel:INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        //create three command for clear digit backspace

        public ICommand ClearCommand { private set; get; }

        public ICommand BackSpaceCommand { private set; get; }

        public ICommand DigitCommand { private set; get; }

        public DecimalKeyPadViewModel()
        {
            ClearCommand = new Command(ClearScreen);
            DigitCommand = new Command<string>(
                   execute: (string arg) =>
                   {
                       Entry += arg;
                       if (Entry.StartsWith("0") && !Entry.StartsWith("0."))
                       {
                           Entry = Entry.Substring(1);
                       }
                       RefreshCanExecutes();
                   },
                   canExecute: (string arg) =>
                   {
                       return !(arg == "." && Entry.Contains("."));
                   });
            BackSpaceCommand = new Command(
               execute: () =>
               {
                   Entry = Entry.Substring(0, Entry.Length - 1);
                   if (Entry == "")
                   {
                       Entry = "0";
                   }
                   RefreshCanExecutes();
               },
               canExecute: () =>
               {
                   return Entry.Length > 1 || Entry != "0";
               });
        }
        private string entry = "0";

        public   string Entry
        {
            private set
            {
                if (entry != value)
                {
                    entry = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entry"));
                }
            }
            get
            {
                return entry;
            }
        }

        private void ClearScreen()
        {
            Entry = "0";
            RefreshCanExecutes();
        }

        void RefreshCanExecutes()
        {
            ((Command)BackSpaceCommand).ChangeCanExecute();
            ((Command)DigitCommand).ChangeCanExecute();
        }
    }
}
