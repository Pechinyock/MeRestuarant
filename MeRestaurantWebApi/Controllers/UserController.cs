using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MeRestaurantWebApi;

[ApiController]
[Route("[controller]/[action]")]
public class UserController: ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserModel newUser){
        if(await IsUserExists(newUser.Email)){
            throw new Exception("User already exists!");            
        }
        await _userService.CreateNewUser(newUser);
        return Ok();
    }

    [HttpGet]
    public async Task<bool> IsUserExists(string email){
        return await _userService.IsUserExists(email);
    }
}
