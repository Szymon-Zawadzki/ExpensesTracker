namespace ExpensesTracker.Entities
{
    public class IncomingExpenses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime DateTime { get; set; }

        public int ExpensesId { get; set; }
    }
}
