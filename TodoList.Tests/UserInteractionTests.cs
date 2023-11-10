using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Cli;

namespace TodoList.Tests
{
    public class UserInteractionTests
    {
        [Fact]
        public void GetInputWorksWhenUserInputsString()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "Maja";
            mock.Setup(x => x.ReadLine()).Returns(expected);
            var sut = new UserInteraction(mock.Object);

            // Act
            var actual = sut.GetStringInput("Vad heter du?");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetInputKeepsTryingOnEmpty()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "Maja";
            mock.SetupSequence(x => x.ReadLine())
                .Returns("")
                .Returns("")
                .Returns("")
                .Returns(expected);
            var sut = new UserInteraction(mock.Object);

            // Act
            var actual = sut.GetStringInput("Vad heter du?");

            // Assert
            Assert.Equal(expected, actual);
            mock.Verify(x => x.ReadLine(), Times.Exactly(4));
        }


        [Fact]
        public void GetInputWorksWhenUserInputsInt()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "42";
            mock.SetupSequence(x => x.ReadLine())
                .Returns(expected); 
            var sut = new UserInteraction(mock.Object);

            // Act
            var actual = sut.GetIntInput("Ange ett heltal:");

            // Assert
            Assert.Equal(42, actual);
        }

        [Fact]
        public void GetInputKeepsTryingOnNonValidInteger()
        {
            // Arrange
            var mock = new Mock<IConsoleWrapper>();
            var expected = "42";
            mock.SetupSequence(x => x.ReadLine())
                .Returns("inte ett heltal")
                .Returns("inte heller ett heltal")
                .Returns("")
                .Returns(expected);
            var sut = new UserInteraction(mock.Object);

            // Act
            var actual = sut.GetIntInput("Ange ett heltal:");

            // Assert
            Assert.Equal(42, actual);
            mock.Verify(x => x.ReadLine(), Times.Exactly(4));
        }





        //[Fact]
        //public void TestUserInteraction()
        //{
        //    // Arrange
        //    var mock = new Mock<IUserInteraction>();

        //    var sequence = new MockSequence();

        //    mock.InSequence(sequence).Setup(x =>
        //        x.GetUserInput("Ange titel: ")).Returns("Vattna blommorna");
        //    mock.InSequence(sequence).Setup(x =>
        //        x.GetUserInput("Ange beskrivning: ")).Returns("Alla blommor utom de i köket");

        //    var sut = mock.Object;

        //    //Act
        //    var result1 = sut.GetUserInput("Ange titel: ");
        //    var result2 = sut.GetUserInput("Ange beskrivning: ");

        //    // Assert
        //    Assert.Equal("Vattna blommorna", result1);
        //    Assert.Equal("Alla blommor utom de i köket", result2);
        //}
    }
}
