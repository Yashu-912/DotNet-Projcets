// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello World!");
Console.WriteLine("Hello Yash!");

string name = "Yash";

Console.WriteLine("Hello " + name);
Console.WriteLine($"Hello {name}");
Console.WriteLine($"Hello {name.ToUpper()}");


var names = new[] {"Ana", "Felipe", "Emilia"};

foreach(var myname in names) {

    Console.WriteLine($"Hello {myname.ToUpper()}!");
    
}