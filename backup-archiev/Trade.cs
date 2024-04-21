namespace Catalog.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public bool IsBuy { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public System.DateTime Timestamp { get; set; }
        public int InstrumentId { get; set; }
    
        public virtual Instrument Instrument { get; set; }
    }
}