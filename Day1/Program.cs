internal class Program
{
    private static void Main(string[] args)
    {
        string[] Input = File.ReadAllLines("Input.txt");

        List<int> CaloriesPerElf= new List<int>();
        int calorieCount = 0;
        foreach (string calorieItem in Input)
        {   
            if(calorieItem == "")
            {
                CaloriesPerElf.Add(calorieCount);
                calorieCount = 0;
            }
            else
            {
                calorieCount += Convert.ToInt32(calorieItem);
            }
        }
        int calorieTotal = 0;
        int calories = CaloriesPerElf.Max();
        Console.WriteLine(CaloriesPerElf.Max());

        calorieTotal += calories;
        CaloriesPerElf.Remove(calories);
        calories = CaloriesPerElf.Max();
        calorieTotal += calories;
        CaloriesPerElf.Remove(calories);
        calories = CaloriesPerElf.Max();
        calorieTotal += calories;
        CaloriesPerElf.Remove(calories);


        Console.WriteLine(calorieTotal);
    }
}