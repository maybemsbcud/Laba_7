namespace laba7;

public class Node
{
    public short Data { get; set; }

    public Node? Next { get; set; }

    public Node(short data)
    {
        Data = data;
        Next = null;
    }
}