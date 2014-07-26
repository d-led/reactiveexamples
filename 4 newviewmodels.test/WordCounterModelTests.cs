using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfrxexample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;


namespace wpfrxexample.ViewModels.Tests
{
    [TestClass]
    public class WordCounterModelTests
    {
        [TestMethod]
        public void WordCounterModelTest()
        {
            var mock = new Mock<IObservable<string>>();
            var vm = new WordCounterModel(mock.Object);

            vm.WordCount.Should().Be(0);

            vm.TextInput = "bla!";
            vm.WordCount.Should().Be(1);

            vm.TextInput = "bla, bla!!";
            vm.WordCount.Should().Be(2);
        }
    }
}
