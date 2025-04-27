using ApiContract.Dtos;
using ApiContracts;
using BussinesLayer.Interfaces.Token;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Entities;
using System.Security.Claims;

namespace BussinessLayer.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _usersRepo;
        private readonly ISellerRepository _sellersRepo;
        private readonly IBuyerRepository _buyersRepo;
        private readonly IAdminRepository _admiRepo;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRoleAuthRepository _groupRoleAuthRepository;
        private readonly IGroupUserRepository _groupUserRepository;
        private readonly ILogger<AuthService> _logger;
        private readonly IBlacklistRepository _blacklistRepository;

        public AuthService(IUserRepository usersRepo, ISellerRepository sellersRepo, IBuyerRepository buyersRepo, ITokenService tokenService, IAdminRepository admiRepo, IUserRepository userRepository, IGroupRoleAuthRepository groupRoleAuthRepository, ILogger<AuthService> logger, IGroupUserRepository groupUserRepository, IBlacklistRepository blacklistRepository)
        {
            _usersRepo = usersRepo;
            _sellersRepo = sellersRepo;
            _buyersRepo = buyersRepo;
            _tokenService = tokenService;
            _admiRepo = admiRepo;
            _userRepository = userRepository;
            _groupRoleAuthRepository = groupRoleAuthRepository;
            _logger = logger;
            _groupUserRepository = groupUserRepository;
            _blacklistRepository = blacklistRepository;
        }

        public async Task<GResponse<string>> SignUpAsync(SignUpDTO dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var existname = await _userRepository.Where(c => c.Name == dto.Name).FirstOrDefaultAsync();
            if (existname != null) return GResponse<string>.CreateFailure("404", "there is an user with this name");
            var existemail = await _userRepository.Where(c => c.Email == dto.Email).FirstOrDefaultAsync();
            var userexist = await _userRepository.Where(c => c.NationalId == dto.NationalId).FirstOrDefaultAsync();
            if (userexist != null || existemail != null) return GResponse<string>.CreateFailure("404", "there is an user with the same email or nationalid");
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                NationalId = dto.NationalId,
            };
            await _usersRepo.InsertAsync(user);
            await _usersRepo.Commit();
            if (dto.IsSeller)
            {
                var sellerusername = await _sellersRepo.Where(s => s.UserName == dto.Username).FirstOrDefaultAsync();
                if (sellerusername != null) return GResponse<string>.CreateFailure("404", "there is a seller with this username");
                var seller = new Seller
                {
                    UserId = user.UserId,
                    StoreName = dto.StoreName,
                    TypeOFProduct = dto.ProductType,
                    GovernmentId = dto.GovernmentId,
                    HashedPassword = hashedPassword,
                    UserName = dto.Username
                };
                await _sellersRepo.InsertAsync(seller);
                await _sellersRepo.Commit();
                var GroupUser = new GroupUser
                {
                    GroupId = 2,
                    UserId = user.UserId

                };
                await _groupUserRepository.InsertAsync(GroupUser);
                await _sellersRepo.Commit();
            }
            else
            {
                var buyerusername = await _buyersRepo.Where(s => s.UserName == dto.Username).FirstOrDefaultAsync();
                if (buyerusername != null) return GResponse<string>.CreateFailure("404", "there is a buyer with this username");
                var buyer = new Buyer
                {
                    UserId = user.UserId,
                    HashedPassword = hashedPassword,
                    UserName = dto.Username
                };
                await _buyersRepo.InsertAsync(buyer);
                await _buyersRepo.Commit();
                var GroupUser = new GroupUser
                {
                    GroupId = 3,
                    UserId = user.UserId

                };
                await _groupUserRepository.InsertAsync(GroupUser);
                await _sellersRepo.Commit();

            }




            return GResponse<string>.CreateSuccess("SignUp Successfully and this User assigned to his group");
        }
        //    public async Task<LoginDto?> Login(LoginInoutDto dto)
        //    {
        //        // Check Admin
        //        var admin = await _admiRepo.GetByCredentialsAsync(dto.UserName, dto.Password);
        //        if (admin?.User?.GroupUsers.Any() == true)
        //            return await BuildLoginResponse(admin.User, "Admin");

        //        // Check Seller
        //        var seller = await _sellersRepo.GetByCredentialsAsync(dto.UserName, dto.Password);
        //        if (seller?.User?.GroupUsers.Any() == true)
        //            return await BuildLoginResponse(seller.User, "Seller");

        //        // Check Buyer
        //        var buyer = await _buyersRepo.GetByCredentialsAsync(dto.UserName, dto.Password);
        //        if (buyer?.User?.GroupUsers.Any() == true)
        //            return await BuildLoginResponse(buyer.User, "Buyer");

        //        return null;
        //    }

        //    private async Task<LoginDto> BuildLoginResponse(User user, string userType)
        //    {
        //        var groupId = user.GroupUsers.First().GroupId;

        //        var claims = new Dictionary<string, string>
        //{
        //    { "UserId", user.UserId.ToString() },
        //    { "UserName", user.Name },
        //    { "UserType", userType },
        //    { "GroupId", groupId.ToString() }
        //};

        //        var token = _tokenService.Create(claims);
        //        var formPermissions = await GetFormPermissionsAsync(groupId);

        //        return new LoginDto
        //        {
        //            Token = token,
        //            UserId = user.UserId,
        //            GroupId = groupId,
        //            UserType = userType,
        //            FormPermissions = formPermissions
        //        };
        //    }


        public async Task<GResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            var admin = await _admiRepo.GetByUsernameWithUserAsync(loginDto.Username);
            if (admin != null && IsPasswordValid(loginDto.Password, admin.HashedPassword))
            {
                return await GenerateLoginResponse(admin.User.UserId, "Admin");
            }

            var seller = await _sellersRepo.GetByUsernameWithUserAsync(loginDto.Username);
            if (seller != null && IsPasswordValid(loginDto.Password, seller.HashedPassword))
            {
                return await GenerateLoginResponse(seller.User.UserId, "Seller", sellerId: seller.SellerId);
            }

            var buyer = await _buyersRepo.GetByUsernameWithUserAsync(loginDto.Username);
            if (buyer != null && IsPasswordValid(loginDto.Password, buyer.HashedPassword))
            {
                return await GenerateLoginResponse(buyer.User.UserId, "Buyer", buyerId: buyer.BuyerId);
            }


            return GResponse<LoginResponseDto>.CreateFailure("401", "Invalid username or password.");
        }


        private bool IsPasswordValid(string plainPassword, string hashedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword) || !hashedPassword.StartsWith("$2"))
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }

        private async Task<GResponse<LoginResponseDto>> GenerateLoginResponse(int userId, string role, int? sellerId = null, int? buyerId = null)
        {
            {
                var user = await _userRepository.GetUserByIdWithGroupAsync(userId);

                if (user is null)
                    return GResponse<LoginResponseDto>.CreateFailure("404", "User not found");

                var group = user.GroupUsers?.FirstOrDefault()?.Group;

                if (group is null)
                    return GResponse<LoginResponseDto>.CreateFailure("403", "User is not assigned to any group");

                var allowedForms = await _groupRoleAuthRepository
                    .Where(x => x.GroupId == group.GroupId)
                    .GroupBy(x => new
                    {
                        x.RequestRoleForm.FormId,
                        x.RequestRoleForm.Form.FormName,
                        x.RequestRoleForm.Role.Category
                    })
                    .Select(g => new FormPermissionDto
                    {
                        FormId = g.Key.FormId,
                        FormName = g.Key.FormName,
                        RoleName = g.Key.Category,
                        Actions = g.Select(a => a.Action).Distinct().ToList()
                    })
                    .ToListAsync();

                var claims = new Dictionary<string, string>
            {
                { ClaimTypes.NameIdentifier, user.UserId.ToString() },
                { ClaimTypes.Name, user.Name ?? "User" },
                { ClaimTypes.Role, role },
                { ClaimTypes.GroupSid, group.GroupId.ToString() }

            };

                var token = _tokenService.Create(claims);

                var response = new LoginResponseDto
                {
                    UserName = user.Name,
                    GroupName = group.GroupName,
                    Token = token,
                    AllowedForms = allowedForms,
                    SellerId = sellerId,
                    BuyerId = buyerId

                };

                return GResponse<LoginResponseDto>.CreateSuccess(response);
            }
        }




        public async Task SignOutAsync(string token)
        {
            var expiration = _tokenService.GetExpiration(token);

            await _blacklistRepository.AddAsync(new BlackListedTokens
            {
                Token = token,
                Expiration = expiration
            });
        }
    }


}








