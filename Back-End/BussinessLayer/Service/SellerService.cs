using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{

    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepo;
        private readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepo, IMapper mapper)
        {
            _sellerRepo = sellerRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<bool>> DeleteSellerAsync(int sellerid)
        {
            var seller = await _sellerRepo.GetSellerByIdAsync(sellerid);
            if (seller == null)
                return GResponse<bool>.CreateFailure("404", "Seller not found");
            _sellerRepo.Delete(seller);
            await _sellerRepo.Commit();
            return GResponse<bool>.CreateSuccess(true);

        }

        public async Task<GResponse<IEnumerable<SellerDto>>> GetAllSellersAsync()
        {
            var sellers = await _sellerRepo.GetAllSellersAsync();
            var result = _mapper.Map<IEnumerable<SellerDto>>(sellers);
            return GResponse<IEnumerable<SellerDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<SellerDto>> GetSellerByIdAsync(int id)
        {
            var seller = await _sellerRepo.GetSellerByIdAsync(id);
            if (seller == null)
                return GResponse<SellerDto>.CreateFailure("404", "Seller not found");
            var result = _mapper.Map<SellerDto>(seller);
            return GResponse<SellerDto>.CreateSuccess(result);
        }
        public async Task<GResponse<SellerDto>> GetSellerByUserIdAsync(int userId)
        {
            var seller = await _sellerRepo.GetSellerByUserIdAsync(userId);
            if (seller == null)
                return GResponse<SellerDto>.CreateFailure("404", "Seller not found");

            var sellerDto = _mapper.Map<SellerDto>(seller);
            return GResponse<SellerDto>.CreateSuccess(sellerDto);
        }

        public async Task<GResponse<bool>> UpdateSellerAsync(UpdateSellerDto updateSellerDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(updateSellerDto.Password);
            var seller = await _sellerRepo.GetByUsernameWithUserAsync(updateSellerDto.UserName);
            if (seller is null) return GResponse<bool>.CreateFailure("404", "there is no seller by this username");
            var updatedseller = new Seller
            {
                UserId = updateSellerDto.UserId,
                UserName = updateSellerDto.UserName,
                HashedPassword = hashedPassword,
                GovernmentId = updateSellerDto.GovernmentId,
                StoreName = updateSellerDto.StoreName,
                TypeOFProduct = updateSellerDto.TypeOFProduct
            };
            await _sellerRepo.Commit();
            return GResponse<bool>.CreateSuccess(true);


        }
    }

}
