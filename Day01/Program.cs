#region Input parsing
string text = File.ReadAllText("input.txt");
string[] data = text.Split(Environment.NewLine);
List<(char Dir, int Offset)> comms = new();
foreach (string line in data)
    comms.Add((line[0], int.Parse(line.Substring(1))));
#endregion

#region Part1
int dial = 50;



// L99
char direction;
int offset;
int r1 = 0;
foreach (string s in data)
{
    direction = s[0];
    offset = int.Parse(s.Substring(1));
    offset = offset % 100;
    switch (direction)
    {
        case 'R':
            dial = (dial + offset) % 100;
            break;
        case 'L':
            dial = (dial + 100 - offset) % 100;
            break;
    }
    if (dial == 0)
        r1++;
}

Console.WriteLine(r1);



#endregion

#region Part2
dial = 50;


int r2 = 0, r = 0;
Console.WriteLine($"Dial starts at {dial}");
foreach (string s in data)
{
    direction = s[0];
    offset = int.Parse(s.Substring(1));
    r = offset / 100;
    offset = offset % 100;
    switch (direction)
    {
        case 'R':
            if(dial + offset >= 100)
                r++;
            dial = (dial + offset) % 100;
            break;
        case 'L':
            if (dial != 0 && dial - offset <= 0)
                r++;
            dial = (dial + 100 - offset) % 100;
            break;
    }
    r2 += r;
    //Console.Write($"Rotation {s} - Dial: {dial} - Zero: {r}");
    //Console.WriteLine();
}

Console.WriteLine(r2);
#endregion