﻿using AutoMapper;
using ExpensesTracker.Entities;
using ExpensesTracker.Models.Expenses;
using ExpensesTracker.Models.IncomingExpenses;

namespace ExpensesTracker
{
    public class ExpensesMappingProfile : Profile
    {
        public ExpensesMappingProfile()
        {
            CreateMap<UpdateExpensesDto, Expenses>();
            CreateMap<Expenses, ExpensesDto>();
            CreateMap<CreateExpensesDto, Expenses>();

            CreateMap<UpdateIncomingExpensesDto, IncomingExpenses>();
            CreateMap<IncomingExpenses, IncomingExpensesDto>();
            CreateMap<CreateIncomingExpensesDto, IncomingExpenses>();
        }
    }
}
