using WebApplicationDapper.Data;
using WebApplicationDapper.Models;

namespace WebApplicationDapper.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly AppDbContext _db;
        public CompanyRepositoryEF(AppDbContext db)
        {
            _db = db;
        }
        public CompanyModel Add(CompanyModel company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return company;
        }

        public CompanyModel Find(int id)
        {
            return _db.Companies.FirstOrDefault(u => u.CompanyId == id);
        }

        public List<CompanyModel> GetAll()
        {
            return _db.Companies.ToList();
        }

        public void Remove(int id)
        {
            CompanyModel company = _db.Companies.FirstOrDefault(u => u.CompanyId == id);
            _db.Companies.Remove(company);
            _db.SaveChanges();
        }

        public CompanyModel Update(CompanyModel company)
        {
            _db.Companies.Update(company);
            _db.SaveChanges();
            return company;
        }
    }
}
