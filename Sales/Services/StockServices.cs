using Sales.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sales.Services
{
    public class StockServices
    {
        public void AddStock(Stock stock)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
            }
        }

        public void DeleteStock(Stock stock)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Stocks.Attach(stock);
                db.Stocks.Remove(stock);
                db.SaveChanges();
            }
        }

        public int GetStocksNumer(string key)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Stocks.Where(w => w.Name.Contains(key)).Count();
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
                return db.Stocks.OrderBy(o => o.Name).ToList();
            }
        }

        public List<Stock> SearchStocks(string search, int page)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Stocks.Where(w => (w.Name).Contains(search)).OrderBy(o => o.Name).Skip((page - 1) * 17).Take(17).Include(c => c.Categories).ToList();
            }
        }
    }
}
