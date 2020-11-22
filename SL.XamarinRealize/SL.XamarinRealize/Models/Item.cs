using SQLite;

namespace SL.XamarinRealize.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement, Unique, NotNull]
        public int Id { get; set; }
        public string Naming { get; set; }
        public int Cost { get; set; }
        public string UniqueId { get; set; }
    }
}
