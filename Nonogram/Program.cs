using Nonogram;


Gra gra = new(11,15);
Console.SetCursorPosition(1, 1);
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WindowWidth = 80;  // Szerokość konsoli w kolumnach
Console.WindowHeight = 50; // Wysokość konsoli w wierszach

//Console.WriteLine("███");

/*Console.ForegroundColor = ConsoleColor.Magenta;
Console.SetCursorPosition(0,21 );
Console.WriteLine("╔");
Console.WriteLine("═");
Console.WriteLine("═");
Console.WriteLine("═");
Console.WriteLine("╔════╗");
Console.WriteLine("║ ██ ║");
Console.WriteLine("╚════╝");*/
//Console.WriteLine(12 / 2);
gra.Play();


