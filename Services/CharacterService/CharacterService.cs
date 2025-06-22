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

        public Task<ServiceResponse<GetCharachterDto>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharachterDto>();
            try
            {
                var character = characters.FirstOrDefault(c => c.Id == id);
                if (character == null)
                {
                    throw new Exception($"Character with Id '{id}' not found.");
                }
                characters.Remove(character);
                serviceResponse.Data = _mapper.Map<GetCharachterDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return Task.FromResult(serviceResponse);
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

        public async Task<ServiceResponse<GetCharachterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
     var serviceResponse = new ServiceResponse<GetCharachterDto>();
            try
            {
           
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character == null)
                {
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");
                }

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;
                  serviceResponse.Data = _mapper.Map<GetCharachterDto>(character);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetCharachterDto>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            return await Task.FromResult(serviceResponse);
        }
    }
}