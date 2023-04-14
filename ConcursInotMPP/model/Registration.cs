namespace ConcursInotMPP.model
{

    public class Registration : IHasId<int>
    {
        public int Id { get; set; }
        public Participant Participant { get; set; }
        public Trial Trial { get; set; }

        public Registration(Participant participant, Trial trial)
        {
            Participant = participant;
            Trial = trial;
        }

        
    }
}
