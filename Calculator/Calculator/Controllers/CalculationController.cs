using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers;

[ApiController]
[Route("api/calculation")]
public class CalculationController:Controller
{
     
    
    [HttpPost]
    public IActionResult Post(string input)
    {
        return Ok();
    }
}