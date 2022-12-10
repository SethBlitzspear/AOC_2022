string[] Input = File.ReadAllLines("Input.txt");
int ClockCycle = 0;
int X = 1;
int addVall = 0;
//int addPoint = 0;
int signalCount = 0;
bool wait = true;
int[] signalPoints = { 20, 60, 100, 140, 180, 220 };
int horizontalPos = 1;
string horizontalLine = "";

foreach (string line in Input)
{
    do
    {
        if (addVall == 0 && line.Substring(0, 4) != "noop")
        {
            addVall = Convert.ToInt32(line.Split(' ')[1]);
            wait = true;
        }
        if (!wait && addVall != 0)
        {
            //Console.WriteLine("At clock cycle " + ClockCycle + " Adding " + addVall + " to X  making it " + X);
            X += addVall;
            addVall = 0;
        }
        if (wait && addVall != 0)
        {
            wait = false;
        }


        /* if (addVall != 0)
    {

        X += addVall > 0 ? 1 : -1;
        addVall += addVall > 0 ? -1 : 1;
        // Console.WriteLine("At clock cycle " + ClockCycle + " Adding " + addVall + " to X  making it " + X);
       
    }*/
        if (X >= horizontalPos - 1 && X <= horizontalPos +1)
        {
            horizontalLine += "#";
        }
        else
        {
            horizontalLine += ".";
        }
        horizontalPos++;
        if(horizontalPos > 40)
        {
            horizontalPos = 1;
            Console.WriteLine(horizontalLine);
            horizontalLine = "";
        }
        if (signalPoints.Contains(++ClockCycle))
        {

            signalCount += ClockCycle * X;
           // Console.WriteLine("Cycle " + ClockCycle + " X is " + X + " So signal strength " + ClockCycle * X + " not toal is " + signalCount);
        }
    }while(addVall != 0);
}
Console.WriteLine(signalCount.ToString());
