using ContactManagementEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        

        public ContactsDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ContactManagement"].ToString();
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
                            ContactID = oReader.GetInt64(oReader.GetOrdinal("ContactID")),
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

        public Contact GetContact(int contactId)
        {
            Contact contact = new Contact();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("CMP_GetContact", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ContactId", contactId));
                    SqlDataReader oReader = cmd.ExecuteReader();
                    while (oReader.Read())
                    {

                        contact.ContactID = oReader.GetInt64(oReader.GetOrdinal("ContactID"));
                          contact.FirstName = oReader.GetString(oReader.GetOrdinal("FirstName"));
                          contact.LastName = oReader.GetString(oReader.GetOrdinal("LastName"));
                          contact.Email = oReader.GetString(oReader.GetOrdinal("Email"));
                          contact.PhoneNumber = oReader.GetString(oReader.GetOrdinal("PhoneNumber"));
                        contact.Status = oReader.GetBoolean(oReader.GetOrdinal("Status"));
                        
                    }
                    oReader.Close();
                }
            }
            return contact;
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
                    
                        cmd.CommandType = CommandType.StoredProcedure;
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
            }
            return newContactId;
        }

        public bool UpdateContact(Contact contact)
        {
            int contactRowsUpdated = 0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("CMP_UpdateContact", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ContactID", contact.ContactID));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", contact.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", contact.LastName));
                        cmd.Parameters.Add(new SqlParameter("@Email", contact.Email));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", contact.PhoneNumber));
                        cmd.Parameters.Add(new SqlParameter("@Status", contact.Status));
                        cmd.Parameters.Add(new SqlParameter("@UpdatedDate", DateTime.Now));
                        contactRowsUpdated = cmd.ExecuteNonQuery();
                        
                   
                }
            }
            return contactRowsUpdated==0;
        }

        public bool UpdateContactStatus(int contactId)
        {
            int contactRowsUpdated = 0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("CMP_UpdateContactStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ContactID", contactId));
                        //cmd.Parameters.Add(new SqlParameter("@Status", newStatus));
                        contactRowsUpdated = cmd.ExecuteNonQuery();
                   
                }
            }
            return contactRowsUpdated > 0;
        }
    }
}
