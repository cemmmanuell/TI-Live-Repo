namespace mmmSelfservice.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;

    public class PaymentMemoController : Controller
    {
        public ActionResult Index()
        {
            return base.View();
        }

        public PartialViewResult newpaymentmemo()
        {
            return base.PartialView();
        }
        public ActionResult openPaymentMemos()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPaymentMemosList(base.Session["username"].ToString());
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

        public ActionResult pendingPaymentMemos()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPaymentMemosList(base.Session["username"].ToString());
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

        public PartialViewResult editpaymentmemos(string paymentmemono)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPaymentMemosList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);

                return base.PartialView((from r in list
                                         where (r.Status == "Open") && (r.No == paymentmemono)
                                         select r).FirstOrDefault<imprestRinfoModel>());

            }
            catch (Exception)
            {
                return null;
            }
        }
        public PartialViewResult viewmissionproposalView(string paymementmemono)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPaymentMemosList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.PartialView((from r in list
                                         where r.No == paymementmemono
                                         select r).FirstOrDefault<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PartialViewResult viewpaymentmemos(string paymementmemono)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPaymentMemosList(base.Session["username"].ToString());
                List<imprestRinfoModel> list = serializer.Deserialize<List<imprestRinfoModel>>(input);
                return base.PartialView((from r in list
                                         where r.No == paymementmemono
                                         select r).FirstOrDefault<imprestRinfoModel>());
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ActionResult releasedPaymentMemos()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnPaymentMemosList(base.Session["username"].ToString());
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
        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }

        public JsonResult editpaymentmemo(string strategicfocusarea, string subpillar, string projecttitle, string country, string county, string dateofactivities, string missionteam, string invitedmembers, string fundcode, string programcode, string budgetdimension, string departmentdimension, string budgetdescription, List<string> objectives, string focus, string outcome, List<string> roles, List<string> activities, List<string> budgetinfo, string refe, List<string> budgetnotes, DateTime date, string subject, string no, string missionproposal, string purchaserequest, string paye)
        {
            resultMt mt = new resultMt();
            try
            {
                int num2;

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string documentno = WSConfig.ObjNav.FnupdatePaymentmemo(date, fundcode, programcode, departmentdimension, budgetdimension, budgetdescription, subject, base.Session["username"].ToString(), refe,no,purchaserequest, missionproposal, paye);
                mt.status = true;

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
            return base.RedirectToAction("appraisallist", "Home");
        }
        public JsonResult insertpaymentmemo(string strategicfocusarea, string subpillar, string projecttitle, string country, string county, string dateofactivities, string missionteam, string invitedmembers, string fundcode, string programcode, string budgetdimension, string departmentdimension, string budgetdescription, List<string> objectives, string focus, string outcome, List<string> roles, List<string> activities, List<string> budgetinfo, string refe, List<string> budgetnotes, DateTime date, string subject, string  missionproposal, string purchaserequest, string paye)
        {
            resultMt mt = new resultMt();
            try { 
            int num2;
           
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string documentno = WSConfig.ObjNav.FnInsertPaymentmemo(date, fundcode, programcode, departmentdimension,budgetdimension, budgetdescription, subject, base.Session["username"].ToString(), refe,purchaserequest, missionproposal, paye);
            mt.status = true;
           
            }
            catch (Exception exception5)
            {
                mt.status = false;
                mt.message = exception5.Message;
                return new JsonResult { Data = mt };
            }
            return new JsonResult { Data = mt };
        }
    }
}

