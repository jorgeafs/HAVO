using System;
using SQLite;

namespace HAVO.Models
{
    public class Evaluation
    {
        public Evaluation()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TaskID { get; set; }
        public Boolean Done { get; set; }
        public String Coments { get; set; }
        public String Pictures { get; set; }
        public DateTime DateChecked { get; set; }
    }
}
