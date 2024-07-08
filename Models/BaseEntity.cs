

namespace MiniApp.Models
{
    public abstract class BaseEntity
    {
        
        public int Id { get; protected set; }

        protected BaseEntity()
        {
           
        }
    }
}
