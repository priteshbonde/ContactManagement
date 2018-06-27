using ContactManagementEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementDAL
{
    public interface IContactsDAL
    {
        List<Contact> GetList();
        Contact GetContact(int contactId);
        int AddContact(Contact contact);
        bool UpdateContact(Contact contact);
        bool UpdateContactStatus(int contactId, bool newStatus);
    }
}
