using tree_solution;

public class MinHeap
{
    public Node Root { get; private set; }

    public MinHeap()
    {
        Root = null;
    }

    public void Insert(int value)
    {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node root, int value)
    {
        if (root == null)
        {
            root = new Node(value);
            return root;
        }

        if (value < root.Data)
        {
            root.Left = InsertRec(root.Left, value);
        }
        else
        {
            root.Right = InsertRec(root.Right, value);
        }

        return root;
    }

    public void Traverse()
    {
        Traverse_forward(Root);
    }

    private void Traverse_forward(Node root)
    {
        if (root != null)
        {
            Traverse_forward(root.Left);
            Console.Write(root.Data + " ");
            Traverse_forward(root.Right);
        }
    }

    public int RemoveMin()
    {
        if (Root == null)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        int minValue = Root.Data;
        Root = DeleteNode(Root, minValue);
        return minValue;
    }

    private Node DeleteNode(Node root, int value)
    {
        if (root == null)
        {
            return root;
        }

        if (value < root.Data)
        {
            root.Left = DeleteNode(root.Left, value);
        }
        else if (value > root.Data)
        {
            root.Right = DeleteNode(root.Right, value);
        }
        else
        {
            // Node with one child or no child
            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            root.Data = MinValue(root.Right);

            // Delete the inorder successor
            root.Right = DeleteNode(root.Right, root.Data);
        }

        return root;
    }

    private int MinValue(Node node)
    {
        int minValue = node.Data;
        while (node.Left != null)
        {
            minValue = node.Left.Data;
            node = node.Left;
        }
        return minValue;
    }
}
