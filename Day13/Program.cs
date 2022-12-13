string[] Input = File.ReadAllLines("Input.txt");

List<packet> LeftInput = new List<packet>();
List<packet> RightInput = new List<packet>();
List<int> correctOrder = new List<int>();
packet decode1 = new packet("[[2]]");
packet decode2 = new packet("[[6]]");


for (int inputCount = 0; inputCount < (Input.Length + 1) / 3; inputCount++)
{
    packet LeftPacket = new packet(Input[inputCount * 3]);
    LeftInput.Add(LeftPacket);
    packet RightPacket = new packet(Input[inputCount * 3 + 1]);
    RightInput.Add(RightPacket);
}

for (int packetCount = 0; packetCount < LeftInput.Count; packetCount++)
{
    if (Compare(LeftInput[packetCount], RightInput[packetCount]) == 1)
    {
        correctOrder.Add(packetCount + 1);
    }
}

Console.WriteLine(correctOrder.Sum());

List<packet> SortPackets = new List<packet>();
SortPackets.AddRange(LeftInput);
SortPackets.AddRange(RightInput);
SortPackets.Add(decode1);
SortPackets.Add(decode2);

//List<packet> SortedPackets = MergeSort(SortPackets);
SortPackets.Sort((l, r) => Compare(r, l));
Console.WriteLine((SortPackets.IndexOf(decode1) + 1) * (SortPackets.IndexOf(decode2) + 1)); 
List<packet> MergeSort(List<packet> sortPackets)
{
  int midPoint = Convert.ToInt32(Math.Floor(sortPackets.Count / 2.0));
    //  List<packet> Lower =MergeSort(sortPackets.)
    return null;
}

int Compare(packet packet1, packet packet2)
{
   if(packet1.ListVal.Count == 0 && packet2.ListVal.Count == 0)
    {
        if( packet1.IntVal < packet2.IntVal)
        {
            return 1;
        }
        else if (packet1.IntVal > packet2.IntVal)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
   else if (packet1.ListVal.Count == 0 || packet2.ListVal.Count == 0)
    {
        if(packet1.ListVal.Count == 0)
        {
            if(packet1.IntVal == -1)
            {
                return 1;
            }
            packet tempPacket = new packet("[" + Convert.ToString(packet1.IntVal) + "]");
            return Compare(tempPacket, packet2);
        }
        else
        {
            if (packet2.IntVal == -1)
            {
                return -1;
            }
            packet tempPacket = new packet("[" + Convert.ToString(packet2.IntVal) + "]");
            return Compare(packet1, tempPacket);
        }
    }
   else
    {
        int max = Math.Min(packet1.ListVal.Count, packet2.ListVal.Count);
        for (int packetCount = 0; packetCount < max; packetCount++)
        {
            if (Compare(packet1.ListVal[packetCount], packet2.ListVal[packetCount]) == -1)
            {
                return -1;
            }
            else if (Compare(packet1.ListVal[packetCount], packet2.ListVal[packetCount]) == 1)
            {
                return 1;
            }
        }
        if (packet1.ListVal.Count > packet2.ListVal.Count)
        {
            return -1;
        }
        else if (packet1.ListVal.Count < packet2.ListVal.Count)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}


public class packet
{
    public packet(string packetInput)
    {
        IntVal = -1;
        ListVal = new List<packet>();
        if (packetInput != "")
        {
            int tryVal;
            if (int.TryParse(packetInput, out tryVal))
            {
                IntVal = Convert.ToInt32(packetInput);
            }
            else
            {
                packetInput = packetInput.Substring(1, packetInput.Length - 2);
                while (packetInput.Length != 0) 
                {
                   
                    if (packetInput[0] == '[')
                    {
                        int checkPos = 0;
                        int bracketCount = 1;
                        do
                        {
                            if (packetInput[++checkPos] == '[')
                            {
                                bracketCount++;
                            }
                            else if (packetInput[checkPos] == ']')
                            {
                                bracketCount--;
                            }

                        } while (bracketCount != 0);

                        packet subPacket = new packet(packetInput.Substring(0, checkPos + 1 ));
                        ListVal.Add(subPacket);
                        if (checkPos + 1 == packetInput.Length)
                        {
                            packetInput = "";
                        }
                        else
                        {
                            packetInput = packetInput.Substring(checkPos + 2);
                        }
                    }
                    else
                    {
                      /*  if (packetInput.Count(l => l == ',') == 0 && ListVal.Count == 0)
                        {
                            IntVal = Convert.ToInt32(packetInput);
                            packetInput = "";
                        }
                        else
                        {*/
                            packet subPacket = new packet(packetInput.Split(',')[0]);
                            ListVal.Add(subPacket);
                            if (packetInput.Count(l => l == ',') == 0)
                            {
                                packetInput = "";
                            }
                            else
                            {
                                packetInput = packetInput.Substring(packetInput.IndexOf(',') + 1);
                            }
                       // }
                    }
                }
            }
        }
    }

    public List<packet> ListVal { get; set; }
    public int IntVal { get; set; }
}