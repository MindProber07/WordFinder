// Driver program:
//
using WordFinderConsoleApp.Business;

IEnumerable<string> matrix = new[]
{
    "abcdc",
    "fgwio",
    "chill",
    "pqnsd",
    "uvdxy"
};

IEnumerable<string> wordstream = new[]
{
    "chill", "cold", "wind"
};

IWordFinder wordFinder = new WordFinder(matrix);
var result = wordFinder.Find(wordstream);

Console.WriteLine("Top Found Words:");
foreach (var word in result)
{
    Console.WriteLine(word);
}

Console.ReadKey();