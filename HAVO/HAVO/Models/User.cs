using System;
using SQLite;

namespace HAVO.Models
{
    class User
    {
        public User()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }

    }
}
