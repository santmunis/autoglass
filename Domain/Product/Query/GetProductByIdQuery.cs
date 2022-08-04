using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using Domain.Interfaces;
using MediatR;

namespace Domain.Product.Query
{
    public class GetProductByIdQuery
    {
        public class Contract : BaseContract<Product>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Contract, Product>
        {
            private readonly IProductRepository _productRepository;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IProductRepository productRepository, IUnitOfWork unitOfWork)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Product> Handle(Contract request, CancellationToken cancellationToken)
            {

                var product = await _productRepository.GetById(request.Id, cancellationToken);
                if (product == null)
                    throw new Exception("Produto não existe");

                return product;
            }
        }
    }
}
