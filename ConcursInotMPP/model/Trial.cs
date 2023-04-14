namespace ConcursInotMPP.model
{
    public class Trial : IHasId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public int Distance { get; set; }

        public Trial(){}
        public Trial(string name, string style, int distance)
        {
            Name = name;
            Style = style;
            Distance = distance;
        }

    }
}
