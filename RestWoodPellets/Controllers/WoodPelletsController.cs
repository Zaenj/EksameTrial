using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WoodPelletsLib;

namespace RestWoodPellets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WoodPelletController : ControllerBase
    {
        private readonly WoodPelletRepository woodPelletRepository;

        public WoodPelletController(WoodPelletRepository repository)
        {
            woodPelletRepository = repository;
        }

        // GET: api/WoodPellet
        [HttpGet]
        public IActionResult GetAll()
        {
            List<WoodPellet> allWoodPellets = woodPelletRepository.GetWoodPellets();
            return Ok(allWoodPellets); // Return 200 OK with the data
        }

        // GET api/WoodPellet/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            WoodPellet pellet = woodPelletRepository.GetById(id);
            if (pellet == null)
            {
                return NotFound(); // 404 Not Found if the pellet doesn't exist
            }
            return Ok(pellet); // Return 200 OK with the pellet data
        }

        // POST api/WoodPellet
        [HttpPost]
        public IActionResult Add([FromBody] WoodPellet pellet)
        {
            if (pellet == null)
            {
                return BadRequest(); // 400 Bad Request if the pellet is null
            }

            woodPelletRepository.Add(pellet);
            return CreatedAtAction(nameof(GetById), new { id = pellet.Id }, pellet); // Return 201 Created
        }

        // PUT api/WoodPellet/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] WoodPellet pellet)
        {
            if (id != pellet.Id)
            {
                return BadRequest(); // 400 Bad Request if IDs don't match
            }

            if (woodPelletRepository.GetById(id) == null)
            {
                return NotFound(); // 404 Not Found if the pellet doesn't exist
            }

            woodPelletRepository.Update(id, pellet);
            return NoContent(); // 204 No Content
        }
    }
}