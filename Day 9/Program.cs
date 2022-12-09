string[] Input = File.ReadAllLines("Input.txt");
int size = 10;
int[] HX = new int[size];
int[] HY = new int[size];

List<string> visited = new List<string>();
visited.Add("0,0");

foreach (string line in Input)
{
    string dir = line.Split(' ')[0];
    int dist = Convert.ToInt32(line.Split(' ')[1]);

    for (int moveCount = 0; moveCount < dist; moveCount++)
    {
        switch(dir)
        {
            case "U":
                HY[0]++;
                moveTail();
                break;
            case "D":
                HY[0]--;
                moveTail();
                break;
            case "R":
                HX[0]++;
                moveTail();
                break;
            case "L":
                HX[0]--;
                moveTail();
                break;
        }
        string tailPos = HX[size - 1] + "," + HY[size - 1];
        if(!visited.Contains(tailPos))
        {
            visited.Add(tailPos);
        }
        else
        {
            int stop = 1;
        }
/*        for (int tailCount = 0; tailCount < size; tailCount++)
        {
            Console.Write(HX[tailCount] + "," + HY[tailCount] + " - ");
        }
        Console.WriteLine();*/
    }
}
Console.WriteLine(visited.Count);
void moveTail()
{
    for (int tailCount = 1; tailCount < size; tailCount++)
    {
        int deltaX = HX[tailCount - 1] - HX[tailCount];
        int deltaY = HY[tailCount - 1] - HY[tailCount];

        if (Math.Abs(deltaY) > 1 && Math.Abs(deltaX) > 1)
        {
            HY[tailCount] += deltaY > 0 ? 1 : -1;
            HX[tailCount] += deltaX > 0 ? 1 : -1;
        }
        else if (Math.Abs(deltaY) > 1)
        {
            HY[tailCount] += deltaY > 0 ? 1 : -1;
            HX[tailCount] = HX[tailCount - 1];
        }
        else if (Math.Abs(deltaX) > 1)
        {
            HX[tailCount] += deltaX > 0 ? 1 : -1;
            HY[tailCount] = HY[tailCount - 1];
        }
    }
}