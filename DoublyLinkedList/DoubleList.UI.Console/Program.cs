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
            Console.WriteLine(list.GetBackward());
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
    Console.WriteLine("0. Exit.");
    Console.Write("Enter your option: ");
    return Console.ReadLine()!;
}