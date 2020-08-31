
using TestModels.Models;
using TestRepository;

namespace TestDataAccess
{
    public class TestRepository : RepositoryBase<cuenta_contable>, ITestRepository
    {
        public TestRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
