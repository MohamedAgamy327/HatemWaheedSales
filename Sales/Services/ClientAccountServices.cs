using Sales.Models;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sales.Services
{
    public class ClientAccountServices
    {
        public ClientAccount AddAccount(ClientAccount account)
        {
            using (SalesDB db = new SalesDB())
            {
                db.ClientsAccounts.Add(account);
                db.SaveChanges();
                return account;
            }
        }

        public ClientAccount DeleteAccount(ClientAccount account)
        {
            using (SalesDB db = new SalesDB())
            {
                db.ClientsAccounts.Attach(account);
                db.ClientsAccounts.Remove(account);
                db.SaveChanges();
                return account;
            }
        }

        public void DeleteAccount(DateTime dt)
        {
            using (SalesDB db = new SalesDB())
            {
                db.ClientsAccounts.RemoveRange(db.ClientsAccounts.Where(x => x.RegistrationDate == dt));
                db.SaveChanges();
            }
        }

        public List<ClientAccount> GetAccounts()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Where(c => c.RegistrationDate.Year == MainViewModel.Year).Include(i => i.Client).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }

        public ClientAccount GetAccount(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).SingleOrDefault(s => s.ID == id);
            }
        }

        public decimal? GetClientAccount(int clientID)
        {
            using (SalesDB db = new SalesDB())
            {
                decimal? _currentAccount = db.ClientsAccounts.Where(w => w.ClientID == clientID).Sum(d => d.Credit) - db.ClientsAccounts.Where(w => w.ClientID == clientID).Sum(d => d.Debit);
                if (_currentAccount == null)
                    _currentAccount = 0;
                return _currentAccount;
            }
        }

        public List<ClientAccount> GetClientAccounts(int clientID)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Where(w => w.ClientID == clientID).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }

        public List<ClientAccount> GetAccounts(DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).Where(w => w.Date >= dtFrom && w.Date <= dtTo).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }
    }
}


