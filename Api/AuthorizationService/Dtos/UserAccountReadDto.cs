using System.ComponentModel.DataAnnotations;

namespace UserAccountManagementService.Dtos
{
	public class UserAccountReadDto
    {
        public class UserAccount
        {
            [Key]
            [Required]
            public int Id { get; set; }
            [Required]
            public string Username { get; set; }
            [Required]
            public string Password { get; set; }
        }
    }
}

