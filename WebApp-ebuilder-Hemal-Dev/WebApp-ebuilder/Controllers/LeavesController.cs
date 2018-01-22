using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp_ebuilder.Authorizer;
using WebApp_ebuilder.Models;

namespace WebApp_ebuilder.Controllers
{
    [CustomAuthorize]
    public class LeavesController : BaseController
    {
        // GET: Leaves
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize]
        [HttpGet]               
        public ActionResult ApplyLeave()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize]
        public async System.Threading.Tasks.Task<ActionResult> ApplyLeave(leaveApplyForm leaveForm)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                    var response = await client.GetAsync("Leaves?EID==" +User.EID + "&leaveCategory=" + leaveForm.leaveCategory);

                    var responseData = response.Content.ReadAsStringAsync().Result;
                    var leavesTaken = JsonConvert.DeserializeObject<List<leav>>(responseData);

                    response = await client.GetAsync("LeaveTypes?leaveCategory=" + leaveForm.leaveCategory + "&jobCategory="+User.Role );
                    responseData = response.Content.ReadAsStringAsync().Result;
                    var leaveTypeDetails = JsonConvert.DeserializeObject<leave_type>(responseData);

                    int leaveCount = 0;

                    foreach (leav leave in leavesTaken)
                    {
                        if(leave.date.Year == leaveForm.date.Year)
                        {
                            leaveCount++;
                        }
                    }
                    if(leaveCount >= leaveTypeDetails.maxAllowed)
                    {
                        message = "All leaves for this category are already taken";
                    }

                    leav newLeave = new leav();
                    newLeave.EID = User.EID;
                    newLeave.date = leaveForm.date;
                    newLeave.reason = leaveForm.reason;
                    newLeave.jobCategory = User.Role;
                    newLeave.leaveCategory = leaveForm.leaveCategory;

                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(newLeave);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    response = await client.PostAsync("Leaves?date", stringContent );

                    if (response.IsSuccessStatusCode)
                    {
                        
                        message = "Leave applying successful";
                    }
                    else
                    {
                        message = "Error occured";
                    }

                }
            }
            ViewBag.Message = message;
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> ViewLeaves()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                var response = await client.GetAsync("Leaves");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    var leaveData = JsonConvert.DeserializeObject<List<leav>>(responseData);
                    return View(leaveData);
                }
                return View();
            }

        }

    }
}