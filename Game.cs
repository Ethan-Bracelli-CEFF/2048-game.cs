using game_2048;
using System.Drawing;
using System.Text;

public class Game
{
    public int score;
    public int bestScore;
    public Grid grid;

    public Game()
    {
        this.score = 0;
        this.bestScore = 0;
        this.grid = new Grid();

        AddRandomCell();
        AddRandomCell();
    }

    public override string ToString()
    {
        StringBuilder gameString = new StringBuilder();
        gameString.AppendLine("Score: " + this.score);
        gameString.AppendLine("Best Score: " + this.bestScore);
        gameString.AppendLine("\n");
        gameString.AppendLine(this.grid.ToString());
        return gameString.ToString();
    }

    public void AddRandomCell()
    {
        Random rnd = new Random();
        int emptyCell = 0;
        int cellToReplace = 0;

        for (int row = 0; row < Grid.SIZE; row++)
        {
            for (int col = 0; col < Grid.SIZE; col++)
            {
                if (grid.Cells[row, col].Value == 0)
                {
                    emptyCell++;
                }     
            }
        }

        cellToReplace = rnd.Next(emptyCell);

        emptyCell = 0;

        for (int row = 0; row < Grid.SIZE; row++)
        {
            for (int col = 0; col < Grid.SIZE; col++)
            {
                if (grid.Cells[row, col].Value == 0)
                {
                    if (emptyCell == cellToReplace)
                    {
                        grid.Cells[row, col].Value = rnd.Next(4) == 0 ? 4 : 2;
                    }
                    emptyCell++;
                }
                
            }
        }
    }

    public void ShiftCells(char direction)
    {
        for (int i = 0; i < Grid.SIZE; i++)
        {
            List<int> newRow = new List<int>();

            for (int j = 0; j < Grid.SIZE; j++)
            {
                int value = 0;
                switch (direction)
                {
                    case 'l':
                        value = grid.Cells[i, j].Value;
                        break;
                    case 'r':
                        value = grid.Cells[i, Grid.SIZE - 1 - j].Value;
                        break;
                    case 'u':
                        value = grid.Cells[j, i].Value;
                        break;
                    case 'd':
                        value = grid.Cells[Grid.SIZE - 1 - j, i].Value;
                        break;
                }

                if (value != 0)
                {
                    if (newRow.Count > 0 && newRow.Last() == value)
                    {
                        newRow[newRow.Count - 1] *= 2;
                        score += newRow[newRow.Count - 1];
                        newRow.Add(0);
                    }
                    else
                    {
                        newRow.Add(value);
                    }
                }
            }

            // Shift les cellules non-nulles vers la gauche
            int index = 0;
            for (int j = 0; j < newRow.Count; j++)
            {
                if (newRow[j] != 0)
                {
                    switch (direction)
                    {
                        case 'l':
                            grid.Cells[i, index].Value = newRow[j];
                            break;
                        case 'r':
                            grid.Cells[i, Grid.SIZE - 1 - index].Value = newRow[j];
                            break;
                        case 'u':
                            grid.Cells[index, i].Value = newRow[j];
                            break;
                        case 'd':
                            grid.Cells[Grid.SIZE - 1 - index, i].Value = newRow[j];
                            break;
                    }
                    index++;
                }
            }

            // Remplir les cellules restantes avec des zéros
            while (index < Grid.SIZE)
            {
                switch (direction)
                {
                    case 'l':
                        grid.Cells[i, index].Value = 0;
                        break;
                    case 'r':
                        grid.Cells[i, Grid.SIZE - 1 - index].Value = 0;
                        break;
                    case 'u':
                        grid.Cells[index, i].Value = 0;
                        break;
                    case 'd':
                        grid.Cells[Grid.SIZE - 1 - index, i].Value = 0;
                        break;
                }
                index++;
            }
        }
    }

    public void hasWon(Game game)
    {
        for (int row = 0; row < Grid.SIZE; row++)
        {
            for (int col = 0; col < Grid.SIZE; col++)
            {
                if (grid.Cells[row, col].Value == 2048)
                {
                    Console.Clear();
                    Console.WriteLine(game);
                    Console.WriteLine("\n");
                    Console.WriteLine(" .o88b.  .d88b.  d8b   db  d888b  d8888b.  .d8b.  d888888b db    db db       .d8b.  d888888b d888888b  .d88b.  d8b   db .d8888.");
                    Console.WriteLine("d8P  Y8 .8P  Y8. 888o  88 88' Y8b 88  `8D d8' `8b `~~88~~' 88    88 88      d8' `8b `~~88~~'   `88'   .8P  Y8. 888o  88 88'  YP");
                    Console.WriteLine("8P      88    88 88V8o 88 88      88oobY' 88ooo88    88    88    88 88      88ooo88    88       88    88    88 88V8o 88 `8bo.  ");
                    Console.WriteLine("8b      88    88 88 V8o88 88  ooo 88`8b   88~~~88    88    88    88 88      88~~~88    88       88    88    88 88 V8o88   `Y8b.");
                    Console.WriteLine("Y8b  d8 `8b  d8' 88  V888 88. ~8~ 88 `88. 88   88    88    88b  d88 88booo. 88   88    88      .88.   `8b  d8' 88  V888 db   8D");
                    Console.WriteLine(" `Y88P'  `Y88P'  VP   V8P  Y888P  88   YD YP   YP    YP    ~Y8888P' Y88888P YP   YP    YP    Y888888P  `Y88P'  VP   V8P `8888Y'");
                }
            }
        }
    }
}
