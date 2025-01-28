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
    "chill", "cold", "wind", "win", "old", "india"
};

IWordFinder wordFinder = new WordFinder(matrix);
var result = wordFinder.Find(wordstream);

var i = 0;
Console.WriteLine("Top Found Words:");
foreach (var word in result)
{
    Console.WriteLine($"{++i}\t{word}");
}

Console.ReadKey();