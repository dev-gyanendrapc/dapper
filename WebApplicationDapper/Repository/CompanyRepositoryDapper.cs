using Dapper;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.ComponentModel.Design;
using System.Data;
using WebApplicationDapper.Data;
using WebApplicationDapper.Models;

namespace WebApplicationDapper.Repository
{
    public class CompanyRepositoryDapper : ICompanyRepository
    {
        private readonly IDbConnection db;

        public CompanyRepositoryDapper(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public CompanyModel Add(CompanyModel company)
        {
            string sql = "INSERT INTO Companies(Name, Address, City, State, PostalCode) VALUES(@name, @address, @city, @state, @postalCode); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var id = db.Query<int>(sql, new
            {
                @name = company.Name,
                @address = company.Address,
                @city = company.City,
                @state = company.State,
                @postalCode = company.PostalCode
            }).Single();
            company.CompanyId = id;
            return company;


        }

        public CompanyModel Find(int id)
        {
            string sql = "SELECT * FROM Companies WHERE CompanyId = @companyId";
            return db.Query<CompanyModel>(sql, new { @companyId = id }).Single();
        }

        public List<CompanyModel> GetAll()
        {
            string sql = "SELECT * FROM Companies";
            return db.Query<CompanyModel>(sql).ToList();
        }

        public void Remove(int id)
        {
            string sql = "DELETE FROM Companies WHERE CompanyId = @Id";
            db.Execute(sql, new { id });
        }

        public CompanyModel Update(CompanyModel company)
        {
            string sql = "UPDATE Companies SET Name = @Name, Address = @Address, City = @City, State = @State, PostalCode = @PostalCode WHERE CompanyId = @CompanyId";
            db.Execute(sql, company);
            return company;
        }
    }
}
