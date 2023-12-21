namespace Calculator.Model;

public class MyStack<T>
{
    public MyLinkedList<T> Elements { get; } = new();
    public int Size { get; set; }

    public void Push(T data)
    {
        Elements.AddFirst(data);
        Size++;
    }

    public string Pop()
    {
        Size--;
        return Elements.RemoveFirst().ToString();
    }

    public string Peek()
    {
        return Elements.Head.ToString();
    }
}

public class MyLinkedList<T>
{
    public Node<T> Head { get; private set; } = new();
    public int Size { get; private set; }

    public void AddFirst(T data)
    {
        Head = new Node<T>
        {
            Data = data,
            NextNode = Head
        };
        Size++;
    }

    public Node<T> RemoveFirst()
    {
        var removed = Head;
        Head = Head.NextNode;
        Size--;
        return removed;
    }
    
}
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> NextNode { get; set; }

    public override string ToString()
    {
        return Data.ToString();
    }
}