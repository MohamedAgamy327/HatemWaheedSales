using Sales.Models;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Services
{
    public class SpendingServices
    {
        public Spending AddSpending(Spending spending)
        {
            using (SalesDB db = new SalesDB())
            {
                spending = db.Spendings.Add(spending);
                db.SaveChanges();
                return spending;
            }
        }

        public void DeleteSpending(Spending spending)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Spendings.Attach(spending);
                db.Spendings.Remove(spending);
                db.SaveChanges();
            }
        }

        public Spending GetLastSpending()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Spendings.OrderByDescending(o => o.RegistrationDate).FirstOrDefault();
            }
        }

        public List<string> GetStatementSuggetions()
        {
            using (SalesDB db = new SalesDB())
            {
                List<string> newData = new List<string>();
                var data = db.Spendings.OrderBy(o => o.Statement).Select(s => new { s.Statement }).Distinct().ToList();
                foreach (var item in data)
                {
                    newData.Add(item.Statement);
                }
                return newData;
            }
        }

        public List<Spending> GetSpendings()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Spendings.AsNoTracking().Where(c => c.RegistrationDate.Year == MainViewModel.Year).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }

        public List<Spending> GetSpendings(DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Spendings.Where(w => w.Date >= dtFrom && w.Date <= dtTo).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }


    }
}
