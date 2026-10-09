public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else 
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // if the value matches this node, we have found it.
        if (value ==  Data)
        {
            return true;
        }

        // if the value is smaller, check the left side.
        if (value < Data)
        {
            if (Left == null)
            {
                return false;
            }
            return Left.Contains(value);
        }

        // if the value is larger, check the right side.
        if (Right == null)
        {
            return false;
        }
        return Right.Contains(value);
    }

    public int GetHeight()
    {
        // Start with zero because a missing child has height zero.
        int leftHeight = 0;
        int rightHeight = 0;

        // Find the height of the left branch if  it exists.
        if (Left != null)
        {
            leftHeight = Left.GetHeight();
        }

        // Find the height o the right bbranch if it exists.
        if (Right !=  null)
        {
            rightHeight = Right.GetHeight();
        }

        // Return one plus the height  of the taller branch.

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}