using FluentAssertions;
using HomeInfo.Application.Exceptions;
using HomeInfo.Application.Interfaces;
using HomeInfo.Application.Users.Commands.CreateUser;
using HomeInfo.Domain.Entities;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HomeInfo.Application.Integration.Tests.Users
{
    [TestFixture]
    public class CreateUserCommandTests : TestBase
    {
        [SetUp]
        public void BeforeAll()
        {
            IUserRepository userRepository = Provider.GetService(typeof(IUserRepository)) as IUserRepository;
            userRepository?.Clear();
        }

        [Test]
        public async Task CreateUserCommand_ShouldAddUser()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand
            {
                Name = "Frank",
                Surname = "Sinatra",
                Email = "sinatra.f@music.org",
                UserName = "sifranco"
            };

            //Act
            User response = await SendAsync(command);
            IUserRepository userRepository = Provider.GetService(typeof(IUserRepository)) as IUserRepository;

            //Assert
            response.Should().BeAssignableTo<User>();
            response.Id.Should().NotBeEmpty("Because id is assigned when new User is created");
            userRepository.GetUsers().Count.Should().Be(1);
            userRepository.GetUsers().Should().Contain(response);
        }

        [Test]
        public async Task CreateUserCommand_ShouldAddTwoUsers()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand
            {
                Name = "Frank",
                Surname = "Sinatra",
                Email = "sinatra.f@music.org",
                UserName = "sifranco"
            };

            CreateUserCommand command2 = new CreateUserCommand
            {
                Name = "Neil",
                Surname = "Armstrong",
                Email = "armstrong.n@nasa.gov",
                UserName = "imstrong"
            };

            //Act
            User response = await SendAsync(command);
            User response2 = await SendAsync(command2);
            IUserRepository userRepository = Provider.GetService(typeof(IUserRepository)) as IUserRepository;

            //Assert
            response.Should().BeAssignableTo<User>();
            response.Id.Should().NotBeEmpty("Because id is assigned when new User is created");
            response2.Should().BeAssignableTo<User>();
            response2.Id.Should().NotBeEmpty("Because id is assigned when new User is created");

            userRepository.GetUsers().Count.Should().Be(2);
            userRepository.GetUsers().Should().Contain(response);
            userRepository.GetUsers().Should().Contain(response2);
        }

        [Test]
        public async Task CreateUserCommand_AddUser_ShouldThrowEmailValidationException()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand
            {
                Name = "Frank",
                Surname = "Sinatra",
                Email = "sinatra.fmusic.org",
                UserName = "sifranco"
            };

            //Act
            ValidationException exception = Assert.CatchAsync<ValidationException>(async () => await SendAsync(command));

            //Assert
            exception.Failures.Keys.Should().Contain("Email");
            exception.Failures.Count.Should().Be(1);
        }

        [Test]
        public async Task CreateUserCommand_AddUser_ShouldThrowUserNameValidationException()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand
            {
                Name = "Frank",
                Surname = "Sinatra",
                Email = "sinatra.f@music.org",
                UserName = ""
            };

            //Act
            ValidationException exception = Assert.CatchAsync<ValidationException>(async () => await SendAsync(command));

            //Assert
            exception.Failures.Keys.Should().Contain("UserName");
            exception.Failures.Count.Should().Be(1);
        }

        [Test]
        public async Task CreateUserCommand_AddUser_ShouldThrowMultipleValidationExceptions()
        {
            //Arrange
            CreateUserCommand command = new CreateUserCommand
            {
                Name = "",
                Surname = "",
                Email = "",
                UserName = ""
            };

            //Act
            ValidationException exception = Assert.CatchAsync<ValidationException>(async () => await SendAsync(command));

            //Assert
            exception.Failures.Keys.Should().Contain("Name");
            exception.Failures.Keys.Should().Contain("Surname");
            exception.Failures.Keys.Should().Contain("Email");
            exception.Failures.Keys.Should().Contain("UserName");
            exception.Failures.Count.Should().Be(4);
        }
    }
}
