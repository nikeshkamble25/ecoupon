using System.ComponentModel.DataAnnotations;

namespace ecoupon.models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}