/*public void play()
{
    int x = width / 2 + 2;
    int y = height / 2 + 2;
    int leftend=width;
    int topend=height;

    ConsoleKeyInfo keyInfo;
    do
    {
        Console.SetCursorPosition(x, y);

        keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:

                if (y > 1)
                    y -= 2;
                break;

            case ConsoleKey.DownArrow:
                if (y < height * 2 - 2)
                    y += 2;
                break;

            case ConsoleKey.LeftArrow:
                if (x > 4)
                    x -= 4;
                break;

            case ConsoleKey.RightArrow:
                if (x <= width * 4 - 4)
                    x += 4;
                break;
            case ConsoleKey.Spacebar:
                if (!field[y / 2, x / 4].answer())
                {
                    if (field[y / 2, x / 4].iscolor(true))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.SetCursorPosition(x - 1, y);
                        Console.WriteLine("███");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(x - 1, y);
                        Console.WriteLine("█X█");
                        //WriteConsoleOutputCharacter
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x, y);
                    }
                }
                break;
            case ConsoleKey.M:
                if (!field[y / 2, x / 4].answer())
                {
                    if (field[y / 2, x / 4].iscolor(false))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition(x - 1, y);
                        Console.WriteLine("███");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x, y);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.SetCursorPosition(x - 1, y);
                        Console.WriteLine("█X█");
                        //WriteConsoleOutputCharacter
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x, y);
                    }
                }

                break;

        }
    } while (keyInfo.Key != ConsoleKey.Escape);
}*/