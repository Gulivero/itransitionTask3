using Task3;

if (args.Length < 3)
{
    Console.WriteLine("Incorrect number of parameters. Must be 3+.");
    return;
}

if (args.Length % 2 == 0)
{
    Console.WriteLine("Incorrect number of parameters. Must be an odd number.");
    return;
}

for (int i = 0; i < args.Length; i++)
{
    for (int j = i + 1; j < args.Length; j++)
    {
        if (args[i] == args[j])
        {
            Console.WriteLine("Incorrect parameters. Must not have the same parameters.");
            return;
        }
    }
}

string[,] helpTable = HelpTable.generateHelpTable(args);
byte[] key = KeyGenerator.generateSecretKey(32);
int computerMoveIndex = KeyGenerator.generateMove(args.Length);
string computerMove = args[computerMoveIndex];
byte[] hmac = KeyGenerator.generateHMAC(key, computerMove);

Console.Write("HMAC: ");
for (int i = 0; i < hmac.Length; i++)
{
    Console.Write(hmac[i].ToString("X2"));
}
Console.WriteLine();

while (true)
{
    string move = string.Empty;
    while (string.IsNullOrWhiteSpace(move))
    {
        Menu(args);
        Console.Write("Enter your move: ");
        move = Console.ReadLine();
    }

    if (move == "0")
    {
        Console.WriteLine("You have closed the program");
        break;
    }
    else if (move == "?")
    {
        Help(helpTable);
        continue;
    }

    if (int.TryParse(move, out int moveInd) && moveInd > 0 && moveInd < args.Length + 1)
    {
        Console.WriteLine($"Your move: {args[moveInd - 1]}");
        Console.WriteLine($"Computer move: {computerMove}");
    }
    else
    {
        continue;
    }

    if (TableRules.rules[moveInd].Contains(computerMoveIndex + 1))
    {
        Console.WriteLine("You lose!");
    }
    else if (moveInd == computerMoveIndex + 1)
    {
        Console.WriteLine("Draw!");
    }
    else
    {
        Console.WriteLine("You win!");
    }

    Console.Write($"HMAC key: ");
    for (int i = 0; i < key.Length; i++)
    {
        Console.Write(key[i].ToString("X2"));
    }
    break;
}

static void Help(string[,] table)
{
    for (int row = 0; row < table.GetLength(0); row++)
    {
        for (int column = 0; column < table.GetLength(1); column++)
        {
            Console.Write("|{0, 10}", table[row, column]);
        }
        Console.WriteLine();
    }
}

static void Menu(string[] args)
{
    Console.WriteLine("Available moves:");

    for (int i = 0; i < args.Length; i++)
    {
        Console.WriteLine($"{i + 1} - {args[i]}");
    }

    Console.WriteLine($"0 - exit \n? - help");
}