namespace BookStoreApi.Helper
{
    public class Util
    {
        public static string GenerateUniqueCode()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff"); // Timestamp in desired format
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Alphanumeric characters

            // Generate a random alphanumeric string (you can adjust the length as needed)
            string randomString = new string(Enumerable.Repeat(chars, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            // Combine timestamp, random number, and random alphanumeric string
            string uniqueCode = $"{timestamp}{random.Next(1000, 9999)}{randomString}";

            return uniqueCode;
        }
    }
}
