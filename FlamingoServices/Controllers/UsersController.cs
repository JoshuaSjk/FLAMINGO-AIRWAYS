using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlamingoServices.Data;
using FlamingoServices.Models;
using FlamingoServices.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using FlamingoServices.Data.Models;
using AutoMapper;

namespace FlamingoServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FlamingoDbContext dBContext;
        private readonly IMapper mapper;

        public UsersController(FlamingoDbContext context, IMapper automapper)
        {
            dBContext = context;
            mapper = automapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await dBContext.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await dBContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.Userid)
            {
                return BadRequest();
            }

            dBContext.Entry(user).State = EntityState.Modified;

            try
            {
                await dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                await dBContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Userid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Userid }, user);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserModel userObj)
        {
            if (userObj == null)
                return BadRequest();

            var errorMsg = string.Empty;
            // use automapper
            var user = mapper.Map<User>(userObj);
            user = await dBContext.Users.FirstOrDefaultAsync(x => x.Userid.Equals(user.Userid));
            if (user == null)
            {
                errorMsg = "User not found!";
            }
            if (user != null)
            {
                if (PasswordHasher.VerifyPassword(user.Password, user.Password))
                {
                    errorMsg = "Incorrect password!";
                }

                user.Token = CreateJWT(user);
            }
            if (!string.IsNullOrEmpty(errorMsg))
                return NotFound(new { Message = errorMsg });

            return Ok(
                new
                {
                    Token = user.Token,
                    Message = "Login success!"
                });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userObj)
        {
            if (userObj == null)
                return BadRequest();

            // use automapper
            var user = mapper.Map<User>(userObj);
            //var user = new User()
            //{
            //    Userid = userObj.Username,
            //    Fname = userObj.Firstname,
            //    Lname = userObj.Lastname,
            //    Password = userObj.Password,
            //    DoB = userObj.DoB,
            //    Email = userObj.Email,
            //    Phone=userObj.Phone,
            //    Role = userObj.Role,
            //};

            // Check username
            if (await CheckUserNameExistAsync(user.Userid))
            {
                return BadRequest(new { Message = "Username already exists!!" });
            }

            // Check password strength
            var errorMsg = CheckPasswordStrength(user.Password);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                return BadRequest(new { Message = errorMsg });
            }

            user.Password = PasswordHasher.HashPassword(user.Password);
            user.Role = "User";
            user.Token = CreateJWT(user);
            await dBContext.Users.AddAsync(user);
            if (await SaveUser())
            {
                return this.BadRequest();
            }

            return Ok(new { Message = "User registered successfully!", User = user });

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await dBContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            dBContext.Users.Remove(user);
            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return dBContext.Users.Any(e => e.Userid == id);
        }

        private async Task<bool> SaveUser()
        {
            return await dBContext.SaveChangesAsync() > 0;
        }

        private Task<bool> CheckUserNameExistAsync(string username)
            => dBContext.Users.AnyAsync(x => x.Userid.Equals(username));

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new();
            if (password.Length < 8)
            {
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") &&
                Regex.IsMatch(password, "[0-9]")))
            {
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            }
            if (!(Regex.IsMatch(password, "[<,>,@,#,$,%,^,&,*,(,),_,+,-,=]")))
            {
                sb.Append("Password should contain special charactors" + Environment.NewLine);
            }
            return sb.ToString();
        }

        private string CreateJWT(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Name,$"{user.Fname} {user.Lname}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
