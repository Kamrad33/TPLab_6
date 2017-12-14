using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using TP_Lab5.DAO;

using TP_Lab5.Models;

namespace TP_Lab5.Controllers

{
    public class HomeController : Controller
    {
        RecordsDAO recordsDAO = new RecordsDAO();
        List<Records> records;
        [HttpGet]
        public ActionResult Index()
        {
            return View(recordsDAO.GetAllRecords());
        }
        [Authorize]
        [HttpGet]

        public ActionResult Details(int id)

        {
            records = recordsDAO.GetAllRecords();
            int trueid = 0;
            for (int i = 0; i < records.Count; i++) if (records[i].Id == id) trueid = i;
            return View(records[trueid]);

        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Records records)
        {
            try
            {
                if (recordsDAO.AddRecord(records))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create");
                }
            }
            catch

            {
                return View("Create");
            }
        }
        [Authorize]
        [HttpGet]

        public ActionResult Edit(int id)

        {
            records = recordsDAO.GetAllRecords();
            int trueid = 0;
            for (int i = 0; i < records.Count; i++) if (records[i].Id == id) trueid = i;
            return View(records[trueid]);
        }
        [Authorize]
        [HttpPost]

        public ActionResult Edit(Records record)

        {
            if (ModelState.IsValid)
            {
                recordsDAO.EditRecord(record);
                return View("OK");
            }
            else
            {
                return View("Ошибка");
            }
        }
        [Authorize]
        [HttpGet]

        public ActionResult Delete(int id)

        {
            try
            {
                records = recordsDAO.GetAllRecords();
                int trueid = 0;
                for (int i = 0; i < records.Count; i++) if (records[i].Id == id) trueid = i;
                return View(records[trueid]);
            }
            catch
            {
                return View("Ошибка");
            }       
        }
     //   [Authorize (Roles = GIBDD_User)]
        [HttpPost]

        public ActionResult Delete(Int64 id)
        {
            try
            {
                int rec_id = Convert.ToInt32(id);
                recordsDAO.DeleteRecord(rec_id);
                return View("OK");
            }      
            catch
            {
                return View("Ошибка");
            }
        }
    }
}
