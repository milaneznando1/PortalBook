using Application.Dtos;
using Domain.Entities;
using Infra.Data.Contexts;
using Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookContext _bookContext;

    public BookRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
    }
    
    public async Task<BookEntity> InsertBook(Book newBook)
    {
        var newBookEntity = new BookEntity(newBook.BookName, newBook.BookAuthor, newBook.BookResume, DateTime.Parse(newBook.PublicationDate));
        await _bookContext.Book.AddAsync(newBookEntity);
        return newBookEntity;
    }

    public async Task<BookEntity> GetById(Guid Id)
    {
        var bookFound = await _bookContext.Book.Where(x => x.Id == Id).FirstOrDefaultAsync();
        return bookFound;
    }

    public async Task<List<BookEntity>> ListAll()
    {
        var booksFound = await _bookContext.Book.ToListAsync();
        return booksFound;
    }

    public async Task DeleteBook(Guid Id)
    {
        var foundBook = await _bookContext.Book.Where(x => x.Id == Id).FirstOrDefaultAsync();
        _bookContext.Book.Remove(foundBook);
    }

    public async Task<BookEntity> UpdateBook(Guid Id, Book updatedInfo)
    {
        var foundBook = await _bookContext.Book.Where(x => x.Id == Id).FirstOrDefaultAsync();
        foundBook.BookName = updatedInfo.BookName;
        foundBook.BookAuthor = updatedInfo.BookAuthor;
        foundBook.BookResume = updatedInfo.BookResume;
        foundBook.PublicationDate = DateTime.Parse(updatedInfo.PublicationDate);
        _bookContext.Book.Update(foundBook);
        return foundBook;
    }
}