using Microsoft.AspNetCore.Mvc;

namespace dvcsa.Controllers;

[ApiController]
[Route("/.env")]
public class EnvController : ControllerBase
{
    [HttpGet(Name = "GetEnv")]
    public ActionResult<string> Get()
    {
       var envContent = """
                      DB_NAME=crapi
                      DB_USER=crapi
                      DB_PASSWORD=crapi
                      DB_HOST=postgresdb
                      DB_PORT=5432
                      SERVER_PORT=8080
                      MONGO_DB_HOST=mongodb
                      MONGO_DB_PORT=27017
                      MONGO_DB_USER=crapi
                      MONGO_DB_PASSWORD=crapi
                      MONGO_DB_NAME=crapi
                      """;
        Response.Headers.Add("Content-Disposition", "attachment; filename=env");
        return envContent;
    }
    
}