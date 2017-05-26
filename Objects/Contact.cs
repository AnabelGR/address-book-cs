using System.Collections.Generic;
using AddressBook.Objects;
using System;

namespace AddressBook.Objects
{
  public class Contact
  {
    private int _id;
    private string _name;
    private int _phoneNumber;
    private string _email;
    private Address _addressInfo;
    private Detail _detailInfo;
    private static List<Contact> _instances = new List<Contact> {};

    public Contact(string name, int phoneNumber, string email, Address addressInfo, Detail detailInfo)
    {
      _id = _instances.Count;
      _name = name;
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
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public void SetPhoneNumber(int newPhoneNumber)
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
