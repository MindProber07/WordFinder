Key Points for Implementation:
Matrix Representation: Store the character matrix in a way that allows efficient row and column lookups. A 2D array or list of strings works well.
Word Search:
Check for words horizontally (row-by-row).
Check for words vertically (column-by-column).
Use a set to ensure words are counted only once.
Optimization:
Use a hash set for the matrix words for constant-time lookups.
Efficiently find and count matches from the word stream.
Output: Return the top 10 most repeated words found in the matrix.

Analysis:
Efficiency:

Matrix Preprocessing: Extracting words horizontally and vertically takes 
O(n×m), where 
n is the number of rows and 
m is the number of columns.
Word Stream Search: Using a hash set for matrix words ensures 
O(1) lookup per word, making it 
O(k) for a stream of 
k words.
Overall time complexity: 
O(n×m+k).
Space Complexity:

Storing matrix words in a hash set requires 
O(n+m) space.
The memory footprint is minimal as we only process words in the stream that match the matrix words.
Scalability:

Works well for the maximum constraints of 64×64 matrix and large word streams due to efficient use of hash sets and grouping.
Enhancements:
Case-insensitive matching can be added by normalizing both matrix words and word stream inputs to lowercase.
Extend to support diagonal word searches if needed.

Why This Approach?
Efficiency: Combines filtering, grouping, and sorting in a highly optimized manner.
Readability: Each step is clear and focused on a specific task.
Scalability: Works efficiently for large word streams and matrix sizes within the problem's constraints.

**Key Features of Implementation**
Matrix Word Extraction:

Horizontal Words: Extracted directly from each row.
Vertical Words: Constructed column-wise from top to bottom.
This ensures both horizontal and vertical possibilities are covered.
=> Substring Matching:
**.Where(word => _matrixWords.Any(matrixWord => matrixWord.Contains(word)))**
For each word in the wordstream, checks if it exists as a substring in any of the pre-extracted words (_matrixWords).
=>Normalization:
Converts the wordstream words to lowercase to ensure case-insensitive matching, ensuring that "Chill" in the stream matches "chill" in the matrix.

=> Efficient Grouping and Sorting:
Groups matched words by occurrence count, sorts by descending frequency, and resolves ties alphabetically:
**.OrderByDescending(x => x.Count).ThenBy(x => x.Word)**

Top 10 Results:
Ensures only the top 10 most frequent matches are returned:
**.Take(10)**

