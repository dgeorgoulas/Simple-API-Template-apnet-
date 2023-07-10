using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TESTHTTP.Models;
using TESTHTTP.Data;
namespace TESTHTTP.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        private readonly DataContext _context;

        public ArtistsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/artists
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> GetArtists()
        {
            return Ok(_context.Artists);
        }

        // GET: api/artists/{id}
        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtist(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // POST: api/artists
        [HttpPost]
        public ActionResult<Artist> CreateArtist(Artist artist)
        {
            artist.Id = _context.Artists.Count + 1;
            _context.Artists.Add(artist);
            return CreatedAtAction(nameof(GetArtist), new { id = artist.Id }, artist);
        }

        // PUT: api/artists/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateArtist(int id, Artist artist)
        {
            var existingArtist = _context.Artists.FirstOrDefault(a => a.Id == id);
            if (existingArtist == null)
            {
                return NotFound();
            }

            existingArtist.Name = artist.Name;
            existingArtist.Genre = artist.Genre;
            existingArtist.Country = artist.Country;

            return NoContent();
        }

        // DELETE: api/artists/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);

            return NoContent();
        }
    }
}
