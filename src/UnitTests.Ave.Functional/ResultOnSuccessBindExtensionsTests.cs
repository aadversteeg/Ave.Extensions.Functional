using Ave.Extensions.Functional;
using Ave.Extensions.Functional.FluentAssertions;
using FluentAssertions;
using Xunit;

namespace UnitTests.Ave.Functional
{
	public class ResultOnSuccessBindExtensionsTests
	{
        [Fact(DisplayName = "ROSBE-0001: If result indicates success, the value should be bound.")]
        public void ROSE0001()
        {
            // arrange
            var result = Result<int, string>.Success(42);

            // act
            var bindResult = result.OnSuccessBind((s) => Result<string, string>.Success( s.ToString()));

            // assert
            bindResult.Should().SucceedWith("42");
        }

        [Fact(DisplayName = "ROSBE-0002: If result indicates failure, the value should not be bound.")]
        public void ROSBE0002()
        {
            // arrange
            var result = Result<int, string>.Failure("something failed");

            // act
            var bindResult = result.OnSuccessBind((s) => Result<string, string>.Success(s.ToString()));

            // assert
            bindResult.Should().FailWith("something failed");
        }

        [Fact(DisplayName = "ROSBE-0003: If result indicates success, but the bind fails, the result will indicate failure.")]
        public void ROSBE0003()
        {
            // arrange
            var result = Result<int, string>.Success(42);

            // act
            var bindResult = result.OnSuccessBind((s) => Result<string, string>.Failure(("bind failed")));

            // assert
            bindResult.Should().FailWith("bind failed");
        }
    }
}
