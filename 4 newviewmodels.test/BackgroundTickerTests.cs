using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfrxexample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Reactive.Testing;
using ReactiveUI.Testing;
using FluentAssertions;

namespace wpfrxexample.ViewModels.Tests
{
    [TestClass]
    public class BackgroundTickerTests
    {
        [TestMethod]
        public void BackgroundTickerTest()
        {
            (new TestScheduler()).With(scheduler =>
            {
                var ticker = new BackgroundTicker(scheduler);

                int count = 0;
                ticker.Ticker.Subscribe(_ => count++);
                count.Should().Be(0);

                scheduler.AdvanceByMs(1000);
                count.Should().Be(1);

                scheduler.AdvanceByMs(2000);
                count.Should().Be(3);
            });
        }
    }
}
