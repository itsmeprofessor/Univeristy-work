using Microsoft.AspNetCore.Mvc;
using RestfulApisWithRepositoryDesignPattern.Models.Entities;
using RestfulApisWithRepositoryDesignPattern.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulApisWithRepositoryDesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> repository;
        public UserController(IDataRepository<User> dataRepository)
        {
            this.repository = dataRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}",Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = repository.GetById(id);
            if (user == null)
            {
                return NotFound("Data Not Found.");
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Data not Sent");
            }
            repository.Add(user);
            return CreatedAtRoute(
                "Get",
                new { Id = user.Id },
                user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Data not Sent");
            }
            var dbUser = repository.GetById(id);
            if (dbUser == null)
            {
                return NotFound("Data Not Found.");
            }
            repository.Update(dbUser, user);
            return Ok(dbUser);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dbUser = repository.GetById(id);
            if (dbUser == null)
            {
                return NotFound("Data Not Found.");
            }
            repository.Delete(dbUser);
            return NoContent();
        }
    }
}
