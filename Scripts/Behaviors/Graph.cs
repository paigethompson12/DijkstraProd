using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connection(float c, Node f, Node t)
    {
        cost = c;
        fromNode = f;
        toNode = t;
    }
    public float getCost()
    {
        return cost;
    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }
}

public class Graph
{
    List<Connection> myConnections;

    // an array of connections outgoing from the given node
    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in myConnections)
        {
            if (c.getFromNode() == fromNode)
                connections.Add(c);
        }
        return connections;
    }

    public void Build()
    {
        //initialize
        myConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float cost;
                if(fromNode.gameObject.tag == "purple")
                    cost = (float)2.0 * (toNode.transform.position - fromNode.transform.position).magnitude;
                else if(fromNode.gameObject.tag == "fuscia")
                    cost = (float)4.0 * (toNode.transform.position - fromNode.transform.position).magnitude;
                else if(fromNode.gameObject.tag == "yellow")
                    cost = (float)3.0 * (toNode.transform.position - fromNode.transform.position).magnitude;
                else
                    cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                Connection c = new Connection(cost, fromNode, toNode);
                myConnections.Add(c);
            }
        }
    }
}

