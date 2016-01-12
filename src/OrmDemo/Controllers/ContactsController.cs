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
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
                ViewBag.OperationResult = this.contactsRepository.AddContact(contact);
            return View();
        }
    }
}
