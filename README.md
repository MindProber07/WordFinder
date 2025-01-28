# Word Finder Console Application

A high-performance console application for efficiently finding words from a word stream within a character matrix. This implementation processes horizontal and vertical words and returns the top 10 most repeated matches.

---

## **Key Features**

### **Matrix Word Extraction**

- **Horizontal Words**: Extracted directly from each row of the matrix.
- **Vertical Words**: Constructed column-wise from top to bottom.
- Ensures that both horizontal and vertical possibilities are covered for accurate word matching.

### **Substring Matching**

- Uses an efficient search algorithm to check if words from the word stream exist as substrings in any of the extracted matrix words:
  ```csharp
  .Where(word => _matrixWords.Any(matrixWord => matrixWord.Contains(word)))
  ```

### **Case-Insensitive Matching**

- Normalizes both the word stream and matrix words to lowercase, ensuring matches like "Chill" correctly find "chill" in the matrix.

### **Efficient Grouping and Sorting**

- Groups matched words by their occurrence count.
- Sorts results:
  1. **By Frequency**: Words with the highest frequency appear first.
  2. **Alphabetically**: Resolves ties using alphabetical order.
  ```csharp
  .OrderByDescending(x => x.Count).ThenBy(x => x.Word)
  ```

### **Top 10 Results**

- Returns only the top 10 most frequent matches:
  ```csharp
  .Take(10)
  ```

---

## **Key Points for Implementation**

### **Matrix Representation**

- The character matrix is stored as a list of strings for efficient row and column lookups.

### **Word Search**

- **Horizontally**: Scans row-by-row for matches.
- **Vertically**: Constructs column-wise words for vertical matching.
- Ensures that each word is counted only once using a set.

### **Optimization**

- Uses a **hash set** for storing matrix words to enable constant-time lookups.
- Processes word streams efficiently with grouping and sorting.

---

## **Analysis**

### **Efficiency**

- **Matrix Preprocessing**:
  - Extracting horizontal and vertical words takes , where  is the number of rows and  is the number of columns.
- **Word Stream Search**:
  - Hash set lookups ensure  complexity per word, resulting in  for a stream of  words.
- **Overall Time Complexity**: .

### **Space Complexity**

- Storing matrix words in a hash set requires  space.
- Minimal memory footprint as only relevant words from the word stream are processed.

### **Scalability**

- Efficient for:
  - Maximum matrix size: .
  - Large word streams.
- Performance remains optimal due to hash-based lookups and streamlined grouping logic.

---

## **Enhancements**

1. **Case-Insensitive Matching**:

   - Normalize both the word stream and matrix words to lowercase for consistent matching.

2. **Diagonal Search** *(Optional)*:

   - Extend functionality to support diagonal word searches if required.

---

## **Why This Approach?**

### **Efficiency**

- Combines filtering, grouping, and sorting in a highly optimized manner, minimizing redundant computations.

### **Readability**

- Each step of the process is modular and focused on a specific task, making the code easy to understand and maintain.

### **Scalability**

- Efficiently handles large word streams and matrix sizes within the problem's constraints.

---

## **How It Works**

1. **Matrix Preprocessing**:

   - Extract horizontal words directly from rows.
   - Extract vertical words by traversing each column.

2. **Word Matching**:

   - For each word in the stream, check if it exists as a substring of any matrix word.

3. **Grouping and Sorting**:

   - Group matched words by their frequency.
   - Sort the groups by descending frequency and resolve ties alphabetically.

4. **Result**:

   - Return the top 10 most frequent matches.

---

## **Example**

### **Input**

Matrix:

```
abcdc
fgwio
chill
pqnsd
uvdxy
```

Word Stream:

```
chill, cold, wind, win, old, india
```

### **Output**

```
Top Found Words:
1.      chill
2.      cold
3.      old
4.      win
5.      wind
```

---

## **How to Run**

1. Clone the repository and navigate to the project directory.
2. Build the project using your preferred IDE or .NET CLI:
   ```bash
   dotnet build
   ```
3. Run the console application:
   ```bash
   dotnet run
   ```

---

Feel free to suggest enhancements or raise issues to improve this implementation further!

