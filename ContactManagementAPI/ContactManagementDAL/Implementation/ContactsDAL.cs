using ContactManagementEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementDAL.Implementation
{
    public class ContactsDAL: IContactsDAL
    {
        string _connectionString;
        

        public ContactsDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Contact> GetList()
        {
            List<Contact> lstContacts = new List<Contact>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("CMP_GetContactList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader oReader = cmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        Contact data = new Contact
                        {
                            ContactID = oReader.GetInt32(oReader.GetOrdinal("ContactID")),
                            FirstName = oReader.GetString(oReader.GetOrdinal("FirstName")),
                            LastName = oReader.GetString(oReader.GetOrdinal("LastName")),
                            Email = oReader.GetString(oReader.GetOrdinal("Email")),
                            PhoneNumber = oReader.GetString(oReader.GetOrdinal("PhoneNumber")),
                            Status = oReader.GetBoolean(oReader.GetOrdinal("Status"))
                        };
                        lstContacts.Add(data);
                    }
                    oReader.Close();
                }
            }
            return lstContacts;
        }

        public int AddContact(Contact contact)
        {
            int newContactId=0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("CMP_AddContact", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader oReader = cmd.ExecuteReader();
                    while (oReader.Read())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ContactID", contact.ContactID));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", contact.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", contact.LastName));
                        cmd.Parameters.Add(new SqlParameter("@Email", contact.Email));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", contact.PhoneNumber));
                        cmd.Parameters.Add(new SqlParameter("@Status", contact.Status));
                        cmd.Parameters.Add(new SqlParameter("@CreatedDate", DateTime.Now));
                        cmd.Parameters.Add(new SqlParameter("@UpdatedDate", DateTime.Now));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            newContactId = Convert.ToInt32(result);
                        }
                    }
                    oReader.Close();
                }
            }
            return newContactId;
        }
    }
}
