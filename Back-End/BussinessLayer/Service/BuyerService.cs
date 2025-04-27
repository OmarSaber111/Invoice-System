using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;

namespace BussinessLayer.Service
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepo;
        private readonly IMapper _mapper;

        public BuyerService(IBuyerRepository buyerRepo, IMapper mapper)
        {
            _buyerRepo = buyerRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<BuyerDto>>> GetAllBuyersAsync()
        {
            var buyers = await _buyerRepo.GetAllBuyersAsync();
            var result = _mapper.Map<IEnumerable<BuyerDto>>(buyers);
            return GResponse<IEnumerable<BuyerDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<BuyerDto>> GetBuyerByIdAsync(int id)
        {
            var buyer = await _buyerRepo.GetBuyerByIdAsync(id);
            if (buyer == null)
                return GResponse<BuyerDto>.CreateFailure("404", "Buyer not found");
            var result = _mapper.Map<BuyerDto>(buyer);
            return GResponse<BuyerDto>.CreateSuccess(result);
        }
    }

}
