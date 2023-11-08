using Moq;

namespace TodoList.Tests
{
    public class TodoTests
    {
        [Fact]
        public void CanShowAllTodoItems()
        {
            //Arrange
            var mockTodoStorage = new Mock<ITodoListStorage>();
            var sut = new TodoList(mockTodoStorage.Object);

            //Act
            var actual = sut.GetTodos();

            //Assert
            mockTodoStorage.Verify(x => x.GetAllTodos(), Times.Once());
        }

        [Fact]
        public void CanShowCompleteTodoItems()
        {
            //Arrange
            var mockTodoStorage = new Mock<ITodoListStorage>();
            mockTodoStorage.Setup(x => x.GetAllTodos()).Returns(new List<TodoItem>
            {
                new TodoItem{ IsComplete = true },
                new TodoItem{ IsComplete = true },
                new TodoItem{ IsComplete = true },
                new TodoItem{ IsComplete = false },
                new TodoItem{ IsComplete = false }
            });

            var sut = new TodoList(mockTodoStorage.Object);

            //Act
            var actual = sut.GetCompleteTodos();

            //Assert
            Assert.All(actual, x => Assert.True(x.IsComplete));
            Assert.Equal(3, actual.Count);
        }

        [Fact]
        public void CanShowInCompleteTodoItems()
        {
            //Arrange
            var mockTodoStorage = new Mock<ITodoListStorage>();
            mockTodoStorage.Setup(x => x.GetAllTodos()).Returns(new List<TodoItem>
            {
                new TodoItem{ IsComplete = false },
                new TodoItem{ IsComplete = false },
                new TodoItem{ IsComplete = false },
                new TodoItem{ IsComplete = true },
                new TodoItem{ IsComplete = true }
            });

            var sut = new TodoList(mockTodoStorage.Object);

            //Act
            var actual = sut.GetIncompleteTodos();

            //Assert
            Assert.All(actual, x => Assert.False(x.IsComplete));
            Assert.Equal(3, actual.Count);
        }

        [Fact]
        public void CanAddTodoItem()
        {
            //Arrange
            string title = "Title";
            string description = "Clean house";

            var mockTodoStorage = new Mock<ITodoListStorage>();
            var sut = new TodoList(mockTodoStorage.Object);

            //Act
            var actual = sut.AddTodo(title, description);

            //Assert
            Assert.NotEqual(Guid.Empty, actual.Id);
            Assert.Equal(title, actual.Title);
            Assert.Equal(description, actual.Description);
            Assert.False(actual.IsComplete);

            mockTodoStorage.Verify(x => x.SaveTodoItem(actual), Times.Once());
        }

        [Fact]
        public void CanMarkTodoItemAsComplete()
        {
            //Arrange
            var todoItem = new TodoItem { IsComplete = false };
            var mockTodoStorage = new Mock<ITodoListStorage>();
            var sut = new TodoList(mockTodoStorage.Object);

            //Act
            var actual = sut.UpdateTodoStatusToComplete(todoItem);

            //Assert
            Assert.True(actual.IsComplete);
            mockTodoStorage.Verify(x => x.SaveTodoItem(actual), Times.Once());
        }

        [Fact]
        public void CanMarkTodoItemAsInComplete()
        {
            //Arrange
            var todoItem = new TodoItem { IsComplete = true };
            var mockTodoStorage = new Mock<ITodoListStorage>();
            var sut = new TodoList(mockTodoStorage.Object);

            //Act
            var actual = sut.UpdateTodoStatusToInComplete(todoItem);

            //Assert
            Assert.False(actual.IsComplete);
            mockTodoStorage.Verify(x => x.SaveTodoItem(actual), Times.Once());
        }
        //[Fact]
        //public void Test_UserInteraction_GetUserInput_Sequential()
        //{
        //    // Arrange
        //    var mock = new Mock<IUserInteraction>();
        //    //mock.SetupSequence(x => x.GetUserInput())
        //    //    .Returns("Vattna blommorna")
        //    //    .Returns("Alla blommor utom de i köket");
        //    mock.Setup(x => x.GetTitleFromUser())
        //        .Returns("Vattna blommorna");

        //    var sut = mock.Object;

        //    // Act
        //    var actual = sut.GetTitleFromUser();
        //    //var result1 = sut.GetUserInput();
        //    //var result2 = sut.GetUserInput();

        //    // Assert
        //    Assert.Equal("Vattna blommorna", actual);
        //    //Assert.Equal("Vattna blommorna", result1);
        //    //Assert.Equal("Alla blommor utom de i köket", result2);
        //}

        [Fact]
        public void Test_UserInteraction_GetUserInput_Sequential()
        {
            // Arrange
            var mock = new Mock<IUserInteraction>();

            var sequence = new MockSequence();

            mock.InSequence(sequence).Setup(x => 
                x.GetUserInput("Ange titel: ")).Returns("Vattna blommorna");
            mock.InSequence(sequence).Setup(x =>
                x.GetUserInput("Ange beskrivning: ")).Returns("Alla blommor utom de i köket");

            var sut = mock.Object;

            //Act
            var result1 = sut.GetUserInput("Ange titel: ");
            var result2 = sut.GetUserInput("Ange beskrivning: ");

            // Assert
            Assert.Equal("Vattna blommorna", result1);
            Assert.Equal("Alla blommor utom de i köket", result2);
        }
    }
}