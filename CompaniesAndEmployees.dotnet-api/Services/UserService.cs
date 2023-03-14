using CompaniesAndEmployees.dotnet_api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly DataContext _context;
    public UserService(DataContext context, IMapper mapper, ILogger<UserService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task Create(UserRegistrationVm newUserVm)
    {
        try
        {
            var user = _mapper.Map<User>(newUserVm);

            if (newUserVm.Password != null)
            {
                var hashedPassword = PasswordHasherService.HashPassword(newUserVm.Password);

                user.Password = hashedPassword;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User Create");
            throw new Exception(ex.Message, ex);
        }
    }
    public async Task<User?> IsExist(UserLoginVm userLoginVm)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLoginVm.Email);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            if (user.Password is not null && userLoginVm.Password is not null)
                if (PasswordHasherService.VerifyPassword(user.Password, userLoginVm.Password))
                    return user;

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User IsExist");
            throw new Exception(ex.Message, ex);
        }
    }
    public async Task<string?> GetRole(UserLoginVm userLoginVm)
    {
        try
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLoginVm.Email);
            if (user is not null)
                return user.Role.ToString();
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User GetRole");
            throw new Exception(ex.Message, ex);
        }
    }
    public async Task<bool> IfEmailExists(string email)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            return user is not null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in User IfEmailExists");
            throw new Exception(ex.Message, ex);
        }
    }
}
