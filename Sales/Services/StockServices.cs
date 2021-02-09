using Sales.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sales.Services
{
    public class StockServices
    {
        public Stock AddStock(Stock stock)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
                return stock;
            }
        }

        public Stock DeleteStock(Stock stock)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Stocks.Attach(stock);
                db.Stocks.Remove(stock);
                db.SaveChanges();
                return stock;
            }
        }

        public Stock GetStock(string name)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Stocks.SingleOrDefault(s => s.Name == name);
            }
        }

        public List<string> GetStocksSuggetions()
        {
            using (SalesDB db = new SalesDB())
            {
                List<string> newData = new List<string>();
                var data = db.Stocks.OrderBy(o => o.Name).Select(s => new { s.Name }).ToList();
                foreach (var item in data)
                {
                    newData.Add(item.Name);
                }
                return newData;
            }
        }

        public List<Stock> GetStocks()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Stocks.OrderBy(o => o.Name).Include(c => c.Categories).ToList();
            }
        }
    }
}
