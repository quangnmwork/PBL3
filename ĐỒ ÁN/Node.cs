using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐỒ_ÁN
{
    public class Node
    {
        public int IdNode;
        public int STT;
        public string name; // name = E110 , E201 
        public double x;
        public double y;
        public double z;
        public bool visited;
        public List<Edge> edges;

        // public void showListNode(){
        //     foreach(Edge edge in edges) { 
        //         edge.destination.show(); 
        //         edge.source.show();
        //     }
        // }
        //Khoi tao nut voi so thu tu n, ten dia diem name, toa do x,y,z
        //visited = true khi canh da duoc di qua
        // edges la list chua cac canh noi voi nut nay
        public void setWeightNode(string name)
        {
            foreach(Edge ed in edges)
            {
                if(ed.destination.name == name)
                {
                    Console.WriteLine(ed.weight);
                    break;
                }
            }
        }
        public Node() { }
        public  void getEdges()
        {
            foreach(Edge ed in edges)
            {
                Console.WriteLine("Source : {0} , Destination :{1}", ed.source.name, ed.destination.name);
            }
        }

        public Node(int n, int STT, string name, double x, double y, double z)
        {
            this.IdNode = n;
            this.STT = STT;
            this.name = name;
            this.x = x;
            this.y = y;
            this.z = z;
            visited = false;
            edges = new List<Edge>();
        }
        //Khoi tao nut voi so thu tu n, ten dia diem name, toa do x,y,z
        public double getDis(Node temp)
        {
            String first = this.name;
            String second = temp.name;
            //if (first[0] == second[0])
            //    return Math.Sqrt((this.y - temp.y) * (this.y - temp.y) + (this.z - temp.z) * (this.z - temp.z));
            //else return Math.Sqrt((this.y - temp.y) * (this.y - temp.y) + (this.x - temp.x) * (this.x - temp.x));
            return Math.Sqrt((this.y - temp.y) * (this.y - temp.y) + (this.z - temp.z) * (this.z - temp.z) + (this.x - temp.x) * (this.x - temp.x));
        }

        public bool isVisited()
        {
            return visited;
        }

        public void visit()
        {
            visited = true;
        }

        public void unvisit()
        {
            visited = false;
        }
        //In ra toa do x,y,z
        public void show()
        {
            Console.WriteLine("{0} , {1} , {2}", x, y, z);
        }
    }
}
