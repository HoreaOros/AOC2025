#region Input parsing
string text = File.ReadAllText("input.txt");
string[] data = text.Split(Environment.NewLine);
int LIN = data.Length;
int COL = data[0].Length;
int[] dr = {-1, -1, -1, 0, 0, 1, 1, 1 };
int[] dc = { 0, 1, -1, -1, 1, 0, 1, -1 };

char[,] dataC = new char[LIN, COL];
for(int i = 0; i < LIN; i++)
    for(int j = 0;  j < COL; j++)
        dataC[i, j] = data[i][j];
#endregion

#region Part1

Console.WriteLine(Part1());

int Part1()
{
    int r1 = 0;
    for (int i = 0; i < LIN; i++)
        for (int j = 0; j < COL; j++)
        {
            if (data[i][j] == '@')
            {
                int rolls = 0;
                for (int k = 0; k < dr.Length; k++)
                {
                    int nr = i + dr[k];
                    int nc = j + dc[k];
                    if (nr >= 0 && nc >= 0 && nr < LIN && nc < COL)
                        if (data[nr][nc] == '@')
                            rolls++;
                }
                if (rolls < 4)
                    r1++;
            }
        }
    return r1;
}

#endregion

#region Part2
int r2 = 0; 

while(Part2(ref  r2) > 0); 

Console.WriteLine(r2);

int Part2(ref int r2)
{
    int r = 0;
    for (int i = 0; i < LIN; i++)
        for (int j = 0; j < COL; j++)
        {
            if (dataC[i, j] == '@')
            {
                int rolls = 0;
                for (int k = 0; k < dr.Length; k++)
                {
                    int nr = i + dr[k];
                    int nc = j + dc[k];
                    if (nr >= 0 && nc >= 0 && nr < LIN && nc < COL)
                        if (dataC[nr, nc] == '@')
                            rolls++;
                }
                if (rolls < 4)
                {
                    r++;
                    r2++;
                    dataC[i, j] = '.';
                }
            }
        }
    return r;
}

#endregion