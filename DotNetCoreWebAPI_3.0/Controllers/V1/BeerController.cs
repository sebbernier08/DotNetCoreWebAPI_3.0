using DotNetCoreWebAPI_3._0.DTO;
using DotNetCoreWebAPI_3._0.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI_3._0.Controllers.V1
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet]
        public ActionResult<BeerDTO> GetAll()
        {
            return Ok(_beerService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BeerDTO> GetItem(long id)
        {
            return Ok(_beerService.GetOneBy(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult Create([FromBody]BeerDTO beer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model");

            _beerService.Save(beer);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]BeerDTO beer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model");

            _beerService.Save(beer);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _beerService.Delete(id);

            return Ok();
        }
    }
}