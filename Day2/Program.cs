internal class Program
{
    private static void Main(string[] args)
    {
        string[] Input = File.ReadAllLines("Input.txt");

        int totalScore = 0;
        foreach (string game in Input)
        {
            switch(game[2])
            {
                case 'X':
                    totalScore += 1;
                    switch(game[0])
                    {
                        case 'A':
                            totalScore += 3;
                            break;
                        case 'B':
                            totalScore += 0;
                            break;
                        case 'C':
                            totalScore += 6;
                            break;
                    }
                    break;
                case 'Y':
                    totalScore += 2;
                    switch (game[0])
                    {
                        case 'A':
                            totalScore += 6;
                            break;
                        case 'B':
                            totalScore += 3;
                            break;
                        case 'C':
                            totalScore += 0;
                            break;
                    }
                    break;
                case 'Z':
                    totalScore += 3;
                    switch (game[0])
                    {
                        case 'A':
                            totalScore += 0;
                            break;
                        case 'B':
                            totalScore += 6;
                            break;
                        case 'C':
                            totalScore += 3;
                            break;
                    }
                    break;
            }

        }
        Console.WriteLine(totalScore);

        totalScore = 0;

        foreach (string game in Input)
        {
            switch (game[2])
            {
                case 'X':
                    totalScore += 0;
                    switch (game[0])
                    {
                        case 'A':
                            totalScore += 3;
                            break;
                        case 'B':
                            totalScore += 1;
                            break;
                        case 'C':
                            totalScore += 2;
                            break;
                    }
                    break;
                case 'Y':
                    totalScore += 3;
                    switch (game[0])
                    {
                        case 'A':
                            totalScore += 1;
                            break;
                        case 'B':
                            totalScore += 2;
                            break;
                        case 'C':
                            totalScore += 3;
                            break;
                    }
                    break;
                case 'Z':
                    totalScore += 6;
                    switch (game[0])
                    {
                        case 'A':
                            totalScore += 2;
                            break;
                        case 'B':
                            totalScore += 3;
                            break;
                        case 'C':
                            totalScore += 1;
                            break;
                    }
                    break;

            }
        }
        Console.WriteLine(totalScore);
    }
}