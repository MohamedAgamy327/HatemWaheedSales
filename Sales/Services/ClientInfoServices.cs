using Sales.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Sales.Services
{
    public class ClientInfoServices
    {
        public void AddClientInfo(ClientInfo clientInfo)
        {
            using (SalesDB db = new SalesDB())
            {
                db.ClientsInfo.Add(clientInfo);
                db.SaveChanges();
            }
        }

        public void DeleteClientInfo(int clientID, int categoryID)
        {
            using (SalesDB db = new SalesDB())
            {
                var clientInfo = db.ClientsInfo.SingleOrDefault(s => s.CategoryID == categoryID && s.ClientID == clientID);
                if (clientInfo != null)
                {
                    db.ClientsInfo.Attach(clientInfo);
                    db.ClientsInfo.Remove(clientInfo);
                    db.SaveChanges();
                }
            }
        }

        public ClientInfo GetClientInfo(int clientID, int categoryID)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsInfo.SingleOrDefault(s => s.CategoryID == categoryID && s.ClientID == clientID);

            }
        }

        public List<ClientInfoVM> GetClientInfoCategories(int clientID)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.ClientsInfo.Where(w=>w.ClientID==clientID).Include(s =>s.Category).Include(i => i.Category.Company).OrderBy(o => o.Category.Name).Select(k => new ClientInfoVM
                {
                    CategoryID=k.CategoryID,
                    ClientID=k.ClientID,
                    Price=k.Price,
                    Category = k.Category.Name + " " + k.Category.Company.Name,
                    Color = k.Color
                }).ToList();
            }
        }
    }
}
