using Sales.Models;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Services
{
    public class SafeServices
    {
        public void AddSafe(Safe safe)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Safes.Add(safe);
                db.SaveChanges();
            }
        }

        public void DeleteSafe(Safe safe)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Safes.Attach(safe);
                db.Safes.Remove(safe);
                db.SaveChanges();
            }
        }

        public void DeleteSafe(DateTime dt)
        {
            using (SalesDB db = new SalesDB())
            {
                var safe = db.Safes.SingleOrDefault(s => s.RegistrationDate == dt);
                if (safe != null)
                {
                    db.Safes.Attach(safe);
                    db.Safes.Remove(safe);
                    db.SaveChanges();
                }
            }
        }

        public Safe GetLastSafe()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Safes.OrderByDescending(o => o.RegistrationDate).FirstOrDefault();
            }
        }

        public decimal? GetCurrentAccount()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Safes.Sum(s => s.Amount);
            }
        }

        public List<string> GetStatementSuggetions()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Safes.Where(w => w.CanDelete == true).OrderBy(o => o.Statement).Select(s => s.Statement).Distinct().ToList();
            }
        }

        public List<Safe> GetSafes()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Safes.Where(w => w.RegistrationDate.Year == MainViewModel.Year).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }

        public List<Safe> GetSafes(DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Safes.Where(w =>  w.Date >= dtFrom && w.Date <= dtTo).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }


    }
}
