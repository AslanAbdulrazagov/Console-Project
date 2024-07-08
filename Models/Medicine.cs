using MiniApp.Exceptions;
using System.Data;

namespace MiniApp.Models
{
    public class Medicine : BaseEntity
    {
        private static int _id = 0;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }


        public Medicine()
        {
            Id= ++_id;
            
        }


    }
}