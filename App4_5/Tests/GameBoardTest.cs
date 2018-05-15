using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Moq;

namespace App4_5
{
    [TestFixture]
    public class GameBoardTest
    {
        private readonly string _pathName = @"..\..\gameconfiguration.cfg";
        private Mock<IConfigFile> mock;
        
        [SetUp]
        void Init()
        {
            mock = new Mock<IConfigFile>();
        }
        
        [TestCase(2, 2)]
        [TestCase(2, 5)]
        [TestCase(1, 51)]
        public void CheckIncorrectArea(int width, int height)
        {
            // Arrange
            
            mock.Setup(foo => foo.GetData(It.IsNotIn(_pathName))).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.GetData(_pathName)).Returns(width + " " + height);
            
            // Act
            var data = mock.Object.GetData(_pathName);
            var numberStrings = Regex.Split(data, @"\D+");
            var numbers = numberStrings.Select(int.Parse).ToArray();
            width = numbers[0];
            height = numbers[1];

            // Assert
            Assert.Throws<ArgumentException>(() => new GameBoard(width, height));
        }
        
        [TestCase(1, 11)]
        [TestCase(20, 2)]
        [TestCase(5, 10)]
        [TestCase(25, 2)]
        public void CheckCorrectData(int width, int height)
        {
            // Arrange
            var mock = new Mock<IConfigFile>();
            mock.Setup(foo => foo.GetData(It.IsNotIn(_pathName))).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.GetData(_pathName)).Returns(width + " " + height);
            
            // Act
            var data = mock.Object.GetData(_pathName);
            var numberStrings = Regex.Split(data, @"\D+");
            var numbers = numberStrings.Select(int.Parse).ToArray();
            width = numbers[0];
            height = numbers[1];

            var gameBoard = new GameBoard(width, height);

            // Assert
            Assert.IsTrue(gameBoard.Height > 0 && gameBoard.Width > 0);
        }
        
        [TestCase(1, 11)]
        [TestCase(20, 2)]
        [TestCase(5, 10)]
        [TestCase(25, 2)]
        public void CheckCorrectArea(int width, int height)
        {
            // Arrange
            var mock = new Mock<IConfigFile>();
            mock.Setup(foo => foo.GetData(It.IsNotIn(_pathName))).Throws<InvalidOperationException>();
            mock.Setup(foo => foo.GetData(_pathName)).Returns(width + " " + height);
            
            // Act
            var data = mock.Object.GetData(_pathName);
            var numberStrings = Regex.Split(data, @"\D+");
            var numbers = numberStrings.Select(int.Parse).ToArray();
            width = numbers[0];
            height = numbers[1];

            var gameBoard = new GameBoard(width, height);

            // Assert
            Assert.IsTrue(gameBoard.Height * gameBoard.Width <= 50 && gameBoard.Height * gameBoard.Width > 10); 
        }

        [Test]
        public void CheckEmptyArguments()
        {
            // Act
            var gameBoard = new GameBoard();

            // Assert
            Assert.IsTrue(gameBoard.Height == 5 && gameBoard.Width == 5);
        }
    }
}