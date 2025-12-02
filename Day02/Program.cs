#region Input parsing


string text = File.ReadAllText("input.txt");
string[] data = text.Split(',');
List<(long Left, long Right)> intervale = new();

foreach (var item in data)
{
    string[] t = item.Split("-");
    intervale.Add((long.Parse(t[0]), long.Parse(t[1])));
}
#endregion

#region Part1
long r1 = 0;
foreach(var interval in intervale)
{
    for(long nr = interval.Left; nr <= interval.Right; nr++)
    {
        //if (InvalidIDStr(nr))
        //    r1 += nr;
        if(InvalidIDNum(nr))
                r1 += nr;
    }
}

bool InvalidIDNum(long nr)
{
    //int digits = (int)(Math.Abs(Math.Log10(nr))) + 1;
    int digits = Digits(nr);
    if (digits % 2 == 1)
        return false;
    // 1212
    long p10 = (long)Math.Pow(10, digits / 2);
    return nr / p10 == nr % p10;
}

int Digits(long nr)
{
    int cnt = 0;
    if(nr == 0) return 0;
    while(nr > 0)
    {
        nr /= 10;
        cnt++;
    }
    return cnt;
}

bool InvalidIDStr(long nr)
{
    string num = nr.ToString();
    if(num.Length % 2 == 1)
        return false;
    return num.Substring(0, num.Length / 2) == num.Substring(num.Length / 2);
}

Console.WriteLine(r1);
#endregion

#region Part2
long r2 = 0;
foreach(var interval in intervale)
{
    for (long nr = interval.Left; nr <= interval.Right; nr++)
    {
        //if (InvalidIDStr2(nr))
        //    r2 += nr;
        if (InvalidIDNum2(nr))
            r2 += nr;
    }
}

bool InvalidIDNum2(long nr)
{
    int digits = Digits(nr);
    long c = nr;
    for (int len = 1; len <= digits / 2; len++)
    {
        nr = c;
        if (digits % len != 0)
            continue;
        List<long> t = new();
        long p10 = (long)Math.Pow(10, len);
        while(nr > 0)
        {
            t.Add(nr % p10);
            nr = nr / p10;
        }

        HashSet<long> s = new HashSet<long>(t);
        if (s.Count == 1)
            return true;
    }
    return false;
}

// 464446// 1, 2, 3


bool InvalidIDStr2(long nr)
{
    string num = nr.ToString();
    for (int len = 1; len <= num.Length / 2; len++)
    {
        if (num.Length % len != 0)
            continue;
        List<string> t = new();
        for(int i = 0; i < num.Length; i += len)
            t.Add(num.Substring(i, len));

        HashSet<string> s = new HashSet<string>(t);
        if (s.Count == 1)
            return true;
    }
    return false;
}

Console.WriteLine(r2);
#endregion