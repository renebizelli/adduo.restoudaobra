using System;

namespace adduo.methodextension
{
    public static class GuidMethodExtension
    {
        public static bool IsEmpty(this Guid _guid)
        {
            return _guid.Equals(Guid.Empty);
        }

        public static bool NotIsEmpty(this Guid _guid)
        {
            return !_guid.IsEmpty();
        }
    }
}
