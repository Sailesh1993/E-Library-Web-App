using AutoMapper;
using Moq;
using WebApi.Business.src.Dtos;
using WebApi.Business.src.Implementations;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.Domain.src.Shared;
using WebApi.WebApi.src.Configuration;

namespace WebApi.Testing.src.Business.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task CreateOne_ValidDto_Success()
        {
            //Arrange
            var userCreateDto = new UserCreateDto
            {
                FirstName = "Radhe",
                LastName = "Krishna",
                Email = "radhe@gmail.com",
                Password = "radhe123",
            };

            var expectedUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email
            };

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
            var userRepoMock = new Mock<IUserRepo>();
            userRepoMock.Setup(repo => repo.CreateOne(It.IsAny<User>()))
            .ReturnsAsync(expectedUser);

            var userService = new UserService(userRepoMock.Object, mapper);

            // Act
            var result = await userService.CreateOne(userCreateDto);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.FirstName, result.FirstName);
            Assert.Equal(expectedUser.LastName, result.LastName);
            Assert.Equal(expectedUser.Email, result.Email);

        }
        [Fact]
        public async Task GetAll_ReturnsAllUsers_Success()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepo>();
            var mockMapper = new Mock<IMapper>();

            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "john@gmail.com", Role = Role.Admin},
                new User { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", Email = "jane@example.com", Role = Role.User }
            };
            var expectedDtos = users.Select(user => new UserReadDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = null, // Password should not be exposed in the read DTO
            Role = user.Role
        }).ToList();

        mockRepo.Setup(repo => repo.GetAll(It.IsAny<QueryOptions>())).ReturnsAsync(users);
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<UserReadDto>>(It.IsAny<IEnumerable<User>>())).Returns(expectedDtos);

        var userService = new UserService(mockRepo.Object, mockMapper.Object);

        // Act
        var result = await userService.GetAll(new QueryOptions());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedDtos.Count, result.Count());
        Assert.Equal(expectedDtos, result); 

        }
    }
}