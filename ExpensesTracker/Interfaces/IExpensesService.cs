using ExpensesTracker.Models.Expenses;

namespace ExpensesTracker.Interfaces
{
    public interface IExpensesService
    {
        IEnumerable<ExpensesDto> GetAll();
        ExpensesDto GetById(int id);
        string Create(CreateExpensesDto dto);
        string Update(UpdateExpensesDto dto, int id);
        string DeleteById(int id);
        string Delete();
    }
}
