using TestRepository;
using TestUnitOfWork;

namespace TestDataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connection)
        {
            CuentaContable = new TestRepository(connection);
        }
        public ITestRepository CuentaContable { get; private set; }
    }
}
