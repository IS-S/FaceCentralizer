using Microsoft.AspNetCore.Mvc;
using FC.Core;


namespace PhotoHubFaceCentralizer.Controllers
{
    [ApiController]
    [Route("centralize_photo")]
    public class FaceCentralizeController : ControllerBase
    {

        private readonly IFaceCentralizer _centralizer;

        public FaceCentralizeController(IFaceCentralizer centralizer)
        {
            _centralizer = centralizer;
        }

        [HttpPost]
        [Route("post_data")]
        public ActionResult Post(string path) // TEST path: C:/Users/i.sumin/Pictures/test2.jpg
        {
            var result = _centralizer.Centralize(path);

            switch(result)
            {
                case "success":
                    return Ok();
                case "Empty faces array":
                    return NotFound();
                default:
                    return StatusCode(500);
            }
        }
    }
}
