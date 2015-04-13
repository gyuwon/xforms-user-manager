using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace UserManager.ViewModels
{
    public class MainViewModel
    {
        private readonly ICollection<UserViewModel> _users;

        public MainViewModel()
        {
            _users = new List<UserViewModel>
            {
                new UserViewModel { Name = "Obiwan Kenobi" }
            };

            Add = new Command(execute: () => Debug.WriteLine(NameEntry));
        }

        public string NameEntry { get; set; }

        public IEnumerable<UserViewModel> Users { get { return _users; } }

        public Command Add { get; private set; }
    }
}
