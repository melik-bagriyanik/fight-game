using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using udemy_dotnet.Models;

namespace udemy_dotnet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
             private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character {Id = 1, Name = "Sam"},

        };
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharachterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharachterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1; // Assign a new ID
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharachterDto>(c)).ToList();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharachterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharachterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharachterDto>(c)).ToList();
            return await Task.FromResult(serviceResponse);
        }

        public async Task<ServiceResponse<GetCharachterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharachterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharachterDto>(character);
            return await Task.FromResult(serviceResponse);
        }
    }
}