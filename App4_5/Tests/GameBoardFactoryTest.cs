using NUnit.Framework;

namespace App4_5
{
    [TestFixture]
    public class GameBoardFactoryTest
    {
        [Test]
        public void CheckGameBoardFactory()
        {
            var gameBoardFactory = new GameBoardFactory();

            var gameBoard = gameBoardFactory.Create();

            Assert.IsTrue(gameBoard.Height == 5 && gameBoard.Width == 5);
        }
    }
}