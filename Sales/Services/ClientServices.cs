using Sales.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sales.Services
{
    public class ClientServices
    {
        public void AddClient(Client client)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }

        public void DeleteClient(Client client)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Clients.Attach(client);
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        public void UpdateClient(Client client)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool IsExistInSupplies(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Supplies.Any(s => s.ClientID == id);
            }
        }

        public bool IsExistInSales(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Sales.Any(s => s.ClientID == id);
            }
        }

        public bool IsExistInClientInfo(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsInfo.Any(s => s.ClientID == id);
            }
        }

        public bool IsExistInClientAccounts(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsAccounts.Any(s => s.ClientID == id);
            }
        }

        public Client GetClient(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Clients.SingleOrDefault(s => s.ID == id);
            }
        }

        public Client GetClient(string name)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Clients.SingleOrDefault(s => s.Name == name);
            }
        }

        public List<Client> GetClients()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Clients.OrderBy(o => o.Name).ToList();
            }
        }
 
    }
}
