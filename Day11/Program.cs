#region Input parsing
using System.Text.RegularExpressions;

string text = File.ReadAllText("inputTest.txt");
string[] lines = text.Split(Environment.NewLine);
Dictionary<string, List<string>> graph = new();
//foreach (var line in lines)
//{
//    string[] t = line.Split(':');
//    graph[t[0]] = new List<string>();
//    string[] t2 = t[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
//    foreach (string s in t2)
//        graph[t[0]].Add(s);

//}


Regex r = new Regex(@"[a-z]{3}");
foreach (string line in lines)
{
    MatchCollection mc = r.Matches(line);
    List<string> value = new();
    graph[mc[0].Value] = value;
    for (int i = 1; i < mc.Count; i++)
        graph[mc[0].Value].Add(mc[i].Value);
}

Console.WriteLine();
StreamWriter sw = new StreamWriter("graph.txt");
foreach(var item in graph.Keys)
{
    foreach(var item2 in graph[item])
        sw.WriteLine($"{item} {item2}");
}
sw.Close();
#endregion

#region Part1
string start = "you";
//Console.WriteLine($"{Part1(start)}");

int Part1(string start)
{
    if (start == "out")
        return 1;
    int result = 0;
    foreach (var item in graph[start])
        result += Part1(item);
    return result;
}
#endregion

#region Part2
start = "svr";
Dictionary<string, int> memo = new();
//Console.WriteLine($"{Part2(start, false, false)}");

List<List<string>> paths = new();
List<string> path = new();
Part2v2(start, path);
Console.WriteLine();



void Part2v2(string start, List<string> path)
{
    path.Add(start);
    if (start == "out")
    {
        paths.Add(path);
        return;
    }
    foreach (var item in graph[start])
    {
        Part2v2(item, new List<string>(path));
    }
}

int Part2(string start, bool fft, bool dac)
{
    if (start == "out")
        if(fft && dac)
            return 1;
        else
            return 0;
    if (start == "fft")
        fft = true;
    if (start == "dac")
        dac = true;
    int result = 0;
    if (!memo.ContainsKey(start))
    {
        foreach (var item in graph[start])
            result += Part2(item, fft, dac);
        memo[start] = result; 
    }    

    return memo[start];
}
#endregion