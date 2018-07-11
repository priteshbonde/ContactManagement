using ContactManagementAPI.Filters;
using ContactManagementDAL;
using ContactManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContactManagementAPI.Controllers
{
    //[CustomException]
    [EnableCors("*","*","*")]
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

        [HttpGet]
        public IEnumerable<Contact> Get(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                return _ContactsDAL.GetList().Where(t => t.FirstName.ToUpper().Contains(searchString.ToUpper())
                        || t.LastName.ToUpper().Contains(searchString.ToUpper()));
            else
                return _ContactsDAL.GetList();
        }
        // POST: api/Contact
        [HttpPost]
        public HttpResponseMessage Post(Contact value)
        {
            if (ModelState.IsValid)
            {
                if (value.ContactID == 0)
                {
                   int contactId=  _ContactsDAL.AddContact(value);
                    value.ContactID = contactId;
                }
                else
                    _ContactsDAL.UpdateContact(value);
                return Request.CreateResponse(HttpStatusCode.OK,value);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
      [HttpPost]
        // DELETE: api/Contact/5
        public HttpResponseMessage Delete(int id)
        {
            if (_ContactsDAL.UpdateContactStatus(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Invalid Request");
            }
                
        }
    }
}
