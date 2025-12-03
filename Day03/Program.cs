#region Input parsing
string text = File.ReadAllText("input.txt");
string[] data = text.Split(Environment.NewLine);
#endregion

#region Part1
long r1 = 0;
foreach (string s in data)
{
    int max1 = 0, max2 = 0;
    int j = 0;
    for (int i = 0; i < s.Length - 1; i++)
    {
        int d = s[i] - '0';
        if (d > max1)
        {
            max1 = d;
            j = i;
        }
    }
    for (int i = j + 1; i < s.Length; i++)
    {
        int d = s[i] - '0';
        if (d > max2)
            max2 = d;
    }
    //Console.WriteLine($"{s} {max1 * 10 + max2}");
    r1 += max1 * 10 + max2; 
}
Console.WriteLine(r1);
#endregion

#region Part2
long r2 = 0;
int times = 12;
foreach (string s in data)
{
    long maxJoltage = 0; 
    int j = -1;
    for (int k = 0; k < times; k++)
    { 
        int max = 0; 
        for(int i = j + 1; i < s.Length - (times - k - 1); i++)
        {
            int d = s[i] - '0';
            if (d > max)
            {
                max = d;
                j = i;
            }
        }
        maxJoltage = maxJoltage * 10 + max;
    }
    //Console.WriteLine($"{s} {maxJoltage}");


    r2 += maxJoltage;
}
Console.WriteLine(r2);
#endregion