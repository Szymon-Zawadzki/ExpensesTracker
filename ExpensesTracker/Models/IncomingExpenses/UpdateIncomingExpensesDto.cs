using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Models.IncomingExpenses
{
    public class UpdateIncomingExpensesDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
