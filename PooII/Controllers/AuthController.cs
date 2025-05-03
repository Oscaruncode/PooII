//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//using PooII.Entities;
//using PooII.Interfaces;

//namespace PooII.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    [EnableCors]
//    public class AuthController : ControllerBase
//    {
//        private readonly JWTAuthenticationConfig _jwtAuthConfig;
//        private readonly IUsuarioService _usuarioService;
//        private readonly IUserDetailsService _userDetailsService;

//        public JwtAuthenticationController(
//            JWTAuthenticationConfig jwtAuthConfig,
//            IUsuarioService usuarioService,
//            IUserDetailsService userDetailsService)
//        {
//            _jwtAuthConfig = jwtAuthConfig;
//            _usuarioService = usuarioService;
//            _userDetailsService = userDetailsService;
//        }

//        [HttpPost("authenticate")]
//        [Consumes("application/json")]
//        [Produces("application/json")]
//        public async Task<IActionResult> CreateAuthenticationToken(
//            [FromBody] JwtRequest authenticationRequest,
//            [FromHeader(Name = "APIkey")] string apiKey)
//        {
//            Console.WriteLine("********************************************************************");
//            Console.WriteLine($"authenticationRequest.Username: [{authenticationRequest.Username}]");
//            Console.WriteLine($"authenticationRequest.Password: [{authenticationRequest.Password}]");
//            Console.WriteLine($"APIKey: [{apiKey}]");
//            Console.WriteLine("********************************************************************");

//            Usuario user = await _usuarioService.FindByUsernameAndApiKeyAsync(authenticationRequest.Username, apiKey);

//            if (user == null)
//            {
//                return Unauthorized("Invalid credentials or API key");
//            }

//            var userDetails = await _userDetailsService.LoadUserByUsernameAsync(user.Id.Login);

//            var token = _jwtAuthConfig.GenerateJwtToken(user.Id.Login);

//            Console.WriteLine("********************************************************************");
//            Console.WriteLine($"token: [{token}]");
//            Console.WriteLine("********************************************************************");

//            return Ok(new JwtResponse { Token = token });
//        }
//    }
//}