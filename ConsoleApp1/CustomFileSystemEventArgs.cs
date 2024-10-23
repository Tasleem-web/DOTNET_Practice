namespace ConsoleApp1
{
    public class CustomFileSystemEventArgs : EventArgs
    {
        public string Path { get; }
        public bool Abort { get; set; }
        public bool Exclude { get; set; }

        public CustomFileSystemEventArgs(string path)
        {
            Path = path;
        }
    }
}