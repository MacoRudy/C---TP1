using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP3Razor.Entities;

namespace TP3Razor.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            List<Chat> chats = FakeDb.Instance.ListeChats;

            return View(chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            List<Chat> chats = FakeDb.Instance.ListeChats;
            Chat chat = chats.First(x => x.Id == id);
            return View(chat);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            List<Chat> chats = FakeDb.Instance.ListeChats;
            Chat chat = chats.First(x => x.Id == id);
            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                List<Chat> chats = FakeDb.Instance.ListeChats;
                Chat chat = chats.First(x => x.Id == id);
                chats.Remove(chat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
