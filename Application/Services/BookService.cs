using Application.Dtos;
using Application.Extensions;
using Application.Services.Interfaces;
using Domain.Entities;
using Infra.Repositories.Interfaces;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookEntity> InsertBook(Book newBook)
    {
        return await _bookRepository.InsertBook(newBook);
    }

    public async Task<Book> GetById(Guid Id)
    {
        var book = await _bookRepository.GetById(Id);
        var newBook = new Book()
        {
            BookName = book.BookName ?? "",
            BookAuthor = book.BookAuthor ?? "",
            PublicationDate = book.PublicationDate != null ? book.PublicationDate.Value.ToUniversalIso8601() : DateTime.Now.ToUniversalIso8601(),
            BookResume = book.BookResume ?? ""
        };
        return newBook;
    }

    public async Task<List<Book>> ListAll(int pageIndex, int totalPerPage = 50)
    {
        var books = await _bookRepository.ListAll();
        var booksListPaginated = books.GetPage(pageIndex, totalPerPage);
        var newBooks = new List<Book>();
        booksListPaginated.ToList().ForEach(book =>
        {
            newBooks.Add(new Book()
            {
                BookName = book.BookName ?? "",
                BookAuthor = book.BookAuthor ?? "",
                PublicationDate = book.PublicationDate != null ? book.PublicationDate.Value.ToUniversalIso8601() : DateTime.Now.ToUniversalIso8601(),
                BookResume = book.BookResume ?? ""
            });
        });
        return newBooks;
    }

    public async Task DeleteBook(Guid Id)
    { 
        await _bookRepository.DeleteBook(Id);
    }

    public async Task<BookEntity> UpdateBook(Guid Id, Book updatedInfo)
    {
        return await _bookRepository.UpdateBook(Id, updatedInfo);
    }
}