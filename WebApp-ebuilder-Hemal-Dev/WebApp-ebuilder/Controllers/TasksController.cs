using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApp_ebuilder.Models;

namespace WebApp_ebuilder.Controllers
{
    public class TasksController : BaseController
    {
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> ViewTasks()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                var response = await client.GetAsync("Tasks");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    var taskData = JsonConvert.DeserializeObject<List<task>>(responseData);

                    return View(taskData);
                }
                return View();
            }
        }
    }
}