namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using mmmSelfservice.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;

    public class UploadController : Controller
    {
        public PartialViewResult deleteuploads(string documentNo, string attachmentNo)
        {
            PartialViewResult result;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            int attachment = Convert.ToInt32(attachmentNo);
            try
            {
                WSConfig.ObjNav.FnDeleteAttachment(attachment);
                try
                {
                    string input = WSConfig.ObjNav.FnUploadedDocuments(documentNo);
                    List<documentUploads> list = serializer.Deserialize<List<documentUploads>>(input);
                    result = this.PartialView("uploadeddocuments", (from r in list
                        where r.DocumentNo == documentNo
                        select r).ToList<documentUploads>());
                }
                catch (Exception)
                {
                    result = null;
                }
            }
            catch (Exception)
            {
                try
                {
                    string input = WSConfig.ObjNav.FnUploadedDocuments(documentNo);
                    List<documentUploads> list2 = serializer.Deserialize<List<documentUploads>>(input);
                    result = this.PartialView("uploadeddocuments", (from r in list2
                        where r.DocumentNo == documentNo
                        select r).ToList<documentUploads>());
                }
                catch (Exception)
                {
                    result = null;
                }
            }
            return result;
        }

        public ActionResult Index()
        {
            return base.View();
        }

        public PartialViewResult uploadeddocuments(string documentNo)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnUploadedDocuments(documentNo);
                List<documentUploads> list = serializer.Deserialize<List<documentUploads>>(input);
                return base.PartialView((from r in list
                    where r.DocumentNo == documentNo
                    select r).ToList<documentUploads>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult uploadeddocumentsJnls(string documentNo)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnUploadedDocuments(documentNo);
                List<documentUploads> list = serializer.Deserialize<List<documentUploads>>(input);
                return base.PartialView((from r in list
                                         where r.DocumentNo == documentNo
                                         select r).ToList<documentUploads>());
            }
            catch (Exception)
            {
                return null;
            }
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

        public JsonResult uploadFileJnls(string document, string documentJnls)
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
                    WSConfig.ObjNav.FnInsertAttachmentsJnls("pdf", file, document, base3.FileName, documentJnls);
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

        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
        }
    }
}

