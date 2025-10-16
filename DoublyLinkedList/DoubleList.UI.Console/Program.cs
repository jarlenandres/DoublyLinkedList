using DoublyLinkedList;
using System.ComponentModel.Design;

var list = new DoubleLinkedList<string>();  
var opc = string.Empty;

do
{
    opc = Menu();
    switch (opc)
    {
        case "0":
            Console.WriteLine("Exiting...");
            break;
        case "1":
            Console.Write("Enter the data: ");
            var data = Console.ReadLine()!;
            if (data != null)
            {
                list.InsertItem(data);
            }
            break;
        case "2":
            Console.WriteLine(list.GetForward());
            break;
        case "3":
            Console.WriteLine(list.GetBackward());
            break;
        case "4":
            list.ReverseOrder();
            break;
        case "5":
            Console.WriteLine(list.GetMode());
            break;
        case "6":
            list.Graph();
            break;
        case "7":
            Console.Write("Enter the data: ");
            var exits = Console.ReadLine()!;
            if (exits != null)
            {
                Console.WriteLine(list.GetContains(exits));
            }
            break;
        case "8":
            list.Remove();
            Console.WriteLine("Item removed.");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (opc != "0");

string Menu()
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("1. Insert data.");
    Console.WriteLine("2. Show forward.");
    Console.WriteLine("3. Show backward.");
    Console.WriteLine("4. Sort descending.");
    Console.WriteLine("5. Show the modes.");
    Console.WriteLine("6. Show graph.");
    Console.WriteLine("7. Contains.");
    Console.WriteLine("8. Delete first item.");
    Console.WriteLine("0. Exit.");
    Console.Write("Enter your option: ");
    return Console.ReadLine()!;
}