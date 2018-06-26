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
        int AddContact(Contact contact);
    }
}
