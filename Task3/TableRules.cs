namespace Task3
{
    internal class TableRules
    {
        public static Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();
        public static Dictionary<int, List<int>> generateRules(int length)
        {
            for (int i = 1; i < length; i++)
            {
                int num = i + 1;
                
                for (int j = 0; j < (length - 1) / 2; j++)
                {
                    if (num > length - 1)
                    {
                        num = 1;
                    }
                    if (rules.ContainsKey(i))
                    {
                        rules[i].Add(num);
                    }
                    else
                    {
                        rules.Add(i, new List<int>());
                        rules[i].Add(num);
                    }
                    num++;

                }
            }

            return rules;
        }
    }
}
