namespace Poketask.Entities
{
    public class Helpers
    {
        public static string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return $"{input[0].ToString().ToUpper()}{input.Substring(1)}";
        }
    }
}