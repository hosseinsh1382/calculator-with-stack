using Calculator.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers;

[ApiController]
[Route("api/calculation")]
public class CalculationController:Controller
{
    private readonly ICalculationRepository _repository;

    public CalculationController(ICalculationRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Post(string input)
    {
        var result = _repository.Calculate(input);
        return Ok(result);
    }
}