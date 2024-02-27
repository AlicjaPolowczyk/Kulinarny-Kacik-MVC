using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Recipe.MVC.Models;

namespace Recipe.MVC.Controllers
{
    public static class ControllerExtensions
    {
        public static void SetNotification (this Controller controller, string type, string message)
        {
            Notification notification = new Notification (type, message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject (notification);
        }
    }
}
