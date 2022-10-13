using System;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Domain.FiltersDb;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);

        //metod que vai listar TODAS pessoas
        Task<ResultService<ICollection<PersonDTO>>> GetAsync();

        //metod que vai listar UMA pessoa
        Task<ResultService<PersonDTO>> GetByIdAsync(int id);

        //metod para fazer o UpDate
        Task<ResultService> UpdateAsync(PersonDTO personDTO);

        //metod para fazer o delete
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);

        

    }
}

