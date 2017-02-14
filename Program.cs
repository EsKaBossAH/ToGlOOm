using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("--- Map ---");
            var map = new Dictionary<string, string>();

        map.Add("B150910044", "(E|A)");
        map.Add("B150910032", "(:D)");
        map.Add("B150910001", "(()))))");
        map.Add("B150910003", "(:())");

        foreach (var pair in map)
        {
            string key = pair.Key;
            string value = pair.Value;
            Console.WriteLine(key + "---" + value);
        }

        string result = map["B150910044"];
        Console.WriteLine(result);

        string mapValue;
        if (map.TryGetValue("asdasa", out mapValue))
        {
            Console.WriteLine(mapValue);
        }
        if (map.TryGetValue("B150910032", out mapValue))
        {
            Console.WriteLine(mapValue);
        }

        Console.WriteLine("\n\n--- List ---");

        List<int> list = new List<int>();
        list.Add(2);
        list.Add(3);
        list.Add(5);
        list.Add(7);
        foreach (int prime in list)
        {
            System.Console.Write(prime);
        }
        int index = list.IndexOf(3); 
        Console.WriteLine(index);

        index = list.IndexOf(10); 
        Console.WriteLine(index);

        list.Reverse();
        foreach (int prime in list)
        {
            System.Console.Write(prime+",");
        }
        List<int> range = list.GetRange(1, 2);
        foreach (int river in range)
        {
            Console.Write(river);
        }
        Console.Write("\n\n--- Stack ---");
        Stack<string> stack = new Stack<string>();
        stack.Push("Tsagaan ayga");
        stack.Push("Nogoon ayga");
        stack.Push("Bor ayga");

        Console.Write("\n"+"Ayganuud:");
        foreach (string i in stack)
        {
            Console.Write(i+",");
        }


        Console.WriteLine("\n--- Avsan ehnii ayga ---");
        Console.WriteLine(stack.Pop());


        Console.WriteLine("\n--- Ayganuudiin deed taliin ayga ---");
        Console.WriteLine(stack.Peek());
        }
    }
    
}
