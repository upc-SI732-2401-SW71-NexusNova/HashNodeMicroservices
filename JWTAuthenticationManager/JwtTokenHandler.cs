using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JWTAuthenticationManager;

public class JwtTokenHandler
{
    public const string JWT_SECURITY_KEY = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTcxOTEzODM0MSwiaWF0IjoxNzE5MTM4MzQxfQ.mumfGYw2wge3P4cEjrgccgrItkZHW_cOLWRsRh_IWB0";
    private const int JWT_TOKEN_VALIDITY_HOURS = 10;
    private readonly List<UserAccount> _userAccountList;

    public JwtTokenHandler()
    {
        _userAccountList = new List<UserAccount>
        {
            new UserAccount { UserName = "admin", Password = "admin123" },
            new UserAccount { UserName = "user01", Password = "user01" }
        };
    }

    public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
    {
        if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) ||
            string.IsNullOrWhiteSpace(authenticationRequest.Password))
            return null;
        var userAccount = _userAccountList.Where(x =>
            x.UserName == authenticationRequest.UserName && x.Password == authenticationRequest.Password).FirstOrDefault();
        if (userAccount == null) return null;

        var tokenExpiryTimeStamp = DateTime.Now.AddHours(JWT_TOKEN_VALIDITY_HOURS);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName)
        });

        var singingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = singingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            UserName = userAccount.UserName,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalHours,
            JwtToken = token
        };
    }
}