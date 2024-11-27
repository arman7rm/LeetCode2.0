using System;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        var cache  = new LRUCache(2);
        cache.Put(2,1);
        cache.Put(2,2);
        cache.Get(2);
        cache.Put(1,1);
        cache.Put(4,1);
        cache.Get(2);
    }
}
