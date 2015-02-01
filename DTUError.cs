using System;
using System.Collections.Generic;
using System.Text;

namespace OPCDialog
{
    class DTUError
    {
        public string ID { get; set; }      // 错误信息的id，例如：12345bbbb.$$IOServerState
        public string name { get; set; }    // 错误信息的名字，例如：$$IOServerState
        public string value { get; set; }   // 读出的值
        public string message { get; set; } // 错误信息

        public DTUError(string id)
        {
            this.ID = id;
            this.name = id.Substring(10);
        }
    }
}
