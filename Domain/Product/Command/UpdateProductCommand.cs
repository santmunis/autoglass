using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Base;
using Domain.Interfaces;
using MediatR;

namespace Domain.Product.Command
{
    public class UpdateProductCommand
    {
        public class Contract : BaseContract<ProductDTO>
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool Situation { get; set; }
            public DateTimeOffset ManufacturingAt { get; set; }
            public DateTimeOffset ValidUntil { get; set; }
            public long SupplierId { get; set; }
            public string DescriptionSupplier { get; set; }
            public string SupplierCnpj { get; set; }
        }

        public class Handler : IRequestHandler<Contract, ProductDTO>
        {
            private readonly IProductRepository _productRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<ProductDTO> Handle(Contract request, CancellationToken cancellationToken)
            {

                var product = await _productRepository.GetById(request.Id, cancellationToken);
                if (product == null)
                    throw new Exception("Produto não existe");

                product.Update(request.Description, request.Situation, request.ManufacturingAt, request.ValidUntil,
                    request.SupplierId, request.DescriptionSupplier, request.SupplierCnpj);

                var result = await _unitOfWork.Commit();

                var response = _mapper.Map<ProductDTO>(product);
                return response;
            }
        }
    }
}
