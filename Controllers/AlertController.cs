using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AlertApi.Models;
using System.Linq;

namespace AlertApi.Controllers
{
    [Route("api/alert")]
    public class AlertController : Controller
    {
        private readonly AlertContext _context;

        public AlertController(AlertContext context)
        {
            _context = context;

            if (_context.AlertItems.Count() == 0)
            {
                _context.AlertItems.Add(new AlertItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<AlertItem> GetAll()
        {
            return _context.AlertItems.ToList();
        }

        [HttpGet("{id}", Name = "GetAlert")]
        public IActionResult GetById(long id)
        {
            var item = _context.AlertItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AlertItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.AlertItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAlert", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] AlertItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var alert = _context.AlertItems.FirstOrDefault(t => t.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            alert.IsComplete = item.IsComplete;
            alert.Name = item.Name;

            _context.AlertItems.Update(alert);
            _context.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var alert = _context.AlertItems.First(t => t.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            _context.AlertItems.Remove(alert);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}