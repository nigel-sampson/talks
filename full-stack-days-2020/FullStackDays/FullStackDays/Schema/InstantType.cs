using HotChocolate.Language;
using HotChocolate.Types;
using NodaTime;
using NodaTime.Text;
using System;

namespace FullStackDays.Schema
{
	public class InstantType : ScalarType
    {
        private static InstantPattern pattern = InstantPattern.ExtendedIso;

		public InstantType() : base(nameof(Instant))
		{
		}

		public override bool IsInstanceOfType(IValueNode literal)
		{
			if (literal == null)
			{
				throw new ArgumentNullException(nameof(literal));
			}

			return literal is StringValueNode || literal is NullValueNode;
		}

		public override object? ParseLiteral(IValueNode literal)
		{
			if (literal == null)
			{
				throw new ArgumentNullException(nameof(literal));
			}

			if (literal is NullValueNode)
			{
				return null;
			}

			if (literal is StringValueNode stringLiteral)
			{
				return pattern.Parse(stringLiteral.Value).Value;
			}

			throw new ArgumentException("The Instant type can only parse string and null literals.", nameof(literal));
		}

		public override IValueNode ParseValue(object value)
		{
			if (value == null)
			{
				return new NullValueNode(null);
			}

			if (value is Instant i)
			{
				return new StringValueNode(InstantPattern.ExtendedIso.Format(i));
			}

			throw new ArgumentException("The specified value has to be a Instant in order to be parsed by the Instant type.");
		}

		public override object? Serialize(object value)
		{
			if (value == null)
			{
				return null;
			}

			if (value is Instant instant)
			{
				return pattern.Format(instant);
			}

			throw new ArgumentException("The specified value cannot be serialized by the StringType.");
		}

		public override bool TryDeserialize(object serialized, out object? value)
		{
			if (serialized is null)
			{
				value = null;
				return true;
			}

			if (serialized is string s)
			{
				value = InstantPattern.ExtendedIso.Parse(s).Value;
				return true;
			}

			value = null;
			return false;
		}

		public override Type ClrType => typeof(Instant);
	}
}
