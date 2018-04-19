namespace App4_1
{
    public class StringConcatenator
    {
        public string concatenate(string first, string second)
        {
            if (first == null || second == null)
                return null;
            return first + second;
        }
    }
}