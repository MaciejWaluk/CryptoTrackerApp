namespace backend.Data
{
    public class Cryptocurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public long circulatingSupply { get; set; }
        public long totalSupply { get; set; }

    }
}
