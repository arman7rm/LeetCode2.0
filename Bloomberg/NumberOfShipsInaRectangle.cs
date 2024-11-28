/**
 * // This is Sea's API interface.
 * // You should not implement it, or speculate about its implementation
 * class Sea {
 *     public bool HasShips(int[] topRight, int[] bottomLeft);
 * }
 */
public partial class Solution {
    public int CountShips(Sea sea, int[] topRight, int[] bottomLeft) {
        if(bottomLeft[0]>topRight[0] || bottomLeft[1]>topRight[1]) return 0;
        if (!sea.HasShips(topRight, bottomLeft))return 0;
        if(bottomLeft[0]==topRight[0] && bottomLeft[1]==topRight[1]) return 1;
        
        int midX = bottomLeft[0]+ (topRight[0] - bottomLeft[0])/2;
        int midY = bottomLeft[1]+ (topRight[1] - bottomLeft[1])/2;
        int ships = 0;
        
        ships += CountShips(sea, new int[] { midX, midY }, bottomLeft); // Bottom-left quadrant
        ships += CountShips(sea, new int[] { midX, topRight[1] }, new int[] { bottomLeft[0], midY + 1 }); // Top-left quadrant
        ships += CountShips(sea, topRight, new int[] { midX + 1, midY + 1 }); // Top-right quadrant
        ships += CountShips(sea, new int[] { topRight[0], midY }, new int[] { midX + 1, bottomLeft[1] }); // Bottom-right quadrant
        
        return ships;
    }
}
public class Sea{
    public bool HasShips(int[] a, int[] b){
        return true;
    }
}