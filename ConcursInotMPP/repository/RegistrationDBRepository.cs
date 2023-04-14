using System;
using System.Collections.Generic;
using System.Data;
using ConcursInotMPP.model;
using log4net;

namespace ConcursInotMPP.repository
{
    public class RegistrationDBRepository : IRegistrationRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantDbRepository");
        IDictionary<String, string> props;
        
        public RegistrationDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating RegistrationDbRepository ");
            this.props = props;
        }

        public void Add(Registration elem)
        {
            log.InfoFormat("Entering RegistrationDBRepo.Add with value {0}", elem);
            IDbConnection con = DbUtils.getConnection(props);
            
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into registrations (id_participant, id_trial) values (@participantId, @trialId)";
                
                IDbDataParameter paramParticipantId = comm.CreateParameter();
                paramParticipantId.ParameterName = "@participantId";
                paramParticipantId.Value = elem.Participant.Id;
                comm.Parameters.Add(paramParticipantId);
                
                IDbDataParameter paramTrialId = comm.CreateParameter();
                paramTrialId.ParameterName = "@trialId";
                paramTrialId.Value = elem.Trial.Id;
                comm.Parameters.Add(paramTrialId);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No registration added !");
                
            }
        }

        public Registration Delete(Registration elem)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Registration elem)
        {
            throw new NotImplementedException();
        }

        public Registration FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Registration> FilterByParticipant(int participantId)
        {
            throw new NotImplementedException();
        }

        public IList<Registration> FilterByTrial(int trialId)
        {
            log.InfoFormat("Entering RegistrationDBRepo.FIlterByTrial");
            IDbConnection con = DbUtils.getConnection(props);
            
            IList<Registration> registrations = new List<Registration>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from registrations where id_trial=@id_trial";
                IDbDataParameter paramName = comm.CreateParameter();
                paramName.ParameterName = "@id_trial";
                paramName.Value = trialId;
                comm.Parameters.Add(paramName);
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int idPart = dataR.GetInt32(1);
                        int idTrial = dataR.GetInt32(2);
                        
                        Participant participant = new Participant();
                        Trial trial = new Trial();

                        participant.Id = idPart;
                        trial.Id = idTrial;

                        Registration registration = new Registration(participant, trial);
                        registration.Id = id;
                        registrations.Add(registration);
                    }
                }
            }
            log.InfoFormat("Exiting ParticipantDBRepo.FindAll");
            return registrations;
        }
    }
}
