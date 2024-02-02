using ASPDotnetCoreMVC_Exercice01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPDotnetCoreMVC_Exercice01.Controllers
{
    public class ContactsController : Controller
    {
        public List<ContactModel> Contacts { get; set; } = new List<ContactModel>()
        {
            new ContactModel()
            {
                Id = 1,
                Lastname = "MASQUELIER",
                Firstname = "Guillaume",
                Email = "gmasquelier@gmail.com",
                Phone = "06 07 08 09 10",
                Resume = "Hello ! I'm a french .Net dvelopper :-)",
                Photo = "https://bootdey.com/img/Content/avatar/avatar2.png"
            },
            new ContactModel()
            {
                Id = 2,
                Lastname = "SMITH",
                Firstname = "John",
                Email = "john.smith@gmail.com",
                Phone = "06 99 88 77 66",
                Resume = "Hey, it's me !",
                Photo = "https://bootdey.com/img/Content/avatar/avatar1.png"
            },
            new ContactModel()
            {
                Id = 3,
                Lastname = "MAO",
                Firstname = "Massima",
                Email = "mao.massima@outlook.com",
                Phone = "06 11 33 44 66",
                Resume = "Hey, it's not me !",
                Photo = "https://bootdey.com/img/Content/avatar/avatar7.png"
            }
        };

        public IActionResult Details(int id)
        {
            ViewData["breadcrumb"] = new List<string> { "Contacts", "Détail" };

            ContactModel contact = Contacts.FirstOrDefault<ContactModel>(c => c.Id == id, null);

            return View(contact);
        }

        public IActionResult Add()
        {
            ViewData["breadcrumb"] = new List<string> { "Contacts", "Nouveau" };

            return View();
        }

        public IActionResult Index()
        {
            ViewData["breadcrumb"] = new List<string>() { "Contacts", "Liste" };

            return View(Contacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
