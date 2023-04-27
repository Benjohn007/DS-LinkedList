using LinkedList;
using Node;

Linkedlist<String> nw = new Linkedlist<string> ();

Node<string> a = new("Benjamin");
nw.AddFirst(a);

Node<string> b = new("John");
nw.AddFirst(b);

Node<string> e = new("JohanBen");
nw.AddFirst(e);

Node<string> c = new("Dada");
nw.AddFirst(c);


//nw.Find();

nw.Traverse();

Console.WriteLine("\n add after John");
nw.AddAfter(new Node<string>("Olamilekan"), b);
nw.Traverse ();

Node<String> target = nw.Find("JohanBen");
if(target != null)
{
    Console.WriteLine("\n found " + target.Data);
}
else
{
    Console.WriteLine("\n not found");
}

Console.WriteLine("\n Removing " + target.Data);
nw.Remove(e);
nw.Traverse();
