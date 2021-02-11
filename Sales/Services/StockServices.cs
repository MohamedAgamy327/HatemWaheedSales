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

        public bool IsExistInCategories(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Categories.Any(s => s.StockID == id);
            }
        }

        public List<Stock> GetStocks()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Stocks.OrderBy(o => o.Name).ToList();
            }
        }
    }
}
