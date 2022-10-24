namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public class ApprovalController : Controller
    {
        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }
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
        protected static void deletefile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        public JsonResult ApprovalDoc(string no)
        {
            string str = base.Session["username"].ToString().Replace("/", "") + "LS";
            string path = HostingEnvironment.MapPath(string.Format("~/Downloads/{0}.pdf", str));
            string bigText = "";
            deletefile(path);
            WSConfig.ObjNav.FnGetApprovalDocument(no, ref bigText);
            byte[] buffer = Convert.FromBase64String(bigText);
            FileStream output = new FileStream(path, FileMode.CreateNew);
            BinaryWriter writer = new BinaryWriter(output);
            writer.Write(buffer, 0, buffer.Length);
            writer.Close();
            string str4 = string.Format("../Downloads/{0}.pdf", str);
            return new JsonResult { Data = str4 };
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

        public JsonResult reject(string DocumentNo, string ApproverID, string comments)
        {
            resultMt mt = new resultMt();

            if (comments != " ")
            {


                try
                {
                    WSConfig.ObjNav.FnRejectApprovalRequest(DocumentNo, Session["userName"].ToString(), comments);
                    mt.status = true;
                }
                catch (Exception e)
                {

                    mt.status = false;
                    mt.message = e.InnerException.ToString();

                }
            }
            else
            {
                mt.status = false;
                mt.message = "Please insert comments before rejecting";
            }
            return new JsonResult { Data = mt };
        }

        public JsonResult approve(string DocumentNo, string ApproverID)
        {
            resultMt mt = new resultMt();



            try
            {
                WSConfig.ObjNav.FnApproveRecords(DocumentNo, Session["userName"].ToString());
                mt.status = true;
            }
            catch (Exception e)
            {

                mt.status = false;
                mt.message = e.InnerException.ToString();

            }


            return new JsonResult { Data = mt };
        }
    }
}

