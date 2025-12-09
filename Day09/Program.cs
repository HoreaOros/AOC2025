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
long r2 = 0L;

List<Line> lines = new();
for (int i = 0; i < points.Count; i++)
    lines.Add(new Line(points[i], points[(i + 1)% points.Count]));

for (int i = 0; i < points.Count; i++)
{
    long localMax = 0L;
    for (int j = i + 1; j < points.Count; j++)
    {
        area = Area(points[i], points[j]);
        if(area > localMax)
        {
            // verificam intersectia dreptunghiului cu toate segmentele

            bool hasIntersection = false;
            for (int lidx = 0; lidx < lines.Count && !hasIntersection; lidx++)
                hasIntersection |= Intersects(lines[lidx].A, lines[lidx].B, points[i], points[j]);
            localMax = hasIntersection ? localMax : area;
        }
    }
    r2 = Math.Max(localMax, r2);
}


// verifica daca cele doua dreptunghiuri se intersecteaza
bool Intersects((long x, long y) l1a, (long x, long y) l1b, (long x, long y) l2a, (long x, long y) l2b)
{
    var (l1mix, l1max) = MinMax(l1a.x, l1b.x);
    var (l1miy, l1may) = MinMax(l1a.y, l1b.y);

    var (l2mix, l2max) = MinMax(l2a.x, l2b.x);
    var (l2miy, l2may) = MinMax(l2a.y, l2b.y);

    return l2max > l1mix && l2mix < l1max && l2may > l1miy && l2miy < l1may;
}

(long min, long max) MinMax(long a, long b) => a < b ? (a, b) : (b, a);

Console.WriteLine(r2);
record struct Line((long x, long y) A, (long x, long y) B);
#endregion