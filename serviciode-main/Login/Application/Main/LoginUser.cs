using FluentValidation.Results;
using Login.Application.Dto;
using Login.Application.Interface;
using Login.Domain.Entity;
using Login.Domain.Interface;
using Login.Infrastructure.Logger;
using Login.Infrastructure.Logger.Models;
using System.Diagnostics;
using System.Reflection;
using TFHKA.Login.Application.Validations;

namespace TFHKA.Login.Application.Main
{
    public class LoginUser : ILoginUser
    {
        private readonly ILogAzure _log;
        private readonly IUserDomain _userDomain;

        public LoginUser(ILogAzure logAzure, IUserDomain userDomain)
        {
            _log = logAzure;
            _userDomain = userDomain;
        }

        public async Task<TokenJwtDto?> Login(LoginRequest request)
        {
            //Log
            Stopwatch timeT = new Stopwatch();
            timeT.Start();

            _log.SetUp(request.User, new LogRequest { });

            try
            {
                //Validation
                UserValidator validator = new UserValidator();

                ValidationResult resultValidation = validator.Validate(request);

                if (!resultValidation.IsValid)
                {
                    _log.WriteComment(MethodBase.GetCurrentMethod().Name, resultValidation.ToString(), LevelMsn.Warning);

                    _log.SaveLog(401, "No Autorizado", ref timeT, LevelMsn.Error);

                    return null;
                }

                //Consumo Domain
                User enterprise = new User
                {
                    Username = request.User,
                    Password = request.Password
                };

                TokenJwtUser result = _userDomain.Validate(enterprise, _log);

                if (result != null)
                {
                    TokenJwtDto token = new TokenJwtDto()
                    {
                        Token = result.Token,
                        PasswordExpiration = result.PasswordExpiration
                    };

                    _log.SaveLog(200, "Autorizado", ref timeT, LevelMsn.Info);

                    return token;
                }
                else
                {
                    _log.SaveLog(401, "No Autorizado", ref timeT, LevelMsn.Error);

                    return null;
                }
            }
            catch (Exception ex)
            {
                _log.SaveLog(500, "No Autorizado", ref timeT, LevelMsn.Error);

                return null;
            }
        }
    }
}
