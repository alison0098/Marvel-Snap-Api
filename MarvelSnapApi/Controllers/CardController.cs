using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarvelSnapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private static List<Card> cards = new List<Card>
            {
                new Card
                {
                    Id = 1, Name = "Doctor Octopus",
                    Text = "On Reveal: Pull 4 random cards from your opponent's hand to their side of this location.",
                    Cost = 5,
                    Power = 10,
                    Image = "imagem1.jpg"
                }
            };
        private readonly DataContext _context;

        public CardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Card>>> Get()
        {

            return Ok(cards);
        }

        [HttpPost]
        public async Task<ActionResult<List<Card>>> AddCard(Card card)
        {
            cards.Add(card);
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Card>>> GetCard(int id)
        {
            var filtered = cards.Find(x => x.Id == id);

            if (filtered == null)
            {
                return BadRequest("Card not found!");
            }

            return Ok(filtered);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Card>>> UpdateCard(Card card)
        {
            var filtered = cards.Find(x => x.Id == card.Id);

            if (filtered == null)
            {
                return BadRequest("Card not found!");
            }

            filtered.Id = card.Id;
            filtered.Name = card.Name;
            filtered.Text = card.Text;
            filtered.Power = card.Power;
            filtered.Cost = card.Cost;
            filtered.Image = card.Image;


            return Ok(filtered);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Card>>> DeleteCard(int id)
        {
            var filtered = cards.Find(x => x.Id == id);

            if (filtered == null)
            {
                return BadRequest("Card not found!");
            }

            cards.Remove(filtered);

            return Ok(cards);
        }

    }
}
