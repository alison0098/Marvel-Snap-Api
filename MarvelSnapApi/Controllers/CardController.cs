using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarvelSnapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly DataContext _context;

        public CardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Card>>> Get()
        {

            return Ok(await _context.Cards.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Card>>> AddCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cards.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var filtered = await _context.Cards.FindAsync(id);

            if (filtered == null)
            {
                return BadRequest("Card not found!");
            }

            return Ok(filtered);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Card>>> UpdateCard(Card request)
        {
            var dbCard = await _context.Cards.FindAsync(request.Id);

            if (dbCard == null)
            {
                return BadRequest("Card not found!");
            }

            dbCard.Id = request.Id;
            dbCard.Name = request.Name;
            dbCard.Text = request.Text;
            dbCard.Power = request.Power;
            dbCard.Cost = request.Cost;
            dbCard.Image = request.Image;

            await _context.SaveChangesAsync();
            return Ok(await _context.Cards.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Card>>> DeleteCard(int id)
        {
            var dbCard = await _context.Cards.FindAsync(id);

            if (dbCard == null)
            {
                return BadRequest("Card not found!");
            }

            _context.Cards.Remove(dbCard);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cards.ToListAsync());
        }

    }
}
