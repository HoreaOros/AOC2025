#region Input parsing
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

string text = File.ReadAllText("input.txt");
List<(int V, List<int> Buttons, List<int> Joltages)> machines = new();
List<(List<List<int>> Buttons, List<int> Joltages)> machines2 = new();
string[] data = text.Split(Environment.NewLine);
Regex r = new Regex(@"\[([\.#]+)\](( \((\d+,*)*\))*) \{((\d+,?)+)\}");
foreach (string s in data)
{
    Match result = r.Match(s);
    string m = result.Groups[1].Value;
    string b = result.Groups[2].Value;
    string j = result.Groups[5].Value;
    int v = 0; // V
    for (int i = 0; i < m.Length; i++)
        if (m[i] == '#')
            v += (1 << i);
    
    List<int> lst = new List<int>(); // Buttons
    List<List<int>> lstP2 = new(); // Buttons for part 2
    b = b.Trim();
    string[] t2 = b.Split(' ');

    foreach (string s2 in t2)
    {
        string s3 = s2.Trim('(', ')');
        string[] t3 = s3.Split(',');
        int value = 0;
        List<int> lst3 = new List<int>();
        foreach(var item  in t3)
        {
            int exp = int.Parse(item);
            value += (1 << exp);
            lst3.Add(exp);
        }
        lst.Add(value);
        lstP2.Add(lst3);


    }

    List<int> lst2 = new List<int>(); // joltages
    string[] t4 = j.Split(',');
    foreach (string s4 in t4)
        lst2.Add(int.Parse(s4));
    machines.Add((v, lst, lst2));

    machines2.Add((lstP2, lst2));

}
Console.WriteLine();
#endregion

#region Part1
int r1 = 0;
foreach(var machine in machines)
{
    int len = machine.Buttons.Count;
    int max = 1 << len;
    int minim = int.MaxValue;
    for(int n = 0; n < max; n++)
    {
        int[] pos = new int[len];
        int c = n;
        for(int i = 0; i < len; i++)
        {
            pos[i] = c % 2;
            c = c / 2;
        }
        int value = 0;
        for(int i = 0;i < len; i++)
        {
            if (pos[i] == 1)
            {
                value ^= machine.Buttons[i];
            }
        }
        if(value == machine.V)
        {
            if (minim > Ones(n))
                minim = Ones(n);
        }
    }
    r1 += minim;
}

int Ones(int n)
{
    int r = 0;
    while (n > 0)
    {
        if (n % 2 == 1)
            r++;
        n /= 2;
    }
    return r;
}

Console.WriteLine(r1);
#endregion

#region Part2
/*int r2 = 0;
foreach(var machine in machines2)
{
    int N = machine.Buttons.Count;
    int[] MAX = new int[N];
    for(int i = 0; i < N; i++)
    {
        int minim = int.MaxValue;
        List<int> button = machine.Buttons[i];
        for (int j = 0; j < button.Count; j++)
        {
            if (minim > machine.Joltages[button[j]])
                minim = machine.Joltages[button[j]];
        }
        MAX[i] = minim;
    }

    r2 += BackT(MAX, machine.Buttons, machine.Joltages);
    //Console.WriteLine();
}

int BackT(int[] mAX, List<List<int>> buttons, List<int> joltages)
{
    int[] v = new int[buttons.Count];
    int N = buttons.Count;
    for (int i = 0; i < N; i++)
        v[i] = -1;
    int k = 0;
    int result = int.MaxValue;
    bool ams = false, ev = false;
    while(k >= 0)
    {
        do
        {
            ams = succesor(v, k, mAX);
            if (ams)
                ev = valid(v, k, buttons, joltages);
        } while (ams && !ev);
        if (ams)
        {
            //for(int i = 0; i <= k; i++)
            //    Console.Write($"{v[i]}");
            //Console.WriteLine();
            if (Solutie(v, k, buttons, joltages))
            {
                int pushes = 0;
                for (int i = 0; i <= k; i++)
                    pushes += v[i];
                if (pushes < result)
                    result = pushes;
            }
            else if(k < N - 1)
            {
                k++;
                v[k] = -1;
            }
        }
        else
            k--;
    }
    return result;
}

bool Solutie(int[] v, int k, List<List<int>> buttons, List<int> joltages)
{
    bool result = true;
    int N = joltages.Count;
    int[] t = new int[N];
    for(int i = 0; i <= k; i++)
    {
        List<int> lst = buttons[i];
        for( int j = 0; j < lst.Count; j++)
        {
            t[lst[j]] += v[i];
        }
    }


    for (int i = 0; i < N; i++)
        if (t[i] != joltages[i])
            result = false;

    return result;
}

bool valid(int[] v, int k, List<List<int>> buttons, List<int> joltages)
{
    return true;
}

bool succesor(int[] v, int k, int[] mAX)
{
    bool ams = false;
    if (v[k] < mAX[k])
    {
        ams = true;
        v[k]++;
    }
    return ams;
}


Console.WriteLine(r2);
*/


#endregion