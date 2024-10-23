class Program
{
    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Please your choice");
            Console.WriteLine("1. View all folder and files");
            Console.WriteLine("2. Enter file name for search...");
            Console.WriteLine("3. Exit.");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter folder path...");
                    string rootPath = Console.ReadLine();
                    ViewAllFolderAndFiles(rootPath);
                    break;

                case 2:
                    Console.WriteLine(@"Please enter folder path... like C:\Users");
                    string rootPath1 = Console.ReadLine();
                    Console.WriteLine("Please enter file name for search...");
                    string fileName = Console.ReadLine();
                    FilterFiles(fileName, rootPath1);
                    break;

                case 3:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void FilterFiles(string fileName, string rootPath)
    {
        if (string.IsNullOrEmpty(fileName)) throw new ArgumentException("File Name should not be empty");
        FileSystemVisitor visitor = new FileSystemVisitor(rootPath, path => path.Contains(fileName));

        // Subscribe to events
        visitor.Start += (s, e) => Console.WriteLine("Search started." + System.Environment.NewLine);
        visitor.Finish += (s, e) => Console.WriteLine("Search finished." + System.Environment.NewLine);
        visitor.FileFound += (s, e) => Console.WriteLine($"File found: {e.Path}" + System.Environment.NewLine);
        visitor.DirectoryFound += (s, e) => Console.WriteLine($"Directory found: {e.Path}" + System.Environment.NewLine);
        visitor.FilteredFileFound += (s, e) => Console.WriteLine($"Filtered file found: {e.Path}" + System.Environment.NewLine);
        visitor.FilteredDirectoryFound += (s, e) => Console.WriteLine($"Filtered directory found: {e.Path}" + System.Environment.NewLine);

        foreach (var item in visitor.GetFilesAndDirectories())
        {
            Console.WriteLine(item);
        }
    }

    static void ViewAllFolderAndFiles(string rootPath)
    {
        FileSystemVisitor visitor = new FileSystemVisitor(rootPath);

        // Subscribe to events
        visitor.Start += (s, e) => Console.WriteLine("Search started.");
        visitor.Finish += (s, e) => Console.WriteLine("Search finished.");
        visitor.FileFound += (s, e) => Console.WriteLine($"File found: {e.Path}");
        visitor.DirectoryFound += (s, e) => Console.WriteLine($"Directory found: {e.Path}");
        visitor.FilteredFileFound += (s, e) => Console.WriteLine($"Filtered file found: {e.Path}");
        visitor.FilteredDirectoryFound += (s, e) => Console.WriteLine($"Filtered directory found: {e.Path}");

        foreach (var item in visitor.GetFilesAndDirectories())
        {
            Console.WriteLine(item);
        }
    }
}
