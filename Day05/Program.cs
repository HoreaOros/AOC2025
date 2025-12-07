#region Input parsing
string text = File.ReadAllText("input.txt");
string[] t = text.Split(Environment.NewLine + Environment.NewLine);
List<(long Left, long Right)> intervale = new();
List<long> ids = new();

string[] lines = t[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
foreach (string line in lines)
{
    string[] t2 = line.Split('-');
    intervale.Add(
        (long.Parse(t2[0]), long.Parse(t2[1]))
        );
}

lines = t[1].Split(Environment.NewLine);
foreach (string line in lines)
{
    ids.Add(long.Parse(line));
}
Console.WriteLine();
#endregion

#region Part1
int r1 = 0;
foreach(var id in ids)
{
    foreach(var interval in intervale)
    {
        if(interval.Left <= id && id <= interval.Right)
        {
            r1++;
            break;
        }
    }
}

Console.WriteLine(r1);
#endregion

#region Part2
intervale.Sort((x, y) => x.Left.CompareTo(y.Left));

long r2 = 0;
r2 = intervale[0].Right - intervale[0].Left + 1;
long R = intervale[0].Right;
for(int i = 1; i < intervale.Count; i++)
{
    if (intervale[i].Right <= R)
        continue;

    if(intervale[i].Left > R)
    {
        r2 += intervale[i].Right - intervale[i].Left + 1;
        R = intervale[i].Right;
    }
    else
    {
        r2 += intervale[i].Right - R;
        R = intervale[i].Right;
    }
}
Console.WriteLine(r2);
#endregion