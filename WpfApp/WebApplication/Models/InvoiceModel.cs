namespace WebApplication.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public decimal IGV { get; set; }
    }
}
