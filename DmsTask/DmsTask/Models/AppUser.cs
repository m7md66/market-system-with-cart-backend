using Microsoft.AspNetCore.Identity;

namespace DmsTask.Models
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
            OrderHeaders = new HashSet<OrderHeader>();

        }
        public string Name { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string CustomerDescription { get; set; }
        public string CustomerDescriptionAr { get; set; }

        //relations
         public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
