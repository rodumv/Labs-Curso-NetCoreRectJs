using System;
using api.Context;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/testdatabase")]
  public class DummyController : ControllerBase
  {
    private MovieInfoContext _context;

    public DummyController(MovieInfoContext context)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IActionResult Testdatabase()
    {
      return Ok();
    }
  }
}