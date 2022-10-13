using System;
using MP.ApiDotNet6.Application.DTOs;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IProductService
    {

        //Metod0 para criar produto
        Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);

        //Metod0 para retornar um produto chamando pelo id
        Task<ResultService<ProductDTO>> GetByIdAsync(int id);

        //Metod0 para retornar uma lista de tod0s os produto
        Task<ResultService<ICollection<ProductDTO>>> GetAsync();
        //ICollection serve para retornar uma lista
        //-----------------------------------------------------

        Task<ResultService> UpdateAsync(ProductDTO productDTO);

        Task<ResultService> RemoveAsync(int id);

    }
}

