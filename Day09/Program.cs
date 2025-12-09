#region Input parsing
string text = File.ReadAllText("input.txt");
string[] t = text.Split(Environment.NewLine);
List<(long x, long y)> points = new();
foreach (string line in t)
{
    string[] t2 = line.Split(',');
    points.Add((
        long.Parse(t2[0]), 
        long.Parse(t2[1])));
}
Console.WriteLine();
#endregion

#region Part1
long r1 = 0;
long area = 0;
for(int i = 0; i < points.Count; i++)
    for(int j = i + 1; j < points.Count; j++)
    {
        area = Area(points[i], points[j]);
        if(area > r1)
            r1 = area;
    }
Console.WriteLine(r1);
long Area((long x, long y) p1, (long x, long y) p2)
{
    long Width = Math.Abs(p1.x - p2.x) + 1;
    long Height = Math.Abs(p1.y - p2.y) + 1;
    return Width * Height;
}
#endregion

#region Part2
#endregion