﻿namespace AP_Theme_5.Domain.Entities.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
    }
}
