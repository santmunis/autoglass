using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using Domain.Interfaces;
using MediatR;

namespace Domain.Product.Command
{
    public class DeleteProductCommand
    {
        public class Contract : BaseContract<bool>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Contract, bool>
        {
            private readonly IProductRepository _productRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IProductRepository productRepository, IUnitOfWork unitOfWork)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(Contract request, CancellationToken cancellationToken)
            {
                
                _productRepository.Remove(request.Id);
                var result = await _unitOfWork.Commit();
                
                return result;
            }
        }
    }
}
