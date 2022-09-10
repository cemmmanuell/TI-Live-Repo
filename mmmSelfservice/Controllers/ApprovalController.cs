namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public class ApprovalController : Controller
    {
        public ActionResult Approved()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.ApprovalList(base.Session["username"].ToString());
                List<Approval> model = serializer.Deserialize<List<Approval>>(input);
                return base.View(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult Index()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.ApprovalList(base.Session["username"].ToString());
                List<Approval> model = serializer.Deserialize<List<Approval>>(input);
                return base.View(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult sendforapproval(string DocumentNo, string ApproverID)
        {
            return null;
        }
    }
}

