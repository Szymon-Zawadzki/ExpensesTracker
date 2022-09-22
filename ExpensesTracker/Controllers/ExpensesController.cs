using ExpensesTracker.Interfaces;
using ExpensesTracker.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Controllers
{
    [ApiController]
    [Route("api/expenses")]
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expencesService;

        public ExpensesController(IExpensesService expencesService)
        {
            _expencesService = expencesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExpensesDto>> GetAllExpenses()
        {
            var expenses = _expencesService.GetAll();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ExpensesDto>> GetExpensesById([FromRoute] int id)
        {
            var expensesById = _expencesService.GetById(id);

            if (expensesById is null)
            {
                return NotFound();
            }

            return Ok(expensesById);
        }

        [HttpPost]
        public ActionResult CreateExpenses([FromBody] CreateExpensesDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _expencesService.Create(dto);
            return Created($"/api/expenses/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult<UpdateExpensesDto> UpdateExpensesById([FromBody] UpdateExpensesDto dto,
                                                                                 [FromRoute] int id)
        {
            var expenseUpdate = _expencesService.Update(dto, id);

            if (expenseUpdate == null)
            {
                return NotFound();
            }

            return Ok(expenseUpdate);
        }

        [HttpDelete]
        public ActionResult<IEnumerable<ExpensesDto>> DelateAllExpenses()
        {
            var expenseDelete = _expencesService.Delete();
            return Ok(expenseDelete);
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<ExpensesDto>> DelateExpensesById([FromRoute] int id)
        {
            var expenseDeleteById = _expencesService.DeleteById(id);

            if (expenseDeleteById == null)
            {
                return NotFound();
            }

            return Ok(expenseDeleteById);
        }
    }
}
