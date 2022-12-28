﻿using Ave.Extensions.Functional;
using Ave.Extensions.Functional.FluentAssertions;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Ave.Functional
{
    public class ResultOnSuccessDoExtensionsTests
    {
        [Fact(DisplayName = "ROSDE-0001: If result indicates success, the action should be done.")]
        public void ROSDE0001()
        {
            // arrange
            var result = Result<int, string>.Success(42);
            int actResult = 0;

            // act
            Action<int> act = (v) => actResult = v;
            var mappedResult = result.OnSuccessDo(act);

            // assert
            mappedResult.Should().SucceedWith(42);
            actResult.Should().Be(42);
        }

        [Fact(DisplayName = "ROSDE-0002: If result indicates failure, the action should not be done.")]
        public void ROSDE0002()
        {
            // arrange
            var result = Result<int, string>.Failure("Something failed");
            int actResult = 0;

            // act
            Action<int> act = (v) => actResult = v;
            var mappedResult = result.OnSuccessDo(act);

            // assert
            mappedResult.Should().FailWith("Something failed");
            actResult.Should().Be(0);
        }
    }
}