namespace WordFinderConsoleApp.Business;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string>? wordstream);
}