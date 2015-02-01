using System;
using System.Collections.Generic;
using System.Text;

namespace OPCDialog
{
    class DTUParam
    {
        public string ID { get; set; }
        public string YYID { get; set; }
        public string GroupID { get; set; }
        public string PartID { get; set; }
        public string ParameterID { get; set; }
        public string KGFlag { get; set; }
        public double value { get; set; }
        public string quality { get; set; }
        public string timestamp { get; set; }

        public DTUParam(string ID)
        {
            this.ID = ID;
            this.YYID = ID.Substring(10,2);
            this.GroupID = ID.Substring(12,4);
            this.PartID = ID.Substring(16,4);
            this.ParameterID = ID.Substring(20,4);
            this.KGFlag = ID.Substring(24,1);
        }
    }
}
