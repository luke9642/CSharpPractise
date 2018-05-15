namespace App4_1
{
    public static class StringConcatenator
    {
        public static string Concatenate(this string first, string second)
        {
            if (first == null || second == null)
                return null;
            return first + second;
        }
    }
}