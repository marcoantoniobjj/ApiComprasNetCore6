using System;
using System.Runtime.ConstrainedExecution;
using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public sealed class Product
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }

        public ICollection<Purchase> Purchases { get; set; } //um produto pode estar em mais de uma compra

        public Product(string name, string codErp, decimal price)
        {

            Validation(name, codErp, price);

            //inicializa lista
            Purchases = new List<Purchase>();
            


        }

       
        public Product(int id, string name, string codErp, decimal price)
        {

            DomainValidationException.When(id<0, "Id do produto deve ser informado");

            Id = id;
            Validation(name, codErp, price);

            //inicializa lista
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string codErp, decimal price)
        {


            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome do produto deve ser iformado");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "Codigo do produto deve ser iformado");
            DomainValidationException.When(price < 0, "Preco do produto deve ser iformado");


            Name = name;
            CodErp = codErp;
            Price = price;

        }
    }
}
