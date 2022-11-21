namespace mmmSelfservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class imprestRinfoModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdNumber { get; set; }

        public string Department { get; set; }

        public string No { get; set; }

        public string Document_Date { get; set; }

        public string DepartmentCode { get; set; }

        public string DirectorateCode { get; set; }

        public DateTime StartDate { get; set; }

        public string EndDate { get; set; }

        public string Purpose { get; set; }

        public string ResponsibilityCenter { get; set; }

        public string Amount { get; set; }

        public string Status { get; set; }

        public string Posted { get; set; }

        public string StrategicFocusArea { get; set; }

        public string SubPillar { get; set; }

        public string ProjectTitle { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string DateOfActivity { get; set; }

        public string MissionTeam { get; set; }

        public string FundCode { get; set; }

        public string ProgramCode { get; set; }

        public string Completed { get; set; }

        public string budgetdminesion { get; set; }

        public string departmentdimension { get; set; }

        public string budgetdescription { get; set; }

        public string strategicFocus { get; set; }

        public string background { get; set; }

        public string outcome { get; set; }

        public string InvitedMembers { get; set; }

        public string missionNo { get; set; }

        public string purchaseRequisition { get; set; }

        public bool surrendered { get; set; }

        public string Ref { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string vendor { get; set; }
        public string vendorName { get; set; }

        public string emno { get; set; }
        public string DateString { get
            {
                string date_ = "";

                date_ = Date.ToString("yyyy-MM-dd");

                return date_;
            }
        }

        public List<travelDetails> TravelDetails { get; set; }
        public List<accomodationDetails> AccomodationDetails { get; set; }
        public List<mealsAndIncidentals> MealsAndIncidentals { get; set; }
        public List<otherExpenses> OtherExpenses { get; set; }
    }


    // Travel details
    public  class travelDetails
    {
        public DateTime date { get; set; }
        public DateTime departureTime { get; set; }
        public string departurePlace { get; set; }
        public DateTime arrivalTime { get; set; }
        public string arrivalPlace { get; set; }
        public string remarks { get; set; }
        public int LineNo { get; set; }
    }

    // Accomodation details 
    public class accomodationDetails
    {
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public Boolean accomodationCatered { get; set; }
        public string locationOfStay { get; set; }
        public decimal amount { get; set; }
        public int noOfNights { get; set; }
        public int LineNo { get; set; }
    }

    // Meals aand incidentals 
    public class mealsAndIncidentals
    {
        public DateTime date { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public int noOfDays { get; set; }
        public int LineNo { get; set; }

    }

    // Otther expenses 
    public class otherExpenses
    {
        public DateTime date { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public int LineNo { get; set; }
    }
}

