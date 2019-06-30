namespace Pess.Web
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Pess.Data;
    using System.ComponentModel.DataAnnotations;

    [Authorize]
    [Route("projects")]
    public class ProjectsController : Controller
    {
        private readonly IPessRepository repository;
        public ProjectsController(IPessRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult ListProjects()
        {
            return View();
        }

        [HttpGet("add")]
        public IActionResult AddProject()
        {
            return View();
        }

        [HttpGet("edit/{id}")]
        public IActionResult EditProject([FromRoute, Required] string id)
        {
            return View();
        }
    }
}
