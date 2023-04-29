namespace DemoQA.Core.Utils
{
    public static class DirectoryUtils
    {
        public static void CreateIfNotExist(string pathToDirectory)
        {
            if (!Directory.Exists(pathToDirectory))
            {
                Directory.CreateDirectory(pathToDirectory);
            }
        }

        public static List<string> GetFiles(string pathToDirectory) => Directory.GetFiles(pathToDirectory).ToList();
    }
}
