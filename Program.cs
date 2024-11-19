using game_2048;

Game game = new Game();


Console.WriteLine(game);
while (true)
{
    var key = Console.ReadKey();

    if (key.Key == ConsoleKey.LeftArrow)
    {
        game.ShiftCells('l');
    } else if (key.Key == ConsoleKey.RightArrow)
    {
        game.ShiftCells('r');
    } else if (key.Key == ConsoleKey.UpArrow)
    {
        game.ShiftCells('u');
    } else if (key.Key == ConsoleKey.DownArrow)
    {
        game.ShiftCells('d');
    }
    game.hasWon(game);
    game.AddRandomCell();
    Console.Clear();
    Console.WriteLine(game);
}

