using NUnit.Framework;
using System;
using static PostgresQueryCreator.Util.PQCHelpers;

namespace PostgresQueryCreator.Tests
{
    public class UtilHelpersTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringsConvertWithQuotes()
        {
            string input = "test";
            string expected_output = "'test'";
            string output = ConvertToSafeString(input);
            Assert.AreEqual(expected_output, output);
        }

        [Test]
        public void IntConvertsAsString()
        {
            int input = 42;
            string expected_output = "42";
            string output = ConvertToSafeString(input);
            Assert.AreEqual(expected_output, output);
        }

        [Test]
        public void FloatConvertsAsString()
        {
            double input = 4.2;
            string expected_output = "4.2";
            string output = ConvertToSafeString(input);
            Assert.AreEqual(expected_output, output);
        }

        [Test]
        public void BoolConvertsAsString()
        {
            bool input = true;
            string expected_output = "True";
            string output = ConvertToSafeString(input);
            Assert.AreEqual(expected_output, output);
        }
        [Test]
        public void DatetimeConvertsAsString()
        {
            DateTime input = new DateTime(2021, 01, 12, 20, 13, 00);
            string expected_output = "'2021-01-12T20:13:00.0000000'";
            string output = ConvertToSafeString(input);
            Assert.AreEqual(expected_output, output);
        }

        [Test]
        public void ColumnConverts()
        {
            string column_name = "Column";
            string prefix = "p";
            Assert.AreEqual("\"Column\"", ConvertToSafeColumn(column_name));
            Assert.AreEqual("p.\"Column\"", ConvertToSafeColumn(column_name, prefix));;
        }
    }
}