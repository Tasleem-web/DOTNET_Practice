using ConsoleApp1;
using System.Reflection;

public class FileSystemVisitor
{
    private readonly string _rootPath;
    private readonly Func<string, bool> _filter;

    // Events
    public event EventHandler Start;
    public event EventHandler Finish;
    public event EventHandler<CustomFileSystemEventArgs> FileFound;
    public event EventHandler<CustomFileSystemEventArgs> DirectoryFound;
    public event EventHandler<CustomFileSystemEventArgs> FilteredFileFound;
    public event EventHandler<CustomFileSystemEventArgs> FilteredDirectoryFound;
    public FileSystemVisitor(string rootPath)
    {
        _rootPath = rootPath;
        _filter = null;
    }

    public FileSystemVisitor(string rootPath, Func<string, bool> filter)
    {
        _rootPath = rootPath;
        _filter = filter;
    }

    public IEnumerable<string> GetFilesAndDirectories()
    {
        OnStart();
        foreach (var item in TraverseDirectory(_rootPath))
        {
            yield return item;
        }
        OnFinish();
    }

    private IEnumerable<string> TraverseDirectory(string currentPath)
    {
        try
        {
            var directoryFound = Directory.GetDirectories(currentPath);
        }
        catch (DirectoryNotFoundException DNF)
        {
            throw new DirectoryNotFoundException(currentPath);
        }

        foreach (var directory in Directory.GetDirectories(currentPath))
        {
            var args = new CustomFileSystemEventArgs(directory);
            OnDirectoryFound(args);
            if (args.Abort) yield break;
            if (!args.Exclude)
            {
                yield return directory;
                OnFilteredDirectoryFound(args);
            }

            foreach (var subItem in TraverseDirectory(directory))
            {
                yield return subItem;
            }
        }

        foreach (var file in Directory.GetFiles(currentPath))
        {
            var args = new CustomFileSystemEventArgs(file);
            OnFileFound(args);
            if (args.Abort) yield break;
            if (!args.Exclude)
            {
                yield return file;
                OnFilteredFileFound(args);
            }
        }

    }

    // Event invoke methods
    protected virtual void OnStart() => Start?.Invoke(this, EventArgs.Empty);
    protected virtual void OnFinish() => Finish?.Invoke(this, EventArgs.Empty);
    protected virtual void OnFileFound(CustomFileSystemEventArgs e) => FileFound?.Invoke(this, e);
    protected virtual void OnDirectoryFound(CustomFileSystemEventArgs e) => DirectoryFound?.Invoke(this, e);
    protected virtual void OnFilteredFileFound(CustomFileSystemEventArgs e) => FilteredFileFound?.Invoke(this, e);
    protected virtual void OnFilteredDirectoryFound(CustomFileSystemEventArgs e) => FilteredDirectoryFound?.Invoke(this, e);
}
