
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] Input = File.ReadAllLines("Input.txt");
        List<string> InputList = new List<string>(Input);
        InputList.RemoveAt(0);
        Folder Base = new Folder("/");
        Base.FillFolder(InputList);
        Folder.total = 0;
        Console.WriteLine(Base.GetFolderBelow(100000));
        UInt64 target = 70000000 - Base.Size;
        Folder.smallest = Base.Size;
        Console.WriteLine(Base.FindSmallest(30000000 - target));


    }
}

public class FileStructureItem
{
    string name;
    public string Name { get => name; set => name = value; }
}

public class Folder : FileStructureItem
{
    public static UInt64 total;
    public static UInt64 smallest;
    Dictionary<string, FileStructureItem> items;
    public UInt64 Size
    {
        get
        {
            UInt64 size = 0;
            foreach (FileStructureItem item in items.Values)
            {
                if (item is Folder)
                {
                    size += ((Folder)item).Size;
                }
                else
                {
                    size += ((FolderFile)item).Size;
                }

            }
            return size;
        }
    }

    public Folder (string newName)
    {
        Name = newName;
        items = new Dictionary<string, FileStructureItem>();
    }
    public void FillFolder(List<string> inputList)
    {
        bool processFolder = true;
       while (processFolder)
        {
            if (inputList.Count > 0)
            {
                string item = inputList[0];
                inputList.RemoveAt(0);
                if (item[0] == '$')
                {
                    if (item.Substring(2, 2) == "ls")
                    {
                        //do nothign
                    }
                    else
                    {
                        string directory = item.Substring(5, item.Length - 5);
                        if (directory == "..")
                        {
                            processFolder = false;
                        }
                        else
                        {

                            ((Folder)items[directory]).FillFolder(inputList);
                        }
                    }
                }
                else
                {
                    if (item.Substring(0, 3) == "dir")
                    {
                        string directory = item.Substring(4, item.Length - 4);
                        Folder newFolder = new Folder(directory);
                        items.Add(directory, newFolder);

                    }
                    else
                    {

                        FolderFile newFile = new FolderFile(item);
                        items.Add(newFile.Name, newFile);

                    }
                }
            }
            else
            {
                processFolder = false;
            }
        }
    }

    public UInt64 GetFolderBelow(int min)
    {
        if (Size < (UInt64) min)
        {
            Folder.total += Size;
        }
        foreach (FileStructureItem item in items.Values)
        {
            if (item is Folder)
            {
                 ((Folder)item).GetFolderBelow(min);
                
            }
        }
        return total;
    }

    internal UInt64 FindSmallest(ulong target)
    {
        Console.Write("Checking " + Name + " with a size of " + Size);
        if (Size >= (UInt64)target)
        {
            Console.Write(" which is bigger than " + target);
            if(Size <= Folder.smallest)
            {
                Console.Write(" and smaller than " + Folder.smallest);
                Folder.smallest = Size;
            }
            
           
        }
        Console.WriteLine(" So current smallest is " + Folder.smallest);

        foreach (FileStructureItem item in items.Values)
        {
            if (item is Folder)
            {
                ((Folder)item).FindSmallest(target);

            }
        }
        return smallest;
    }
}

public class FolderFile : FileStructureItem
{

    UInt64 size;

    
    public UInt64 Size { get => size; set => size = value; }

    public FolderFile(string item)
    {
        Name = item.Split(' ')[1];
        Size = Convert.ToUInt64(item.Split(' ')[0]);
    }
}