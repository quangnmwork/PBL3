using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN
{
    public partial class Form1 : Form
    {
        int AddNode = 1;
        public Graph g = new Graph(false);
        public Graph g1 = new Graph(false);
        public List<string> firstDel = new List<string>();
        public List<string> secondDel =new List<string>();
        public List<Node> AllNodeInCSDL;
        public string []NameKhu;
        Node dp1 = new Node(0, -1, "DP1", 1667, 557, 0);
        Node dp2 = new Node(0, -1, "DP2", 1272, 569, 0);
        Node dp3 = new Node(0, -1, "DP3", 1284, 784, 0);
        Node dp4 = new Node(0, -1, "DP4", 1627, 978, 0);
        Node dp5 = new Node(0, -1, "DP5", 1664, 94, 0);
        Node htruongF = new Node(0, -1, "HTF", 1663, 970, 0);
        public Form1()
        {
            InitializeComponent();   
            AddNodeInGrap();
            NameKhu = CSDL_OOP.Instance.GetNameKhu().ToArray();
        }
        
        private void AddNodeInGrap()
        {
            AllNodeInCSDL = new List<Node>();
            foreach(PHONGHOC i in CSDL_OOP.Instance.GetAllPhongHoc())
            {
                AllNodeInCSDL.Add(CSDL_OOP.Instance.ConverNodeFromPhongHoc(AddNode++, i));
            }
            foreach (CAUTHANG i in CSDL_OOP.Instance.GetAllCauThang())
            {
                AllNodeInCSDL.Add(CSDL_OOP.Instance.ConverNodeFromCauThang(AddNode++, i));
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn ("IdNode", typeof(int)),
                new DataColumn ("STT", typeof(int)),
                new DataColumn ("name", typeof(string)),
                //new DataColumn ("STT", typeof(int)),
            }
            );
            foreach(Node i in AllNodeInCSDL)
            {
                DataRow dr = dt.NewRow();
                dr["IdNode"] = i.IdNode;
                dr["STT"] = i.STT;
                dr["name"] = i.name;
                dt.Rows.Add(dr);
            }

            dgv.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dgv.DataSource = CSDL_OOP.Instance.GetAllKhu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv.DataSource = CSDL_OOP.Instance.GetAllCauThang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv.DataSource = CSDL_OOP.Instance.GetAllPhongHoc();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            int checkText1 = 0, checkText2 = 0;
            Show.Text = "";
            string start = txtStart.Text;
            string end = txtEnd.Text;
            Node source = new Node(0, -1, "0", 0, 0, 0), destination = new Node(0, -1, "0", 0, 0, 0);
            foreach ( Node node  in  AllNodeInCSDL)
            {
                if (node.name == start)
                {
                    source = node;
                    checkText1 = 1;
                }
                if (node.name == end) { 
                    destination = node; 
                    checkText2 = 1; 
                }
            }
            AllNodeInCSDL.Add(dp1);
            AllNodeInCSDL.Add(dp2);
            AllNodeInCSDL.Add(dp3);
            AllNodeInCSDL.Add(dp4);
            AllNodeInCSDL.Add(dp5);
            AllNodeInCSDL.Add(htruongF);
            g.resetNodesVisited();
            g.createGraph(AllNodeInCSDL, NameKhu, NameKhu.Length);
            this.Connect();
            g.removeListEdge(firstDel, secondDel);
            if (checkText1 == 1 && checkText2 == 1)
            {
                g.DijkstraShortestPath(source, destination);
                Show.Text += g.ShortestPath + "\n";
            }
            else
            {
                MessageBox.Show("Invalid room !");
            }

        }
        public void Connect ()
        {
            Node source = new Node(0, -1, "0", 0, 0, 0), destination = new Node(0, -1, "0", 0, 0, 0);
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "EM_CT21") source = node;
                if (node.name == "EC110B") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "EC112") source = node;
                if (node.name == "CM128") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "CM125") source = node;
                if (node.name == "CC101") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
            //foreach (Node node in AllNodeInCSDL)
            //{
            //    if (node.name == "CC107") source = node;
            //    if (node.name == "BT106") destination = node;
            //}
            //g.addEdge(source, destination, source.getDis(destination));
            //foreach (Node node in AllNodeInCSDL)
            //{
            //    if (node.name == "CC107") source = node;
            //    if (node.name == "BS107") destination = node;
            //}
            //g.addEdge(source, destination, source.getDis(destination));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BT_CT21") source = node;
                if (node.name == "BS108") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BS109") source = node;
                if (node.name == "BT_CT11") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BS209") source = node;
                if (node.name == "BT_CT12") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BS208") source = node;
                if (node.name == "BT_CT22") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BS207") source = node;
                if (node.name == "BT_CT32") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
           
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "F_CT11") source = node;
                if (node.name == "BT_CT11") destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));          
            

            g.addEdge(dp1, dp2, dp1.getDis(dp2));
            g.addEdge(dp3, dp2, dp3.getDis(dp2));
            g.addEdge(dp3, htruongF, dp3.getDis(htruongF));
            g.addEdge(dp1, dp4, dp1.getDis(dp4));
            g.addEdge(dp5,dp1,dp5.getDis(dp1));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "EC112") source = node;
            }
            g.addEdge(dp1, source, dp1.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "EM_CT11") source = node;
            }
            g.addEdge(dp5, source, dp5.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "CM128") source = node;
            }
            g.addEdge(dp1,source, dp1.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "F110") source = node;
            }
            g.addEdge(source, dp2, dp2.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "F108") source = node;
            }
            g.addEdge(source, dp3, dp3.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "F107") source = node;
            }
            g.addEdge(source, dp3, dp3.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "F_CT21") source = node;
            }
            g.addEdge(source, dp3, dp3.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "CC107") source = node;
            }
            g.addEdge(source, dp4, dp4.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BT106") source = node;
            }
            g.addEdge(source, dp4, dp4.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "CC106") source = node;
            }
            g.addEdge(source, htruongF, htruongF.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "CC107") source = node;
            }
            g.addEdge(source, htruongF, htruongF.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "CC105") source = node;
            }
            g.addEdge(source, htruongF, htruongF.getDis(source));

            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BS107") source = node;
            }
            g.addEdge(source, htruongF, htruongF.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BS108") source = node;
            }
            g.addEdge(source, htruongF, htruongF.getDis(source));
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == "BS109") source = node;
            }
            g.addEdge(source, htruongF, htruongF.getDis(source));
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        private  void addEdgefromText(string txt1,string txt2)
        {
            Node source = new Node(0, -1, "0", 0, 0, 0), destination = new Node(0, -1, "0", 0, 0, 0);
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == txt1) source = node;
                if (node.name == txt2) destination = node;
            }
            g.addEdge(source, destination, source.getDis(destination));
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            string txt1 = textBox1.Text;
            string txt2 = textBox2.Text;
            int checkText1 = 0, checkText2 = 0;
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == txt1)
                {
                    checkText1 = 1;
                }
                if (node.name == txt2)
                {
                    checkText2 = 1;
                }
            }
            if(checkText1 == 1 && checkText2 ==1) {
                firstDel.Add(txt1);
                secondDel.Add(txt2);
            }
            else
            {
                MessageBox.Show("Invalid room !");
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int checkText1 = 0,checkText2=0; 
            string txt1 = textBox1.Text;
            string txt2 = textBox2.Text;
            Node source = new Node(0, -1, "0", 0, 0, 0), destination = new Node(0, -1, "0", 0, 0, 0);
            foreach (Node node in AllNodeInCSDL)
            {
                if (node.name == txt1)
                {
                    source = node;
                    checkText1 = 1;
                }
                if (node.name == txt2)
                {
                    destination = node; 
                    checkText2 = 1;
                }
            }
            if(checkText1 == 1 && checkText2 == 1) {
                for (int i = 0; i < firstDel.Count(); i++)
                {
                    if (firstDel[i] == txt1)
                    {
                        if (secondDel[i] == txt2)
                        {
                            g.addEdge(source, destination, source.getDis(destination));
                            firstDel.RemoveAt(i);
                            secondDel.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            g.addEdge(source, destination, source.getDis(destination));
                        }
                    }
                    if (firstDel[i] == txt2)
                    {
                        if (secondDel[i] == txt1)
                        {
                            g.addEdge(source, destination, source.getDis(destination));
                            firstDel.RemoveAt(i);
                            secondDel.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            g.addEdge(source, destination, source.getDis(destination));
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Invalid room !");
            }
            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}
