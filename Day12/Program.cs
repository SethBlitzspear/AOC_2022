// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

string[] Input = File.ReadAllLines("Input.txt");
Node startNode = null, endNode = null;
List<Node> SearchNodes= new List<Node>();
List<Node> ANodes = new List<Node>();
Node[,] Nodes = new Node[Input.Length, Input[0].Length];
for (int xNode = 0; xNode < Input.Length; xNode++)
{
    for (int yNode = 0; yNode < Input[0].Length; yNode++)
    {
        Nodes[xNode, yNode] = new Node(Input[xNode][yNode], xNode, yNode);
        
        SearchNodes.Add(Nodes[xNode, yNode]);
        if (Nodes[xNode, yNode].Heightletter == 'S')
        {
            startNode = Nodes[xNode, yNode];
        }
        else if (Nodes[xNode, yNode].Heightletter == 'E')
        {
            endNode = Nodes[xNode, yNode];  
        }
     
    }
    ANodes.Add(Nodes[xNode, 0]);
}



for (int xNode = 0; xNode < Input.Length; xNode++)
{
    for (int yNode = 0; yNode < Input[0].Length; yNode++)
    {

        if (Nodes[xNode, yNode].Heightletter == 'S')
        {
            startNode = Nodes[xNode, yNode];
        }

        if (Nodes[xNode, yNode].Heightletter == 'E')
        {
            endNode = Nodes[xNode, yNode];
        }

        try
        {
            if (Nodes[xNode - 1, yNode].Height  <= Nodes[xNode, yNode].Height + 1)
            {
                Nodes[xNode, yNode].Links.Add(Nodes[xNode - 1, yNode]);
                if (Nodes[xNode - 1, yNode].Heightletter == 'E')
                {
                    int stop = 1;
                }

            }
        }
        catch (Exception)
        {
        }
        try
        {
            if (Nodes[xNode + 1, yNode].Height <= Nodes[xNode, yNode].Height + 1)
            {
                Nodes[xNode, yNode].Links.Add(Nodes[xNode + 1, yNode]);
            }
        }
        catch (Exception)
        {
        }
        try
        {
            if (Nodes[xNode, yNode - 1].Height <= Nodes[xNode, yNode].Height + 1)
            {
                Nodes[xNode, yNode].Links.Add(Nodes[xNode, yNode - 1]);
                if(Nodes[xNode, yNode - 1].Heightletter == 'E')
                {
                    int stop = 1;
                }
            }
        }
        catch (Exception)
        {
        }
        try
        {
            if (Nodes[xNode, yNode + 1].Height <= Nodes[xNode, yNode].Height + 1)
            {
                Nodes[xNode, yNode].Links.Add(Nodes[xNode, yNode + 1]);
            }
        }
        catch (Exception)
        {
        }

    }
}
int minCountback = 100000;
while (ANodes.Count > 0)
{
    Console.Write("Searching " + ANodes.Count + " to go!");
    SearchNodes = new List<Node>();
    startNode = ANodes[0];
    ANodes.RemoveAt(0);
    for (int xNode = 0; xNode < Input.Length; xNode++)
    {
        for (int yNode = 0; yNode < Input[0].Length; yNode++)
        {
            Nodes[xNode, yNode].Distance = int.MaxValue;
            Nodes[xNode, yNode].LastTravelled = null; 
            SearchNodes.Add(Nodes[xNode, yNode]);

        }
    }
    startNode.Distance = 0;
    startNode.LastTravelled = null;

    bool founIt = false;
    while (!founIt)
    {

        SearchNodes.Sort((n, m) => n.Distance.CompareTo(m.Distance));
        if (SearchNodes[1].Distance == 100000)
        {
            int stop = 1;
        }
        Node currentNode = SearchNodes[0];
        SearchNodes.RemoveAt(0);
        if (currentNode.Heightletter == 'E')
        {
            founIt = true;
        }
        else
        {
            foreach (Node node in currentNode.Links)
            {
                if (SearchNodes.Contains(node))
                {
                    if (node.Distance > currentNode.Distance + 1)
                    {
                        node.Distance = currentNode.Distance + 1;
                        node.LastTravelled = currentNode;
                    }
                }
            }
        }
    }

    int countBack = 0;
    Node findNode = endNode;
    while (findNode != startNode)
    {
        countBack++;
        findNode = findNode.LastTravelled;
    }
    Console.Write(" distance was " + countBack);
   if(minCountback > countBack)
    {
        minCountback = countBack;
        Console.Write(" - New low!!");
    }
    Console.WriteLine();
}
Console.WriteLine(minCountback);
public class Node
{
    public Node(char v, int newX, int newY)
    {
        X = newX;
        Y = newY;
        Heightletter = v;
        if (v == 'S')
        {
            Distance = 0;
        }
        else
        {
            Distance = 100000;
        }
        Links = new List<Node>();
    }

    public char Heightletter { get; set; }
    public int Height
    {
        get
        {
            if (Heightletter == 'S')
            {
                return Convert.ToInt32('a');
            }
            else
            {
                if (Heightletter == 'E')
                {
                    return Convert.ToInt32('z');
                }
                else
                {
                    return Convert.ToInt32(Heightletter);
                }
            }
           // return 0;
        }
    }
    public int Distance { get; set;  }
    public Node LastTravelled { get; set; }
    public List<Node> Links { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

}
