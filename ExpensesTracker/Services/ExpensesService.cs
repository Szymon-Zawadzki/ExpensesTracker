using AutoMapper;
using ExpensesTracker.Entities;
using ExpensesTracker.Interfaces;
using ExpensesTracker.Models.Expenses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExpensesTracker.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly ExpensesDbContext _expensesDbContext;
        private readonly IMapper _mapper;
        public ExpensesService(ExpensesDbContext expensesDbContext, IMapper mapper)
        {
            _expensesDbContext = expensesDbContext;
            _mapper = mapper;
        }

        public IEnumerable<ExpensesDto> GetAll()
        {
            var expenses = _expensesDbContext
                .Expenses.ToList();
            var expensesDto = _mapper.Map<List<ExpensesDto>>(expenses);
            expensesDto.Sort(delegate(ExpensesDto x, ExpensesDto y) {
                return x.DateTime.CompareTo(y.DateTime);
            });
            return expensesDto;
        }

        public ExpensesDto GetById(int id)
        {
            var expenses = _expensesDbContext
                .Expenses.FirstOrDefault(r => r.Id == id);

            if (expenses == null)
            {
                return null;
            }

            var expensesDto = _mapper.Map<ExpensesDto>(expenses);
            return expensesDto;
        }

        public string Create(CreateExpensesDto dto)
        {
            var expenses = _mapper.Map<Expenses>(dto);
            _expensesDbContext.Expenses.Add(expenses);
            _expensesDbContext.SaveChanges();

            return ("Expenses has been added correctly");
        }

        public string DeleteById(int id)
        {
            var expenses = _expensesDbContext
                .Expenses
                .FirstOrDefault(r => r.Id == id);

            if (expenses == null)
            {
                return null;
            }

            _expensesDbContext.Expenses.Remove(expenses);
            _expensesDbContext.SaveChanges();

            return ("Expense have been removed correctly");
        }

        public string Delete()
        {
            var expenses = _expensesDbContext
                .Expenses.ToList();

            if (expenses == null)
            {
                return null;
            }

            _expensesDbContext.Expenses.RemoveRange(expenses);
            _expensesDbContext.SaveChanges();

            return ("All Expenses has been removed correctly");
        }

        public string Update(UpdateExpensesDto dto, int id)
        {
            var expenses = _expensesDbContext
               .Expenses
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
            _expensesDbContext.SaveChanges();
            }

            return ("Expanse have been updated correctly");
        }
    }
}
