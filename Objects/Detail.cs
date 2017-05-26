namespace AddressBook.Objects
{
  public class Detail
  {
    private string _birthday;
    private string _anniversary;
    private string _notes;

    public Detail(string birthday, string anniversary, string notes)
    {
      _birthday = birthday;
      _anniversary = anniversary;
      _notes = notes;
    }

    public string GetBirthday()
    {
      return _birthday;
    }
    public void SetBirthday(string newBirthday)
    {
      _birthday = newBirthday;
    }
    public string GetAnniversary()
    {
      return _anniversary;
    }
    public void SetAnniversary(string newAnniversary)
    {
      _anniversary = newAnniversary;
    }
    public string GetNotes()
    {
      return _notes;
    }
    public void SetNotes(string newNotes)
    {
      _notes = newNotes;
    }
  }
}
