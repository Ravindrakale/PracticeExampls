using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class DefectTrackAttribute : Attribute
    {
        private string cDefectID;
        private DateTime dModificationDate;
        private string cDeveloperID;
        private string cDefectOrigin;
        private string cFixComment;
        public DefectTrackAttribute(string lcDefectID, string lcModificationDate, string lcDeveloperID)
        {
            this.cDefectID = lcDefectID;
            this.dModificationDate = System.DateTime.Parse(lcModificationDate);
            this.cDeveloperID = lcDeveloperID;
        }
        public string DefectID
        { get { return cDefectID; } }

        public DateTime ModificationDate
        {
            get
            {
                return dModificationDate;
            }
        }

        public string DeveloperID
        { get { return cDeveloperID; } }

        public string Origin
        {
            get { return cDefectOrigin; }
            set { cDefectOrigin = value; }
        }

        public string FixComment
        {
            get { return cFixComment; }
            set { cFixComment = value; }
        }
    }

    [DefectTrack("1377", "12/15/2002", "David Tansey")]
    [DefectTrack("1363", "12/12/2002", "Toni Feltman",
      Origin = "Coding: Unhandled Exception")]
    public class SomeCustomPricingClass
    {
        public double GetAdjustedPrice(
          double tnPrice,
          double tnPctAdjust)
        { return tnPrice + (tnPrice * tnPctAdjust); }

        [DefectTrack("1351", "12/10/02", "David Tansey",
          Origin = "Specification: Missing Requirement",
          FixComment = "Added PriceIsValid( ) function")]
        public bool PriceIsValid(double tnPrice)
        { return tnPrice > 0.00 && tnPrice < 1000.00; }
    }

    [DefectTrack("NEW", "12/12/02", "Mike Feltman")]
    public class AnotherCustomClass
    {
        string cMyMessageString;

        public AnotherCustomClass() { }

        [DefectTrack("1399", "12/17/02", "David Tansey",
           Origin = "Analysis: Missing Requirement")]
        public void SetMessage(string lcMessageString)
        { this.cMyMessageString = lcMessageString; }
    }
}
