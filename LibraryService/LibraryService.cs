namespace LibraryService;

public sealed class LibraryService : ILibraryService
{

  private List<IItem> _items = new List<IItem>();

  public LibraryService() { }

  public IItem GetItem(string id)
  {
    IItem? item = this._items.Find(delegate(IItem book) {
      return book.Id.Equals(id);
    });

    if (item == null)
    {
        throw new InvalidOperationException();
    } else { return item; }
  }

  public void AddItem(IItem item)
  {
    bool addItem = false;
    try {
        this.GetItem(item.Id);
    } catch {
        addItem = true;
    }

    if (addItem)
    {
      this._items.Add(item);
    }
    else
    {
      throw new InvalidOperationException();
    }
  }

  public void RemoveItem(string id)
  {
    try
    {
        IItem itemToRemove = this.GetItem(id);
        this._items.Remove(itemToRemove);
    }
    catch
    {
        throw new InvalidOperationException();
    }
  }

  public void BorrowItem(string id, Person borrower)
  {
    IItem itemToBorrow = this.GetItem(id);
    if (itemToBorrow.IsAvailable()) {
        itemToBorrow.BorrowItem(borrower);
    } else
    {
        throw new InvalidOperationException();
    }
  }

  public void ReturnItem(string id, Person returnee)
  {
    this.GetItem(id).ReturnItem(returnee);
  }
}
