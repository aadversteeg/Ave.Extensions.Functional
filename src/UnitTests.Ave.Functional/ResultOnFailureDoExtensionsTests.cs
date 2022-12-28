﻿using Ave.Extensions.Functional;
using Ave.Extensions.Functional.FluentAssertions;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Ave.Functional
{
    public class ResultOnFailureDoExtensionsTests
    {
        [Fact(DisplayName = "ROFDE-0001: If result indicates failure, the action should be done.")]
        public void ROFDE0001()
        {
            // arrange
            var result = Result<int, string>.Failure("Something failed");
            string actResult = String.Empty;

            // act
            Action<string> act = (e) => actResult = e;
            var mappedResult = result.OnFailureDo(act);

            // assert
            mappedResult.Should().FailWith("Something failed");
            actResult.Should().Be("Something failed");
        }

        [Fact(DisplayName = "ROFDE-0002: If result indicates success, the action should not be done.")]
        public void ROFDE0002()
        {
            // arrange
            var result = Result<int, string>.Success(42);
            string actResult = String.Empty;

            // act
            Action<string> act = (e) => actResult = e;
            var mappedResult = result.OnFailureDo(act);

            // assert
            mappedResult.Should().SucceedWith(42);
            actResult.Should().BeEmpty();
        }
    }
}