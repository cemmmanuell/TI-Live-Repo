namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using mmmSelfservice.Models;
   
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public class ImprestController : Controller
    {
        private static Uri uri = new Uri(ConfigurationManager.AppSettings["ODATA_URI"]);
        

        public PartialViewResult Activities(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Activity"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult ActivitiesView(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Activity"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult AddImprestLine(string imprestNo, string Type, decimal Amount)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string input = WSConfig.ObjNav.FnImprestLineCardEdit(imprestNo, Type, Amount);
            base.Session["ImprestNo"] = imprestNo;
            List<mmmSelfservice.Models.ImprestLine> model = serializer.Deserialize<List<mmmSelfservice.Models.ImprestLine>>(input);
            return this.PartialView("ImprestLine", model);
        }

        public ActionResult Approvedimprests()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnImprestList(base.Session["username"].ToString());
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

        public ActionResult approvedProposals()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
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

        public PartialViewResult budgetdescription()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnDimensionValuesList("");
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView((from r in list
                    where r.Type == "4"
                    select r).ToList<standardtexts>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult budgetdimesion(string fundcode)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnDimensionValuesList(fundcode);
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView(list);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public PartialViewResult Payes()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnVendors();
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView(list);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public PartialViewResult UnitsOfMeasure()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnUnitsOfMeasure();
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView(list);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult BudgetInformation(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Budget Info"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult BudgetInformationView(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Budget Info"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult budgetnotes(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Budget Notes"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult completedProposals()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                    where r.Completed == "Yes"
                    select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult country()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnGetContryregions();
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.View((from r in list
                    where r.Type == "Country"
                    select r).ToList<standardtexts>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult county()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnGetContryregions();
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView((from r in list
                    where r.Type == "County"
                    select r).ToList<standardtexts>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult createimprest(string departmentcode, string directoratecode, string responsibilitycenter, string purposes, DateTime startdate, DateTime enddate)
        {
            imprestRinfoModel model = JsonConvert.DeserializeObject<imprestRinfoModel>(WSConfig.ObjNav.FnImprestCard(base.Session["username"].ToString(), departmentcode, directoratecode, purposes, responsibilitycenter, startdate, enddate));
            return base.View(model);
        }

        public ActionResult currencies()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnGetcurrencyCodes();
                List<mmmSelfservice.Models.currencies> model = serializer.Deserialize<List<mmmSelfservice.Models.currencies>>(input);
                return base.PartialView(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult deleteImprestLine(string imprestNo, int LineNo)
        {
            string str = WSConfig.ObjNav.FnImprestLineDelete(imprestNo, LineNo);
            base.Session["ImprestNo"] = imprestNo;
            List<mmmSelfservice.Models.ImprestLine> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.ImprestLine>>(str);
            return this.PartialView("ImprestLine", model);
        }

        public JsonResult deleteline(string line, string document)
        {
            resultMt mt = new resultMt();
            int lineno = Convert.ToInt32(line);
            string documentNo = document;
            try
            {
                WSConfig.ObjNav.FnDeletePurchaseLine(lineno, documentNo);
                mt.status = true;
            }
            catch (Exception exception)
            {
                mt.status = false;
                mt.message = exception.Message;
            }
            return new JsonResult { Data = mt };
        }

        public ActionResult department()
        {
            List<mmmSelfservice.Models.department> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.department>>(WSConfig.ObjNav.FnDepartment());
            return base.View(model);
        }

        public PartialViewResult departments()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnDimensionValuesList("");
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView((from r in list
                    where r.Type == "5"
                    select r).ToList<standardtexts>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult departmentvalue(string fundcode)
        {
            List<mmmSelfservice.Models.departmentvalue> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.departmentvalue>>(WSConfig.ObjNav.FnDepartmentValue());
            return base.PartialView(model);
        }

       

        public PartialViewResult editImp(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnImprestList(base.Session["username"].ToString());
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

        public PartialViewResult editImpView(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnImprestList(base.Session["username"].ToString());
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

        public PartialViewResult editmissionproposal(string missionno)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.PartialView((from r in list
                    where (r.Status == "Open") && (r.No == missionno)
                    select r).FirstOrDefault<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult editmissionproposalView(string missionno)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.PartialView((from r in list
                    where r.No == missionno
                    select r).FirstOrDefault<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult expensecategories()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnGetStandardText();
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView(list);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult fundcodeonchange(string fundcode)
        {
            List<mmmSelfservice.Models.departmentvalue> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.departmentvalue>>(WSConfig.ObjNav.FnDepartmentValue());
            return base.PartialView(model);
        }

        public PartialViewResult ImprestEdit(string ImprestNo)
        {
            string str = WSConfig.ObjNav.FnImprestCardEdit(ImprestNo);
            base.Session["ImprestNo"] = ImprestNo;
            imprestRinfoModel model = JsonConvert.DeserializeObject<imprestRinfoModel>(str);
            return base.PartialView(model);
        }

        public PartialViewResult ImprestLine(string ImprestNo)
        {
            if (ImprestNo == null)
            {
                ImprestNo = base.Session["ImprestNo"].ToString();
            }
            string str = WSConfig.ObjNav.FnImprestLine(ImprestNo);
            base.Session["ImprestNo"] = ImprestNo;
            List<mmmSelfservice.Models.ImprestLine> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.ImprestLine>>(str);
            return base.PartialView(model);
        }

        public ActionResult imprestreq(string no)
        {
            WSConfig.ObjNav.FnApproval(no);
            return base.RedirectToAction("index", "imprest");
        }

        public ActionResult Index()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnImprestList(base.Session["username"].ToString());
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

        public JsonResult insertimprestheader(imprestRinfoModel s)
        {
            int num2;
            resultMt mt = new resultMt();
            try
            {
                //s.emno = Session["username"].ToString();

                WSConfig.ObjNav.Fninsertimprestnew (JsonConvert.SerializeObject(s), Session["username"].ToString());
                mt.status = true;

            }
            catch(Exception e)
            {
                mt.status = false;
                mt.message = e.Message.ToString();
            }
           
            //string documentno = WSConfig.ObjNav.Fninsertimprestnew(programcode, fundcode, purpose, departmentdimension, budgetdimension, budgetdescription, base.Session["username"].ToString(), "", "");
            


            return new JsonResult { Data = mt };
        }

        public JsonResult insertmissionproposal(string strategicfocusarea, string subpillar, string projecttitle, string country, string county, string dateofactivities, string missionteam, string invitedmembers, string fundcode, string programcode, string budgetdimension, string departmentdimension, string budgetdescription, List<string> objectives, string focus, string outcome, List<string> roles, List<string> activities, List<string> budgetinfo, string background, List<string> budgetnotes)
        {
            int num2;
            resultMt mt = new resultMt();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string documentno = WSConfig.ObjNav.FnInsertMissionProporsal(strategicfocusarea, subpillar, projecttitle, country, county, dateofactivities, missionteam, invitedmembers, programcode, fundcode, departmentdimension, budgetdimension, budgetdescription, background, focus, outcome, base.Session["username"].ToString());
            mt.status = true;
            try
            {
                for (int i = 0; i < objectives.Count; i = num2 + 1)
                {
                    if (objectives[i].ToString() != "")
                    {
                        WSConfig.ObjNav.Fninsertmisssionobjectives(objectives[i].ToString(), documentno);
                    }
                    num2 = i;
                }
            }
            catch (Exception exception)
            {
                mt.status = false;
                mt.message = exception.Message;
                return new JsonResult { Data = mt };
            }
            try
            {
                for (int i = 0; i < activities.Count; i = num2 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray = activities[i].Split(separator, StringSplitOptions.None);
                    if (strArray[0].ToString() != "")
                    {
                        WSConfig.ObjNav.Fninsertmissionactivities(Convert.ToDateTime(strArray[0].ToString()), strArray[1].ToString(), documentno, strArray[2].ToString(), strArray[3].ToString());
                    }
                    num2 = i;
                }
            }
            catch (Exception exception2)
            {
                mt.status = false;
                mt.message = exception2.Message;
                return new JsonResult { Data = mt };
            }
            try
            {
                for (int i = 0; i < roles.Count; i = num2 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray2 = roles[i].Split(separator, StringSplitOptions.None);
                    if (strArray2[0].ToString() != "")
                    {
                        WSConfig.ObjNav.Fninsertteamroles(strArray2[0].ToString(), strArray2[1].ToString(), documentno);
                    }
                    num2 = i;
                }
            }
            catch (Exception exception3)
            {
                mt.status = false;
                mt.message = exception3.Message;
                return new JsonResult { Data = mt };
            }
            try
            {
                for (int i = 0; i < budgetnotes.Count; i = num2 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray3 = budgetnotes[i].Split(separator, StringSplitOptions.None);
                    if (strArray3[0].ToString() != "")
                    {
                        WSConfig.ObjNav.FninsertBudgetNotes(strArray3[0].ToString(), strArray3[1].ToString(), strArray3[2].ToString(), strArray3[3].ToString(), strArray3[4].ToString(), documentno);
                    }
                    num2 = i;
                }
            }
            catch (Exception exception4)
            {
                mt.status = false;
                mt.message = exception4.Message;
                return new JsonResult { Data = mt };
            }
            try
            {
                for (int i = 0; i < budgetinfo.Count; i = num2 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray4 = budgetinfo[i].Split(separator, StringSplitOptions.None);
                    if (strArray4[0].ToString() != "")
                    {
                        decimal noofdays = 0M;
                        decimal noofpas = 0M;
                        decimal ksh = 0M;
                        decimal othercurrency = 0M;
                        if (strArray4[2].ToString() != "")
                        {
                            noofdays = Convert.ToDecimal(strArray4[2].ToString());
                        }
                        if (strArray4[3].ToString() != "")
                        {
                            noofpas = Convert.ToDecimal(strArray4[3].ToString());
                        }
                        if (strArray4[4].ToString() != "")
                        {
                            ksh = Convert.ToDecimal(strArray4[4].ToString());
                        }
                        WSConfig.ObjNav.Fninsertbudgetinfo(strArray4[1].ToString(), strArray4[0].ToString(), documentno, noofdays, noofpas, ksh, othercurrency, strArray4[6].ToString(), strArray4[5].ToString());
                    }
                    num2 = i;
                }
            }
            catch (Exception exception5)
            {
                mt.status = false;
                mt.message = exception5.Message;
                return new JsonResult { Data = mt };
            }
            return new JsonResult { Data = mt };
        }

        public ActionResult missionproporsalreq(string no)
        {
            WSConfig.ObjNav.FnApproval(no);
            return base.RedirectToAction("openMissionProposals", "imprest");
        }

        public PartialViewResult newimprest()
        {
            return base.PartialView();
        }

        public PartialViewResult newmissionProposal()
        {
            return base.PartialView();
        }

        public PartialViewResult Objectives(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Objectives"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult ObjectivesView(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Objectives"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult openMissionProposals()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
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

        public ActionResult paymenttype()
        {
            List<mmmSelfservice.Models.paymenttype> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.paymenttype>>(WSConfig.ObjNav.FnPaymentTypes(3));
            return base.View(model);
        }

        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }

        public ActionResult pendingimprests()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnImprestList(base.Session["username"].ToString());
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

        public ActionResult pendingProposals()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
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

        public ActionResult Postedimprests()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnImprestList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.View((from r in list
                    where r.Posted == "Yes"
                    select r).ToList<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult purchaserequest(string no)
        {
            WSConfig.ObjNav.FnApproval(no);
            return base.RedirectToAction("openpurchases", "Purchase");
        }
        

        public ActionResult rolecenter()
        {
            List<mmmSelfservice.Models.rolecenter> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.rolecenter>>(WSConfig.ObjNav.FnRolecenter());
            return base.View(model);
        }

        public ActionResult sendforapproval(string imprestNo)
        {
            WSConfig.ObjNav.FnImprestApprovalRequest(imprestNo);
            return base.RedirectToAction("index");
        }

        public ActionResult sendforapprovalcancel(string imprestNo)
        {
            WSConfig.ObjNav.FnImprestCancelApprovalRequest(imprestNo);
            return base.RedirectToAction("index");
        }

        public PartialViewResult strategicFocusAreas()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnGetStandardText();
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView((from r in list
                    where r.Type == "Focus Area"
                    select r).ToList<standardtexts>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult subpillar()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnGetStandardText();
                List<standardtexts> list = serializer.Deserialize<List<standardtexts>>(input);
                return base.PartialView((from r in list
                    where r.Type == "Sub Pillar"
                    select r).ToList<standardtexts>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult teamRoles(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Team Roles"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult teamRolesview(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnpurchaseLines(no);
                List<PurchaseLines> list = serializer.Deserialize<List<PurchaseLines>>(input);
                return base.PartialView((from r in list
                    where r.LineType == "Team Roles"
                    select r).ToList<PurchaseLines>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult updateimprest(string ImprestNo, string departmentcode, string directoratecode, string responsibilitycenter, string purposes, DateTime startdate, DateTime enddate)
        {
            imprestRinfoModel model = JsonConvert.DeserializeObject<imprestRinfoModel>(WSConfig.ObjNav.FnUpdateImprestCard(ImprestNo, departmentcode, directoratecode, purposes, responsibilitycenter, startdate, enddate));
            return base.View("~/View/Imprest/Index", model);
        }

        public JsonResult updateimprestheader(string purpose, string fundcode, string programcode, List<string> implines, string budgetdimension, string departmentdimension, string budgetdescription, string missionno, string purchaseNo, string document)
        {
            resultMt mt = new resultMt();
            try
            {
                int num3;
                for (int i = 0; i < implines.Count; i = num3 + 1)
                {
                    string[] separator = new string[] { "??" };
                    string[] strArray = implines[i].Split(separator, StringSplitOptions.None);
                    if (strArray[5] != "")
                    {
                        int lienno = Convert.ToInt32(strArray[5].ToString());
                        WSConfig.ObjNav.FninsertimprestModify(programcode, fundcode, purpose, departmentdimension, budgetdimension, budgetdescription, base.Session["username"].ToString(), "", "", document);
                        WSConfig.ObjNav.Fnimprestlinemodify(strArray[0].ToString(), strArray[1].ToString(), Convert.ToDecimal(strArray[2].ToString()), strArray[3].ToString(), Convert.ToDecimal(strArray[4].ToString()), document, lienno);
                    }
                    else
                    {
                        WSConfig.ObjNav.FninsertimprestModify(programcode, fundcode, purpose, departmentdimension, budgetdimension, budgetdescription, base.Session["username"].ToString(), missionno, purchaseNo, document);
                        WSConfig.ObjNav.Fnimprestlineinsert(strArray[0].ToString(), strArray[1].ToString(), Convert.ToDecimal(strArray[2].ToString()), strArray[3].ToString(), Convert.ToDecimal(strArray[4].ToString()), document);
                    }
                    mt.status = true;
                    num3 = i;
                }
            }
            catch (Exception)
            {
                mt.status = false;
            }
            return new JsonResult { Data = mt };
        }

        public JsonResult updatemissionproposal(string strategicfocusarea, string subpillar, string projecttitle, string country, string county, string dateofactivities, string missionteam, string invitedmembers, string fundcode, string programcode, string no)
        {
            resultMt mt = new resultMt();
            try
            {
                mt.status = true;
            }
            catch (Exception exception)
            {
                mt.status = false;
                mt.message = exception.InnerException.ToString();
            }
            return new JsonResult { Data = mt };
        }

        public JsonResult updatemsproposal(string strategicfocusarea, string subpillar, string projecttitle, string country, string county, string dateofactivities, string missionteam, string invitedmembers, string fundcode, string programcode, string budgetdimension, string departmentdimension, string budgetdescription, List<string> objectives, string focus, string outcome, List<string> roles, List<string> activities, List<string> budgetinfo, string background, string msno, List<string> budgetnotes)
        {
            resultMt mt = new resultMt();
            try
            {
                int num2;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string documentno = msno;
                WSConfig.ObjNav.FnUpdateMissionProporsal(strategicfocusarea, subpillar, projecttitle, country, county, dateofactivities, missionteam, invitedmembers, programcode, fundcode, msno, departmentdimension, budgetdimension, budgetdescription, background, focus, outcome);
                mt.status = true;
                try
                {
                    for (int i = 0; i < objectives.Count; i = num2 + 1)
                    {
                        string[] separator = new string[] { "??" };
                        string[] strArray = objectives[i].Split(separator, StringSplitOptions.None);
                        if (strArray[0].ToString() != "")
                        {
                            if (strArray[1].ToString() == "")
                            {
                                WSConfig.ObjNav.Fninsertmisssionobjectives(strArray[0].ToString(), documentno);
                            }
                            else
                            {
                                WSConfig.ObjNav.FnUpdatebudgetinfo("", "", msno, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, "", "", Convert.ToInt32(strArray[1].ToString()), 1, DateTime.Today, "", "", "", "", "", strArray[0].ToString(), "");
                            }
                        }
                        num2 = i;
                    }
                }
                catch (Exception exception)
                {
                    mt.status = false;
                    mt.message = exception.Message;
                    return new JsonResult { Data = mt };
                }
                try
                {
                    for (int i = 0; i < activities.Count; i = num2 + 1)
                    {
                        string[] separator = new string[] { "??" };
                        string[] strArray2 = activities[i].Split(separator, StringSplitOptions.None);
                        if (strArray2[0].ToString() != "")
                        {
                            string str3 = "";
                            str3 = strArray2[3].ToString();
                            if (strArray2[4].ToString() == "")
                            {
                                WSConfig.ObjNav.Fninsertmissionactivities(Convert.ToDateTime(strArray2[0].ToString()), strArray2[1].ToString(), documentno, strArray2[2].ToString(), strArray2[3].ToString());
                            }
                            else
                            {
                                WSConfig.ObjNav.FnUpdatebudgetinfo(strArray2[1].ToString(), strArray2[0].ToString(), documentno, decimal.Zero, decimal.Zero, decimal.Zero, decimal.Zero, strArray2[0].ToString(), "", Convert.ToInt32(strArray2[4].ToString()), 3, DateTime.Now, strArray2[1].ToString(), strArray2[2].ToString(), strArray2[3].ToString(), strArray2[0].ToString(), strArray2[1].ToString(), "", "");
                            }
                        }
                        num2 = i;
                    }
                }
                catch (Exception exception2)
                {
                    mt.status = false;
                    mt.message = exception2.Message;
                    return new JsonResult { Data = mt };
                }
                try
                {
                    for (int i = 0; i < budgetnotes.Count; i = num2 + 1)
                    {
                        string[] separator = new string[] { "??" };
                        string[] strArray3 = budgetnotes[i].Split(separator, StringSplitOptions.None);
                        if (strArray3[0].ToString() != "")
                        {
                            if (strArray3[5].ToString() == "")
                            {
                                WSConfig.ObjNav.FninsertBudgetNotes(strArray3[0].ToString(), strArray3[1].ToString(), strArray3[2].ToString(), strArray3[3].ToString(), strArray3[4].ToString(), documentno);
                            }
                            else
                            {
                                WSConfig.ObjNav.FnUdpateBudgetNotes(strArray3[0].ToString(), strArray3[1].ToString(), strArray3[2].ToString(), strArray3[3].ToString(), strArray3[4].ToString(), documentno, Convert.ToInt32(strArray3[5].ToString()));
                            }
                        }
                        num2 = i;
                    }
                }
                catch (Exception exception3)
                {
                    mt.status = false;
                    mt.message = exception3.Message;
                    return new JsonResult { Data = mt };
                }
                try
                {
                    for (int i = 0; i < roles.Count; i = num2 + 1)
                    {
                        string[] separator = new string[] { "??" };
                        string[] strArray4 = roles[i].Split(separator, StringSplitOptions.None);
                        if (strArray4[0].ToString() != "")
                        {
                            if (strArray4[2].ToString() == "")
                            {
                                WSConfig.ObjNav.Fninsertteamroles(strArray4[0].ToString(), strArray4[1].ToString(), documentno);
                            }
                            else
                            {
                                WSConfig.ObjNav.FnUpdatebudgetinfo(strArray4[1].ToString(), strArray4[0].ToString(), documentno, Convert.ToDecimal(strArray4[2].ToString()), decimal.Zero, decimal.Zero, decimal.Zero, "", "", Convert.ToInt32(strArray4[2].ToString()), 2, DateTime.Today, "", "", "", strArray4[0].ToString(), strArray4[1].ToString(), "", "");
                            }
                        }
                        num2 = i;
                    }
                }
                catch (Exception exception4)
                {
                    mt.status = false;
                    mt.message = exception4.Message;
                    return new JsonResult { Data = mt };
                }
                try
                {
                    for (int i = 0; i < budgetinfo.Count; i = num2 + 1)
                    {
                        string[] separator = new string[] { "??" };
                        string[] strArray5 = budgetinfo[i].Split(separator, StringSplitOptions.None);
                        decimal noofdays = 0M;
                        decimal noofpas = 0M;
                        decimal ksh = 0M;
                        decimal othercurrency = 0M;
                        if (strArray5[2].ToString() != "")
                        {
                            noofdays = Convert.ToDecimal(strArray5[2].ToString());
                        }
                        if (strArray5[3].ToString() != "")
                        {
                            noofpas = Convert.ToDecimal(strArray5[3].ToString());
                        }
                        if (strArray5[4].ToString() != "")
                        {
                            ksh = Convert.ToDecimal(strArray5[4].ToString());
                        }
                        if (strArray5[0].ToString() != "")
                        {
                            if (strArray5[7].ToString() != "")
                            {
                                WSConfig.ObjNav.FnUpdatebudgetinfo(strArray5[1].ToString(), strArray5[0].ToString(), documentno, noofdays, noofpas, ksh, othercurrency, strArray5[6].ToString(), "", Convert.ToInt32(strArray5[7].ToString()), 4, DateTime.Today, "", "", "", "", "", "", strArray5[5].ToString());
                            }
                            else
                            {
                                WSConfig.ObjNav.Fninsertbudgetinfo(strArray5[1].ToString(), strArray5[0].ToString(), documentno, noofdays, noofpas, ksh, othercurrency, strArray5[6].ToString(), strArray5[5].ToString());
                            }
                        }
                        num2 = i;
                    }
                }
                catch (Exception exception5)
                {
                    mt.status = false;
                    mt.message = exception5.Message;
                    return new JsonResult { Data = mt };
                }
                string input = WSConfig.ObjNav.FnMissionProportsalsList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
            }
            catch (Exception exception6)
            {
                mt.status = false;
                mt.message = exception6.Message;
                return new JsonResult { Data = mt };
            }
            return new JsonResult { Data = mt };
        }

        public JsonResult uploadFile(string document)
        {
            resultMt mt = new resultMt();
            if (base.Request.Files.Count > 0)
            {
                try
                {
                    HttpPostedFileBase base3 = base.Request.Files[0];
                    byte[] inArray = new byte[base3.ContentLength];
                    using (BinaryReader reader = new BinaryReader(base3.InputStream))
                    {
                        inArray = reader.ReadBytes(base3.ContentLength);
                    }
                    string file = Convert.ToBase64String(inArray);
                    WSConfig.ObjNav.FnInsertAttachments("pdf", file, document, base3.FileName);
                    mt.status = true;
                    mt.message = "File saved successfully";
                    return new JsonResult { Data = mt };
                }
                catch (Exception)
                {
                    mt.message = "Error occured";
                    return new JsonResult { Data = mt };
                }
            }
            return new JsonResult { Data = mt };
        }

      
        }
}

