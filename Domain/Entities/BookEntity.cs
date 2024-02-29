namespace Domain.Entities;

public class BookEntity
{
    public BookEntity(){}

    public BookEntity(string bookName, string bookAuthor, string bookResume, DateTime publicationDate)
    {
        BookName = bookName;
        BookAuthor = bookAuthor;
        BookResume = bookResume;
        PublicationDate = publicationDate;
    }
    
    public string? BookName { get; set; }
    public string? BookAuthor { get; set; }
    public string? BookResume { get; set; }
    public DateTime? PublicationDate { get; set; }
    public Guid Id { get; set; }
}