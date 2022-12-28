﻿using Ave.Extensions.Functional;
using Ave.Extensions.Functional.FluentAssertions;
using FluentAssertions;
using Xunit;

namespace UnitTests.Ave.Functional
{
	public class ResultOnSuccessMapExtensionsTests
	{
		[Fact(DisplayName = "ROSME-0001: If result indicates success, the value should be mapped.")]
		public void ROSME0001()
		{
			// arrange
			var result = Result<int, string>.Success(42);

			// act
			var mappedResult = result.OnSuccessMap((s) => s.ToString());

			// assert
			mappedResult.Should().SucceedWith("42");
		}

        [Fact(DisplayName = "ROSME-0002: If result indicates failure, the value should not be mapped.")]
        public void ROSME0002()
        {
            // arrange
            var result = Result<int, string>.Failure("something failed");

            // act
            var mappedResult = result.OnSuccessMap((s) => s.ToString());

            // assert
            mappedResult.Should().FailWith("something failed");
        }		
	}
}