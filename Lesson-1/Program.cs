using System;
namespace Interface_sample
{
    public interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
    }
    internal class Countdown : IEnumerator
    {
        int count = 11;
        public bool MoveNext() { return count-- > 0; }
        public object Current { get { return count; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerator e = new Countdown();
            while (e.MoveNext())
                Console.Write(e.Current); // 109876543210
        }
    }
}