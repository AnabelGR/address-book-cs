namespace AddressBook.Objects
{
  public class Address
  {
    private string _address;
    private string _city;
    private string _state;
    private int _zipCode;

    public Address(string address, string city, string state, int zipCode)
    {
      _address = address;
      _city = city;
      _state = state;
      _zipCode = zipCode;
    }

    public string GetAddress()
    {
      return _address;
    }
    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }
    public string GetCity()
    {
      return _city;
    }
    public void SetCity(string newCity)
    {
      _city = newCity;
    }
    public string GetState()
    {
      return _state;
    }
    public void SetState(string newState)
    {
      _state = newState;
    }
    public int GetZipCode()
    {
      return _zipCode;
    }
    public void SetZipCode(int newZipCode)
    {
      _zipCode = newZipCode;
    }
  }
}
