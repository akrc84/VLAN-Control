using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VLAN_Control
{
    public partial class VLAN_Control_Form : Form
    {
        List<SwitchData> SwitchD = new List<SwitchData>();
        XmlDocument SwitchXML = new XmlDocument();

        public VLAN_Control_Form()
        {
            InitializeComponent();
            SwitchXML.Load(@"Db\switch_db.xml");

            XmlNodeList Switches = SwitchXML.SelectNodes("//switches/cisco/switch");
            foreach (XmlNode Switch in Switches)
            {
                XmlNode typeNode = Switch.SelectSingleNode("type");
                XmlNode IPNode = Switch.SelectSingleNode("IP");
                XmlNode VLAN_oidNode = Switch.SelectSingleNode("VLAN_oid");

                SwitchData SWData = new SwitchData
                {
                    name = Switch.Attributes["name"].Value,
                    type = typeNode.InnerText,
                    IP = IPNode.InnerText,
                    VLAN_oid = VLAN_oidNode.InnerText
                };
                main_devices_comboBox.Items.Add(SWData.name);

                SwitchD.Add(SWData);
            }
            
        }
    }

    public class SwitchData
    {
        public string name { get; set; }
        public string type { get; set; }
        public string IP { get; set; }
        public string VLAN_oid { get; set; }
    }
}
