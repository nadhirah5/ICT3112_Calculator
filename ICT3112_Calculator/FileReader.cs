using System.IO;

namespace ICT3112_Calculator
{
    public class FileReader : IFileReader
    {
        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
