using Microsoft.AspNetCore.Mvc;

namespace dvcsa.Controllers;

[ApiController]
[Route("/api/.[controller]")]
public class EnvController : ControllerBase
{
    [HttpGet(Name = "GetEnv")]
    public ActionResult<string> Get()
    {
       var envContent = """
                      DB_NAME=dvcsa
                      DB_USER=dvcsa
                      DB_PASSWORD=dvcsa
                      """;
        Response.Headers.Add("Content-Disposition", "attachment; filename=env");
        return envContent;
    }
    
}