using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using udemy_dotnet.Models;

namespace udemy_dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharachterDto>>> GetAllCharacters(); //we can use Task to make it async

        Task<ServiceResponse<GetCharachterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharachterDto>>> AddCharacter(AddCharacterDto character);
    }
}