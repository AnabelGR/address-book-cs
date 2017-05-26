using System.Collections.Generic;
using AddressBook.Objects;
using System;

namespace AddressBook.Objects
{
  public class Contact
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private string _email;
    private Address _addressInfo;
    private Detail _detailInfo;
    private static List<Contact> _instances = new List<Contact> {};

    public Contact(string firstName, string lastName, string phoneNumber, string email, Address addressInfo, Detail detailInfo)
    {
      _id = _instances.Count;
      _firstName = firstName;
      _lastName = lastName;
      _phoneNumber = phoneNumber;
      _email = email;
      _addressInfo = addressInfo;
      _detailInfo = detailInfo;
      _instances.Add(this);
    }
    public int GetId()
    {
      return _id;
    }
    public string GetFirstName()
    {
      return _firstName;
    }
    public void SetFirstName(string newFirstName)
    {
      _firstName = newFirstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public void SetLastName(string newLastName)
    {
      _lastName = newLastName;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(string newPhoneNumber)
    {
      _phoneNumber = newPhoneNumber;
    }
    public string GetEmail()
    {
      return _email;
    }
    public void SetEmail(string newEmail)
    {
      _email = newEmail;
    }
    public Address GetAddressInfo()
    {
      return _addressInfo;
    }
    public void SetAddressInfo(Address newAddressInfo)
    {
      _addressInfo = newAddressInfo;
    }
    public Detail GetDetailInfo()
    {
      return _detailInfo;
    }
    public void SetDetailInfo(Detail newDetailInfo)
    {
      _detailInfo = newDetailInfo;
    }


    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Contact SearchContacts(int searchId)
    {
      return _instances[searchId];
    }
    public void Remove()
    {
      _instances.Remove(this);
    }
  }
}
