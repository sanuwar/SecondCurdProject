using DotNETSqlDapperProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNETSqlDapperProject.Controllers;

[ApiController]
[Route("[Controller]")]

public class TestConnectionController: ControllerBase
{
    DataContextDapper _dapper;

    public TestConnectionController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }


    [HttpGet("TestConnection")]

    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }
    
}