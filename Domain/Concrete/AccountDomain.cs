using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.AccountDTO;
using DTO.UserDTO;
using Entities.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using RestSharp;
using System.Text.RegularExpressions;

namespace Domain.Concrete
{
    internal class AccountDomain : DomainBase, IAccountDomain
    {
        private readonly ITokenService _tokenService;

        public AccountDomain(IUnitOfWork unitOfWork, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, ITokenService tokenService) : base(unitOfWork, mapper, httpContextAccessor)
        {
            _tokenService = tokenService;
        }

        private IUserRepository userRepositoryInstance => _unitOfWork.GetRepository<IUserRepository>();
        private IRoliRepository roleRepositoryInstance => _unitOfWork.GetRepository<IRoliRepository>();

        public TokenDTO Login(LoginDTO loginDTO)
        {

            var user = CheckUsername(loginDTO.userName);

            if (user == null)
                throw new ArgumentException("Invalid username");

            if (isPasswordCorrect(user, loginDTO.Password) == false)
                throw new ArgumentException("Invalid password");

            return new TokenDTO
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                UserId = user.UserId
            };
        }

        private AppUser CheckUsername(string username)
        {
            var user = userRepositoryInstance.GetByUserName(username);
            return user;
        }

        private bool isPasswordCorrect(AppUser user, string password)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return false;
            }
            return true;
        }

        public TokenDTO Register(RegisterDTO registerDTO)
        {
            using var hmac = new HMACSHA512();

            //var passsword = GeneratePassword();
            var password = registerDTO.Password;
            var user = _mapper.Map<AppUser>(registerDTO);
            user.UserId = Guid.NewGuid();
            user.UserIsActive = true;
            user.BalancaLeje = 20;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            user.PasswordSalt = hmac.Key;

            foreach (string role in registerDTO.roles)
            {
                var userRole = new UserRoli
                {
                    UserId = user.UserId,
                    RoliId = roleRepositoryInstance.GetRoleId(role),
                    DataCaktimit = DateTime.Now
                };
                user.UserRolis.Add(userRole);
            }

            userRepositoryInstance.Add(user);
            _unitOfWork.Save();

            //SendEmail(registerDTO, password);

            return new TokenDTO
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private void SendEmail(RegisterDTO registerDTO, string password)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("hrmanagementcompany3i@gmail.com"));
            email.To.Add(MailboxAddress.Parse(registerDTO.UserEmail));
            email.Subject = "Account Registration";

            string roles = string.Join(", ", registerDTO.roles);

            string textBody = "Hello, " + registerDTO.UserFirstname + "\n" +
                "Your username is: " + registerDTO.UserName + "\n" +
                "Your generated password is: " + password + "\n" +
                "Your assigned roles are: " + roles;
            email.Body = new TextPart(TextFormat.Plain)
            {
                Text = textBody
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //	smtp.Authenticate("hrmanagementcompany3i@gmail.com", "erkxkqkaofufgkmp");
            smtp.Authenticate("brajanbarzini123@gmail.com", "irishmasters1990");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private string GeneratePassword()
        {
            string allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[8];
            int allowedCharCount = allowedChars.Length;
            for (int i = 0; i < 8; i++)
            {
                chars[i] = allowedChars[(int)((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public void ChangePassword(PasswordChangeDTO passwordChangeDTO)
        {
            var user = userRepositoryInstance.GetById(passwordChangeDTO.UserId);

            if (passwordChangeDTO.newPassword != passwordChangeDTO.confirmNewPassword)
                throw new ArgumentException("Passwords do not match.");

            if (isPasswordCorrect(user, passwordChangeDTO.oldPassword) == false)
                throw new ArgumentException("Old password is not correct.");

            // password must be more than 8 chrs, at least one uppercase, at least one nr
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (hasNumber.IsMatch(passwordChangeDTO.newPassword) == false)
                throw new ArgumentException("Please include a number");
            if (hasUpperChar.IsMatch(passwordChangeDTO.newPassword) == false)
                throw new ArgumentException("Please include an uppercase letter");
            if (hasMinimum8Chars.IsMatch(passwordChangeDTO.newPassword) == false)
                throw new ArgumentException("Password must be 8 characters long");

            using var hmac = new HMACSHA512();

            // encrypt new one and update
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordChangeDTO.newPassword));
            user.PasswordSalt = hmac.Key;

            userRepositoryInstance.Update(user);
            _unitOfWork.Save();
        }
    }
}