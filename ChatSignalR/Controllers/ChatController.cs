using Microsoft.AspNetCore.Mvc;

namespace ChatSignalR.Controllers
{
    public class ChatController : Controller
    {
        public static Dictionary<int, string> Rooms =
            new Dictionary<int, string>() {
                {1, "Programación"},
                {2, "Videojuegos"},
                {3, "Comics"}
            
            };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Room(int room)
        {
            string roomName;
            if (Rooms.TryGetValue(room, out roomName))
            {
                return View("Room", roomName);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
