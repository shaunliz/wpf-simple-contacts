using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Pilot_Contact_Local.Model;

namespace Pilot_Contact_Local.Service
{
    public static class ContactService
    {
        // DB Info.
        public static string ConnectionString /* : IDisposable */
        {
            get { return ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString; }
        }

        // select all contacts information
        public static List<Person> GetAllPeople()
        {
            var list = new List<Person>();

            string query = "select * from people";

            using(var connection = new SQLiteConnection(ConnectionString))
            {
                using(var command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    SQLiteDataReader rd = command.ExecuteReader();

                    while(rd.Read())
                    {
                        var person = new Person();

                        person.Id = Int32.Parse(rd["id"].ToString());
                        person.Name = rd["name"].ToString();
                        person.Email = rd["email"].ToString();
                        person.MobilePhone = rd["mobilephone"].ToString();
                        person.TelePhone = rd["telephone"].ToString();
                        person.FaxNumber = rd["faxnumber"].ToString();
                        person.Address = rd["address"].ToString();
                        person.Memo = rd["memo"].ToString();
                        person.Photo = "image test";

                        list.Add(person);
                    }
                    rd.Close();
                }
            }
            return list;
        }

        // add contact
        public static void AddPersonToDB(Person person)
        {
            string sql = "insert into people values (null, '" + person.Name + "', '" + person.Email + "', '"
                + person.MobilePhone + "', '" + person.TelePhone + "', '" + person.FaxNumber + "', '"
                + person.Address + "', '" + person.Memo + "', '" + person.Photo + "')";

            using(var connection = new SQLiteConnection(ConnectionString))
            {
                using(var command = new SQLiteCommand(sql, connection))
                {
                    connection.Open();

                    try
                    {
                        int queryResult = command.ExecuteNonQuery();
                    }
                    catch (System.InvalidCastException ex)
                    {
                        System.ArgumentException argEx = new System.ArgumentException("Invalid Case Exception", ex);
                        throw argEx;
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        System.ArgumentException argEx = new System.ArgumentException("SqlException", ex);
                        throw argEx;
                    }
                }
            }
        }
    }
}
