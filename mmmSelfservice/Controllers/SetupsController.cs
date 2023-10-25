using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace mmmSelfservice.Controllers
{
    public class SetupsController : Controller
    {
        // GET: Setups
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult donors()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model);
        }
        public PartialViewResult departments()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model);
        }
        public PartialViewResult thematicAreas()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model);
        }
        public PartialViewResult goals()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model);
        }
        public PartialViewResult focusAreas()
        {
            mmmSelfservice.Models.Projects model = JsonConvert.DeserializeObject<mmmSelfservice.Models.Projects>(WSConfig.ObjNav.FnprojectSetups());
            return PartialView(model);
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
    }
}