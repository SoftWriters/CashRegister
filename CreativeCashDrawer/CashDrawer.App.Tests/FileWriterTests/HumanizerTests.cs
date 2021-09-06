using CashDrawer.App.FileWriters;
using CashDrawer.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashDrawer.App.Tests.FileWriterTests
{
    [TestClass]
    public class HumanizerTests
    {

        [TestMethod]
        public void humanizer_converts_change_to_friendly_string()
        {

            var change = new Change(5, 4, 3, 2, 1);
            var humanizer = new Humanizer();
            var text = humanizer.Humanize(change);

            Assert.AreEqual("5 dollars, 4 quarters, 3 dimes, 2 nickles, 1 penny", text);
        }



        [TestMethod]
        public void humanizer_converts_uses_singular_nouns_when_change_values_are_1()
        {

            var change = new Change(1, 1, 1, 1, 1);
            var humanizer = new Humanizer();
            var text = humanizer.Humanize(change);

            Assert.AreEqual("1 dollar, 1 quarter, 1 dime, 1 nickle, 1 penny", text);
        }



        [TestMethod]
        public void humanizer_converts_uses_plural_nouns_when_change_values_are_greater_than_0()
        {

            var change = new Change(2, 2, 2, 2, 2);
            var humanizer = new Humanizer();
            var text = humanizer.Humanize(change);

            Assert.AreEqual("2 dollars, 2 quarters, 2 dimes, 2 nickles, 2 pennies", text);
        }



        [TestMethod]
        [DataRow(0, 1, 1, 1, 1, "1 quarter, 1 dime, 1 nickle, 1 penny")]
        [DataRow(1, 0, 1, 1, 1, "1 dollar, 1 dime, 1 nickle, 1 penny")]
        [DataRow(1, 1, 0, 1, 1, "1 dollar, 1 quarter, 1 nickle, 1 penny")]
        [DataRow(1, 1, 1, 0, 1, "1 dollar, 1 quarter, 1 dime, 1 penny")]
        [DataRow(1, 1, 1, 1, 0, "1 dollar, 1 quarter, 1 dime, 1 nickle")]
        public void humanizer_does_not_display_change_amount_if_value_is_zero(int dollars,
                                                                              int quarters,
                                                                              int dimes,
                                                                              int nickles,
                                                                              int pennies,
                                                                              string expectedText)
        {
            var change = new Change(dollars, quarters, dimes, nickles, pennies);
            var humanizer = new Humanizer();
            var text = humanizer.Humanize(change);

            Assert.AreEqual(expectedText, text);
        }



        [TestMethod]
        public void humanizer_returns_message_if_no_change_due()
        {

            var change = new Change(0, 0, 0, 0, 0);
            var humanizer = new Humanizer();
            var text = humanizer.Humanize(change);

            Assert.AreEqual("no change due", text);
        }

    }
}
