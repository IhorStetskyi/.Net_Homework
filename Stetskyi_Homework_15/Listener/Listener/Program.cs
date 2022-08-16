namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            MyListener listener = new MyListener();
            listener.StartListening();
        }
    }
}
