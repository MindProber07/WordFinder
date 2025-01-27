namespace WordFinderConsoleApp.Business;

public class WordFinder : IWordFinder
{
    // Stores all precomputed words from the matrix (both horizontal and vertical)
    private readonly HashSet<string> _matrixWords;

    // Constructor that accepts the matrix and precomputes all words
    public WordFinder(IEnumerable<string> matrix)
    {
        // Precompute words horizontally and vertically
        // Extract horizontal and vertical words, normalize to lowercase for case-insensitive matching
        //_matrixWords = new HashSet<string>(
        //    ExtractMatrixWords(matrix).Select(word => word.ToLower())
        //);
        _matrixWords = new HashSet<string>(ExtractMatrixWords(matrix));
    }

    // Finds the top 10 most frequent words in the wordstream that are substrings of the matrix words
    public IEnumerable<string> Find(IEnumerable<string>? wordstream)
    {
        // Return an empty list if the wordstream is null or if the matrix contains no words
        if (wordstream == null || !_matrixWords.Any())
            return [];

        // Process the wordstream to count occurrences of valid words
        var wordCounts = wordstream
            .Select(word => word.ToLower()) // Normalize each word in the stream to lowercase for case-insensitive matching
            .Where(word => _matrixWords.Any(matrixWord => matrixWord.Contains(word))) // Check if the word is a substring of any matrix word
            .GroupBy(word => word) // Group the words to count occurrences
            .Select(group => new { Word = group.Key, Count = group.Count() }) // Create an object for each word with its count
            .OrderByDescending(x => x.Count) // Sort by count in descending order (most frequent words first)
            .ThenBy(x => x.Word) // If counts are equal, sort alphabetically
            .Take(10) // Take the top 10 words
            .Select(x => x.Word); // Extract just the words from the result

        return wordCounts; // Return the list of top words
    }

    // Helper method to extract all horizontal and vertical words from the matrix
    private IEnumerable<string> ExtractMatrixWords(IEnumerable<string> matrix)
    {
        // Convert the matrix to an array for easier access
        string[] rows = matrix.ToArray();
        int numRows = rows.Length;
        int numCols = rows[0].Length; // Assume all rows have the same number of columns

        // Extract horizontal words (each row as-is)
        foreach (var row in rows)
        {
            yield return row; // Return the row as a word
        }

        // Extract vertical words (construct words column by column)
        for (int col = 0; col < numCols; col++)
        {
            char[] verticalWord = new char[numRows];
            for (int row = 0; row < numRows; row++)
            {
                // Collect characters from the same column across all rows
                verticalWord[row] = rows[row][col];
            }
            yield return new string(verticalWord); // Return the constructed vertical word
        }
    }
}
