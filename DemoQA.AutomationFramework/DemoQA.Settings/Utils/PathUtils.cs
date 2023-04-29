namespace DemoQA.Settings.Utils
{
    public static class PathUtils
    {
        public static string Combine(params string[] args) => Path.Combine(args);

        public static string ConfigureBaseDirectoryPath(params string[] pathToCombine)
        {
            var path = new List<string>()
            {
                AppDomain.CurrentDomain.BaseDirectory,
            };

            foreach (var pathItem in pathToCombine)
            {
                var pathChanks = pathItem.Split(new string[] { @"\", "\\", "/" }, StringSplitOptions.TrimEntries);

                foreach (var chank in pathChanks)
                {
                    path.Add(chank);
                }
            }

            return Combine(path.ToArray());
        }
    }
}
