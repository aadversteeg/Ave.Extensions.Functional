using AutoFixture;
using Ave.Extensions.Functional;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Ave.Functional
{
	public class MaybeTests
	{
        public class TestClass
        {
            private readonly int _value;

            public TestClass(int value)
            {
                _value = value;
            }

            public override bool Equals(object other)
            {
                var otherAsTestClass = other as TestClass;

                if (otherAsTestClass == null) 
                { 
                    return false; 
                }

                if (object.ReferenceEquals(this, otherAsTestClass)) 
                { 
                    return true; 
                }

                return _value.Equals(otherAsTestClass._value);
            }

            public override int GetHashCode()
            {
                return _value.GetHashCode();
            }

            public override string ToString()
            {
                return _value.ToString();
            }
        }

		[Fact(DisplayName = "M-0001: String representation of may without value is (No Value)")]
		public void M0001()
		{
			// arrange

			// act
			var mayBeAsString = Maybe<int>.None.ToString();

			// assert
			mayBeAsString.Should().Be("(No Value)");
		}

		[Fact(DisplayName = "M-0002: String representation of maybe with value is string representation of value")]
		public void M0002()
		{
			// arrange
			var maybe = Maybe.From(42);

			// act
			var mayBeAsString = maybe.ToString();

			// assert
			mayBeAsString.Should().Be("42");
		}

        [Fact(DisplayName = "M-0003: Getting value from maybe with no value should fail")]
        public void M0003()
        {
            // arrange
            var maybe = Maybe<int>.None;

            // act
            var act = () => maybe.Value;

            // assert
           act.Should().Throw<InvalidOperationException>();
        }

        [Fact(DisplayName = "M-0004: Two maybe's without value are equal")]
        public void M0004()
        {
            // arrange
            var left = Maybe<int>.None;
            var right = Maybe<int>.None;

            // act
            var areEqual = left == right;
            var areNotEqual = left != right;

            // assert
            areEqual.Should().BeTrue();
            areNotEqual.Should().BeFalse();
        }

        [Fact(DisplayName = "M-0005: Two maybe's with same value are equal")]
        public void M0005()
        {
            // arrange
            var fixture = new Fixture();
            var value = fixture.Create<int>();

            var left = Maybe.From(value);
            var right = Maybe.From(value);

            // act
            var areEqual = left == right;
            var areNotEqual = left != right;

            // assert
            areEqual.Should().BeTrue();
            areNotEqual.Should().BeFalse();
        }

        [Fact(DisplayName = "M-0006: Two maybe's with different value are not equal")]
        public void M0006()
        {
            // arrange
            var fixture = new Fixture();
            var value = fixture.Create<int>();

            var left = Maybe.From(value);
            var right = Maybe.From(value + 1);

            // act
            var areEqual = left == right;
            var areNotEqual = left != right;

            // assert
            areEqual.Should().BeFalse();
            areNotEqual.Should().BeTrue();
        }

        [Fact(DisplayName = "M-0007: Assigning null to a maybe will result in a maybe with no value")]
        public void M0007()
        {
            // arrange
            Maybe<TestClass> value = null;

            // act
            var hasValue = value.HasValue;

            // assert
            hasValue.Should().BeFalse();
        }

        [Fact(DisplayName = "M-0008: A maybe with a value is equal to the value")]
        public void M0008()
        {
            // arrange
            var fixture = new Fixture();
            var value = fixture.Create<int>();

            var left = Maybe.From(value);
            var right = value;

            // act
            var areEqual = left == right;
            var areNotEqual = left != right;

            // assert
            areEqual.Should().BeTrue();
            areNotEqual.Should().BeFalse();
        }

        [Fact(DisplayName = "M-0009: A maybe without a value is not equal to a value")]
        public void M0009()
        {
            // arrange
            var fixture = new Fixture();
            var value = fixture.Create<int>();

            var left = Maybe<int>.None;
            var right = value;

            // act
            var areEqual = left == right;
            var areNotEqual = left != right;

            // assert
            areEqual.Should().BeFalse();
            areNotEqual.Should().BeTrue();
        }

        [Fact(DisplayName = "M-0010: Value should return value of maybe.From")]
        public void M0010()
        {
            // arrange
            var fixture = new Fixture();
            var value = fixture.Create<int>();
            var maybe = Maybe.From(value);

            // act
            var valueFromMaybe = maybe.Value;

            // assert
            valueFromMaybe.Should().Be(value);
        }

        [Fact(DisplayName = "M-0011: A maybe with an object is equal to an other object if objects are equal")]
        public void M00011()
        {
            // arrange
            var fixture = new Fixture();
            var value = new TestClass(fixture.Create<int>());

            var left = Maybe.From(value);
            var right = (object)value;

            // act
            var areEqual = left == right;
            var areNotEqual = left != right;

            // assert
            areEqual.Should().BeTrue();
            areNotEqual.Should().BeFalse();
        }

        [Fact(DisplayName = "M-0012: A maybe with no value has a hash code of zero")]
        public void M00012()
        {
            // arrange
            var maybe = Maybe<int>.None;

            // act
            var hashCode = maybe.GetHashCode();

            // assert
            hashCode.Should().Be(0);
        }

        [Fact(DisplayName = "M-0013: A maybe with value has a hash code of the value")]
        public void M00013()
        {
            // arrange
            var fixture = new Fixture();
            var value = new TestClass(fixture.Create<int>());
            
            var maybe = Maybe.From(value);

            // act
            var hashCode = maybe.GetHashCode();

            // assert
            var expectedHashCode = value.GetHashCode();
            hashCode.Should().Be(expectedHashCode);
        }
    }
}