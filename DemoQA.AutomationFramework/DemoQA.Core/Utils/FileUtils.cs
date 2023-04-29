namespace DemoQA.Core.Utils
{
    public static class FileUtils
    {
        public static bool Exists(string pathToFile) => File.Exists(pathToFile);

        public static void RemoveAll(string pathToDirectory) =>
            DirectoryUtils.GetFiles(pathToDirectory).ForEach(file => File.Delete(file));
    }
}
