using System;
using System.Collections.Generic;
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
            _users = new List<UserViewModel>
            {
                new UserViewModel { Name = "Obiwan Kenobi" }
            };

            Add = new Command(execute: () => NameEntry = string.Empty);
        }

        public string NameEntry
        {
            get { return _nameEntry; }
            set { SetProperty(ref _nameEntry, value); }
        }

        public IEnumerable<UserViewModel> Users { get { return _users; } }

        public Command Add { get; private set; }
    }
}
