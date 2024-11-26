public partial class Solution
{
    public int NumIslands(char[][] grid)
    {
        int count = 0;
        var dirs = new List<int[]>
        {
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 }
        };
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    var q = new Queue<int[]>();
                    q.Enqueue([i, j]);
                    grid[i][j] = '0';
                    while (q.Count > 0)
                    {
                        var curr = q.Dequeue();
                        foreach (var dir in dirs)
                        {
                            int row = curr[0] + dir[0];
                            int col = curr[1] + dir[1];
                            if (row >= 0 && row < grid.Length && col >= 0 && col < grid[0].Length)
                            {
                                if (grid[row][col] == '1')
                                {
                                    grid[row][col] = '0';
                                    q.Enqueue([row, col]);
                                }
                            }
                        }
                    }
                    count++;
                }
            }
        }
        return count;
    }

    public int NumIslands2(char[][] grid) {
        int count = 0;
        for(int i=0; i<grid.Length; i++){
            for(int j=0; j<grid[0].Length; j++){
                if(grid[i][j]=='1'){
                    DFS(grid, i,j);
                    count++;
                }
            }
        }
        return count;
    }
    public void DFS( char[][] grid,int i, int j){
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0') return;
        grid[i][j] = '0'; 
        DFS(grid, i + 1, j); 
        DFS(grid, i - 1, j); 
        DFS(grid, i, j + 1); 
        DFS(grid, i, j - 1);
    }
}