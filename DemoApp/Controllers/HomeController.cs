using AO.GenericRepository.Core.Interfaces;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IGenericRepository<Student> _repository;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<Student> repository)
        {
            _logger = logger;
            _repository = repository;   
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getAll()
        {
            var students = _repository.GetAll();
            return View();
        }

        public IActionResult getById(int id)
        {
            var student = _repository.GetById(id);
            return View();
        }


        public IActionResult SearchByName(string name)
        {
            var student = _repository.FindWithSpecificationPattern(new StudentByNameSpecification(name)).FirstOrDefault();
            return View();
        }



        public IActionResult AddStudent(string name, string prenom)
        {
            var student = new Student();
            student.Id = 1;
            student.Name = name;
            student.Prenom = prenom;
            _repository.AddAndSave(student);
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}