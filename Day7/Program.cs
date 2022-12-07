
internal class Program
{
    private static void Main(string[] args)
    {
        string[] Input = File.ReadAllLines("Input.txt");
        List<string> InputList = new List<string>(Input);
        InputList.RemoveAt(0);
        Folder Base = new Folder(InputList);
    }
}

public class FileStructureItem
{

}

public class Folder : FileStructureItem
{
    List<FileStructureItem> items;

    public Folder(List<string> inputList)
    {
       while (inputList.Count > 0)
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
                    string directory = 
                }
            }
            else if(item)
        }
    }

    public List<FileStructureItem> Items { get => items; set => items = value; }
}

public class FolderFile : FileStructureItem
{
    string name;
    int size;

    public string Name { get => name; set => name = value; }
    public int Size { get => size; set => size = value; }

    public FolderFile(string item)
    {
        Name = item.Split(' ')[1];
        Size = Convert.ToInt32(item.Split(' ')[0]);
    }
}