using WebApplicationDapper.Models;

namespace WebApplicationDapper.Repository
{
    public interface ICompanyRepository
    {
        CompanyModel Find(int id);
        List<CompanyModel> GetAll();
        CompanyModel Add(CompanyModel company);
        CompanyModel Update(CompanyModel company);
        void Remove(int id);
    }
}
