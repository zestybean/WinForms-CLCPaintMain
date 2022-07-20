using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKPaint
{
    public class SecondarySchedule
    {
        public SecondarySchedule()
        {
            ScheduleID = 0;
            SequenceNumber = "";
            JobNumber = "";
            SetNumber = "";
            PartNumber = "";
            PartNumberRH = "";
            ColorCode = "";
            Primer = 0;
            ProductType = "";
            ProductPlatform = "";
            Description = "";
            DescriptionRH = "";
            RackCode = "";
            RackPosition = "";
            RackPositionRH = "";
            AssembleDate = DateTime.Now;
            PaintDate = DateTime.Now;
            PaintStation = "";
            PaintBlock = "";
            WOID = "";
            WOIDRH = "";
            ShipDate = DateTime.Now;
            ImportDate = DateTime.Now;
            PartInline = 0;
            PartRework = 0;
            PartDisposed = 0;
            PartFinesse = 0;
            PartScrap = 0;
        }

        //ORM DB Definition 
        public Decimal ScheduleID { get; set; }
        public string SequenceNumber { get; set; }
        public string JobNumber { get; set; }
        public string SetNumber { get; set; }
        public string PartNumber { get; set; }
        public string PartNumberRH { get; set; }
        public string ColorCode { get; set; }
        public Int16 Primer { get; set; }
        public string ProductType { get; set; }
        public string ProductPlatform { get; set; }
        public string Description { get; set; }
        public string DescriptionRH { get; set; }
        public string RackCode { get; set; }
        public string RackPosition { get; set; }
        public string RackPositionRH { get; set; }
        public DateTime AssembleDate { get; set; }
        public DateTime PaintDate { get; set; }
        public string PaintStation { get; set; }
        public string PaintBlock { get; set; }
        public string WOID { get; set; }
        public string WOIDRH { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ImportDate { get; set; }
        public Int16 PartInline { get; set; }
        public Int16 PartRework { get; set; }
        public Int16 PartDisposed { get; set; }
        public Int16 PartFinesse { get; set; }
        public Int16 PartScrap { get; set; }

    }
}
