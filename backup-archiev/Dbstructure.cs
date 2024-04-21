using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using Npgsql;
// allows us to interact with SQL

namespace datastruct
{
    public static void FinancialInstrument(int id, string exchange)
    {
        var db = new FinanceContext();
            
        db.Add(new FinancialInstrument{
            Id = Id,
            Exchange = exchange,
        });

        db.SaveChanges();

    }

    public static void Rate(int id, double term_in_years, DateTime meaure_date, double rate)
    {
        db.Add(new Rate{
        Id = rate_id,
        term_in_years = rate_term, 
        measure_date = rate_date,
        rate = our_rate,
        });
        
        db.SaveChanges();

    }

           
    public static void HistoricalPrice(int Id, double prices, int inst_id, double close_price)
    {
        db.Add(new HistoricalPrice{
            Id = price_id,
            Date = his_date,
            inst_id = instrument_id,
            close_price = our_closing_price
        });
        
        db.SaveChanges();
    }

    public static void Underlying(int Id, string Name, string Symbol, double close_price)
    {
        db.Add(new Underlying{
        Id = udl_id,
        Name = Underlying_name, 
        Symbol = udl_symbol,
        close_price = udl_closePrice,
        });
            
        db.SaveChanges();

    }
    public static void Option (int Id, int Option_Under , DateTime Expiration)
    {
        db.Add(new Option{
            Id = Option_Id,
            Option_Under = our_underlying.Id,
            Expiration = Option_expiration,
        });
            
        db.SaveChanges();

    }
    public static void European (double Strike, Boolean Is_Call )
    {
        
        db.Add(new European{
            Strike = our_strike,
            Is_Call = iscall,
        });
        db.SaveChanges();

    }

    public static void EurDigital  (double Strike, Boolean Is_Call, double Payout )
    {
        db.Add(new Digital{
            Strike = our_strike,
            Is_Call = iscall,
            Payout = payout,
        });
        db.SaveChanges();
    }

    public static void Asian  (double Strike, Boolean Is_Call)
    {
        db.Add(new Asian{
            Strike = our_strike,
            Is_Call = iscall,
        });
        db.SaveChanges();

    }

    public static void Lookback  (double Strike, Boolean Is_Call )
    {
        db.Add(new Lookback{
        Strike = our_strike,
        Is_Call = iscall,
        });
        db.SaveChanges();
    }

    public static void Barrier  (double Strike, Boolean Is_Call, double Barrier_Level, string Knock_Type)
        
    {

        db.Add(new Barrier{
        Strike = our_strike,
        Is_Call = iscall,
        Barrier_Level = our_barrier_level,
        Knock_Type = knock_num,

        });

        db.SaveChanges();

    }



    

        
         

        public class FinanceContext : DbContext
        {
            // public DbSet<Exchange> Exchages { get; set;}
            // public DbSet<Market> Markets {get;set;}
            // public DbSet<Unit> Units {get;set;}
            public DbSet<FinancialInstrument> FinancialInstruments {get;set;}
            public DbSet<Rate> Rate {get;set;}
            public DbSet<Historical_price> HistoricalPrice {get;set;}
            public DbSet<Underlying> Underlyings {get; set;}
            public DbSet<Option> Options {get;set;}
            public DbSet<European> EuropeanOptions {get;set;}
            public DbSet<Digital> DigitalOptions {get;set;}
            public DbSet<Asian> AsianOptions {get;set;}
            public DbSet<Lookback> LookbackOptions {get;set;}
            public DbSet<Range> RangeOptions {get;set;}
            public DbSet<Barrier> BarrierOptions{get;set;}
            public DbSet<Trade> Trades{get;set;}
            public DbSet<Option_Trade_Evaluation> OptionTradeEvaluations{get;set;}

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                            =>optionsBuilder.UseNpgsql("host=localhost;Database=student_db;Username=admin;Password=secret");
        }





        [Table("Rate")]
        public class Rate
        {
            public int Id{get;set;}
            public DateTime measure_date {get;set;} // put into historical price?
            public double term_in_years {get;set;}
            public double rate {get;set;}
            
        }

        [Table("HistoricalPrice")]
        public class HistoricalPrice
        {
            public int Id{get;set;}
            public List<double> close_prices {get;set;}
            public int inst_id {get;set;} //instrument Id, locate a list of price to certain instruments(option, stock, future.etc)
            public DateTime date {get;set;} //underlying price
            
        }

        [Table("FinancialInstrument")]
        public class FinancialInstrument
        {   
            public int Id{get;set;}
            public string Exchange {get;set;} //exhange market

        }

        [Table("Underlying")]

        public class Underlying : FinancialInstrument
        {
            // market underlying_market{get;set;}
            public int Id{get;set;}
            public string Name {get;set;}
            public string Symbol {get;set;}
            public Historical_price close_price {get;set;} 
            //the underlying price is the closing price of the day(from historical price)
        }
        [Table("Option")]
        public class Option: FinancialInstrument
        {
            public int Id{get;set;}
            public Underlying Option_Under {get;set;}
            // double imp_volatility {get;set;}
            public DateTime Expiration {get; set;}
            
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
            public bool Is_Call {get; set;}
            public double Payout {get; set;}
        }
        [Table("Asian")]
        public class Asian : Option
        {
            public double Strike {get; set;}
            public bool Is_Call {get; set;}
        }
        [Table("Range")]
        public class Range : Option
        {
            // Nothing here, dawg.
        }
        [Table("Lookback")]
        public class Lookback : Option
        {
            public double Strike {get; set;}
            public bool Is_Call {get; set;}
        }

        enum KnockType
        {
            DownAndOut,
            UpandOut,
            DownAndIn,
            UpAndIn
        }
        [Table("Barrier")]
        public class Barrier : Option
        {
            public double Strike {get; set;}
            public bool Is_Call {get; set;}
            public double Barrier_Level {get; set;}
            KnockType Knock_Type {get; set;}
        }
        [Table("Trade")]
        public class Trade
        {  
            public int Id {get;set;}
            public Boolean Is_Buy {get;set;}
            public double Trade_Amount {get;set;} // change to quantity
            public Underlying Trade_Underlying {get;set;}
            public double Trade_Price {get;set;}
        }
        [Table("OptionTradeEvaluation")]
        public class Option_Trade_Evaluation
        {
            public int Id {get;set;}
            
            // double standard_error {get; set;}
            // Monte Carlo evals. an instrument; not a trade.
            // public double Unrealized_Pnl {get; set;} // different from market value; refer to trade price
            public double Delta {get; set;}
            public double Gamma {get; set;}
            public double Vega {get; set;}
            public double Rho {get; set;}
            public double Theta {get; set;}


        }



        
    
}


