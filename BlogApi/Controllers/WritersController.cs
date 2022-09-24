using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        IWriterService _writerService;

        public WritersController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _writerService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetWriterById(int id)
        {
            var result = _writerService.GetById(id);
            return Ok(result);
        }
        
        [HttpPost("add")]
        public IActionResult Add(Writer writer)
        {
            _writerService.Add(writer);
            return Ok(writer);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var deleteWriter = _writerService.GetById(id);
            _writerService.Delete(deleteWriter);
            return Ok(deleteWriter);
        }

        [HttpPut("update")]
        public IActionResult Update(Writer writer)
        {
            _writerService.Update(writer);
            return Ok(writer);
        }
    }
}
