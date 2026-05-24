using ContactBook.Models;
using ContactBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactServices _service;

        public ContactsController(ContactServices service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Contact>> Get() =>
            _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(string id)
        {
            var contact = _service.GetByTd(id);
            if (contact == null) return NotFound();
            return contact;
        }

        [HttpPost]
        public ActionResult<Contact> Post(Contact contact) =>
            _service.Create(contact);

        [HttpPut("{id}")]
        public IActionResult Put(string id, Contact contact)
        {
            var existing = _service.GetByTd(id);
            if (existing == null) return NotFound();
            _service.Update(id, contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var existing = _service.GetByTd(id);
            if (existing == null) return NotFound();
            _service.Delete(id);
            return NoContent();
        }
    }
}