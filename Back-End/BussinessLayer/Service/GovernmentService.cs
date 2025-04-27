using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{
    public class GovernmentService : IGovernmentService
    {
        private readonly IGovernmentRepository _governmentRepo;
        private readonly IMapper _mapper;

        public GovernmentService(IGovernmentRepository governmentRepo, IMapper mapper)
        {
            _governmentRepo = governmentRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<GovernmentDto>>> GetAllGovernmentsAsync()
        {
            var governments = await _governmentRepo.GetAllGovernmentsAsync();
            var result = _mapper.Map<IEnumerable<GovernmentDto>>(governments);
            return GResponse<IEnumerable<GovernmentDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<GovernmentDto>> GetGovernmentByIdAsync(int id)
        {
            var government = await _governmentRepo.GetGovernmentByIdAsync(id);
            if (government == null)
                return GResponse<GovernmentDto>.CreateFailure("404", "Government not found");

            var result = _mapper.Map<GovernmentDto>(government);
            return GResponse<GovernmentDto>.CreateSuccess(result);
        }

        public async Task<GResponse<GovernmentDto>> CreateGovernmentAsync(CreateGovernmentDto dto)
        {
            var government = _mapper.Map<Government>(dto);
            await _governmentRepo.InsertAsync(government);
            await _governmentRepo.Commit();
            var result = _mapper.Map<GovernmentDto>(government);
            return GResponse<GovernmentDto>.CreateSuccess(result);
        }

        public async Task<GResponse<string>> UpdateGovernmentAsync(UpdateGovernmentDto dto)
        {
            var government = await _governmentRepo.GetGovernmentByIdAsync(dto.Id);
            if (government == null)
                return GResponse<string>.CreateFailure("404", "Government not found");

            _mapper.Map(dto, government);
            await _governmentRepo.Commit();
            return GResponse<string>.CreateSuccess("Government updated successfully.");
        }

        public async Task<GResponse<bool>> DeleteGovernmentAsync(int id)
        {
            var government = await _governmentRepo.GetGovernmentByIdAsync(id);
            if (government == null)
                return GResponse<bool>.CreateFailure("404", "Government not found");

            _governmentRepo.Delete(government);
            await _governmentRepo.Commit();
            return GResponse<bool>.CreateSuccess(true);
        }
    }

}
