namespace WordFinderConsoleApp.Business;

public class WordFinder : IWordFinder
{
    private readonly HashSet<string> _matrixWords;

    public WordFinder(IEnumerable<string> matrix)
    {
        // Precompute words horizontally and vertically
        // Extract horizontal and vertical words, normalize to lowercase for case-insensitive matching
        //_matrixWords = new HashSet<string>(
        //    ExtractMatrixWords(matrix).Select(word => word.ToLower())
        //);
        _matrixWords = new HashSet<string>(ExtractMatrixWords(matrix));
    }

    public IEnumerable<string> Find(IEnumerable<string>? wordstream)
    {
        if (wordstream == null || !_matrixWords.Any())
            return [];

        // Count occurrences of words in the stream
        var wordCounts = wordstream
            .Select(word => word.ToLower()) // Normalize the wordstream to lowercase for case-insensitive matching
            .Where(word => _matrixWords.Any(matrixWord => matrixWord.Contains(word))) // Check if the word is a substring
            .GroupBy(word => word)
            .Select(group => new { Word = group.Key, Count = group.Count() })
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Word)
            .Take(10) // Top 10
            .Select(x => x.Word);

        return wordCounts;
    }

    private IEnumerable<string> ExtractMatrixWords(IEnumerable<string> matrix)
    {
        string[] rows = matrix.ToArray();
        int numRows = rows.Length;
        int numCols = rows[0].Length;

        // Extract horizontal words (rows)
        foreach (var row in rows)
        {
            yield return row;
        }

        // Extract vertical words (columns)
        for (int col = 0; col < numCols; col++)
        {
            char[] verticalWord = new char[numRows];
            for (int row = 0; row < numRows; row++)
            {
                verticalWord[row] = rows[row][col];
            }
            yield return new string(verticalWord);
        }
    }
}
