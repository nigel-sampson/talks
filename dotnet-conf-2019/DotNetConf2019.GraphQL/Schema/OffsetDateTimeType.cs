using HotChocolate.Language;
using HotChocolate.Types;
using NodaTime;
using NodaTime.Text;
using System;

namespace DotNetConf2019.GraphQL.Schema
{
    public class OffsetDateTimeType : ScalarType
    {
        public OffsetDateTimeType() : base(nameof(OffsetDateTime))
        {
        }

        public override bool IsInstanceOfType(IValueNode literal)
        {
            return literal is StringValueNode;
        }

        public override object ParseLiteral(IValueNode literal)
        {
            var asString = ((StringValueNode)literal).Value;
            var instant = OffsetDateTimePattern.ExtendedIso.Parse(asString).Value;

            return instant;
        }

        public override IValueNode ParseValue(object value)
        {
            if (value == null)
                return new NullValueNode(null);

            var instant = (OffsetDateTime)value;
            return new StringValueNode(OffsetDateTimePattern.ExtendedIso.Format(instant));
        }

        public override object Serialize(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is OffsetDateTime offsetDateTime)
            {
                return OffsetDateTimePattern.ExtendedIso.Format(offsetDateTime);
            }

            throw new ArgumentException("The specified value cannot be serialized by the StringType.");
        }

        public override bool TryDeserialize(object serialized, out object value)
        {
            if (serialized is null)
            {
                value = null;
                return true;
            }

            if (serialized is string s)
            {
                value = OffsetDateTimePattern.ExtendedIso.Parse(s).Value;
                return true;
            }

            value = null;
            return false;
        }

        public override Type ClrType => typeof(OffsetDateTime);
    }
}
