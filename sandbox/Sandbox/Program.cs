// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         int x =  10;
//         int y =  20;
//         int z =  30;

//         if (x == 10 || y == 21 && z == 30)
//         {
        
//             Console.WriteLine("X is 10");
//             Console.WriteLine("Y is fun");
//         }
//         else if (x == 20)
//             Console.WriteLine("Were are in the else if.");
        
//         else
//             Console.WriteLine("Z is not much fun");
        
//     }
// } 



            // bool done = false;

            // while (!done)
            // {
            //     Console.Write("Are we done (y/n): ");
            //     done = Console.ReadLine(). ToLower() == "y";
            // }

            // bool done;

            // do
            // {
            //     Console.Write("Are we done (y/n): ");
            //     done = Console.ReadLine().ToLower() == "y";
            // } while(!done);

            // for (int i = 0; i <= 10; i+=5)
            // {
            //     Console.WriteLine($"{i} -");
            //     Console.WriteLine("Hey Bob");
            // }

            List<string> myFriends = ["BoB", "Betty", "Bubba"];
            List<string> names= new List<string>();
            myFriends.Add("James");
            myFriends.Add("Doug");

            foreach(string name in myFriends)
            {
                Console.WriteLine(name);
            }