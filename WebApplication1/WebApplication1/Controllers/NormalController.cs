using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //The ApiVersion attribute allows you to specify which API versions that WorkoutsController supports.
    //In this case, the controller supports both v1 and v2. You use the MapToApiVersion attribute on the endpoints to specify the concrete API version.
    [ApiVersion(1, Deprecated = true)] //If you want to deprecate an old API version, you can set the Deprecated property on the ApiVersion attribute. The deprecated API versions will be reported using the api-deprecated-versions response header.
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{v:apiVersion}/workouts")]
    public class WorkoutsController : ControllerBase
    {
        [MapToApiVersion(1)]
        [HttpGet("{workoutId}")]
        public IActionResult GetWorkoutV1(Guid workoutId)
        {
            // old logic
            return Ok();
        }

        [MapToApiVersion(2)]
        [HttpGet("{workoutId}")]
        public IActionResult GetWorkoutV2(Guid workoutId)
        {
            // new logic
            return Ok();
        }
    }
}
