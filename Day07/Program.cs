#region Input parsing
string text = File.ReadAllText("input.txt");
string[] data = text.Split(Environment.NewLine);
int start = 0;
for (int i = 0; i < data[0].Length; i++)
    if (data[0][i] == 'S')
    {
        start = i;
        break;
    }
int LIN = data.Length;
int COL = data[0].Length;
int[,] splits = new int[LIN, COL];
#endregion

#region Part1
Console.WriteLine($"{Part1(0, start)}");
int Part1(int line, int col)
{
    if (line == LIN)
        return 0;
    if (col < 0 || col >= COL)
        return 0;
    if (data[line][col] == '^')
    {
        if (splits[line, col] == 0)
        {
            splits[line, col] = 1;
            return 1 + Part1(line, col - 1) + Part1(line, col + 1);
        }
        else
            return 0; 
    }
    else
        return Part1(line + 1, col);
}
#endregion

#region Part2
// Memoization
long[,] timelines = new long[LIN, COL];
Console.WriteLine($"{Part2(0, start)}");

long Part2(int line, int col)
{
    if (line == LIN)
        return 1;
    if (data[line][col] == '^')
    {
        if(timelines[line, col] == 0)
            timelines[line, col] = Part2(line, col - 1) + Part2(line, col + 1);
        return timelines[line, col];
    }
    else
        return Part2(line + 1, col);
}
#endregion