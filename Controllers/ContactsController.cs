using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ContactManagement.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactDbContext _context;

        public ContactsController(ContactDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index(string searchString)
        {
            var contacts = await _context.GetContactsAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = await _context.SearchContactsAsync(searchString);
            }

            ViewData["CurrentFilter"] = searchString;
            return View(contacts);
        }

        // GET: Contacts/List - Simple list view for navigation
        public async Task<IActionResult> List()
        {
            var contacts = await _context.GetContactsAsync();
            return View(contacts);
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.GetContactByIdAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,Address")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateContactAsync(contact);
                TempData["SuccessMessage"] = "Contact created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.GetContactByIdAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,Address")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _context.UpdateContactAsync(contact);
                if (success)
                {
                    TempData["SuccessMessage"] = "Contact updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.GetContactByIdAsync(id.Value);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _context.DeleteContactAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Contact deleted successfully!";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Export
        public async Task<IActionResult> Export()
        {
            var contacts = await _context.GetContactsAsync();

            var builder = new StringBuilder();
            builder.AppendLine("First Name,Last Name,Email,Phone Number,Address");

            foreach (var contact in contacts)
            {
                builder.AppendLine($"{contact.FirstName},{contact.LastName},{contact.Email},{contact.PhoneNumber},{contact.Address}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "contacts.csv");
        }
    }
}
