using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace GraphPlayground
{
    internal class Program
    {
        public static void DFS(Graph graph, Node startNode, Node targetNode = null)
        {
            Node currentNode = null;
            List<Node> stack = new List<Node>() { startNode};
            Console.WriteLine("starting node:" + startNode.index);
            while (stack.Count > 0) 
            {
                currentNode = stack[0];
                Console.WriteLine("current node:" + startNode.index);
                stack.RemoveAt(0);
                foreach (Node neighbor in currentNode.neighbors)
                {
                    if (!neighbor.visited)
                    {
                        Console.WriteLine("Adding neighbor: " + neighbor.index + " to queue");
                        stack.Insert(0, neighbor);
                        neighbor.visited = true;

                    }
                    else
                    {
                        //Console.WriteLine(" neighbor: " + neighbor.index + " is already visited or in queue");
                    }
                }
            }
        }

        public static void BFS(Graph graph, Node startNode, Node targetNode = null)
        {
            Node currentNode = null;
            List<Node> queue = new List<Node>();
            queue.Add(startNode);
            Console.WriteLine("starting node:" + startNode.index);
            while(queue.Count > 0)
            {
                currentNode = queue[0];
                Console.WriteLine("current node:" + startNode.index);
                queue.RemoveAt(0);
                foreach(Node neighbor in currentNode.neighbors)
                {
                    if (!neighbor.visited)
                    {
                        Console.WriteLine("Adding neighbor: " + neighbor.index + " to queue");
                        queue.Add(neighbor);
                        neighbor.visited = true;

                    }
                    else
                    {
                        Console.WriteLine("Adding neighbor: " + neighbor.index + " to queue");
                    }
                    
                }
            }
            Console.WriteLine();

        }

        static void Main(string[] args)
        {
            //Create and print the graph
            Graph graph = new Graph();
            graph.PrintGraph();
            graph.PrintGraphForVisualization();

            //Call both algorithms with a random starting node
            Random rng = new Random();
            DFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);
            //BFS(graph, graph.nodes[rng.Next(0, graph.nodes.Count)]);

            Console.ReadKey();
        }
    }
}