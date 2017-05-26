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
      Get["/categories"] = _ => {
        List<Category> allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/new"] = _ => {
        return View["category_form.cshtml"];
      };
      Post["/categories"] = _ => {
       Category newCategory = new Category(Request.Form["category-name"]);
        List<Category> allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Contact> categoryContacts = selectedCategory.GetContacts();
        model.Add("category", selectedCategory);
        model.Add("contacts", categoryContacts);
        return View["category.cshtml", model];
      };
      Get["/categories/{id}/contacts/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Contact> allContacts = selectedCategory.GetContacts();
        model.Add("category", selectedCategory);
        model.Add("contacts", allContacts);
        return View["category-contact-form.cshtml", model];
      };
      Post["/contacts"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<Contact> categoryContacts = selectedCategory.GetContacts();
        string lastName = Request.Form["lastName"];
        Contact newContact = new Contact(lastName);
        categoryContacts.Add(newContact);
        model.Add("contacts", categoryContacts);
        model.Add("category", selectedCategory);
        return View["category.cshtml", model];
      };
    }
  }
}
