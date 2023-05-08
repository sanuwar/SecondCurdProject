using DotNETSqlDapperProject.Data;
using DotNETSqlDapperProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotNETSqlDapperProject.Controllers;
[ApiController]
[Route("[Controller]")]

public class CountryController : ControllerBase
{
    DataContextDapper _dapper;

    public CountryController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }


    [HttpGet("GetCounties")]
    public IEnumerable<Country> GetCountries()
    {
        string sql = @"SELECT
	        [CountryId],
	        [CountryName],
	        [IsDemocracy],
	        [PopulationInMillion]
        FROM WebAPIDapperSchema.Country";
        IEnumerable<Country> countries = _dapper.LoadData<Country>(sql);
        return countries;
    }

    [HttpGet("GetSingleCountry/{countryId}")]

    public Country GetSingleCountry(int countryId)
    {
        string sql = @"SELECT
	        [CountryId],
	        [CountryName],
	        [IsDemocracy],
	        [PopulationInMillion]
        FROM WebAPIDapperSchema.Country
        WHERE CountryId =" + countryId.ToString();
        Country country = _dapper.LoadDataSingle<Country>(sql);
        return country;
    }

    [HttpPut("EditCountry")]

    public IActionResult EditCounty(Country country)
    {
        string sql = @"UPDATE WebAPIDapperSchema.Country
	    SET 
	        [CountryName]='" + country.CountryName + 
	        "', [IsDemocracy] ='" + country.IsDemocracy +
	        "', [PopulationInMillion]= "+ country.PopulationInMillion +
	    "WHERE CountryId =" + country.CountryId;

        Console.WriteLine (sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } else throw new Exception("Failed to update data");
    }

    [HttpPost("AddCountry")]

    public IActionResult AddCountry(Country country)
    {
        string sql =@"INSERT WebAPIDapperSchema.Country
	    (
	        [CountryName],
	        [IsDemocracy],
	        [PopulationInMillion]
	    ) 
        VALUES
	    ('" +
	        country.CountryName + 
            "','" + country.IsDemocracy + 
	        "'," + country.PopulationInMillion +
	        ")";
	

        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } else throw new Exception("Failed to add data");
    }

    [HttpDelete("DeleteCountry/{countryId}")]

    public IActionResult DeleteCountry(int countryId)
    {
        string sql = @"DELETE FROM WebAPIDapperSchema.Country 
            WHERE CountryId=" + countryId.ToString();

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        } else throw new Exception("Failed to Delete data");

    }

}