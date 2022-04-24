namespace LibraryService;

public class Book : IItem
{
  public string Id { get; }
  private string Title;
  private string Author;
  private Person? Borrower;

  public Book(string isbn, string title, string author)
  {
    Id = isbn;
    Title = title;
    Author = author;
  }

  public override string ToString()
  {
    return $"BOOK - {Title} by {Author}";
  }

  public void BorrowItem(Person borrower)
  {
    if  (this.IsAvailable()) {
      this.Borrower = borrower;
    } else {
      throw new InvalidOperationException();
    }
  }

  public void ReturnItem(Person returnee)
  {
    if (this.Borrower == returnee) {
      this.Borrower = null;
    } else {
      throw new InvalidOperationException();
    }
  }

  public bool IsAvailable()
  {
    return Borrower == null;
  }
}
