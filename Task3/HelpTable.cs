namespace Task3
{
    internal class HelpTable
    {
        static string[,] helpTable;

        public static string[,] generateHelpTable(string[] args)
        {
            int N = args.Length;

            helpTable = new string[N + 1, N + 1];

            int j = 1;
            for (int i = 0; i < args.Length; i++)
            {
                helpTable[0, j] = args[i];
                helpTable[j, 0] = args[i];
                j++;
            }

            Dictionary<int, List<int>> dict = TableRules.generateRules(helpTable.GetLength(0));

            for (int i = 1; i < helpTable.GetLength(0); i++)
            {
                for (int k = 1; k < helpTable.GetLength(1); k++)
                {
                    if (i == k)
                    {
                        helpTable[i, k] = "Draw";
                    }
                    else if (dict[i].Contains(k))
                    {
                        helpTable[i, k] = "Lose";
                    }
                    else
                    {
                        helpTable[i, k] = "Win";
                    }
                }
            }

            return helpTable;
        }
    }
}
