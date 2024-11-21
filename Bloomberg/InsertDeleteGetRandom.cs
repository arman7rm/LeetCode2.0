public partial class Solution
{
    public class RandomizedSet
    {
        Dictionary<int, int> map;
        List<int> list;
        Random ran = new Random();

        public RandomizedSet()
        {
            this.map = new Dictionary<int, int>();
            this.list = new List<int>();
        }

        public bool Insert(int val)
        {
            if (map.ContainsKey(val)) return false;
            map[val] = list.Count;
            list.Add(val);
            return true;
        }

        public bool Remove(int val)
        {
            if (map.ContainsKey(val))
            {
                int i = map[val];
                int last = list[list.Count - 1];
                map[last] = i;
                list[i] = last;
                list.RemoveAt(list.Count - 1);
                map.Remove(val);
                return true;
            }
            return false;
        }

        public int GetRandom()
        {
            return list[ran.Next(0, map.Count)];
        }
    }
}