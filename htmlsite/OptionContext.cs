namespace OptionDatabase;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Npgsql;

public class FinanceContext : DbContext
{
    public DbSet<Exchange> Exchanges { get; set; }
    public DbSet<TradingMarket> Markets { get; set; }
    // public DbSet<Unit> Unit {get;set;}
    public DbSet<FinancialInstrument> FinancialInstruments {get;set;}

    public DbSet<Underlying> Underlyings {get; set;}
    public DbSet<Option> Options {get;set;}
    public DbSet<European> Europeans {get;set;}
    public DbSet<Digital> DigitalOptions {get;set;}
    public DbSet<Asian> AsianOptions {get;set;}
    public DbSet<Lookback> LookbackOptions {get;set;}
    public DbSet<Range> RangeOptions {get;set;}
    public DbSet<Barrier> BarrierOptions{get;set;}
    public DbSet<Trade> Trades{get;set;}
    public DbSet<Option_Trade_Evaluation> OptionTradeEvaluations{get;set;}

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder.UseNpgsql("host=localhost;Database=OptionEval;Username=root;Password=root");
}

public class Exchange
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public virtual ICollection<TradingMarket>? Markets { get; set; }

}

public class TradingMarket
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int ExchangeId { get; set; }
    public virtual Exchange? Exchange { get; set; }
}


[Table("FinancialInstrument")]
public class FinancialInstrument
{   
    public int FinancialInstrumentID{get;set;}
    public string Name {get;set;}
    public string Symbol {get;set;}
    public int TradingMarketId {get;set;}
    public TradingMarket? market {get;set;}
    public double price {get;set;}
  
}



// //ratepoint = new ratepoint{}
[Table("Underlying")]
public class Underlying : FinancialInstrument{
    
}

  

[Table("Option")]
public class Option: FinancialInstrument
{
    public double volatility {get;set;}
    public double expireIn {get; set;}
    public int underlyingId {get; set;}
    public Underlying? underlying {get; set;}

    //internal double EuropeanCall(long numberOfPath, double tenor, double mu, double sigma, double underlyingPrice, double strike, double rate, double[,] price)
    //{
    //    throw new NotImplementedException();
    //}
}

[Table("European")]

public class European : Option
{
    public double Strike {get; set;}
    public bool Is_Call {get; set;}
}

[Table("Digital")]

public class Digital : Option
{
    public double Strike {get; set;}
    public Boolean Is_Call {get; set;}
    public double Payout {get; set;}
}

[Table("Asian")]
public class Asian : Option
{
    public double Strike {get; set;}
    public Boolean Is_Call {get; set;}
}
[Table("Range")]
public class Range : Option
{
}

[Table("Lookback")]
public class Lookback : Option
{
    public double Strike {get; set;}
    public Boolean Is_Call {get; set;}
}

[Table("Barrier")]
public class Barrier : Option
{
    public double Strike {get; set;}
    public Boolean Is_Call {get; set;}
    public double Barrier_Level {get; set;}
    public string Knock_Type {get; set;}
}

[Table("Trade")]
public class Trade
{  
    public int Id {get;set;}
    public double quantity {get;set;} // change to quantity, dont need is buy
    public int FinancialInstrumentId {get;set;}
    public FinancialInstrument? financialInstrument {get;set;}
    public double Trade_Price {get;set;} // price it was traded at
    public int EvaluationId {get;set;}
    public Option_Trade_Evaluation Evaluation {get;set;}
}

[Table("OptionTradeEvaluation")]
public class Option_Trade_Evaluation
{
    public int Id {get;set;}
    public double Unrealized_Pnl {get; set;} // different from market value; refer to trade price
    public double Delta {get; set;}
    public double Gamma {get; set;}
    public double Vega {get; set;}
    public double Rho {get; set;}
    public double Theta {get; set;}
}


