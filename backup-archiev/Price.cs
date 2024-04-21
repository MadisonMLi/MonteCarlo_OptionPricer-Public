namespace Catalog.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public double ClosingPrice { get; set; }
        public int InstrumentId { get; set; }
    
        public virtual Instrument Instrument { get; set; }
    }
}