namespace Catalog.Entities
{
    public class Instrument
    {
        public Instrument()
        {
            this.Trades = new HashSet<Trade>();
            this.Prices = new HashSet<Price>();
        }
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Exchange { get; set; }
        public string Underlying { get; set; }
        public int InstTypeId { get; set; }
        public string CompanyName { get; set; }
        public Nullable<bool> IsCall { get; set; }
        public Nullable<double> Strike { get; set; }
        public Nullable<double> Tenor { get; set; }
        public Nullable<double> Rebate { get; set; }
        public Nullable<double> Barrier { get; set; }
        public string BarrierType { get; set; }
    
        public virtual InstType InstType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trade> Trades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }

    }
}