// Time Based Key-Value Store
// Design a time-based key-value data structure that can store multiple values for the same key at different time stamps and retrieve the key's value at a certain timestamp.

// Implement the TimeMap class:

// TimeMap() Initializes the object of the data structure.
// void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
// String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp. If there are multiple such values, it returns the value associated with the largest timestamp_prev. If there are no values, it returns "".
 

// Example 1:

// Input
// ["TimeMap", "set", "get", "get", "set", "get", "get"]
// [[], ["foo", "bar", 1], ["foo", 1], ["foo", 3], ["foo", "bar2", 4], ["foo", 4], ["foo", 5]]
// Output
// [null, null, "bar", "bar", null, "bar2", "bar2"]

// Explanation
// TimeMap timeMap = new TimeMap();
// timeMap.set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
// timeMap.get("foo", 1);         // return "bar"
// timeMap.get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
// timeMap.set("foo", "bar2", 4); // store the key "foo" and value "bar2" along with timestamp = 4.
// timeMap.get("foo", 4);         // return "bar2"
// timeMap.get("foo", 5);         // return "bar2"
 

// Constraints:

// 1 <= key.length, value.length <= 100
// key and value consist of lowercase English letters and digits.
// 1 <= timestamp <= 107
// All the timestamps timestamp of set are strictly increasing.
// At most 2 * 105 calls will be made to set and get.
public class TimeMap {
    Dictionary<string, List<int>> timeStamps;
    Dictionary<string, Dictionary<int, string>> store;

    public TimeMap() {
        this.timeStamps = new Dictionary<string, List<int>>();
        this.store = new Dictionary<string, Dictionary<int, string>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if(!timeStamps.ContainsKey(key)) timeStamps[key] = new List<int>();
        timeStamps[key].Add(timestamp);
        if(!store.ContainsKey(key)) store[key] = new Dictionary<int, string>();
        store[key][timestamp] = value;
    }
    
    public string Get(string key, int timestamp) {
        if(!store.ContainsKey(key)) return "";
        int correctTime = findTimeStamp(timeStamps[key], timestamp, 0, timeStamps[key].Count-1);
        if(correctTime==-1)return "";
        return store[key][correctTime];
    }

    public int findTimeStamp(List<int> nums, int target, int l, int r){
        if (l > r) {
            if (r < 0) return -1;
            return nums[r];
        }
        int m = l + (r - l) / 2;
        if(nums[m]==target) return nums[m];
        if(nums[m]>target) return findTimeStamp(nums, target, l, m-1);
        if(m==nums.Count-1 || nums[m]<target && nums[m+1]>target) return nums[m];
        return findTimeStamp(nums, target, m+1, r);
    }
}
