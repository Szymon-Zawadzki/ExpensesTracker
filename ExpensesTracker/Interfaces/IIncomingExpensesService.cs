using ExpensesTracker.Models;

namespace ExpensesTracker.Interfaces
{
    public interface IIncomingExpensesService
    {
        IEnumerable<IncomingExpensesDto> GetAll();
        IncomingExpensesDto GetById(int id);
        string Create(CreateIncomingExpensesDto dto);
        string Update(UpdateIncomingExpensesDto dto, int id);
        string DeleteById(int id);
        string Delete();
    }
}
