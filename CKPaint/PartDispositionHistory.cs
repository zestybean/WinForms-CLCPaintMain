using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKPaint
{
    public class PartDispositionHistory
    {
        public PartDispositionHistory()
        {
            InspectorName = "";
            SequenceNumber = "";
            PartNumber = "";
            PartNumberRH = "";
            JobNumber = "";
            ColorCode = "";
            ProductType = "";
            InspectorID = "";
            PaintStation = "";
            PaintDate = DateTime.Now;
            PartProcess = "";
            WOID = "";
            WOIDRH = "";
            PartDefect = "";
            DPUCount = 0;
            PartDescription = "";
            PartDescriptionRH = "";
            PartDisposition = "";
            DispositionDate = DateTime.Now;
            PartRework = 0;
            PartFinesse = 0;

        }

        //ORM DB Definition 
        public string InspectorName { get; set; }
        public string SequenceNumber { get; set; }
        public string PartNumber { get; set; } //
        public string PartNumberRH { get; set; }
        public string JobNumber { get; set; } //
        public string ColorCode { get; set; } //
        public string ProductType { get; set; } //
        public string InspectorID { get; set; } //NEED IMP
        public string PaintStation { get; set; } //NEED IMP
        public DateTime PaintDate { get; set; }
        public string PartProcess { get; set; }//HOw?
        public string WOID { get; set; }//
        public string WOIDRH { get; set; }//
        public string PartDefect { get; set; }//
        public Int16 DPUCount { get; set; }//
        public string PartDisposition { get; set; }
        public string PartDescription { get; set; }
        public string PartDescriptionRH { get; set; }
        public DateTime DispositionDate { get; set; }
        public Int16 PartRework { get; set; }
        public Int16 PartFinesse { get; set; }
    }
}
