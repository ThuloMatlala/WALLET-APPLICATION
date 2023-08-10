using System.ComponentModel.DataAnnotations;

namespace AuthorizationService.Dtos
{
	public class UserAccountCreateDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

