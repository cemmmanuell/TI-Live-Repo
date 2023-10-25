using mmmSelfservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace mmmSelfservice.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                return View();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PartialViewResult editActivityReport(string no)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnActivityReportList(base.Session["username"].ToString());
                List<Activity> list = serializer.Deserialize<List<Activity>>(input);
                return base.PartialView((from r in list
                                         where (r.no == no)
                                         select r).FirstOrDefault<Activity>());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult ProjectReport(string status)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                string input = WSConfig.ObjNav.FnActivityReportList(base.Session["username"].ToString());
                List<Activity> list = serializer.Deserialize<List<Activity>>(input);
                return base.View((from r in list
                                  where r.status == status
                                  select r).ToList<Activity>());
            }
            catch (Exception)
            {
                return null;
            }
        }
        public PartialViewResult newPlannedActivity()
        {
            return PartialView();
        }

        public ActionResult approvalRequest(string no)
        {
            WSConfig.ObjNav.FnApproval(no);
            return base.RedirectToAction("Index", "Projects", new { status = "Pending Approval" });
        }
        public PartialViewResult newActivityReport()
        {
            return PartialView();
        }

        public PartialViewResult thematicAreas()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.thematicAreas);
        }
        public PartialViewResult Donors()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.donors);
        }

        public PartialViewResult Wards(string constituency)
        {
            IEnumerable<mmmSelfservice.Models.wards> model = JsonConvert.DeserializeObject<IEnumerable<mmmSelfservice.Models.wards>>(WSConfig.ObjNav.FnGetWards(constituency));
            return PartialView(model);
        }

        public PartialViewResult Constituencies()
        {
            IEnumerable<mmmSelfservice.Models.wards> model = JsonConvert.DeserializeObject<IEnumerable<mmmSelfservice.Models.wards>>(WSConfig.ObjNav.FnGetConstituency());
            return PartialView(model);
        }
        public PartialViewResult goals(string relation)
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.goals.Where(r => r.relation == relation));
        }
        public PartialViewResult focusAreas(string relation)
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.focusAreas.Where(r => r.relation == relation));
        }
        public PartialViewResult implimentingPartners()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model);
        }
        public PartialViewResult stations()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model);
        }
        public PartialViewResult projects()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.projects);
        }
        public PartialViewResult projectObjectives(string relation)
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.projectObjectives.Where(r => r.relation == relation));
        }
        public PartialViewResult projectOutcomes(string relation)
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.projectOutcomes.Where(r => r.relation == relation));
        }

        public JsonResult insertProject(Activity tar, Dimensions dims)
        {
            resultMt resultMt = new resultMt();
            try
            {
                tar.employeeNo = Session["username"].ToString();
                WSConfig.ObjNav.FnInsertActivityReport(JsonConvert.SerializeObject(tar), JsonConvert.SerializeObject(dims));

                resultMt.status = true;
            }
            catch (Exception e)
            {
                resultMt.status = false;
                resultMt.message = e.InnerException.Message;

            }

            return new JsonResult { Data = resultMt };
        }

        public JsonResult editProject(Activity tar, Dimensions dims)
        {
            resultMt resultMt = new resultMt();
            try
            {
                tar.employeeNo = Session["username"].ToString();

                WSConfig.ObjNav.FnEditActivityReport(JsonConvert.SerializeObject(tar), JsonConvert.SerializeObject(dims));

                resultMt.status = true;
            }
            catch (Exception e)
            {
                resultMt.status = false;
                resultMt.message = e.InnerException.Message;

            }

            return new JsonResult { Data = resultMt };
        }
        public PartialViewResult projectOutput(string relation)
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model.projectOutputs.Where(r => r.relation == relation));
        }
    }
}