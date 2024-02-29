using Application.Dtos;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IBookService
{
    public Task<BookEntity> InsertBook(Book newBook);
    public Task<Book> GetById(Guid Id);
    public Task<List<Book>> ListAll(int pageIndex, int totalPerPage = 50);
    public Task DeleteBook(Guid Id);
    public Task<BookEntity> UpdateBook(Guid Id, Book updatedInfo);
}