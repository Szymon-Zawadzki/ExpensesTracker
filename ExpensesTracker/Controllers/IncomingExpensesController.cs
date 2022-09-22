using ExpensesTracker.Interfaces;
using ExpensesTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Controllers
{
    [ApiController]
    [Route("api/expenses/incoming")]
    public class IncomingExpensesController : Controller
    {

        private readonly IIncomingExpensesService _incomingExpencesService;

        public IncomingExpensesController(IIncomingExpensesService incomingExpencesService)
        {
            _incomingExpencesService = incomingExpencesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IncomingExpensesDto>> GetAllExpenses()
        {
            var expenses = _incomingExpencesService.GetAll();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<IncomingExpensesDto>> GetExpensesById([FromRoute] int id)
        {
            var expensesById = _incomingExpencesService.GetById(id);

            if (expensesById is null)
            {
                return NotFound();
            }

            return Ok(expensesById);
        }

        [HttpPost]
        public ActionResult CreateExpenses([FromBody] CreateIncomingExpensesDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _incomingExpencesService.Create(dto);
            return Created($"/api/expenses/incoming/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult<UpdateIncomingExpensesDto> UpdateExpensesById([FromBody] UpdateIncomingExpensesDto dto,
                                                                                 [FromRoute] int id)
        {
            var expenseUpdate = _incomingExpencesService.Update(dto, id);

            if (expenseUpdate == null)
            {
                return NotFound();
            }

            return Ok(expenseUpdate);
        }

        [HttpDelete]
        public ActionResult<IEnumerable<IncomingExpensesDto>> DelateAllExpenses()
        {
            var expenseDelete = _incomingExpencesService.Delete();
            return Ok(expenseDelete);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<IncomingExpensesDto>> DelateExpensesById([FromRoute] int id)
        {
            var expenseDeleteById = _incomingExpencesService.DeleteById(id);

            if (expenseDeleteById == null)
            {
                return NotFound();
            }

            return Ok(expenseDeleteById);
        }
    }
}

