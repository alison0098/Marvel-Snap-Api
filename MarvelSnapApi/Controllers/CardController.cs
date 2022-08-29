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
                    Power = 10
                }
            };

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
    }
}
