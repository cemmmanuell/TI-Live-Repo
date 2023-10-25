namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using mmmSelfservice.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public class PettyCashController : Controller
    {
        public ActionResult createPettyCash(string departmentcode, string directoratecode, string purposes, decimal amountrequested, string bank)
        {
            pettycashInfo model = JsonConvert.DeserializeObject<pettycashInfo>(WSConfig.ObjNav.FnPettyCashCard(base.Session["username"].ToString(), departmentcode, directoratecode, purposes, amountrequested, bank));
            return base.View(model);
        }

        public ActionResult deletePettyCash(string PettyCashNo)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                WSConfig.ObjNav.FnPettyCashCardDelete(PettyCashNo);
                string input = WSConfig.ObjNav.FnPettyCashList(base.Session["username"].ToString());
                List<pettycashInfo> model = serializer.Deserialize<List<pettycashInfo>>(input);
                return base.View("Index", model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult department()
        {
            List<mmmSelfservice.Models.department> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.department>>(WSConfig.ObjNav.FnDepartment());
            return base.View(model);
        }

        public PartialViewResult departmentvalue(string fundcode)
        {
            List<mmmSelfservice.Models.departmentvalue> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.departmentvalue>>(WSConfig.ObjNav.FnDepartmentValue());
            return base.PartialView(model);
        }

        public ActionResult forapproval(string PettyCashNo, bool Approval)
        {
            WSConfig.ObjNav.FnPettyCashApproval(PettyCashNo, Approval);
            return base.RedirectToAction("index");
        }

        public ActionResult Index()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPettyCashList(base.Session["username"].ToString());
                List<pettycashInfo> model = serializer.Deserialize<List<pettycashInfo>>(input);
                return base.View(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public JsonResult InsertJournals(string Document, string PBank, List<jnllines> Journals)
        {
            resultMt mt = new resultMt();
            try
            {
                int num2;
                foreach (var i in Journals)
                {
                    if (i.documentNo != "")
                    {
                        if (i.description != null)
                        {
                            if (i.currency == null) i.currency = "";

                            WSConfig.ObjNav.FnInsertGeneralJournal(i.postingdate, i.documentNo, PBank,
                               
                                i.amount, i.description, Session["username"].ToString(), i.glAccount, i.fundCode, i.currency);
                        }
                     }

                }
                mt.status = true;
            }
            catch (Exception exception)
            {
                mt.status = false;
                mt.message = exception.Message;
            }
            return new JsonResult { Data = mt };
        }

        public ActionResult payingbank()
        {
            List<bank> model = JsonConvert.DeserializeObject<List<bank>>(WSConfig.ObjNav.FnPettyCashBank());
            return base.View(model);
        }

        public ActionResult pettycashbank()
        {
            return base.View();
        }

       public ActionResult rolecenter()
        {
            List<mmmSelfservice.Models.rolecenter> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.rolecenter>>(WSConfig.ObjNav.FnRolecenter());
            return base.View(model);
        }

        public ActionResult glaccounts()
        {
            List<mmmSelfservice.Models.rolecenter> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.rolecenter>>(WSConfig.ObjNav.FnGLAccounts());
            return base.View(model);
        }
        public PartialViewResult savedjournals(string payingbank)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string input = "";
            input = WSConfig.ObjNav.FnJournalLines(base.Session["username"].ToString(), payingbank);
            List<jnllines> model = serializer.Deserialize<List<jnllines>>(input);
            return base.PartialView(model);
        }

        public ActionResult updatePettyCash(string PettyCashNo, string departmentcode, string directoratecode, string purposes, decimal amountrequested, string bank)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string input = "";
            input = WSConfig.ObjNav.FnPettyCashCardDoUpdate(PettyCashNo, departmentcode, directoratecode, purposes, amountrequested, bank);
            List<pettycashInfo> model = serializer.Deserialize<List<pettycashInfo>>(input);
            return base.View("index", model);
        }

        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }
    }
}

