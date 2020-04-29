using System;

namespace Core.Entities
{
    public class Quote
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Quotation { get; set; }
        public DateTime TimeOfQuote { get; set; }
    }
}
