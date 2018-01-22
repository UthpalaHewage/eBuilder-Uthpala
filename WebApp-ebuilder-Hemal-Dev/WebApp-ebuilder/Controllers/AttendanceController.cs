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
    public class AttendanceController : BaseController
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> ViewAttendance(string EID)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                var response = await client.GetAsync("Attendance?EID=" + EID);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    List<attendance> attendances = JsonConvert.DeserializeObject<List<attendance>>(responseData);
                    return View(attendances);
                }

                return View();
            }
        }
    }
}