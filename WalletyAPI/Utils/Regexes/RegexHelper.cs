using System.Text.RegularExpressions;
namespace WalletyAPI.Utils.Regexes
{
    public static class RegexHelper
    {
        public const string PhoneNumberRegex = @"^\+?[1-9]\d{1,14}$";
        public const string TaxNumberRegex = @"^[A-Z0-9]{8,15}$";
        public const string UserIdRegex = @"^[a-fA-F0-9]{24}$";
        public const string EmailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
        public const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,128}$";
        public const string CurrencyCodeRegex = @"^[A-Z]{3}$";
        public const string BusinessRegistrationNumberRegex = @"^[A-Z0-9]{8,20}$";
        public const string TransactionPINRegex = @"^\d{5}$";
        public const string TransactionReferenceRegex = @"^[A-Z0-9]{10,20}$";
        public const string UrlRegex = @"^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$";
        public const string AlphaNumericRegex = @"^[a-zA-Z0-9]+$";
        public const string DateRegex = @"^\d{4}-\d{2}-\d{2}$";
        public const string TimeRegex = @"^\d{2}:\d{2}:\d{2}$";
        public const string DateTimeRegex = @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(Z|[+-]\d{2}:\d{2})$";
        public const string IPv4Regex = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        public const string IPv6Regex = @"^(([0-9a-fA-F]{1,4}:){7}([0-9a-fA-F]{1,4}|:)|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|(2[0-4][0-9]|[01]?[0-9][0-9]?))|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|(2[0-4][0-9]|[01]?[0-9][0-9]?))))$";
        public const string HexColorCodeRegex = @"^#?([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$";
        public const string CreditCardNumberRegex = @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|6(?:011|5[0-9]{2})[0-9]{12}|(?:2131|1800|35\d{3})\d{11})$";
        public const string UsernameRegex = @"^[a-zA-Z0-9_]{3,16}$";
        public const string UUIDRegex = @"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
        public const string DeviceIDRegex = @"^[a-fA-F0-9]{16,32}$";
        public const string BrowserUserAgentRegex = @"^Mozilla\/[\d.]+\s*\([^)]+\)\s*(AppleWebKit|Gecko|Trident|Edge)\/[\d.]+.*$";
        public const string ImeiNumberRegex = @"^\d{15}$";
       // public const string RSAIdOrPassportNumberRegex = @"^[A-Z0-9]{5,15}$";
        public const string KycReferenceNumberRegex = @"^[A-Z0-9]{10,20}$";

        public static bool IsValid(string input, string pattern)
        {
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(pattern))
                return false;

            return Regex.IsMatch(input, pattern);
        }
    }
}