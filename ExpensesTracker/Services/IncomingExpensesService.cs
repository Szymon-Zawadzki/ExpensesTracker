using AutoMapper;
using ExpensesTracker.Entities;
using ExpensesTracker.Interfaces;
using ExpensesTracker.Models.IncomingExpenses;

namespace ExpensesTracker.Services
{
    public class IncomingExpensesService : IIncomingExpensesService
    {
        private readonly ExpensesDbContext _incomingExpensesDbContext;
        private readonly IMapper _mapper;
        public IncomingExpensesService(ExpensesDbContext incomingExpensesDbContext, IMapper mapper)
        {
            _incomingExpensesDbContext = incomingExpensesDbContext;
            _mapper = mapper;
        }

        public IEnumerable<IncomingExpensesDto> GetAll()
        {
            var expenses = _incomingExpensesDbContext
                .IncomingExpenses.ToList();
            var expensesDto = _mapper.Map<List<IncomingExpensesDto>>(expenses);
            expensesDto.Sort(delegate (IncomingExpensesDto x, IncomingExpensesDto y) {
                return x.DateTime.CompareTo(y.DateTime);
            });
            return expensesDto;
        }

        public IncomingExpensesDto GetById(int id)
        {
            var expenses = _incomingExpensesDbContext
                .IncomingExpenses.FirstOrDefault(r => r.Id == id);

            if (expenses == null)
            {
                return null;
            }

            var expensesDto = _mapper.Map<IncomingExpensesDto>(expenses);
            return expensesDto;
        }

        public string Create(CreateIncomingExpensesDto dto)
        {
            var expenses = _mapper.Map<IncomingExpenses>(dto);
            _incomingExpensesDbContext.IncomingExpenses.Add(expenses);
            _incomingExpensesDbContext.SaveChanges();

            return ("Expenses has been added correctly");
        }

        public string DeleteById(int id)
        {
            var expenses = _incomingExpensesDbContext
                .IncomingExpenses
                .FirstOrDefault(r => r.Id == id);

            if (expenses == null)
            {
                return null;
            }

            _incomingExpensesDbContext.IncomingExpenses.Remove(expenses);
            _incomingExpensesDbContext.SaveChanges();

            return ("Expense have been removed correctly");
        }

        public string Delete()
        {
            var expenses = _incomingExpensesDbContext
                .IncomingExpenses.ToList();

            if (expenses == null)
            {
                return null;
            }

            _incomingExpensesDbContext.IncomingExpenses.RemoveRange(expenses);
            _incomingExpensesDbContext.SaveChanges();

            return ("All Expenses has been removed correctly");
        }

        public string Update(UpdateIncomingExpensesDto dto, int id)
        {
            var expenses = _incomingExpensesDbContext
               .IncomingExpenses
               .FirstOrDefault(r => r.Id == id);

            if (expenses == null)
            {
                return null;
            }

            if (dto.DateTime != null)
            {
                expenses.DateTime = dto.DateTime;
            }
            if (dto.Name != "string")
            {
                expenses.Name = dto.Name;
            }
            if (dto.Description != "string")
            {
                expenses.Description = dto.Description;
            }
            if (dto.Price != 0)
            {
                expenses.Price = dto.Price;
                _incomingExpensesDbContext.SaveChanges();
            }

            return ("Expanse have been updated correctly");
        }
    }
}

