#region Input parsing
string text = File.ReadAllText("input.txt");
//int CONNS = 10;
int CONNS = 1000;
string[] t = text.Split(Environment.NewLine);
List<(long X, long Y, long Z)> data = new();
foreach (var item in t)
{
    string[] t2 = item.Split(',');
    data.Add((long.Parse(t2[0]), long.Parse(t2[1]), long.Parse(t2[2])));
}
int N = data.Count;
List<(int x, int y, long distance)> lst = new();
for (int i = 0; i < N; i++)
    for (int j = i + 1; j < N; j++)
        lst.Add((i, j, EuclideanDistance(data[i], data[j])));
lst.Sort((x, y) => x.distance.CompareTo(y.distance));
long EuclideanDistance((long X, long Y, long Z) v1, (long X, long Y, long Z) v2)
{
    return (v1.X - v2.X) * (v1.X - v2.X) +
            (v1.Y - v2.Y) * (v1.Y - v2.Y) +
            (v1.Z - v2.Z) * (v1.Z - v2.Z);
}
#endregion

#region Part1
Part1();
void Part1()
{
    int[] links = new int[N];
    for(int i = 0; i < N; i++)
        links[i] = i;
    for(int i = 0; i < CONNS;i++)
    {
        int p1id = lst[i].x;
        int p2id = lst[i].y;

        if (links[p1id] != links[p2id])
        {
            int v = links[p2id];
            for (int k = 0; k < N; k++)
                if (links[k] == v)
                    links[k] = links[p1id];
        }
    }
    int[] f = new int[N];
    for (int i = 0; i < N; i++)
        f[links[i]]++;
    Array.Sort(f, (x, y) => y - x);
    Console.WriteLine(f[0] * f[1] * f[2]);
}

#endregion

#region Part2
Part2();
void Part2()
{
    int[] links = new int[N];
    int circuites = N;
    for (int j = 0; j < N; j++)
        links[j] = j;
    int i = 0, p1id = 0, p2id = 0;
    while(true)
    {
        p1id = lst[i].x;
        p2id = lst[i].y;

        if (links[p1id] != links[p2id])
        {
            circuites--;
            int v = links[p2id];
            for (int k = 0; k < N; k++)
                if (links[k] == v)
                    links[k] = links[p1id];
        }
        if (circuites == 1)
            break;
        i++;
    }
    Console.WriteLine($"{data[p1id].X * data[p2id].X}");
}
#endregion