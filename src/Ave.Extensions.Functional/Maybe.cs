using System;
using System.Collections.Generic;

namespace Ave.Extensions.Functional
{
	public readonly struct Maybe<T> : IEquatable<Maybe<T>>, IEquatable<object>
	{
		private readonly bool _hasValue;
		private readonly T _value;

		private Maybe(T value)
		{
			if (value == null)
			{
				_hasValue = false;
				_value = default;
				return;
			}

			_hasValue = true;
			_value = value;
		}

		public T Value
		{
			get 
			{
				if (!_hasValue)
				{
					throw new InvalidOperationException();
				}
				return _value; 
			}
		}

		public static Maybe<T> None => new Maybe<T>();

		public bool HasValue => _hasValue;
		public bool HasNoValue => !_hasValue;

		public static implicit operator Maybe<T>(T value)
		{
			if (value is Maybe<T> valueAsMaybe)
			{
				return valueAsMaybe;
			}

			return Maybe.From(value);
		}

		public static implicit operator Maybe<T>(Maybe value) => None;

		public static Maybe<T> From(T obj)
		{
			return new Maybe<T>(obj);
		}

		public static bool operator ==(Maybe<T> maybe, T value)
		{
			if (value is Maybe<T>)
				return maybe.Equals(value);

			if (maybe.HasNoValue)
				return value == null;

			return maybe._value.Equals(value);
		}

		public static bool operator !=(Maybe<T> maybe, T value)
		{
			return !(maybe == value);
		}

		public static bool operator ==(Maybe<T> maybe, object other)
		{
			return maybe.Equals(other);
		}

		public static bool operator !=(Maybe<T> maybe, object other)
		{
			return !(maybe == other);
		}

		public static bool operator ==(Maybe<T> first, Maybe<T> second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(Maybe<T> first, Maybe<T> second)
		{
			return !(first == second);
		}

		public override bool Equals(object obj)
		{
			if (obj is null)
				return false;
			if (obj is Maybe<T> other)
				return Equals(other);
			if (obj is T value)
				return Equals(value);
			return false;
		}

		public bool Equals(Maybe<T> other)
		{
			if (HasNoValue && other.HasNoValue)
				return true;

			if (HasNoValue || other.HasNoValue)
				return false;

			return EqualityComparer<T>.Default.Equals(_value, other._value);
		}

		public override int GetHashCode()
		{
			if (HasNoValue)
				return 0;

			return _value.GetHashCode();
		}

		public override string ToString()
		{
			if (HasNoValue)
				return "(No Value)";

			return _value.ToString();
		}
	}

	public readonly struct Maybe
	{
		public static Maybe<T> From<T>(T value) => Maybe<T>.From(value);
	}
}
