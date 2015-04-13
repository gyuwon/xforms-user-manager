using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private string _nameEntry;
        private readonly ICollection<UserViewModel> _users;

        public MainViewModel()
        {
            _users = new ObservableCollection<UserViewModel>
            {
                new UserViewModel { Name = "Obiwan Kenobi" }
            };

            Add = new Command(
                canExecute: () => string.IsNullOrEmpty(_nameEntry) == false,
                   execute: () =>
                   {
                       _users.Add(new UserViewModel { Name = _nameEntry });
                       NameEntry = string.Empty;
                   });
        }

        public string NameEntry
        {
            get { return _nameEntry; }
            set
            {
                if (true == SetProperty(ref _nameEntry, value))
                {
                    Add.ChangeCanExecute();
                }
            }
        }

        public ICollection<UserViewModel> Users { get { return _users; } }

        public Command Add { get; private set; }
    }
}
