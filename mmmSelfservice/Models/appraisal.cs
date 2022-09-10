namespace mmmSelfservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class appraisal
    {
        public string background { get; set; }
        public DateTime reviewFrom { get; set; }
        public DateTime reviewTo { get; set; }
        public string emno { get; set; }

        public string no { get; set; }

        public string Status { get; set; }
        public List<performance> Performance { get; set; }
        public List<sections> Sections { get; set; }
        public List<personalQualities> PersonalQualities { get; set; }
        public List<reflections> Reflections { get; set; }
        public List<capacityNeeds> CapacityNeeds { get; set; }
        public List<actionPoints> ActionPoints { get; set; }

    }
    public class performance
    {
        public string documentNo { get; set; }
        public int lineNo { get; set; } = 0;
        public string keyResultAreas { get; set; }
        public string keyActivities { get; set; }
        public string performanceMeasures { get; set; }
        public string commentsOnAchievedResults { get; set; }
        public decimal target { get; set; }
        public decimal actualAchieved { get; set; }
        public decimal percentageOfTarget { get; set; }
        public decimal rating { get; set; }
        public decimal weightingRating { get; set; }
        public decimal weighting { get; set; }
        public int count { get; set; }

    } 
    public class sections
    {
        public string documentNo { get; set; }
        public int lineNo { get; set; } = 0;
        public string appraisalType { get; set; }
        public string appraisalDescription { get; set; }
        public int staffRating { get; set; }
        public int supervisorRating { get; set; }
        public int count { get; set; }

    }
    public class personalQualities
    {
        public string documentNo { get; set; }
        public int lineNo { get; set; } = 0;
        public string personalDescription { get; set; }
        public int score { get; set; }
        public string comments { get; set; }
        public int count { get; set; }
    }
    public class reflections
    {
        public string documentNo { get; set; }
        public int lineNo { get; set; } = 0;
        public string reflectionDescription { get; set; }
        public string selfAppraisal { get; set; }
        public string supervisorsFeedback { get; set; }
        public int count { get; set; }
    }
    public class capacityNeeds
    {
        public string documentNo { get; set; }
        public int lineNo { get; set; } = 0;
        public string capacity { get; set; }
        public DateTime completionDate { get; set; }
        public string capacityNeedsDescription { get; set; }
        public string remedialMeasures { get; set; }
        public int count { get; set; }
    }
    public class actionPoints
    {
        public string documentNo { get; set; }
        public int lineNo { get; set; } = 0;
        public string planning { get; set; }
        public string personResponsible { get; set; }
        public string agreedActionPoints { get; set; }
        public string timelines { get; set; }
        public int count { get; set; }

    }
}

