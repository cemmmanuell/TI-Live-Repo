namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using mmmSelfservice.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Web.UI;
    using System.Xml.Serialization;

    public class PurchaseController : Controller
    {
        public PartialViewResult addrequestLine(string purchaseNo)
        {
            return base.PartialView();
        }

        public PartialViewResult approvalrequest()
        {
            return base.PartialView();
        }

        public ActionResult approvedPurchase()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPurchaseRequisitionList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                    where (r.Status == "Released") && (r.Completed == "No")
                    select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult cancelApprovalRequest()
        {
            return base.PartialView();
        }

        public PartialViewResult deleterequestLines(string purchaseNo)
        {
            return base.PartialView();
        }

        public PartialViewResult editPurchase(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPurchaseRequisitionList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.PartialView((from r in list
                    where (r.Status == "Open") && (r.No == no)
                    select r).FirstOrDefault<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult editPurchaseView(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPurchaseRequisitionList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.PartialView((from r in list
                    where r.No == no
                    select r).FirstOrDefault<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult editrequestliens(string purchaseNo)
        {
            return base.PartialView();
        }

        public ActionResult Index()
        {
            return base.View();
        }

        public JsonResult insertimprestheader1(string purpose, string fundcode, string programcode, List<string> implines, DateTime daterequired, string budgetdimension, string departmentdimension, string budgetdescription, string missiono)
        {
            resultMt mt = new resultMt();
            try
            {
                int num2;
                string documentno = WSConfig.ObjNav.FninsertPurchasenew(fundcode, programcode, "", daterequired, departmentdimension, budgetdimension, budgetdescription, missiono, base.Session["username"].ToString());
                for (int i = 0; i < implines.Count; i = num2 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray = implines[i].Split(separator, StringSplitOptions.None);
                    WSConfig.ObjNav.FnPurchaselineinsert(strArray[1].ToString(), strArray[0].ToString(), Convert.ToDecimal(strArray[2].ToString()), strArray[3].ToString(), Convert.ToDecimal(strArray[4].ToString()), documentno);
                    mt.status = true;
                    num2 = i;
                }
            }
            catch (Exception)
            {
                mt.status = false;
            }
            return new JsonResult { Data = mt };
        }

        public JsonResult insertrequisition(string fundcode, string programcode, DateTime daterequired, string missionno, string budgetdimension, string departmentdimension, string budgetdescription)
        {
            resultMt mt = new resultMt();
            try
            {
                WSConfig.ObjNav.FnInsertPurchaseRequest(fundcode, programcode, daterequired, missionno, departmentdimension, budgetdimension, budgetdescription, base.Session["username"].ToString());
            }
            catch (Exception)
            {
            }
            return new JsonResult { Data = mt };
        }

        public PartialViewResult newPurchase()
        {
            return base.PartialView();
        }

        public ActionResult openPurchases()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPurchaseRequisitionList(base.Session["username"].ToString());
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

        public ActionResult pendingPurchases()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPurchaseRequisitionList(base.Session["username"].ToString());
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

        public ActionResult postedmissionProposals()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                    where r.Status == "Released"
                    select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult postedpurchasereq()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPurchaseRequisitionList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                    where r.Status == "Released"
                    select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult postedPurchases()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPurchaseRequisitionList(base.Session["username"].ToString());
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

        public static string RenderPartialToString(string controlName, object viewData)
        {
            ViewPage page = new ViewPage {
                ViewContext = new ViewContext()
            };
            page.ViewData = new ViewDataDictionary(viewData);
            page.Controls.Add(page.LoadControl(controlName));
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                using (HtmlTextWriter writer2 = new HtmlTextWriter(writer))
                {
                    page.RenderControl(writer2);
                }
            }
            return sb.ToString();
        }

        public PartialViewResult requestlines(string purchaseNo)
        {
            List<ImprestLine> model = JsonConvert.DeserializeObject<List<ImprestLine>>(WSConfig.ObjNav.FnImprestLine(purchaseNo));
            return base.PartialView(model);
        }

        public PartialViewResult requestlinesView(string purchaseNo)
        {
            List<ImprestLine> model = JsonConvert.DeserializeObject<List<ImprestLine>>(WSConfig.ObjNav.FnImprestLine(purchaseNo));
            return base.PartialView(model);
        }

        public JsonResult Updateimprestheader1(string fundcode, string programcode, List<string> implines, DateTime daterequired, string budgetdimension, string departmentdimension, string budgetdescription, string missiono, string no)
        {
            resultMt mt = new resultMt();
            try
            {
                int num3;
                string documentno = WSConfig.ObjNav.FnUpdatePurchasenew(fundcode, programcode, "", daterequired, departmentdimension, budgetdimension, budgetdescription, missiono, no);
                for (int i = 0; i < implines.Count; i = num3 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray = implines[i].Split(separator, StringSplitOptions.None);
                    if (strArray[5] != "")
                    {
                        int lineno = Convert.ToInt32(strArray[5].ToString());
                        WSConfig.ObjNav.FnPurchaselineModify(strArray[0].ToString(), strArray[1].ToString(), Convert.ToDecimal(strArray[2].ToString()), strArray[3].ToString(), Convert.ToDecimal(strArray[4].ToString()), documentno, lineno);
                    }
                    else
                    {
                        WSConfig.ObjNav.FnPurchaselineinsert(strArray[0].ToString(), strArray[1].ToString(), Convert.ToDecimal(strArray[2].ToString()), strArray[3].ToString(), Convert.ToDecimal(strArray[4].ToString()), documentno);
                    }
                    num3 = i;
                }
                mt.status = true;
            }
            catch (Exception)
            {
                if (implines == null)
                {
                    mt.status = true;
                }
                else
                {
                    mt.status = false;
                }
            }
            return new JsonResult { Data = mt };
        }

       
        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }
    }
}

