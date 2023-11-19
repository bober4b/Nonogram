using Nonogram;


Gra gra = new(10,10);
Console.SetCursorPosition(1, 1);
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WindowWidth = 90;  
Console.WindowHeight = 50;
gra.Menu();
gra.ConsoleInGameMenu();
Console.SetCursorPosition(1,44);


