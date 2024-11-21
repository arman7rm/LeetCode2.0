public partial class Solution {
    public IList<string> InvalidTransactions(string[] transactions) {
        var res = new List<string>();
        var map = new Dictionary<string, List<Transaction>>();
        foreach(var t in transactions){
            var transaction = new Transaction(t);
            if(!map.ContainsKey(transaction.name)) map[transaction.name] = new List<Transaction>();
            map[transaction.name].Add(transaction);
        }
        foreach(var account in map){
            var invalidIds = new HashSet<int>();
            for(int i=0;i<account.Value.Count; i++){
                var curr = account.Value[i];
                if(curr.amount>1000){
                    invalidIds.Add(i);
                }
                for(int j=i+1; j<account.Value.Count; j++){
                    var payment = account.Value[j];
                    if(curr.id==payment.id && invalidIds.Contains(i)){
                        invalidIds.Add(j);
                        continue;
                    }
                    if(curr.city!=payment.city && Math.Abs(curr.time-payment.time)<=60){
                        invalidIds.Add(i);
                        invalidIds.Add(j);
                    }
                }
            }
            foreach(var k in invalidIds.ToList()){
                res.Add(account.Value[k].id);
            }
        }
        return res;
    }

    public class Transaction{
        public int time;
        public int amount;
        public string city;
        public string name;
        public string id;

        public Transaction(string t){
            var item = t.Split(',');
            this.name = item[0];
            this.time = Int32.Parse(item[1]);
            this.amount = Int32.Parse(item[2]);
            this.city = item[3];
            this.id = t;
        }
    }
}