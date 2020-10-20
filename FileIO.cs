using System.IO;

namespace Maeily_Windows
{
    internal class FileIO
    {
        public void WriteJObject(string path, string msg)
        {
            StreamWriter writer = new StreamWriter(path);

            writer.Write(msg);
            writer.Close();
        }

        public void AddDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        public bool CheckFile(string path)
        {
            FileInfo file = new FileInfo(path);

            if (!file.Exists)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}