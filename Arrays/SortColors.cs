// Sort colors

// Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

// You must solve this problem without using the library's sort function.


public partial class Solution {
    public void SortColors(int[] nums) {
        int s=0, e=nums.Length-1, i=0;
        while(i<=e){
            if(nums[i]==0){
                nums[i++] = nums[s];
                nums[s++] = 0;
            }
            else if(nums[i]==2){
                nums[i] = nums[e];
                nums[e--] = 2;
            }else{
                i++;
            }
        }
    }
}