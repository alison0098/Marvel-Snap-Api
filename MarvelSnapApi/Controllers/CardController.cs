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
    }
}
