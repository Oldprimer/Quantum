using Microsoft.AspNetCore.Mvc;
using Quantum.Data.Model;
using Quantum.Data.Repositories;

namespace Quantum.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteRepository nodeRepository;

        public HomeController(NoteRepository nodeRepository)
        {
            this.nodeRepository = nodeRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Note>> Index()
        {
            return View(nodeRepository.GetAll());
        }
        [HttpGet]
        public ActionResult<Note> Edit(Guid guid)
        {
            var note = nodeRepository.Find(guid);
            return View(note);
        }
        [HttpPut]
        public IActionResult Edit(string Header, string Content)
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult<Task<Note>> Action(string Header, string Content)
        {
            Note note = new Note()
            {
                Note_Id = Guid.NewGuid(),
                Header = Header,
                Content = Content,
                Created = DateTime.Now,
            };
            Console.WriteLine(Header);
            Console.WriteLine(Content);
            nodeRepository.Add(note);
            return RedirectToAction("Index");
        }
    }
}
