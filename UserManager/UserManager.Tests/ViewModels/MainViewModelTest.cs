using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserManager.ViewModels;

namespace UserManager.Tests.ViewModels
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void NameEntryShouldBeClearedWhenAddCommandExecuted()
        {
            // Arrange
            var viewModel = new MainViewModel();
            viewModel.NameEntry = new Random().Next().ToString();

            // Act
            viewModel.Add.Execute(parameter: null);

            // Assert
            viewModel.NameEntry.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void PropertyChangedForNameEntryShouldBeRaisedWhenNameEntryChanged()
        {
            // Arrange
            var viewModel = new MainViewModel();
            viewModel.NameEntry = new Random().Next().ToString();
            viewModel.MonitorEvents();

            // Act
            viewModel.NameEntry = string.Empty;

            // Assert
            viewModel.ShouldRaisePropertyChangeFor(vm => vm.NameEntry);
        }

        [TestMethod]
        public void UserShouldBeAddedToUsersWhenAddCommandExecuted()
        {
            // Arrange
            var viewModel = new MainViewModel();
            var userName = new Random().Next().ToString();
            viewModel.NameEntry = userName;
            var userCountBeforeExecution = viewModel.Users.Count;

            // Act
            viewModel.Add.Execute(parameter: null);

            // Assert
            viewModel.Users.Count.Should().Be(userCountBeforeExecution + 1);
            viewModel.Users.Last().Name.Should().Be(userName);
        }
    }
}
