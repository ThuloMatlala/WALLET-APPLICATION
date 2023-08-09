using System.ComponentModel.DataAnnotations;

namespace AuthorizationService.Dtos
{
	public class UserAccountReadDto
    {
        public class UserAccount
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}

