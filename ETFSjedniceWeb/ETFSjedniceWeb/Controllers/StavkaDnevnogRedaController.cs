using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETFSjedniceWeb.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ETFSjedniceWeb.Controllers
{
    public class StavkaDnevnogRedaController : Controller
    {

        HttpClient client;
        //The URL of the WEB API Service
        string url = Startup.url + "/api/StavkaDnevnogReda";
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public StavkaDnevnogRedaController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: EmployeeInfo
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employees = JsonConvert.DeserializeObject<List<STAVKA_DNEVNOG_REDA>>(responseData);
                return View(Employees);
            }
            return View("Error");
        }

        public async Task<ActionResult> ListaStavki(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employees = JsonConvert.DeserializeObject<List<STAVKA_DNEVNOG_REDA>>(responseData);
                var filteredList = Employees.Where(x => x.SJEDNICA_ID==id).ToList();
                return View(filteredList);
            }
            return View("Error");
        }

        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employees = JsonConvert.DeserializeObject<STAVKA_DNEVNOG_REDA>(responseData);
                return View(Employees);
            }
            return View("Error");
        }

        public ActionResult Create()
        {
            return View(new STAVKA_DNEVNOG_REDA());
        }
        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(STAVKA_DNEVNOG_REDA tipGlasa)
        {
            tipGlasa.STATUS_STAVKE_DR_ID = 1;
            tipGlasa.SJEDNICA_ID = 61;
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, tipGlasa);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListaStavki/61");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employee = JsonConvert.DeserializeObject<STAVKA_DNEVNOG_REDA>(responseData);
                return View(Employee);
            }
            return View("Error");
        }
        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, STAVKA_DNEVNOG_REDA Emp)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employee = JsonConvert.DeserializeObject<STAVKA_DNEVNOG_REDA>(responseData);
                return View(Employee);
            }
            return View("Error");
        }
        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, STAVKA_DNEVNOG_REDA tipGlasa)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListaStavki/61");
            }
            return RedirectToAction("Error");
        }
    }
}
