using Azure.Core;
using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result.Result;

using Entities.DTOs.UserDtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExist(string email);
        IDataResult<Core.Utilities.Security.JWT.AccessToken> CreateAccessToken(User user);
    }
}
