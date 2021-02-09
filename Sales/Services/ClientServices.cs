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

        public int GetClientsNumer(string key)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Clients.Include(i => i.ClientAccounts).Where(w => (w.Name + w.Address + w.Telephone).Contains(key)).Count();
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

        public List<string> GetNamesSuggetions()
        {
            using (SalesDB db = new SalesDB())
            {
                List<string> newData = new List<string>();
                var data = db.Clients.OrderBy(o => o.Name).Select(s => new { s.Name }).Distinct().ToList();
                foreach (var item in data)
                {
                    newData.Add(item.Name);
                }
                return newData;
            }
        }

        public List<string> GetAddressSuggetions()
        {
            using (SalesDB db = new SalesDB())
            {
                List<string> newData = new List<string>();
                var data = db.Clients.OrderBy(o => o.Telephone).Select(s => new { s.Telephone }).Distinct().ToList();
                foreach (var item in data)
                {
                    newData.Add(item.Telephone);
                }
                return newData;
            }
        }

        public List<Client> GetClients()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Clients.OrderBy(o => o.Name).ToList();
            }
        }

        public List<Client> SearchClients(string key, int page)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Clients.Include(i => i.ClientAccounts).Where(w => (w.Name + w.Address + w.Telephone).Contains(key)).OrderBy(o => o.Name).Skip((page - 1) * 17).Take(17).ToList();
            }
        }      
    }
}
