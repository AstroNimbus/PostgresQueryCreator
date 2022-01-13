using NUnit.Framework;
using System;
using PostgresQueryCreator.Util;

namespace PostgresQueryCreator.Tests
{
    public class UtilStringBuilderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BlankInitCreatesBlankString()
        {
            var sb = new PqcStringBuilder();
            string expected_output = "";
            Assert.AreEqual(expected_output, sb.ToString());
        }

        [Test]
        public void ValueInitCreatesValueString()
        {
            string input = "First Value";
            var sb = new PqcStringBuilder(input);
            string expected_output = "First Value";
            Assert.AreEqual(expected_output, sb.ToString());
        }

        [Test]
        public void ValuesGetAppendedWithSpace()
        {
            var value_one = "One";
            var value_two = "Two";
            var sb = new PqcStringBuilder();
            sb.Append(value_one);
            sb.Append(value_two);
            var expected_output = "One Two";
            Assert.AreEqual(expected_output, sb.ToString());
        }

        [Test]
        public void StringBuilderReturnedIsStringBuilder()
        {
            var sb = new PqcStringBuilder();
            var new_sb = sb.Append("test");
            Assert.AreEqual(sb, new_sb);
        }
    }
}