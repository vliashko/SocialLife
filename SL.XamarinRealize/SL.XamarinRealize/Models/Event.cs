using SQLite;

namespace SL.XamarinRealize.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey,AutoIncrement,Unique,NotNull]
        public int Id { get; set; }
        public string Naming { get; set; }
        public string DateAndTime { get; set; }
        public string Description { get; set; }
    }
}
