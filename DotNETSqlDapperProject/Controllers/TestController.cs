using Microsoft.AspNetCore.Mvc;

namespace DotNETSqlDapperProject.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    //Premitive return type

    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }

    [HttpGet("Features")]

    public string[] GetFeatures()
    {
        string[] features = {"feature1", "feature2", "feature3"};
        return features;
    }

    [HttpGet("Features/{featureNumber}")]

    public string GetFeatureByNumber (int featureNumber)
    {
        string[] features = {"feature1", "feature2", "feature3"};

        if (featureNumber>= 0 && featureNumber<=2)
        {
            return features[featureNumber];
        }
        else 
        return "Not Found";

    }

    [HttpGet("Features1/{featureByActionResult}")]

    public IActionResult GetFeatureByNumberUsingIActionResult(int featureByActionResult)
    {
        string[] features = {"feature1", "feature2", "feature3"};

        if (featureByActionResult>= 0 && featureByActionResult<=2)
        {
            return Ok(features[featureByActionResult]);
        }
        else 
        return NotFound();
    }

}
