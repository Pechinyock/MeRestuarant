using System.ComponentModel.DataAnnotations;

namespace MeRestaurantWebApi;

public class CreateUserModel
{ 
    [Required]
    public string Email{ get; set; } = "";
    
    [Required]
    public string Password { get; set; } = "";

    [Required]
    [Compare(nameof(Password))]
    public string RetryPassword { get; set; } = "";
}
