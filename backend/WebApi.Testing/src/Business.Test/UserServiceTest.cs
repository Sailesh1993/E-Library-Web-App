using AutoMapper;
using Microsoft.AspNetCore.Razor.Language;
using Moq;
using WebApi.Business.src.Dtos;
using WebApi.Business.src.Implementations;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
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
    }
}