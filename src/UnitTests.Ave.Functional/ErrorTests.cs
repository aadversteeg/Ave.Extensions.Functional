using Ave.Extensions.Functional;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Ave.Functional
{
	public class ErrorTests
	{
		[Fact(DisplayName ="E-0001: Creating an error without a message should fail")]
		public void E0001()
		{
			// arrange

			// act
			var act = () => new Error("code", null);

			// assert
			act.Should().Throw<ArgumentNullException>();
		}

        [Fact(DisplayName = "E-0002: Creating an error without a code should fail")]
        public void E0002()
        {
            // arrange

            // act
            var act = () => new Error(null, "message");

            // assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "E-0003: Creating an error without a message should fail")]
        public void E0003()
        {
            // arrange

            // act
            var act = () => new Error("code", "");

            // assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "E-0004: Creating an error without an empty code should fail")]
        public void E0004()
        {
            // arrange

            // act
            var act = () => new Error("", "message");

            // assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}