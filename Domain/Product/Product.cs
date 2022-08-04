using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.Product
{
    public class Product: Entity
    {
        public string Description { get; set; }
        public bool Situation { get; set; }
        public DateTimeOffset ManufacturingAt { get; set; }
        public DateTimeOffset ValidUntil { get; set; }
        public long SupplierId { get; set; }
        public string DescriptionSupplier { get; set; }
        public string SupplierCnpj { get; set; }

        private Product(string description, bool situation, DateTimeOffset manufacturingAt, DateTimeOffset validUntil, long supplierId, string descriptionSupplier, string supplierCnpj)
        {
            Description = description;
            Situation = situation;
            ManufacturingAt = manufacturingAt;
            ValidUntil = validUntil;
            SupplierId = supplierId;
            DescriptionSupplier = descriptionSupplier;
            SupplierCnpj = supplierCnpj;
        }

        private static bool Validate(string description, DateTimeOffset manufacturingAt, DateTimeOffset validUntil )
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception("O Campo descrição não pode ser nulo");

            if (manufacturingAt >= validUntil)
                throw new Exception("A data de fabricação não pode ser maior ou igual a de validade");

            return true;
        }

        public static Product Create(string description, bool situation, DateTimeOffset manufacturingAt,
            DateTimeOffset validUntil, long supplierId, string descriptionSupplier, string supplierCnpj)
        {
            if (Validate(description, manufacturingAt, validUntil))
            {
                return new Product(description, situation, manufacturingAt, validUntil, supplierId, descriptionSupplier,
                    supplierCnpj);
            }

            throw new Exception("Produto inválido");
        }

        public void Update(string description, bool situation, DateTimeOffset manufacturingAt,
            DateTimeOffset validUntil, long supplierId, string descriptionSupplier, string supplierCnpj)
        {
            if (Validate(description, manufacturingAt, validUntil))
            {
                Description = description;
                Situation = Situation;
                ManufacturingAt = manufacturingAt;
                ValidUntil = validUntil;
                SupplierId = supplierId;
                DescriptionSupplier = descriptionSupplier;
                SupplierCnpj = supplierCnpj;

                return;
            }

            throw new Exception("Produto inválido");
        }
    }
}
