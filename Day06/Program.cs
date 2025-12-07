#region Input parsing
string text = File.ReadAllText("input.txt");
string[] lines = text.Split(Environment.NewLine);
int LIN = lines.Length - 1;
int COL = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
int[,] values = new int[LIN, COL];
for(int i = 0; i < LIN; i++)
{
    string[] t = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
    for(int j = 0; j < COL; j++)
        values[i, j] = int.Parse(t[j]);
}
string[] operators = lines[LIN].Split(' ', StringSplitOptions.RemoveEmptyEntries);
//for part2
string ops = lines[LIN];
#endregion

#region Part1
long r1 = 0;
for(int j = 0; j < COL; j++)
{
    long radd = 0;
    long rmul = 0;
    if (operators[j] == "+")
    {
        for (int i = 0; i < LIN; ++i)
            radd += values[i, j];
    }
    else
    {
        rmul = 1;
        for (int i = 0; i < LIN; ++i)
            rmul *= values[i, j];
    }
    r1 += radd + rmul;
}
Console.WriteLine(r1);
#endregion

#region Part2
long r2 = 0;
long num = 0;
long result = 0;
char op = '+';
for(int j = 0; j < ops.Length; j++)
{
    num = 0;
    for(int i = 0; i < LIN; i++)
    {
        if (lines[i][j] != ' ')
            num = num * 10 + lines[i][j] - '0';
    }

    if (ops[j] == '+')
    {
        op = '+';
        result = 0;
    }
    else if (ops[j] == '*')
    {
        op = '*';
        result = 1;
    }

    if (num != 0)
    {
        if (op == '+')
            result += num;
        else if (op == '*')
            result *= num;
    }
    else
        r2 += result;
}
r2 += result; // ultimul numar trebuie adaugat aici

Console.WriteLine(r2);
#endregion