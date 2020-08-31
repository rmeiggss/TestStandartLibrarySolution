using AutoMapper;
using System;
using System.Collections.Generic;
using TestService.DTO;
using TestService.Interfaces;
using TestUnitOfWork;

namespace TestService.Implementations
{
    public class TestLogic : ITestLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IEnumerable<CuentaContableDTO> GetCuentaContable()
        {
            _unitOfWork.CuentaContable.SetSchema("modelo");

            var result = _unitOfWork.CuentaContable.GetList();
            return _mapper.Map<IEnumerable<CuentaContableDTO>>(result);
        }
    }
}
