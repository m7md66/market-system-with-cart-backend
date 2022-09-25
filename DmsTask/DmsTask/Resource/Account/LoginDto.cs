using System.ComponentModel.DataAnnotations;

namespace DmsTask.Resource.Account
{
    public class LoginDto


    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPresist { get; set; }
    }
}
