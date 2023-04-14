using ConcursInotMPP.model;

namespace ConcursInotMPP.repository
{
    public interface IParticipantRepository : IRepository<int, Participant>
    {
        Participant FindOneByName(string name);
    }
}