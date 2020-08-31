using System.Collections.Generic;
using TestService.DTO;

namespace TestService.Interfaces
{
    public interface ITestLogic
    {
        IEnumerable<CuentaContableDTO> GetCuentaContable();
    }
}
