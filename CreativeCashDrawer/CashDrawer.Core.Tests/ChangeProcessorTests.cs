using CashDrawer.Core.ChangeCalculatorFactories;
using CashDrawer.Core.Readers;
using CashDrawer.Core.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CashDrawer.Core.Tests
{
    [TestClass]
    public class ChangeProcessorTests
    {

        [TestMethod]
        public void change_processor_writes_change_to_output()
        {
            var factory = new Mock<IChangeCalculatorFactory>();
            var changeCalculator = new FakeChangeCalculator();
            var reader = new FakeReader();
            var writer = new FakeWriter();

            changeCalculator.ReturnedChange = new Change(1, 0, 0, 0, 0);

            reader.Add(ReadResult.Ok(10, 11));
            reader.Add(ReadResult.Ok(10, 11));
            reader.Add(ReadResult.Ok(10, 11));

            factory.Setup(x => x.GetChangeCalculator(10)).Returns(changeCalculator);

            var processor = new ChangeProcessor(factory.Object);
            processor.Process(reader, writer);

            factory.VerifyAll();
            Assert.AreEqual(3, writer.WrittenChange.Count);
            Assert.AreEqual(1, writer.WrittenChange[0].Dollars);
            Assert.AreEqual(1, writer.WrittenChange[1].Dollars);
            Assert.AreEqual(1, writer.WrittenChange[2].Dollars);
        }



        [TestMethod]
        public void change_processor_writes_reader_error_to_output()
        {
            var factory = new Mock<IChangeCalculatorFactory>();
            var reader = new FakeReader();
            var writer = new FakeWriter();

            var readerError = ReadResult.Failed("this failed");
            reader.Add(readerError);

            var processor = new ChangeProcessor(factory.Object);
            processor.Process(reader, writer);

            Assert.AreEqual(1, writer.WrittenErrors.Count);
            Assert.AreEqual("this failed", writer.WrittenErrors[0]);
        }



        [TestMethod]
        public void change_processor_writes_underpayment_error_to_output()
        {
            var factory = new Mock<IChangeCalculatorFactory>();
            var reader = new FakeReader();
            var writer = new FakeWriter();

            var underpayment = ReadResult.Ok(10, 0);
            reader.Add(underpayment);

            var processor = new ChangeProcessor(factory.Object);
            processor.Process(reader, writer);

            Assert.AreEqual(1, writer.WrittenErrors.Count);
            Assert.AreEqual("Underpayment", writer.WrittenErrors[0]);
        }
    }
}
