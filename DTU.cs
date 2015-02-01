using System;
using System.Collections.Generic;
using System.Text;

namespace OPCDialog
{
    class DTU
    {
        public string ID { get; set; }
        public string projID { get; set; }
        public string DTUID { get; set; }
        public DateTime dellTime { get; set; }
        public TimeSpan timespan { get; set; }
        public DateTime lastDellTime { get; set; }
        public List<string> systemInfo { get; set; }
        public List<DTUParam> DTUParams { get; set; }
        public List<DTUError> DTUErrors { get; set; }


        private List<string> sqlList;

        public DTU(string ID) {
            this.ID = ID;
            this.projID = ID.Substring(0,5);
            this.DTUID = ID.Substring(5,4);
            this.DTUParams = new List<DTUParam>();
            this.DTUErrors = new List<DTUError>();
            this.sqlList = new List<string>();
        }

        db_load mydb = new db_load();

        #region delltime bug?
        #endregion
        private void setTimespan() 
        {
            try
            {
                this.dellTime = Convert.ToDateTime(this.DTUParams[0].timestamp);
            }
            catch
            {
                this.dellTime = DateTime.Now;
            }
            if (this.lastDellTime == Convert.ToDateTime(null))
            {
                this.timespan = new TimeSpan(0, 0, 0);
            }
            else
            {
                this.timespan = this.dellTime - this.lastDellTime;
            }
        }

        public bool insertData()
        {
            sqlList.Clear();
            this.setTimespan();
            int errorReturn = this.checkErrors();
            string str = "";
            switch (errorReturn)
            {
                case 0:
                    str = "replace into D20_07(ProjID,DTUID,IOServerState,COM1ERROR,notice,time,state) values('" + this.projID + "','" + this.DTUID + "',1,0,'现场传输网络断线','" + DateTime.Now.ToString() + "',0)";
                    sqlList.Add(str);
                    break;
                case -1:
                    str = "replace into D20_07(ProjID,DTUID,IOServerState,COM1ERROR,notice,time,state) values('" + this.projID + "','" + this.DTUID + "',0,1,'现场ＰＬＣ断线','" + DateTime.Now.ToString() + "',0)";
                    sqlList.Add(str);
                    break;
                default:
                    Dictionary<string, DTUParam> paraArray = new Dictionary<string, DTUParam>();
                    foreach (DTUParam param in this.DTUParams)
                    {
                        saveArray(paraArray, param);//向内存中保存数据    
                    }                   
                    confirmValidKG(paraArray);//判断表中的开关量有效性
                    this.lastDellTime = this.dellTime;
                    break;
            }

            bool result = mydb.ExecuteSqlTran(sqlList);

            //调用存储过程
            if (result)
            {
                callMysqlStoreProceed(projID, DTUID, this.dellTime);
            }
           return result;
        }

        private void confirmValidKG(Dictionary<string, DTUParam> _paraArray)
        {
            //读取开关量对位表中的数据
            System.Data.DataSet KGDataSet = mydb.return_ds("SELECT * FROM d04_05 where projCode='" + this.projID + "' and DTUCode='" + this.DTUID + "'");

            foreach (string fullcodeA in _paraArray.Keys)
               {
                   String KGFlag = fullcodeA.Substring(fullcodeA.Length - 1, 1);//判断是模拟量还是开关量
 
                   //fullcode为条件查询Ｄ04—05表中fullcodeA字段
                   String validFlag = "1";//若存不出值，则默认为开，直接设置validFlag为1
                   String fullcodeD = "0";                   
                   if (KGFlag == "1")  //开关量就不再去检索开关量对位的表了
                   {
                       System.Data.DataRow[] fullcodeD_row = KGDataSet.Tables[0].Select(string.Format("fullcodeA ='{0}'", fullcodeA));
                       if (fullcodeD_row.Length > 0)
                       {
                           fullcodeD = fullcodeD_row[0]["fullcodeD"].ToString();
                       } 
                       //根据开关量表中的对位信息，查看有效性
                       validFlag = validFromKGTable(_paraArray,fullcodeD);
                   }           
                   dataInsertByTime(_paraArray, fullcodeA, KGFlag, validFlag);//轮询写入数据

               }
        }

        private string validFromKGTable(Dictionary<string, DTUParam> _paraArray, String fullcodeD)
        {
            String result = "1";
            if (fullcodeD != "0")  //可以取出值
            {
                //用取出的fullcodeD的值为主键再取出内存中对应开关量fullcode的值（开关量的的值），
                try
                {
                    DTUParam KGPara = _paraArray[fullcodeD];
                    if (Convert.ToInt32(KGPara.value) == 0)  //??这种转化是否有风险
                    {
                        //如果该开关量为开状态，将模拟量的validFlag值设置为1,如果为关状态，则将validFlag设置为0.
                        result = "0";
                    }
                }
                catch
                {
                    result = "1";
                    //Console.WriteLine("不存在这样的开关量！");
                }
            }
            return result;
        }

        private void dataInsertByTime(Dictionary<string, DTUParam> _paraArray, string fullcodeA, String KGFlag, String validFlag)
        {
            DTUParam param = _paraArray[fullcodeA];
            string strInserIntoHistory =
                "insert into D20_02(ProjID,DTUID,YYID,GroupID,PartID,ParameterID,KGFlag,FullCoder,value,DellTime,timespan,collectFlag,validFlag) values("
                + "'" + this.projID + "','" + this.DTUID + "','" + param.YYID
                + "','" + param.GroupID + "','" + param.PartID + "','" + param.ParameterID + "','" + param.KGFlag + "','" + param.ID + "'," + param.value + ",'" + this.dellTime.ToString() + "'," + this.timespan.TotalMinutes + ",0,'" + validFlag + "')";

            string strUpdateReal = "replace into D20_01(ProjID,DTUID,YYID,GroupID,PartID,ParameterID,KGFlag,FullCoder,value,DellTime,timespan,validFlag) values("
                 + "'" + this.projID + "','" + this.DTUID + "','" + param.YYID
                + "','" + param.GroupID + "','" + param.PartID + "','" + param.ParameterID + "','" + param.KGFlag + "','" + param.ID + "'," + param.value + ",'" + this.dellTime.ToString() + "'," + this.timespan.TotalMinutes + ",'" + validFlag + "')";
           
            insertIntoDatabase(KGFlag,strInserIntoHistory, strUpdateReal);
        }

        private void insertIntoDatabase(String KGFlag,string strInserIntoHistory, string strUpdateReal)
        {
            //开关量不写入到历史表中
            if (KGFlag == "1")
            {
                sqlList.Add(strInserIntoHistory);
            }
            sqlList.Add(strUpdateReal);
        }

        private void saveArray(Dictionary<string, DTUParam> _paraArray,DTUParam _param)
        {
            _paraArray.Add(_param.ID,_param);
        }
        //调用存储过程
        private void callMysqlStoreProceed(string _projID,string _dTUID,DateTime _dellTime)
        {
            string xxxxxbbbb = _projID + _dTUID;
            
            if (!mydb.callStoreProceed(xxxxxbbbb, _dellTime))
                throw new Exception("存储过程调用失败！"); 
        }


        private int checkErrors()
        {
            int index1 = indexOf("$$IOServerState");
            int index2 = indexOf("$COM1ERROR");
            try
            {
                if (this.DTUErrors[index1].value == "1" && this.DTUErrors[index2].value == "0")
                {
                    return 0;
                }
                if (this.DTUErrors[index1].value == "0" && this.DTUErrors[index2].value == "1")
                {
                    return -1;
                }
                return 1;

            }
            catch 
            {
                return 1;
            }
        }
        private int indexOf(string str)
        {
            for (int i = 0; i < this.DTUErrors.Count; i++)
            {
                if (this.DTUErrors[i].name == str)
                {
                    return i;
                }
            }
            return -1;
        }

        public void setlastDellTime() 
        {
            string str = "select DellTime from D20_01 where FullCoder='"+this.DTUParams[0].ID+"'";
            this.lastDellTime = Convert.ToDateTime(mydb.return_first_row(str));            
        }
    }

}
