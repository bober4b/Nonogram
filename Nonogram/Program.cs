using Nonogram.controls;
using System;


public class main
{//Gra gra = new(10,10);
 //Console.SetCursorPosition(1, 1);

    public static void Main(string[] args)
    {
        Menu menu = new();
        //menu.Menuinit();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WindowWidth = 90;
        Console.WindowHeight = 45;
        menu.Menuinit();
        //gra.Menu();
        //gra.ConsoleInGameMenu();
        Console.SetCursorPosition(1, 44);
    }

}

