using ExpensesTracker.Interfaces;
using ExpensesTracker.Models.Resource;
using Microsoft.AspNetCore.Mvc;


namespace ExpensesTracker.Controllers
{
    [ApiController]
    [Route("api/resource")]
    public class ResourceController : Controller
    {
        private readonly IResourceServices _resourceService;

        public ResourceController(IResourceServices reourceService)
        {
            _resourceService = reourceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResourceDto>> GetAllResources()
        {
            var resource = _resourceService.GetAll();
            return Ok(resource);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ResourceDto>> GetResourceById([FromRoute] int id)
        {
            var resourceById = _resourceService.GetById(id);

            if (resourceById is null)
            {
                return NotFound();
            }

            return Ok(resourceById);
        }

        [HttpPost]
        public ActionResult CreateResource([FromBody] CreateResourceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _resourceService.Create(dto);
            return Created($"/api/expenses/incoming/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult<UpdateResourceDto> UpdateResourceById([FromBody] UpdateResourceDto dto,
                                                                                 [FromRoute] int id)
        {
            var resourceUpdate = _resourceService.Update(dto, id);

            if (resourceUpdate == null)
            {
                return NotFound();
            }

            return Ok(resourceUpdate);
        }

        [HttpDelete]
        public ActionResult<IEnumerable<ResourceDto>> DelateAllResources()
        {
            var resourceDelete = _resourceService.Delete();
            return Ok(resourceDelete);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<ResourceDto>> DelateResourcesById([FromRoute] int id)
        {
            var resourceDeleteById = _resourceService.DeleteById(id);

            if (resourceDeleteById == null)
            {
                return NotFound();
            }

            return Ok(resourceDeleteById);
        }
    }
}

