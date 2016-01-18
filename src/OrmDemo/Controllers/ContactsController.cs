using Microsoft.AspNet.Mvc;
using OrmDemo.Interfaces;
using OrmDemo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OrmDemo.Controllers
{
    public class ContactsController : Controller
    {
        private IContactRepository contactsRepository;

        public ContactsController(IContactRepository contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = this.contactsRepository.GetContacts();
            return View(result.Data);
        }

        public IActionResult Edit(string id)
        {
            var result = new OperationResult<Contact>();
            var contactId = 0;
            int.TryParse(id, out contactId);
            if (contactId != 0)
                result = contactsRepository.GetContact(contactId);
            else
                result.Data = new Contact();
            return View(result.Data);
        }

        public IActionResult Remove(string id)
        {
            int contactId = 0;
            int.TryParse(id, out contactId);
            contactsRepository.DeleteContact(contactId);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.Id == 0)
                    ViewBag.OperationResult = this.contactsRepository.AddContact(contact);
                else
                    ViewBag.OperationResult = this.contactsRepository.UpdateContact(contact);
            }
                
            return RedirectToAction("Index");
        }
    }
}
