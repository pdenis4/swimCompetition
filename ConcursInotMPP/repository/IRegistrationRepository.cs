using System.Collections.Generic;
using ConcursInotMPP.model;

namespace ConcursInotMPP.repository
{
    public interface IRegistrationRepository : IRepository<int, Registration>
    {
        IList<Registration> FilterByParticipant(int participantId);
        IList<Registration> FilterByTrial(int trialId);
    }
}