namespace Project_Backend_2024.Controllers.CommandControllers;

[ApiController]
[Route("[controller]")]
public class UsersController() : Controller
{

    [HttpPost("register")]
    public async Task<IActionResult> RegisterRecruiter([FromBody] )
    {
        try
        {
            var result = await recruiterUserRegistration.Register(registerRecruiterUserModel);



            return Ok("Registered yay!");
        }
        catch (EmailAlreadyExistsException ex)
        {
            logger.LogError("{Date}: Email already registered redirecting to log in: {errorMessage}", DateTime.Now,
                ex.Message);
            return Ok(new { message = ex.Message });
        }
        catch (IdentityException ex)
        {
            logger.LogWarning("{Date}: Identity error: {errorMessage}", DateTime.Now, ex.Message);
            return BadRequest(new { message = "Format error, please check your credentials again!" });
        }
        catch (EmailValidationException ex)
        {
            logger.LogWarning("{Date}: Email validation error: {errorMessage}", DateTime.Now, ex.Message);
            return BadRequest(new { message = "Invalid Email" });
        }
        catch (PasswordValidationException ex)
        {
            logger.LogError("{Date}: Password format error: {errorMessage}", DateTime.Now, ex.Message);
            return BadRequest(new { message = ex.Message });
        }

        catch (EntityAlreadyExistsException ex)
        {
            logger.LogError("{Date}: {errorMessage}", DateTime.Now, ex.Message);
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}