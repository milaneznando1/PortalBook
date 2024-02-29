using Application.Dtos;
using Application.Extensions;
using Application.Services;
using Domain.Entities;
using Infra.Data.Contexts;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestProject1;

[TestClass]
public class BookTest
{
    [TestMethod]
    public async Task SaveBookDatabase_ShouldSaveSucessfull()
    {
        var options = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var mockTest = new Mock<DbSet<BookEntity>>();
        var mockContext = new Mock<BookContext>(options);
        mockContext.Setup(m => m.Set<BookEntity>()).Returns(mockTest.Object);

        var service = new BookService(new BookRepository(mockContext.Object));
        await service.InsertBook(new Book()
        {
            BookName = "Alice’s Adventures in Wonderland",
            PublicationDate = DateTime.Now.ToUniversalIso8601(),
            BookAuthor = "Lewis Carroll",
            BookResume = "Lorem ipsum"
        });
        
        mockTest.Verify(m => m.Add(It.IsAny<BookEntity>()), Times.AtLeastOnce);
        mockContext.Verify(m => m.SaveChanges(), Times.Once);
    }
    
    [TestMethod]
    public async Task SearchAllBooksDatabase_ShouldFind()
    {
        var options = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var mockTest = new Mock<DbSet<BookEntity>>();
        var mockContext = new Mock<BookContext>(options);
        mockContext.Setup(m => m.Set<BookEntity>()).Returns(mockTest.Object);

        var service = new BookService(new BookRepository(mockContext.Object));
        var books = await service.ListAll(0);
        
        Assert.IsNotNull(books);
    }
    
    [TestMethod]
    public async Task DeleteBookById_ShouldReturnTrue()
    {
        var options = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var mockTest = new Mock<DbSet<BookEntity>>();
        var mockContext = new Mock<BookContext>(options);
        mockContext.Setup(m => m.Set<BookEntity>()).Returns(mockTest.Object);

        var service = new BookService(new BookRepository(mockContext.Object));
        var book = await service.InsertBook(new Book()
        {
            BookName = "Alice’s Adventures in Wonderland", 
            PublicationDate = DateTime.Now.ToUniversalIso8601(),
            BookAuthor = "Lewis Carroll",
            BookResume = "Lorem ipsum dolor simet"
        });
        await service.DeleteBook(book.Id);

        var foundBook = await service.GetById(book.Id);
        
        Assert.IsNull(foundBook);
    }
    
    [TestMethod]
    public async Task GetBookById_ShouldReturnTrue()
    {
        var options = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var mockTest = new Mock<DbSet<BookEntity>>();
        var mockContext = new Mock<BookContext>(options);
        mockContext.Setup(m => m.Set<BookEntity>()).Returns(mockTest.Object);

        var service = new BookService(new BookRepository(mockContext.Object));
        var book = await service.InsertBook(new Book() {
            BookName = "Alice’s Adventures in Wonderland", 
            PublicationDate = DateTime.Now.ToUniversalIso8601(),
            BookAuthor = "Lewis Carroll",
            BookResume = "Lorem ipsum dolor simet"
        });

        var foundBook = await service.GetById(book.Id);
        
        Assert.IsNull(foundBook);
    }
    
    [TestMethod]
    public async Task UpdateById_ShouldReturnTrue()
    {
        var options = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var mockTest = new Mock<DbSet<BookEntity>>();
        var mockContext = new Mock<BookContext>(options);
        mockContext.Setup(m => m.Set<BookEntity>()).Returns(mockTest.Object);

        var service = new BookService(new BookRepository(mockContext.Object));
        var book = await service.InsertBook(new Book() {
            BookName = "Alice’s Adventures in Wonderland", 
            PublicationDate = DateTime.Now.ToUniversalIso8601(),
            BookAuthor = "Lewis Carroll",
            BookResume = "Lorem ipsum dolor simet"
        });
        var updateBook = await service.UpdateBook(book.Id,
            new Book()
            {
                BookName = "1984", 
                PublicationDate = DateTime.Now.ToUniversalIso8601(),
                BookAuthor = "George Orwell",
                BookResume = "Lorem ipsum dolor simet"
            });
        
        Assert.AreNotEqual(book, updateBook);
    }
}