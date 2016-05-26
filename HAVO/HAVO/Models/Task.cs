using System;
using SQLite;

namespace HAVO.Models
{
    class Task
    {
        public Task ()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ListID { get; set; }
        public DateTime created { get; set; }
        public String Title { get; set; }
        public String Criteria { get; set; }
        public String Placement { get; set; }
        public DateTime LastModification { get; set; }

    }
}
