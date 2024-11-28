public partial class Solution {
                    
    public bool Exist(char[][] board, string word) {
        for(int i=0; i<board.Length; i++){
            for(int j=0; j<board[0].Length; j++){
                if(board[i][j]==word[0]){
                    if(DFS(board, 0, word, i, j)) return true;
                }
            }
        }
        return false;
    }

    public bool DFS(char[][] board, int index, string word, int row, int col){
        // Out of bounds or already visited
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col]=='#') {
            return false;
        }
        // Character mismatch
        if (board[row][col] != word[index]) {
            return false;
        }
        // Found the entire word
        if (index == word.Length - 1) {
            return true;
        }
        var original = board[row][col];

        // Mark the current cell as visited
        board[row][col] = '#';
        // Explore all four directions
        if(DFS(board, index + 1, word, row + 1, col)
                   || DFS(board, index + 1, word, row - 1, col)
                   || DFS(board, index + 1, word, row, col + 1)
                   || DFS(board, index + 1, word, row, col - 1)) return true;

        // Backtrack: unmark the current cell
        board[row][col] = original;
        return false;
    }
    public List<int[]> dirs;               
    public bool ExistWithBackTracking(char[][] board, string word) {
        dirs = new List<int[]>();
        dirs.AddRange(new int[][]{new int[] {0,1}, new int[] {1,0}, new int[] {0,-1}, new int[] {-1,0}});
        for(int i=0; i<board.Length; i++){
            for(int j=0; j<board[0].Length; j++){
                if(board[i][j]==word[0]){
                    var visited = new bool[board.Length][];
                    for(int v= 0; v<visited.Length; v++){
                        visited[v] = new bool[board[0].Length];
                    }
                    visited[i][j] = true;
                    if(backTrack(board, visited, i,j, 1, word)) return true;;
                }
            }
        }
        return false;
    }
    public bool backTrack(char[][] board, bool[][] visited, int i, int j,int curr, string word){
        bool exists = false;
        if(curr==word.Length) return true;
        for(int k=0; k<dirs.Count; k++){
            int row = dirs[k][0]+i;
            int col = dirs[k][1]+j;
            if(row<0 || row>=board.Length || col<0 || col>=board[0].Length || visited[row][col])continue;
            visited[row][col]=true;
            if(board[row][col]==word[curr]){
                if(backTrack(board, visited, row, col, curr+1, word)) return true;
            }
            visited[row][col]=false;
        }
        return exists;
    }
}