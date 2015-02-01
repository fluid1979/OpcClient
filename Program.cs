
//=======================================================================
// 日期           开发者     修改类型     备注
// 2009.12.29     骆剑　     创建
//=======================================================================
//  Copyright (c) 2004-2009 艾因泰克科技股份有限公司 All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OPCDialog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OPCClient());
        }
    }
}