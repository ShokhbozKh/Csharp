namespace RazorPagesMovie.Helpers
{
    public static class Utility
    {
        public static string GetLastChars(byte[] token)
            => token[7].ToString();
    }
}