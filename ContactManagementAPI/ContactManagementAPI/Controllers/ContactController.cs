using ContactManagementDAL;
using ContactManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagementAPI.Controllers
{
    public class ContactController : ApiController
    {
        readonly IContactsDAL _ContactsDAL;
        public ContactController(IContactsDAL contactsDAL)
        {
            _ContactsDAL = contactsDAL;
        }
        // GET: api/Contact
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _ContactsDAL.GetList();
        }

        // GET: api/Contact/5
        [HttpGet]
        public Contact Get(int id)
        {
            return _ContactsDAL.GetContact(id);
        }

        // POST: api/Contact
        [HttpPost]
        public HttpResponseMessage Post(Contact value)
        {
            if (ModelState.IsValid)
            {
                _ContactsDAL.UpdateContact(value);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
      
        [HttpPost]
        // DELETE: api/Contact/5
        public HttpResponseMessage Delete(int id, bool newStatus)
        {
                _ContactsDAL.UpdateContactStatus(id, newStatus);
                return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
