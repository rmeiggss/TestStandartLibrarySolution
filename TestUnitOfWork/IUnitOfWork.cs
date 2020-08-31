using TestRepository;

namespace TestUnitOfWork
{
    public interface IUnitOfWork
    {
        ITestRepository CuentaContable { get; }
    }
}
