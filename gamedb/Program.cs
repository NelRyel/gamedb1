// See https://aka.ms/new-console-template for more information
using gamedb;

Console.WriteLine("Hello, World!");

using(DbContextGame db = new DbContextGame())
{
    Console.WriteLine(  "in using");
}

