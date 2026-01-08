namespace WalletyAPI.Services.ServiceHelpers
{
    public class ServiceHelper
    {
        internal static Guid ParseGuid(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            if (id is not Guid guidId)
            {
                if (id is string s && Guid.TryParse(s, out var parsed))
                    guidId = parsed;
                else
                    throw new ArgumentException("Id must be a Guid or string representing a Guid.", nameof(id));
            }

            return guidId;
        }
    }
}
