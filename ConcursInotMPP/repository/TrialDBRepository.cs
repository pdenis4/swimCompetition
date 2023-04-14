using System;
using System.Collections.Generic;
using System.Data;
using ConcursInotMPP.model;
using log4net;

namespace ConcursInotMPP.repository
{
    

    public class TrialDBRepository : ITrialRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantDbRepository");
        IDictionary<String, string> props;
        
        public TrialDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating ParticipantDbRepository ");
            this.props = props;
        }

        public void Add(Trial elem)
        {
            throw new NotImplementedException();
        }

        public Trial Delete(Trial elem)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Trial elem)
        {
            throw new NotImplementedException();
        }

        public Trial FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trial> FindAll()
        {
            log.InfoFormat("Entering ParticipantDBRepo.FindAll");
            IDbConnection con = DbUtils.getConnection(props);
            
            IList<Trial> trials = new List<Trial>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from trials";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string name = dataR.GetString(1);
                        string style = dataR.GetString(2);
                        int distance = dataR.GetInt32(3);
                        
                        Trial trial = new Trial(name, style, distance);
                        trial.Id = id;
                        trials.Add(trial);
                    }
                }
            }
            log.InfoFormat("Exiting ParticipantDBRepo.FindAll");
            return trials;
        }
    }
}