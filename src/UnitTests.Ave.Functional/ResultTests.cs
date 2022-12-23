using Ave.Extensions.Functional;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Ave.Functional
{
	public class ResultTests
	{
		[Fact(DisplayName = "R-0001: Success should return result indicating success.")]
		public void R0001()
		{
			// arrange

			// act
			var result = Result.Success();

			// assert
			result.IsSuccess.Should().BeTrue();
			result.IsFailure.Should().BeFalse();
		}

		[Fact(DisplayName = "R-0002: Failure should return result indicating failure with cause of failure.")]
		public void R0002()
		{
			// arrange
			var error = new Error("code", "message");

			// act
			var result = Result.Failure(error);

			// assert
			result.IsSuccess.Should().BeFalse();
			result.IsFailure.Should().BeTrue();
			// result.Errors.Should().BeEquivalentTo(new[] { new Error("code", "message") });
		}

		[Fact(DisplayName = "R-0003: Success with a value should return result indicating success with value.")]
		public void R0003()
		{
			// arrange

			// act
			var result = Result.Success(42);

			// assert
			result.IsSuccess.Should().BeTrue();
			result.IsFailure.Should().BeFalse();
			result.Value.Should().Be(42);
		}

		[Fact(DisplayName = "R-0004: Failure for a certain type of value should return result indicating failure with cause of failure.")]
		public void R0004()
		{
			// arrange
			var error = new Error("code", "message");

			// act
			var result = Result<int>.Failure(error);

			// assert
			result.IsSuccess.Should().BeFalse();
			result.IsFailure.Should().BeTrue();
	        result.Errors.Should().BeEquivalentTo( new[] { new Error("code", "message") });
		}


		[Fact(DisplayName = "R-0005: Getting value on result indicating failure should fail.")]
		public void R0005()
		{
			// arrange
			var error = new Error("code", "message");

			// act
			var result = Result<int>.Failure(error);
			var act = () => result.Value;

			// assert
			act.Should().Throw<InvalidOperationException>();
		}

		[Fact(DisplayName = "R-0006: Getting errors on result indicating success should fail.")]
		public void R0006()
		{
			// arrange

			// act
			var result = Result.Success();
			var act = () => result.Errors;

			// assert
			act.Should().Throw<InvalidOperationException>();
		}

		[Fact(DisplayName = "R-0007: Getting errors on result indicating success with a value should fail.")]
		public void R0007()
		{
			// arrange

			// act
			var result = Result.Success(42);
			var act = () => result.Errors;

			// assert
			act.Should().Throw<InvalidOperationException>();
		}
	}
}
