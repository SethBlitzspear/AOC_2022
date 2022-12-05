// See https://aka.ms/new-console-template for more information
string[] Input = File.ReadAllLines("Input.txt");

int problemCount = 0;

foreach (string line in Input)
{
    string elf1 = line.Split(',')[0];
    string elf2 = line.Split(',')[1];

    int elf1Start = Convert.ToInt32(elf1.Split('-')[0]);
    int elf1End = Convert.ToInt32(elf1.Split('-')[1]);
    int elf2Start = Convert.ToInt32(elf2.Split('-')[0]);
    int elf2End = Convert.ToInt32(elf2.Split('-')[1]);

    if ( elf1End >=elf2Start && elf1Start <= elf2End)
    {
        problemCount++;
    }
    else if(elf2End >= elf1Start && elf2Start <= elf1End)
    {
        problemCount++;
    }
}
Console.WriteLine(problemCount);
