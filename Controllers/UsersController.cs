using dvcsa.Db;
using dvcsa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dvcsa.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly ILogger<UsersController> _logger;
    private readonly GenericContext _context;

    public UsersController(ILogger<UsersController> logger, GenericContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("", Name = "GetUserByName")]
    public ActionResult<User?> Get(string name)
    {
        try
        {
            return _context.Set<User>().FromSqlRaw($"SELECT * FROM Users WHERE Users.Name = '{name}'").FirstOrDefault();
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost(Name = "CreateUser")]
    public ActionResult<User> Post(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtRoute("CreateUser", new { id = user.Id }, user);
    }
}
