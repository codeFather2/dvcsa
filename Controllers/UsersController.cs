using System.Text.Encodings.Web;
using dvcsa.Db;
using dvcsa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dvcsa.Controllers;

[ApiController]
[Route("/[controller]")]
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
            // var user = _context.Set<User>().FromSqlRaw($"SELECT * FROM Users WHERE Users.Name = '{name}'").FirstOrDefault();
            // to avoid SQLI use parameters (or EF methods)
            var user = _context.Set<User>().FromSqlRaw("SELECT * FROM Users WHERE Users.Name = {0}", name).FirstOrDefault();
            if (user == null)
            {
                return NotFound($"User {name} not found");
            }
            return Ok(user);
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
    
    [HttpGet("search", Name = "SearchForUser")]
    public ActionResult<string> SearchForUser(string name)
    {
        var user = _context.Users.FirstOrDefault(u => u.Name == name);
        if (user == null)
        {
            // return Content($"<p>User {name} not found</p>", "text/html");
            var encodedName = UrlEncoder.Default.Encode(name);
            return Content($"<p>User {encodedName} not found</p>", "text/html");
        }
        return Ok($"Name: {user.Name} - Password: {user.Password}");
    }
}
