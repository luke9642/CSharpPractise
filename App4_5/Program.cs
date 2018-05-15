namespace App4_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var gameBoardFactory = new GameBoardFactory();
            var tmp = gameBoardFactory.Create();
        }
    }
}