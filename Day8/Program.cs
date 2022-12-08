string[] Input = File.ReadAllLines("Input.txt");
int Height = Input.Length;
int Width = Input[0].Length;
bool[,] visible = new bool[Height, Width];
int[,] scenic = new int[Height, Width];

for (int rowCount = 0; rowCount < Height; rowCount++)
{
    int maxHeight = Convert.ToInt32(Input[rowCount][0].ToString());
    int maxHeight2 = Convert.ToInt32(Input[rowCount][Width - 1].ToString());
    visible[rowCount, 0] = true;
    visible[rowCount, Width - 1] = true;
    for (int columnCount = 1; columnCount < Width - 1; columnCount++)
    {
        if (Convert.ToInt32(Input[rowCount][columnCount].ToString()) > maxHeight)
        {
            visible[rowCount, columnCount] = true;
            maxHeight = Convert.ToInt32(Input[rowCount][columnCount].ToString());
        }
        if (Convert.ToInt32(Input[rowCount][Width - 1 - columnCount].ToString()) > maxHeight2)
        {
            visible[rowCount, Width - 1 - columnCount] = true;
            maxHeight2 = Convert.ToInt32(Input[rowCount][Width - 1 - columnCount].ToString());
        }
    }
}
for (int columnCount = 0; columnCount < Width; columnCount++)
{
    int maxHeight = Convert.ToInt32(Input[0][columnCount].ToString());
    int maxHeight2 = Convert.ToInt32(Input[Height - 1][columnCount].ToString());
    visible[0, columnCount] = true;
    visible[Height - 1, columnCount] = true;
    for (int rowCount = 1; rowCount < Height - 1; rowCount++)
    {
        if (Convert.ToInt32(Input[rowCount][columnCount].ToString()) > maxHeight)
        {
            visible[rowCount, columnCount] = true;
            maxHeight = Convert.ToInt32(Input[rowCount][columnCount].ToString());
        }
        if (Convert.ToInt32(Input[Height - 1 - rowCount][columnCount].ToString()) > maxHeight2)
        {
            visible[Height - 1 - rowCount, columnCount] = true;
            maxHeight2 = Convert.ToInt32(Input[Height - 1 - rowCount][columnCount].ToString());
        }
    }
}
int visibleCount = 0;
for (int rowCount = 0; rowCount < Height; rowCount++)
{
    for (int columnCount = 0; columnCount < Width; columnCount++)
    {
        if (visible[rowCount, columnCount])
        {
            visibleCount++;
        }
    }
}
Console.WriteLine(visibleCount);

for (int rowCount = 0; rowCount < Height; rowCount++)
{
    for (int columnCount = 0; columnCount < Width; columnCount++)
    {
        int currentHeight = Convert.ToInt32(Input[rowCount][columnCount].ToString());
        int north = 0;
        int east = 0;
        int south = 0;
        int west = 0;

        int northCounter = rowCount - 1;
        bool goNorth = true;
        while (goNorth)
        {
            if (northCounter < 0)
            {
                goNorth = false;
            }
            else
            {
                if (Convert.ToInt32(Input[northCounter][columnCount].ToString()) <= currentHeight)
                {
                    north++;
                }
                if (Convert.ToInt32(Input[northCounter][columnCount].ToString()) >= currentHeight)
                {
                    goNorth = false;
                }

                northCounter--;
            }
        }

        int eastCounter = columnCount + 1;
        bool goEast = true;
        while (goEast)
        {
            if (eastCounter == Width)
            {
                goEast = false;
            }
            else
            {
                if (Convert.ToInt32(Input[rowCount][eastCounter].ToString()) <= currentHeight)
                {
                    east++;
                }
                if (Convert.ToInt32(Input[rowCount][eastCounter].ToString()) >= currentHeight)
                {
                    goEast = false;
                }

                eastCounter++;
            }
        }

        int southCounter = rowCount + 1;
        bool goSouth = true;
        while (goSouth)
        {
            if (southCounter == Height)
            {
                goSouth = false;
            }
            else
            {
                if (Convert.ToInt32(Input[southCounter][columnCount].ToString()) <= currentHeight)
                {
                    south++;
                }
                if (Convert.ToInt32(Input[southCounter][columnCount].ToString()) >= currentHeight)
                {
                    goSouth = false;
                }

                southCounter++;
            }
        }
        int westCounter = columnCount - 1;
        bool goWest = true;
        while (goWest)
        {
            if (westCounter < 0)
            {
                goWest = false;
            }
            else
            {
                if (Convert.ToInt32(Input[rowCount][westCounter].ToString()) <= currentHeight)
                {
                    west++;
                }
                if (Convert.ToInt32(Input[rowCount][westCounter].ToString()) >= currentHeight)
                {
                    goWest = false;
                }
                westCounter--;
            }
        }
        //Console.WriteLine("Checking " + rowCount + ", " + columnCount + " with NESW of " + north + "/" + east + "/" + south + "/" + west);
        scenic[rowCount, columnCount] = north * south * east * west;
    }
}

int maxScenic = 0;
for (int rowCount = 0; rowCount < Height; rowCount++)
{
    for (int columnCount = 0; columnCount < Width; columnCount++)
    {
        if (maxScenic < scenic[rowCount, columnCount])
        {
            maxScenic = scenic[rowCount, columnCount];
        }
    }
}
Console.WriteLine(maxScenic);
