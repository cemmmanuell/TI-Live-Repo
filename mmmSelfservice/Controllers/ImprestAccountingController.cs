namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using mmmSelfservice.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public class ImprestAccountingController : Controller
    {
        public ActionResult Approvedimprestsurrender()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnSurrenderList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                                  where r.Status == "Approved"
                                  select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult createimprestSurrender(string ImprestNo)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string str = "";
            ImprestAccounting model = JsonConvert.DeserializeObject<ImprestAccounting>(str);
            return base.View("Index", model);
        }

        public PartialViewResult departmentvalue(string fundcode)
        {
            List<mmmSelfservice.Models.departmentvalue> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.departmentvalue>>(WSConfig.ObjNav.FnDepartmentValue());
            return base.PartialView(model);
        }

        public ActionResult imprestAccountingDoc()
        {
            return base.View();
        }

        public ActionResult imprestList()
        {
            List<imprestRinfoModel> list = JsonConvert.DeserializeObject<List<imprestRinfoModel>>(WSConfig.ObjNav.FnImprestList(base.Session["username"].ToString()));
            return base.View(from r in list
                             where (r.Posted == "Yes") && !r.surrendered
                             select r);
        }

        public PartialViewResult imprestsurrendercard()
        {
            return base.PartialView();
        }

        public PartialViewResult imprestsurrendercardView()
        {
            return base.PartialView();
        }

        public PartialViewResult imprestsurrenderedit(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string input = WSConfig.ObjNav.FnSurrenderList(base.Session["username"].ToString());
            List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
            return base.PartialView((from r in list
                                     where r.No == no
                                     select r).ToList<imprestRinfoModel>().FirstOrDefault<imprestRinfoModel>());
        }

        public PartialViewResult imprestsurrendereditView(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string input = WSConfig.ObjNav.FnSurrenderList(base.Session["username"].ToString());
            List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
            return base.PartialView((from r in list
                                     where r.No == no
                                     select r).ToList<imprestRinfoModel>().FirstOrDefault<imprestRinfoModel>());
        }

        public PartialViewResult imprestsurrenderlines(string ImprestNo)
        {
            List<ImprestLine> source = JsonConvert.DeserializeObject<List<ImprestLine>>(WSConfig.ObjNav.FnImprestLine(ImprestNo));
            return base.PartialView(source.ToList<ImprestLine>());
        }

        public ActionResult Index()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnSurrenderList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                                  where r.Status == "Open"
                                  select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult insertimprestsurrender(string imprestno)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            resultMt mtS = new resultMt();
            string no = WSConfig.ObjNav.FnInstImrSrNew(imprestno, base.Session["username"].ToString());
            mtS.status = true;
            string input = WSConfig.ObjNav.FnSurrenderList(base.Session["username"].ToString());
            List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
            return base.PartialView((from r in list
                                     where r.No == no
                                     select r).ToList<imprestRinfoModel>().FirstOrDefault<imprestRinfoModel>());
        }

        public ActionResult newimprestsurrender()
        {
            return base.View();
        }

        public ActionResult Pendingimprestsurrender()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnSurrenderList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                                  where r.Status == "Pending Approval"
                                  select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult rolecenter()
        {
            List<mmmSelfservice.Models.rolecenter> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.rolecenter>>(WSConfig.ObjNav.FnRolecenter());
            return base.View(model);
        }

        public ActionResult sendforapproval(string no)
        {
            try
            {
                WSConfig.ObjNav.FnApproval(no);
                return base.RedirectToAction("index");
            }
            catch (Exception)
            {
            }
            return base.RedirectToAction("index");
        }
        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }


        public JsonResult updatesurrenderline(List<string> implines)
        {
            resultMt mt = new resultMt();
            try
            {
                int num2;
                for (int i = 0; i < implines.Count; i = num2 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray = implines[i].Split(separator, StringSplitOptions.None);
                    WSConfig.ObjNav.FnSurrenderLineUpdate(Convert.ToInt32(strArray[1].ToString()), Convert.ToDecimal(strArray[0].ToString()), strArray[2].ToString(), Convert.ToDecimal(strArray[3].ToString()));
                    num2 = i;
                }
                mt.status = true;
            }
            catch (Exception)
            {
            }
            return new JsonResult { Data = mt };
        }

    }
}

