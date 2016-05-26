using System;
using SQLite;

namespace HAVO.Models
{
    class List
    {
        public List()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int UserID { get; set; }
        public String Title { get; set; }
        public String Project { get; set; }
        public String Address { get; set; }
        public String BIM { get; set; }
        public DateTime Created { get; set; }
    }
}
