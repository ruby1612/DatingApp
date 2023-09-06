using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route ("api/[controller]")] // you can use /api/users to see what happens.
public class UsersController : ControllerBase // sends the https respone to inside code injected
{
    private readonly DataContext _context; //whenever usercontroller sees the context it creates an instance for datacontext

    public UsersController(DataContext context) //context should be avail to the rest of the class
    {                                           // the context is gonna get injected whenever usercontroller is initiated
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers() // async and await
    {
        var users = await _context.Users.ToListAsync(); // lists the users

        return users;
    }

    [HttpGet("{id}")] // /api/user/1 (1->id)  this is synchronous now, later it will get changed to asynchronous
    public async Task<ActionResult<AppUser>>GetUser(int id) 
    {
        //find the user with id in the parameter that matches

        return await _context.Users.FindAsync(id); //reduced space, returning in single line
    }

}
