using LocadoraAPI.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocadoraAPI.Controllers
{
    [Route("api/rent")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly  RentDbContext _context;
        public RentController(RentDbContext context)
        {
            _context = context;
        }

        // GET: api/<LocadoraController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var rent = _context.Rents.ToList();
                
            return Ok(rent);
        }

        // GET api/<LocadoraController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var rent = _context.Rents.SingleOrDefault(d => d.Id == id);

            if(rent == null)
            {
                return NotFound();
            }
            return Ok(rent);
            
        }

        // POST api/<LocadoraController>
        [HttpPost]
        public IActionResult Post(Rent rent)
        {
            _context.Rents.Add(rent);

            return CreatedAtAction(nameof(GetById), new {id = rent.Id, rent});
        }

        // PUT api/<LocadoraController>/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Rent input)
        {
            var rent = _context.Rents.SingleOrDefault(d => d.Id == id);

            if (rent == null)
            {
                return NotFound();
            }
            rent.Update(input.Vehicle, input.StartDate, input.EndDate, input.Price);

            return NoContent();
        }

        // DELETE api/<LocadoraController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rent = _context.Rents.SingleOrDefault(d => d.Id == id);

            if (rent == null)
            {
                return NotFound();
            }
            _context.Rents.Remove(rent);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult ChangeStatus(Guid id, bool status)
        {
            var rent = _context.Rents.SingleOrDefault(d => d.Id == id);

            if (rent == null)
            {
                return NotFound();
            }
            rent.ChangeStatus(status);
            return NoContent();
        }
    }
}
