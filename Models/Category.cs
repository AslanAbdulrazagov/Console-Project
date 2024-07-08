namespace MiniApp.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        private static int _id = 0;
        public Category() {
            Id = ++_id;
        }
    }
}