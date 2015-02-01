using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using OPCAutomation;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;


namespace OPCDialog
{
    public partial class OPCClient : Form
    {
        public OPCClient()
        {
            InitializeComponent();
        }

        db_load mydb = new db_load();

        #region ˽�б���
        /// <summary>
        /// OPCServer Object
        /// </summary>
        OPCServer KepServer;
        /// <summary>
        /// OPCGroups Object
        /// </summary>
        OPCGroups KepGroups;
        /// <summary>
        /// OPCGroup Object
        /// </summary>
        OPCGroup KepGroup;
        /// <summary>
        /// OPCItems Object
        /// </summary>
        OPCItems KepItems;
        /// <summary>
        /// OPCItem Object
        /// </summary>
        OPCItem KepItem;
        /// <summary>
        /// ����IP
        /// </summary>
        string strHostIP = "";
        /// <summary>
        /// ��������
        /// </summary>
        string strHostName = "";
        /// <summary>
        /// ����״̬
        /// </summary>
        bool opc_connected = false;
        /// <summary>
        /// �ͻ��˾��
        /// </summary>
        int itmHandleClient = 0;
        /// <summary>
        /// ����˾��
        /// </summary>
        int itmHandleServer = 0;
        /// <summary>
        /// �����DTU
        /// </summary>
        List<DTU> activeDTU = new List<DTU>();
        /// <summary>
        /// ��һ��д���dtu
        /// </summary>
        List<DTU> lastDTU ;
        /// <summary>
        /// ����״��--��ʼ�����ı�ʶ false��ʾδ��ʼ��true��ʾ��ʼ
        /// </summary>
        bool runningState = false;
        /// <summary>
        /// ��ѡ�����б���
        /// </summary>
        List<string> itemList;
        /// <summary>
        /// �ۼ�д�����
        /// </summary>
        int insertTimesCount = 0;
        /// <summary>
        /// ���һ��д��ʱ��
        /// </summary>
        DateTime lastInsertTime = DateTime.Now;
        /// <summary>
        /// �û���
        /// </summary>
        string userName = "";
        /// <summary>
        /// 
        /// </summary>
        List<string> opcSystemInfoItems = new List<string>();

        List<string> opcDataItems = new List<string>();
        

        




        #endregion



        #region ����
        /// <summary>
        /// ö�ٱ���OPC������
        /// </summary>
        private void GetLocalServer()
        {
            //��ȡ���ؼ����IP,���������
            IPHostEntry IPHost = Dns.Resolve(Environment.MachineName);
            if (IPHost.AddressList.Length > 0)
            {
                strHostIP = IPHost.AddressList[0].ToString();
            }
            else
            {
                return;
            }
            //ͨ��IP����ȡ��������ƣ������ھ�������
            //IPHostEntry ipHostEntry = Dns.GetHostByAddress("127.0.0.1");
            IPHostEntry ipHostEntry = Dns.GetHostByAddress(strHostIP);
            string tempHostName = ipHostEntry.HostName.ToString();
            if (tempHostName.Contains("."))
            {
                string[] tempHostNames = tempHostName.Split(new char[] { '.' });
                strHostName = tempHostNames[0];
            }
            else
            {
                strHostName = ipHostEntry.HostName.ToString();
            }

            //��ȡ���ؼ�����ϵ�OPCServerName
            try
            {
                KepServer = new OPCServer();
                object serverList = KepServer.GetOPCServers(strHostName);

                foreach (string turn in (Array)serverList)
                {
                    cmbServerName.Items.Add(turn);
                }
                if (cmbServerName.Items.Count > 0)
                {
                    cmbServerName.SelectedIndex = 0;
                }



                //this.btnConnLocalServer.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("ö�ٱ���OPC����������" + err.Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// ������
        /// </summary>
        private bool CreateGroup()
        {
            try
            {
                KepGroups = KepServer.OPCGroups;
                KepGroup = KepGroups.Add("OPCDOTNETGROUP");
                SetGroupProperty();
                KepGroup.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
                KepGroup.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(KepGroup_AsyncWriteComplete);
                KepItems = KepGroup.OPCItems;
            }
            catch (Exception err)
            {
                MessageBox.Show("��������ִ���" + err.Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        /// <summary>
        /// ����������
        /// </summary>
        private void SetGroupProperty()
        {
            string errors = "";
            Boolean GroupIsActive = true;
            int Deadband = 0;
            int UpdateRate = 180;
            Boolean IsActive = true;
            Boolean IsSubscribed = true;
            //KepGroup.TimeBias = 0;
            try
            {
                Convert.ToInt16(txt_biasTime.Text);
            }
            catch
            {
                txt_biasTime.Text = "480";
                errors += "ƫ��ʱ��¼�����\r";
            }
            try
            {
                GroupIsActive = Convert.ToBoolean(txtGroupIsActive.Text);
            }
            catch
            {
                GroupIsActive = true;
                txtGroupIsActive.Text = "true";
                errors += "����Ĭ����¼�����\r";
            }
            finally
            {
                KepServer.OPCGroups.DefaultGroupIsActive = GroupIsActive;
            }
            try
            {
                Deadband = Convert.ToInt32(txtGroupDeadband.Text);
            }
            catch
            {
                Deadband = 0;
                txtGroupDeadband.Text = "0";
                errors += "Ĭ��������¼�����\r";
            }
            finally
            {
                KepServer.OPCGroups.DefaultGroupDeadband = Deadband;
            }

            try
            {
                UpdateRate = Convert.ToInt32(txtUpdateRate.Text);
            }
            catch
            {
                UpdateRate = 180;
                txtUpdateRate.Text = "180";
                errors += "ˢ��Ƶ��¼�����\r";
            }
            finally
            {
                KepGroup.UpdateRate = UpdateRate * 1000;
            }
            try
            {
                IsActive = Convert.ToBoolean(txtIsActive.Text);
            }
            catch
            {
                IsActive = true;
                txtIsActive.Text = "true";
                errors += "�Ƿ񼤻�¼�����\r";
            }
            finally
            {
                KepGroup.IsActive = IsActive;
            }
            try
            {
                IsSubscribed = Convert.ToBoolean(txtIsSubscribed.Text);
            }
            catch
            {
                IsSubscribed = true;
                txtIsSubscribed.Text = "true";
                errors += "�Ƿ���¼�����\r";
            }
            finally
            {
                KepGroup.IsSubscribed = IsSubscribed;
            }


            if (errors != "")
                MessageBox.Show(errors, "������ʾ");
        }
        /// <summary>
        /// �г�OPC�����������нڵ�
        /// </summary>
        /// <param name="oPCBrowser"></param>
        private void RecurBrowse(OPCBrowser oPCBrowser)
        {
            //չ����֧
            oPCBrowser.ShowBranches();
            //չ��Ҷ��
            oPCBrowser.ShowLeafs(true);
            

            foreach (object turn in oPCBrowser)
            {
                if (filter(turn.ToString()))
                {
                    ListItem item = new ListItem(turn.ToString());    
                    listBox1.Items.Add(item);
                }
            }
            checkList();


        }
        /// <summary>
        /// ��ȡ��������Ϣ������ʾ�ڴ���״̬����
        /// </summary>
        private void GetServerInfo()
        {
            tool_state.Text = "     �ۼ�д�������" + insertTimesCount.ToString();
            //tsslServerStartTime.Text = "��ʼʱ��:" + KepServer.StartTime.ToString() + "    ";
            tsslServerStartTime.Text = "��ʼʱ��:" + dateTimeBias(KepServer.StartTime.ToString()) + "    ";
            //tsslServerStartTime.Text = "��ʼʱ��:" + KepServer.LastUpdateTime.ToString() + "    ";
            tsslversion.Text = "�������˰汾:" + KepServer.MajorVersion.ToString() + "." + KepServer.MinorVersion.ToString() + "." + KepServer.BuildNumber.ToString();
        }
        /// <summary>
        /// ����OPC������
        /// </summary>
        /// <param name="remoteServerIP">OPCServerIP</param>
        /// <param name="remoteServerName">OPCServer����</param>
        private bool ConnectRemoteServer(string remoteServerIP, string remoteServerName)
        {
            try
            {
                KepServer.Connect(remoteServerName, remoteServerIP);

                if (KepServer.ServerState == (int)OPCServerState.OPCRunning)
                {
                    tsslServerState.Text = "�����ӵ�-" + KepServer.ServerName + "   ";
                }
                else
                {
                    //��������Ը��ݷ��ص�״̬���Զ�����ʾ��Ϣ����鿴�Զ����ӿ�API�ĵ�
                    tsslServerState.Text = "״̬��" + KepServer.ServerState.ToString() + "   ";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("����Զ�̷��������ִ���" + err.Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        #endregion

        #region �¼�
        /// <summary>
        /// д��TAGֵʱִ�е��¼�
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="Errors"></param>
        void KepGroup_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
            lblState.Text = "";
            for (int i = 1; i <= NumItems; i++)
            {
                lblState.Text += "Tran:" + TransactionID.ToString() + "   CH:" + ClientHandles.GetValue(i).ToString() + "   Error:" + Errors.GetValue(i).ToString();
            }
        }
        /// <summary>
        /// ÿ���������б仯ʱִ�е��¼�
        /// </summary>
        /// <param name="TransactionID">����ID</param>
        /// <param name="NumItems">�����</param>
        /// <param name="ClientHandles">��ͻ��˾��</param>
        /// <param name="ItemValues">TAGֵ</param>
        /// <param name="Qualities">Ʒ��</param>
        /// <param name="TimeStamps">ʱ���</param>
        void KepGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            //Ϊ�˲��ԣ����Լ��˿���̨����������鿴����ID��
            // Console.WriteLine("********"+TransactionID.ToString()+"*********");
            DateTime startInsert = DateTime.Now;
            if (NumItems > 0)
            {
                if(itemList.Count==ItemValues.Length)
                {
                    parseItemData(itemList, ItemValues, TimeStamps, Qualities);
                    foreach (DTU dtu in activeDTU)
                    {
                        dtu.insertData();     
                    }
                    
                    insertTimesCount++;
                    DateTime stopInsert = DateTime.Now;
                    tool_state.Text = "     �ۼ�д�������" + insertTimesCount.ToString();
                    label12.Text = "�ϴ�д���ʱ��" + (stopInsert - startInsert).ToString();
                    label13.Text = "�������д��ʱ������" + (stopInsert - lastInsertTime);
                    lastInsertTime = DateTime.Now;
                }
                
            }



        }
  
        /// <summary>
        /// ���봰��ʱ���������
        /// </summary>
        /// //read over
        private void OPCDialog_Load(object sender, EventArgs e)
        {
            initComboBox();
            GetLocalServer();
            btnSetGroupPro.Enabled = false;
        }
        /// <summary>
        /// �رմ���ʱ���������
        /// </summary>
        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!opc_connected)
            {
                return;
            }

            if (KepServer != null)
            {
                KepServer.Disconnect();
                KepServer = null;
            }
            opc_connected = false;
        }
        /// <summary>
        /// ����ť������
        /// </summary>
        private void btnSetGroupPro_Click(object sender, EventArgs e)
        {
            SetGroupProperty();
        }
        /// <summary>
        /// ����ť�����ӣϣУ÷�����
        /// </summary>
        private void btnConnLocalServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ConnectRemoteServer("", cmbServerName.Text))
                {
                    return;
                }

                btnSetGroupPro.Enabled = true;

                opc_connected = true;


                GetServerInfo();


                if (!CreateGroup())
                {
                    return;
                }

                // �г�OPC�����������нڵ�
                RecurBrowse(KepServer.CreateBrowser());

                setControlState("connected");

            }
            catch (Exception err)
            {
                MessageBox.Show("��ʼ������" + err.Message, "��ʾ��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        //read over
        private void initComboBox()
        {
            DataSet opcReaderList = mydb.return_ds("select username from d20_08");
            opcreaderlogin.Items.Clear();
            DataRow dr = opcReaderList.Tables[0].NewRow();
            dr["username"] = "�ֶ�¼��";
            opcReaderList.Tables[0].Rows.InsertAt(dr, 0);
            opcreaderlogin.DataSource = opcReaderList.Tables[0].DefaultView;
            opcreaderlogin.ValueMember = "username";
            opcreaderlogin.DisplayMember = "username";
            opcreaderlogin.SelectedIndex = 0;
        }


        private string GetParaName(string AllParName)
        {
            string[] paraNames = AllParName.Split('.');
            string paraName = paraNames[1];
            return paraName;
        }


        //read over
        private void btnBegin_Click(object sender, EventArgs e)
        {
            runningState = true;
            try
            {
                itemList = new List<string>();
                int count = 1;
                // ������ѡ���б����Ŀ����dtu������
                count = parseItemByDTU(count);

                // ����ϵͳ��Ϣ����ÿ��dtu����
                count = parseErrorsByDTU(count);

                foreach (DTU dtu in activeDTU)
                {
                    dtu.setlastDellTime();
                }
                setControlState("startDellData");
            }
            catch(Exception ex)
            {
                lb_info.Text = "��ʼ��ʧ��:"+ex.Message;
                runningState = false;
                return;
            }


        }

        //read over
        private int parseErrorsByDTU(int count)
        {
            int result = count;
            for (int i = 0; i < opcSystemInfoItems.Count; i++)
            {
                itemList.Add(opcSystemInfoItems[i]);
                DTUError error = new DTUError(opcSystemInfoItems[i]);
                int index = isContainDTU(activeDTU, opcSystemInfoItems[i].Substring(0, 9));

                if (index > -1)
                {
                    activeDTU[index].DTUErrors.Add(error);
                }
                KepItems.AddItem(opcSystemInfoItems[i], count);
                result++;
            }
            return result;
        }

        //read over
        private int parseItemByDTU(int count)
        {
            int result = count;
            foreach (ListItem item in listBox2.Items)
            {
                itemList.Add(item.Text);
                DTUParam para = new DTUParam(item.Text);
                int index = isContainDTU(activeDTU, item.Text.Substring(0, 9));
                if (index == -1)
                {
                    DTU dtu = new DTU(item.Text.ToString().Substring(0, 9));

                    dtu.DTUParams.Add(para);
                    activeDTU.Add(dtu);
                }
                else
                {
                    activeDTU[index].DTUParams.Add(para);
                }
                KepItems.AddItem(item.Text, count);
                result++;
            }
            return result;
        }

        //read over
        private void btnStop_Click(object sender, EventArgs e)
        {



            Array Errors;
            List<int> temp = new List<int>();
            temp.Add(0);                  //ע��OPC����1Ϊ����Ļ���
            //temp����ĺ��⣿���ã�
            for (int i = 1; i <= itemList.Count; i++)
            {
                OPCItem bItem = KepItems.Item(i);
                temp.Add(bItem.ServerHandle);
            }            
            Array serverHandle = temp.ToArray();
            try
            {
                KepItems.Remove(KepItems.Count, ref serverHandle, out Errors);
            }
            catch(Exception ex)
            {
                Console.WriteLine("kepItems.Remove����ִ�д���"+ex.Message);
            }
            finally
            {
                runningState = false;
                ResetProperty();
                setControlState("stopDellData");
            }
        }
        private void ResetProperty()
        {
            itemList.Clear();
            activeDTU.Clear();                   
        }

 

        private void parseItemData(List<string> items, Array itemValues, Array timeStamps, Array qualities)
        {
            for (int i = 0; i < items.Count; i++)
            {
                int index = isContainDTU(activeDTU, items[i].Substring(0, 9));
                if (index > -1)
                {
                    for (int j = 0; j < activeDTU[index].DTUParams.Count; j++)
                    {
                        if (activeDTU[index].DTUParams[j].ID == items[i])
                        {
                            activeDTU[index].DTUParams[j].value = Convert.ToDouble(itemValues.GetValue(i + 1).ToString());
                            #region
                            activeDTU[index].DTUParams[j].timestamp = dateTimeBias(timeStamps.GetValue(i + 1));
                            //activeDTU[index].DTUParams[j].timestamp = timeStamps.GetValue(i + 1).ToString();
                            #endregion
                            activeDTU[index].DTUParams[j].quality = qualities.GetValue(i + 1).ToString();
                            break;
                        }
                    }
                    for (int j = 0; j < activeDTU[index].DTUErrors.Count;j++ )
                    {
                        if (activeDTU[index].DTUErrors[j].ID == items[i])
                        {
                            activeDTU[index].DTUErrors[j].value = itemValues.GetValue(i + 1).ToString();
                            break;
                        }
                    }
                }
            }
        }

        #region ���о�
        private string dateTimeBias(object dateTimeSource)
        {        
            int _intBiasMinute = Convert.ToInt16(txt_biasTime.Text);
            DateTime soure = Convert.ToDateTime(dateTimeSource);
            DateTime biasTime = soure.AddHours(_intBiasMinute);
            Console.WriteLine("dateTimeSource:" + soure.ToString() + "  BiasHoure:" + _intBiasMinute.ToString() + "  biasTime:" + biasTime.ToString());
            return biasTime.ToString();
        }
        #endregion
        //read over
        //���ص�ǰDTU��DTU�����е������Ż�λ��
        private int isContainDTU(List<DTU> dtus, string dtuId)
        {
            for (int j = 0; j <dtus.Count; j++)
            {
                if (dtus[j].ID == dtuId)
                {
                    return j;
                }
            }
            return -1;
        }



        
        private void bt_add_Click(object sender, EventArgs e)
        {
            ListItem selectItem = (ListItem)listBox1.SelectedItem;
            if (selectItem != null)
                foreachListItemsAndAdd(listBox1, listBox2, selectItem.Text.Substring(0, 5));
            if (listBox2.Items.Count > 0)
            {
                btnBegin.Enabled = true;
            }
            else
            {
                btnBegin.Enabled = false;
            }
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            ListItem selectItem = (ListItem)listBox2.SelectedItem;
            if (selectItem != null)
                foreachListItemsAndAdd(listBox2, listBox1, selectItem.Text.Substring(0, 5));
            if (listBox2.Items.Count > 0)
            {
                btnBegin.Enabled = true;
            }
            else
            {
                btnBegin.Enabled = false;
            }
        }

        public void foreachListItemsAndAdd(System.Windows.Forms.ListBox foreachListbox, System.Windows.Forms.ListBox addListbox, string proj)
        {
            List<ListItem> removeItems = new List<ListItem>();
            foreach (ListItem item in foreachListbox.Items)
            {
                if (item.Text.Substring(0, 5) == proj)
                {
                    addListbox.Items.Add(item);
                    removeItems.Add(item);
                }
            }

            foreach (ListItem removeItem in removeItems)
            {
                foreachListbox.Items.Remove(removeItem);
            }

        }

        //read over
        private void bt_login_Click(object sender, EventArgs e)
        {
            Console.Write(opcreaderlogin.Text.Trim().ToString());
            if (opcreaderlogin.Text.Trim().ToString() == "�ֶ�¼��" || opcreaderlogin.Text.Trim().ToString() == "")
            {
                MessageBox.Show("��¼��OPC�б�����");
                return;

            }
            else
            {
                userName = opcreaderlogin.Text.Trim().ToString();
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            readDefineCodeList();
            setControlState("init");
        }

        //read over
        private void setControlState(string spotType)
        {
            switch (spotType)
            {
                case "init":
                    btnConnLocalServer.Enabled = true;
                    bt_add.Enabled = false;
                    bt_remove.Enabled = false;
                    bt_saveList.Enabled = false;
                    runningState = false;
                    break;
                case "stopDellData":
                    btnBegin.Enabled = true;
                    btnStop.Enabled = false;
                    runningState = false;
                    bt_add.Enabled = true;
                    bt_remove.Enabled = true;
                    break;

                case "startDellData":
                    lb_info.Text = "��ʼ���ɹ���";
                    btnBegin.Enabled = false;
                    btnStop.Enabled = true;
                    runningState = true;
                    bt_add.Enabled = false;
                    bt_remove.Enabled = false;
                    break;
                case "connected":
                    btnConnLocalServer.Enabled = false;
                    bt_add.Enabled = true;
                    bt_remove.Enabled = true;
                    bt_saveList.Enabled = true;
                    break;

                default:
                    break;


            }

        }

        //read over
        private void readDefineCodeList()
        {
            string str = "select list from D20_08 where username='" + userName + "'";
            object ob = mydb.return_first_row(str);
            string mylist = "";
            if (ob != null)
            {
                mylist = ob.ToString();
                string[] list = mylist.Split('|');
                foreach (string item in list)
                {
                    ListItem it = new ListItem(item, item);
                    listBox2.Items.Add(it);
                }
            }
        }

        //read over
        private void bt_saveList_Click(object sender, EventArgs e)
        {
            string mylist = selectedItemsToString();
            string username = opcreaderlogin.Text.Trim();
            string str = "select * from D20_08 where username='" + username + "'";
            object ob = mydb.return_first_row(str);
            string str1 = "";
            if (ob != null)
            {
                str1 = "update D20_08 set list='" + mylist + "' where username='" + username + "'";
            }
            else
            {
                str1 = "insert into D20_08(username,list) values('" + username + "','" + mylist + "')";
            }
            if (mydb.db_exec(str1))
            {
                lb_info.Text = "����ɹ���";
                lb_info.ForeColor = Color.FromArgb(new Random().Next(0, 255 * 255 * 255));
            }
            else
            {
                lb_info.Text = "�����б�ʧ�ܣ�";
                lb_info.ForeColor = Color.FromArgb(new Random().Next(0, 255 * 255 * 255));
            }
        }

        //read over
        private string selectedItemsToString()
        {
            string mylist = "";
            if (listBox2.Items.Count > 0)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    ListItem item = (ListItem)listBox2.Items[i];
                    mylist += item.Text;
                    if (i != listBox2.Items.Count - 1)
                    {
                        mylist += "|";
                    }
                }
            }
            return mylist;
        }

        private void checkList()
        {
            List<string> proListInFile = new List<string>();

            foreach (ListItem item in listBox2.Items)
            {
                if (!proListInFile.Contains(item.Text.ToString().Substring(0, 5)))
                {
                    proListInFile.Add(item.Text.Substring(0, 5));
                }

            }
            listBox2.Items.Clear();
            foreach (string pro in proListInFile)
            {
                foreachListItemsAndAdd(listBox1, listBox2, pro);
            }
            if (listBox2.Items.Count > 0)
            {
                btnBegin.Enabled = true;
            }
        }

        private object findParaByItem(string id)
        {
            foreach (DTU dtu in activeDTU)
            {
                foreach (DTUParam para in dtu.DTUParams)
                {
                    if (para.ID == id)
                        return para;
                }
            }
            return null;
        }

        private bool filter(string str)
        {
            string isRightItem = "(^[a-z0-9A-Z]{9}\\.[a-z0-9A-Z]{14}[01]$)";
            string isSystemInfoItem = "(^[a-z0-9A-Z]{9}\\.\\${1,2}\\w*)";
            if( Regex.IsMatch(str,isRightItem))
            {
                opcDataItems.Add(str);
                return true;
            }
            if(Regex.IsMatch(str,isSystemInfoItem))
            {
                opcSystemInfoItems.Add(str);
                return false;
            }
            return false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (runningState)
            {
                //try
                //{
                //    if (itmHandleClient != 0)
                //    {
                //        this.txtTagValue.Text = "";
                //        this.txtQualities.Text = "";
                //        this.txtTimeStamps.Text = "";

                //        Array Errors;
                //        OPCItem bItem = KepItems.GetOPCItem(itmHandleServer);
                //        //ע��OPC����1Ϊ����Ļ���
                //        int[] temp = new int[2] { 0, bItem.ServerHandle };
                //        Array serverHandle = (Array)temp;
                //        //�Ƴ���һ��ѡ�����
                //        KepItems.Remove(KepItems.Count, ref serverHandle, out Errors);
                //    }
                //    itmHandleClient = 1234;
                //    //�ص��============

                //    KepItem = KepItems.AddItem(listBox2.Text, itmHandleClient);
                //    itmHandleServer = KepItem.ServerHandle;
                //}
                //catch (Exception err)
                //{
                //    //û���κ�Ȩ�޵������OPC������������ϵͳ��˴��ɲ�������
                //    itmHandleClient = 0;
                //    txtTagValue.Text = "����" + err.Message;
                //    txtQualities.Text = "����" + err.Message;
                //    txtTimeStamps.Text = "����" + err.Message;
                //}
                DTUParam selectPara = (DTUParam)findParaByItem(listBox2.Text);
                try
                {
                    txtTagValue.Text = selectPara.value.ToString();
                    txtQualities.Text = selectPara.quality.ToString();
                    txtTimeStamps.Text = selectPara.timestamp.ToString();
                }
                catch (Exception)
                {
                    txtTagValue.Text = "���ݳ���";
                    txtQualities.Text = "���ݳ���";
                    txtTimeStamps.Text = "���ݳ���";
                }
            }
            else
            {
                txtTagValue.Text = "δ��������ʱ��";
                txtQualities.Text = "δ��������ʱ��";
                txtTimeStamps.Text = "δ��������ʱ��";
            }
        }


    }
}