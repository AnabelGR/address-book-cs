using System.Collections.Generic;
using AddressBook.Objects;
using System;

namespace AddressBook.Objects
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    private string _name;
    private int _id;
    private List<Contact> _contacts;

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _contacts = new List<Contact>{};
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Category> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public List<Contact> GetContacts()
    {
      return _contacts;
    }
    public void AddContact(Contact contact)
    {
      _contacts.Add(contact);
    }
  }
}
