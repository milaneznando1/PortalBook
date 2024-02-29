using Application.Dtos;
using Domain.Entities;

namespace Infra.Repositories.Interfaces;

public interface IBookRepository
{
    public Task<BookEntity> InsertBook(Book newBook);
    public Task<BookEntity> GetById(Guid Id);
    public Task<List<BookEntity>> ListAll();
    public Task DeleteBook(Guid Id);
    public Task<BookEntity> UpdateBook(Guid Id, Book updatedInfo);
}