using Nancy;
using System.Collections.Generic;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml", Contact.GetAll()];
          Get["/contacts/new"] = _ => View["contact-form.cshtml"];
          Post["/"] = _ => {
            Contact newContact = new Contact(Request.Form["name"],  Request.Form["phoneNumber"], Request.Form["email"]);
            return View["index.cshtml", Contact.GetAll()];
          };
      Post["/contacts/cleared"] = _ => {
        Contact.ClearAll();
        return View["contacts-cleared.cshtml"];
      };
      Get["/contacts/{id}"] = parameters => {
        return View["contact-listing.cshtml", Contact.SearchContacts(parameters.id)];
      };
      Post["/contacts/{id}"] = parameters => {
        Contact contact = Contact.SearchContacts(parameters.id);
        contact.Remove();
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
    }
  }
}
