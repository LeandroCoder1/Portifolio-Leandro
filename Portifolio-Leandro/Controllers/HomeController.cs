using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portifolio_Leandro.Models;

namespace Portifolio_Leandro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Project()
        {
            var projects = new List<ProjectModel>
            {
                new ProjectModel { Id = 1, Title = "API de Autenticação", Description = "API REST com JWT e .NET 7", RepoUrl = "https://github.com/seuusuario/projeto-auth", Tags = new[]{"C#","API","JWT"} },
                new ProjectModel { Id = 2, Title = "App Web", Description = "SPA com React + .NET", LiveUrl = "https://seusite.com", Tags = new[]{"React","C#","SPA"} }
            };

            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
