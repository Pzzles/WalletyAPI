using System.Security.Cryptography;

namespace WalletyAPI.Utils.Security
{
    public static class TransactionPinHelper
    {
        private static readonly Random _random = new();

        /// <summary>
        /// Generates a valid 5-digit transaction PIN
        /// </summary>
        public static string GeneratePin()
        {
            while (true)
            {
                var pin = _random.Next(0, 100000).ToString("D5");

                if (IsValidPin(pin))
                    return pin;
            }
        }

        /// <summary>
        /// Validates a transaction PIN
        /// </summary>
        public static bool IsValidPin(string pin)
        {
            if (string.IsNullOrWhiteSpace(pin))
                return false;

            if (pin.Length != 5 || !pin.All(char.IsDigit))
                return false;

            return !HasSequentialDigits(pin);
        }

        /// <summary>
        /// Checks for 3 or more sequential ascending or descending digits
        /// </summary>
        private static bool HasSequentialDigits(string pin)
        {
            for (int i = 0; i <= pin.Length - 3; i++)
            {
                int a = pin[i] - '0';
                int b = pin[i + 1] - '0';
                int c = pin[i + 2] - '0';

                // Ascending (e.g. 123)
                if (b == a + 1 && c == b + 1)
                    return true;

                // Descending (e.g. 321)
                if (b == a - 1 && c == b - 1)
                    return true;
            }

            return false;
        }
    }
}