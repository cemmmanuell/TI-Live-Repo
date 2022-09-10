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

    public class TrainingController : Controller
    {
        public ActionResult createTraining(string TrainingCode)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public JsonResult createTrainingSchedule(string year, string facilitator, DateTime scheduleDate, string employees, string evidence, string department, string topic)
        {
            resultMt mt = new resultMt();
            try
            {
                WSConfig.ObjNav.Fininserttrainingschedule(year, facilitator, scheduleDate, employees, evidence, department, topic);
                mt.status = true;
            }
            catch (Exception exception)
            {
                mt.status = false;
                mt.message = exception.Message;
            }
            return new JsonResult { Data = mt };
        }

        public JsonResult createTrainingScheduleUpdate(string year, string facilitator, DateTime scheduleDate, string employees, string evidence, string department, string topic)
        {
            resultMt mt = new resultMt();
            try
            {
                WSConfig.ObjNav.Fininserttrainingschedule(year, facilitator, scheduleDate, employees, evidence, department, topic);
                mt.status = true;
            }
            catch (Exception exception)
            {
                mt.status = false;
                mt.message = exception.Message;
            }
            return new JsonResult { Data = mt };
        }

        public PartialViewResult edit(string application)
        {
            List<TrainingInfo> list = JsonConvert.DeserializeObject<List<TrainingInfo>>(WSConfig.ObjNav.FnTrainingList(base.Session["username"].ToString()));
            
            return base.PartialView((from r in list
                where r.ApplicationNo == application.TrimEnd(new char[0]).ToString()
                select r).FirstOrDefault<TrainingInfo>());
        }

        public PartialViewResult edittrainingschedule(string year, string topic)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string input = WSConfig.ObjNav.FnTrainingSchedule();
            List<mmmSelfservice.Models.trainingschedule> list = new List<mmmSelfservice.Models.trainingschedule>();
            list = serializer.Deserialize<List<mmmSelfservice.Models.trainingschedule>>(input);
            return base.PartialView((from r in list
                where ((r.status == "Pending") && (r.topic == topic)) && (r.Year == year)
                select r).FirstOrDefault<mmmSelfservice.Models.trainingschedule>());
        }

        public ActionResult Index()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnTrainingList(base.Session["username"].ToString());
                List<TrainingInfo> list = serializer.Deserialize<List<TrainingInfo>>(input);
                return base.View((from r in list
                    where r.Status == "New"
                    select r).ToList<TrainingInfo>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult pending()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnTrainingList(base.Session["username"].ToString());
                List<TrainingInfo> source = serializer.Deserialize<List<TrainingInfo>>(input);
                return base.View((from r in source.ToList<TrainingInfo>()
                    where r.Status == "Pending Approval"
                    select r).ToList<TrainingInfo>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult trainingneed()
        {
            string str = "";
            List<TrainingNeedsInfo> model = JsonConvert.DeserializeObject<List<TrainingNeedsInfo>>(str);
            return base.View(model);
        }

        public ActionResult trainingReq(string no)
        {
            WSConfig.ObjNav.FnReqTrainingApproval(no);
            return base.RedirectToAction("index", "Training");
        }

        public JsonResult TrainingRequest(string need, string employees, string link, string purpose, string outcome, string details, string otherdetails)
        {
            resultMt mt = new resultMt();
            try
            {
                WSConfig.ObjNav.FnInsertTrainingRequest(need, employees, link, purpose, outcome, details, otherdetails, base.Session["username"].ToString());
                mt.status = true;
            }
            catch (Exception exception)
            {
                mt.message = exception.Message;
            }
            return new JsonResult { Data = mt };
        }

        public JsonResult TrainingRequestUpdate(string need, string employees, string link, string purpose, string outcome, string details, string otherdetails, string appNo)
        {
            resultMt mt = new resultMt();
            try
            {
                WSConfig.ObjNav.FnUpdateTrainingRequest(need, employees, link, purpose, outcome, details, otherdetails, base.Session["username"].ToString(), appNo);
                mt.status = true;
            }
            catch (Exception exception)
            {
                mt.message = exception.Message;
            }
            return new JsonResult { Data = mt };
        }

        public ActionResult trainingschedule()
        {
            return base.View();
        }

        public ActionResult trainingScheduleDone()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnTrainingSchedule();
                List<mmmSelfservice.Models.trainingschedule> list = serializer.Deserialize<List<mmmSelfservice.Models.trainingschedule>>(input);
                return base.View((from r in list
                    where r.status == "Done"
                    select r).ToList<mmmSelfservice.Models.trainingschedule>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult trainingScheduleOPen()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnTrainingSchedule();
                List<mmmSelfservice.Models.trainingschedule> list = serializer.Deserialize<List<mmmSelfservice.Models.trainingschedule>>(input);
                return base.View((from r in list
                    where r.status == "Pending"
                    select r).ToList<mmmSelfservice.Models.trainingschedule>());
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
    }
}

