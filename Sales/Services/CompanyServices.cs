using Sales.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Services
{
    public class CompanyServices
    {
        public void AddCompany(Company company)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
        }

        public void DeleteCompany(Company company)
        {
            using (SalesDB db = new SalesDB())
            {
                db.Companies.Attach(company);
                db.Companies.Remove(company);
                db.SaveChanges();
            }
        }

        public Company GetCompany(string name)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Companies.SingleOrDefault(s => s.Name == name);
            }
        }

        public List<Company> GetCompanies()
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Companies.OrderBy(o => o.Name).ToList();
            }
        }
    
        public bool IsExistInCategories(int id)
        {
            using (SalesDB db = new SalesDB())
            {
                return db.Categories.Any(s => s.CompanyID == id);
            }
        }

    }
}
