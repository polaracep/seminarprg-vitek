using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Node
    {
        public int index;
        public List<Node> neighbours;

        public Node(int index)
        {
            this.index = index;
            neighbours = new List<Node>();
        }
        public void AddNeighbours(List<Node> neighboursToAdd)
        {
            foreach(Node neighbour in neighboursToAdd)
            {
                if (neighbours.Contains(neighbour))
                {
                    Console.WriteLine("lsit already contains neighbor " +  neighbour.index);
                }
                else
                {
                    neighbours.AddRange(neighboursToAdd);
                }
            }


            
        }
        public void PrintNeightbours()
        {
            Console.Write("Node " + index + " has neighbours ");
            foreach (Node neighbour in neighbours)
            {
                Console.Write(neighbour.index + " ");
            }
            Console.WriteLine();
        }
        public Node TraverseNode(int index)
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.index == index)
                {
                    return neighbour;
                } 
            }
            return this;


   
        }
    }
}
