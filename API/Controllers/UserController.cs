using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]// api/user
public class UserController : ControllerBase
{
    private DataContext _context;
    public UserController(DataContext context)
    {
        _context=context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>>GetAllUsers()
    {
        var users= await _context.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUserById(int id)
    {
        var user=await _context.Users.FindAsync(id);
        return user;
    }
}