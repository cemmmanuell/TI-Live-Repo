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
    using System.Xml.Serialization;

    public class LeaveController : Controller
    {
        public ActionResult cancelApproval(string leaveno)
        {
            WSConfig.ObjNav.FnLeaveCancelApprovalRequest(leaveno);
            return base.RedirectToAction("Index");
        }

        public JsonResult EditLeave(DateTime start, int days, string leavetype, string reliever, string leaveNo, string pendingtasks)
        {
            string str = "";
            try
            {
                string applicationNo = leaveNo;
                WSConfig.ObjNav.FnEditApplication(base.Session["username"].ToString(), leavetype, days, start, reliever, applicationNo, pendingtasks);
                str = "Leave edited successfully";
            }
            catch (Exception exception)
            {
                str = exception.Message.ToString();
            }
            return new JsonResult { Data = str };
        }

        public JsonResult getleavedays(string leavetype)
        {
            string str = "0";
            str = WSConfig.ObjNav.FngetLeaveBalanceType(base.Session["username"].ToString(), leavetype);
            return new JsonResult { Data = str };
        }

        public ActionResult Index()
        {
            List<leave> model = JsonConvert.DeserializeObject<List<leave>>(WSConfig.ObjNav.FnLeaveList(base.Session["username"].ToString()));
            return base.View(model);
        }

        public JsonResult LeaveApply(DateTime? start, decimal? days, string leavetype, string reliever, string pendingtasks)
        {
            resultMt mt = new resultMt();
            string str = "";
            try
            {
                WSConfig.ObjNav.FnLeaveApplication(base.Session["username"].ToString(), leavetype, Convert.ToDecimal(days), Convert.ToDateTime(start), reliever, pendingtasks);
                str = "Leave applied successfully";
                mt.status = true;
            }
            catch (Exception exception)
            {
                str = exception.Message.ToString();
                mt.status = false;
                mt.message = str;
            }
            return new JsonResult { Data = mt };
        }

        public ActionResult LeaveApproved()
        {
            List<leave> model = JsonConvert.DeserializeObject<List<leave>>(WSConfig.ObjNav.FnLeaveList(base.Session["username"].ToString()));
            return base.View(model);
        }

        public ActionResult leaveCard()
        {
            return base.View();
        }

        public ActionResult leaveDelete(string leaveNo)
        {
            WSConfig.ObjNav.FnLeaveDelete(base.Session["username"].ToString(), leaveNo);
            return base.RedirectToAction("index");
        }

        public PartialViewResult LeaveEdit(string applicationcode)
        {
            List<leave> list = JsonConvert.DeserializeObject<List<leave>>(WSConfig.ObjNav.FnLeaveList(base.Session["username"].ToString()));
          
            return base.PartialView((from r in list
                where r.No == applicationcode.TrimEnd(new char[0])
                select r).FirstOrDefault<leave>());
        }

        public ViewResult LeaveEdit1(string applicationcode, DateTime startdate, string responsibilitycenter, string leavetype, decimal daysapplied, string releavercode)
        {
            string str = WSConfig.ObjNav.FnLeaveCardEdit(base.Session["username"].ToString(), applicationcode, startdate, responsibilitycenter, leavetype, daysapplied, releavercode);
            base.Session["leaveNo"] = applicationcode;
            leave model = JsonConvert.DeserializeObject<leave>(str);
            return base.View("Index", model);
        }

        public PartialViewResult leaveinfo()
        {
            Leaveinfo model = JsonConvert.DeserializeObject<Leaveinfo>(WSConfig.ObjNav.Fnleaveinformation(base.Session["username"].ToString()));
            return base.PartialView(model);
        }

        public ActionResult leavelist()
        {
            List<leave> model = JsonConvert.DeserializeObject<List<leave>>(WSConfig.ObjNav.FnLeaveList(base.Session["username"].ToString()));
            return base.View(model);
        }

        public ActionResult leavependingapproval()
        {
            List<leave> model = JsonConvert.DeserializeObject<List<leave>>(WSConfig.ObjNav.FnLeaveList(base.Session["username"].ToString()));
            return base.View(model);
        }

        public ActionResult leaverejected()
        {
            List<leave> model = JsonConvert.DeserializeObject<List<leave>>(WSConfig.ObjNav.FnLeaveList(base.Session["username"].ToString()));
            return base.View(model);
        }

        public PartialViewResult leavetypes()
        {
            List<mmmSelfservice.Models.leavetypes> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.leavetypes>>(WSConfig.ObjNav.FnGetLeaveTypes());
            return base.PartialView(model);
        }

        public PartialViewResult relievers()
        {
            List<mmmSelfservice.Models.relievers> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.relievers>>(WSConfig.ObjNav.FnHrEmployees());
            return base.PartialView(model);
        }

        public ActionResult sendApproval(string leaveNo)
        {
            WSConfig.ObjNav.FnLeaveApprovalRequest(leaveNo);
            return base.RedirectToAction("Index");
        }

        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }
    }
}

