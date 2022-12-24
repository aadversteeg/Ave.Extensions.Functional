using System;

namespace Ave.Extensions.Functional
{
	public readonly struct Maybe<T>
	{
		private readonly bool _hasValue;
		private readonly T _value;

		private Maybe(bool hasValue, T value)
		{
			_hasValue = hasValue;
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

		public static Maybe<T> None => new Maybe<T>(false, default);

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

		public static Maybe<T> From(T source)
		{
			return new Maybe<T>(true, source);
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
