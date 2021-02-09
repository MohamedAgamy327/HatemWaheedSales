using Sales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sales.Services
{
    public class ClientAccountServices
    {
        ClientServices clientServ = new ClientServices();

        public void AddAccount(ClientAccount account)
        {
            using (SalesDB db = new SalesDB())
            {
                db.ClientsAccounts.Add(account);
                db.SaveChanges();
            }
        }

        public void DeleteAccount(ClientAccount account)
        {
            using (SalesDB db = new SalesDB())
            {
                db.ClientsAccounts.Attach(account);
                db.ClientsAccounts.Remove(account);
                db.SaveChanges();
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

        public int GetClientsAccountsNumer(string key)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).Where(w => (w.Statement + w.Client.Name).Contains(key)).Count();
            }
        }

        public int GetClientsAccountsNumer(string key, DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).Where(w => (w.Statement + w.Client.Name).Contains(key) && w.Date >= dtFrom && w.Date <= dtTo).Count();
            }
        }

        public decimal? GetTotalDebit(string key, DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).Where(w => (w.Statement + w.Client.Name).Contains(key) && w.Date >= dtFrom && w.Date <= dtTo).Sum(s => s.Debit);
            }
        }

        public decimal? GetTotalCredit(string key, DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).Where(w => (w.Statement + w.Client.Name).Contains(key) && w.Date >= dtFrom && w.Date <= dtTo).Sum(s => s.Credit);
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

        public DateTime GetFirstDate(int clientID)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Where(w => w.ClientID == clientID).Min(d => d.Date).Date;
            }
        }

        public DateTime GetLastDate(int clientID)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Where(w => w.ClientID == clientID).Max(d => d.Date).Date;
            }
        }

        public ClientAccountVM GetAccountInfo(int clientID, DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                var client = clientServ.GetClient(clientID);
                ClientAccountVM accountVM = new ClientAccountVM();
                accountVM.TotalCredit = db.ClientsAccounts.Where(w => w.ClientID == clientID && w.Date >= dtFrom && w.Date <= dtTo).Sum(d => d.Credit);
                if (accountVM.TotalCredit == null)
                    accountVM.TotalCredit = 0;
                accountVM.TotalDebit = db.ClientsAccounts.Where(w => w.ClientID == clientID && w.Date >= dtFrom && w.Date <= dtTo).Sum(d => d.Debit);
                if (accountVM.TotalDebit == null)
                    accountVM.TotalDebit = 0;
                accountVM.DuringAccount = accountVM.TotalCredit - accountVM.TotalDebit;
                accountVM.CurrentAccount = client.AccountStart + db.ClientsAccounts.Where(w => w.ClientID == clientID).Sum(d => d.Credit) - db.ClientsAccounts.Where(w => w.ClientID == clientID).Sum(d => d.Debit);
                accountVM.OldAccount = accountVM.CurrentAccount - accountVM.DuringAccount;
                return accountVM;
            }
        }

        public List<ClientAccount> GetClientAccounts(int clientID, DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Where(w => w.ClientID == clientID && w.Date >= dtFrom && w.Date <= dtTo).OrderByDescending(o => o.RegistrationDate).ToList();
            }
        }

        public List<ClientAccount> SearchClientsAccounts(string search, int page)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).Where(w => (w.Statement + w.Client.Name).Contains(search)).OrderByDescending(o => o.RegistrationDate).Skip((page - 1) * 17).Take(17).ToList();
            }
        }

        public List<ClientAccount> SearchClientsAccounts(string search, int page, DateTime dtFrom, DateTime dtTo)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Include(i => i.Client).Where(w => (w.Statement + w.Client.Name).Contains(search) && w.Date >= dtFrom && w.Date <= dtTo).OrderByDescending(o => o.RegistrationDate).Skip((page - 1) * 17).Take(17).ToList();
            }
        }
    }
}
