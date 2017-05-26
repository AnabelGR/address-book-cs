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
            Address newAddress = new Address(Request.Form["address"], Request.Form["city"], Request.Form["state"], Request.Form["zipCode"]);
            Detail newDetail = new Detail(Request.Form["birthday"], Request.Form["anniversary"], Request.Form["notes"]);
            Contact newContact = new Contact(Request.Form["firstName"], Request.Form["lastName"], Request.Form["phoneNumber"], Request.Form["email"], newAddress, newDetail);
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

      // Get["/"] = _ => {
      //    Dictionary<string, object> indexDict = new Dictionary <string, object> {{"genres", Genre.GetAll()}, {"cds", Cd.GetAll()}};
      //    return View["index.cshtml", indexDict];
      //  };
      //  Get["/filter/"] = _ => {
      //    Dictionary<string, object> indexDict = new Dictionary <string, object> {{"genres", Genre.GetAll()}, {"cds", Cd.GetAll()}, {"query", Genre.Find(int.Parse(Request.Query["genre"]))}};
      //    return View["index.cshtml", indexDict];
      //  };
      //  Post["/genre/new"] = _ => {
      //    Dictionary<string, object> indexDict = new Dictionary <string, object> {{"genres", Genre.GetAll()}, {"cds", Cd.GetAll()}};
      //    Genre newGenre = new Genre(Request.Form["genre-name"]);
      //    return View["index.cshtml", indexDict];
      //  };
      //  Post["/cd/new"] = _ => {
      //    Dictionary<string, object> indexDict = new Dictionary <string, object> {{"genres", Genre.GetAll()}, {"cds", Cd.GetAll()}};






    }
  }
}
