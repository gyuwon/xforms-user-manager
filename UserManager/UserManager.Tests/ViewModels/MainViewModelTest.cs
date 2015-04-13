using System;
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
    }
}
