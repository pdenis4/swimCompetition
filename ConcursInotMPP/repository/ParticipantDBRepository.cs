using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using ConcursInotMPP.model;
using log4net;

namespace ConcursInotMPP.repository
{
    public class ParticipantDBRepository : IParticipantRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantDbRepository");

        IDictionary<String, string> props;
        public ParticipantDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating ParticipantDbRepository ");
            this.props = props;
        }

        public void Add(Participant elem)
        {
            log.InfoFormat("Entering ParticipantDBRepo.Add with value {0}", elem);
            IDbConnection con = DbUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into participants (name, email, age) values (@name, @email, @age)";
                
                IDbDataParameter paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = elem.Name;
                comm.Parameters.Add(paramName);
                
                IDbDataParameter paramEmail = comm.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = elem.Email;
                comm.Parameters.Add(paramEmail);
                
                IDbDataParameter paramAge = comm.CreateParameter();
                paramAge.ParameterName = "@age";
                paramAge.Value = elem.Age;
                comm.Parameters.Add(paramAge);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new Exception("No participant added !");
                
            }
        }

        public Participant Delete(Participant elem)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Participant elem)
        {
            throw new NotImplementedException();
        }

        public Participant FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> FindAll()
        {
            log.InfoFormat("Entering ParticipantDBRepo.findAll");
            IDbConnection con = DbUtils.getConnection(props);
            
            IList<Participant> participants = new List<Participant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, name, email, age from participants";
                
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string name = dataR.GetString(1);
                        string email = dataR.GetString(2);
                        int age = dataR.GetInt32(3);
                        Participant participant = new Participant(name, email, age);
                        participant.Id = id;
                        participants.Add(participant);
                    }
                }
            }
            
            log.InfoFormat("Exiting ParticipantDBRepo.findAll with value {0}", participants);
            return participants;
        }
        

        public Participant FindOneByName(string name)
        {
            log.InfoFormat("Entering ParticipantDBRepo.findOneByName with value {0}", name);
            IDbConnection con = DbUtils.getConnection(props);
            
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, name, email, age from participants where name=@name";
                IDbDataParameter paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = name;
                comm.Parameters.Add(paramName);
                
                using (IDataReader dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string nameR = dataR.GetString(1);
                        string email = dataR.GetString(2);
                        int age = dataR.GetInt32(3);
                        Participant participant = new Participant(nameR, email, age);
                        participant.Id = id;
                        log.InfoFormat("Exiting ParticipantDBRepo.findOneByName with value {0}", participant);
                        return participant;
                    }
                }
            }
            
            log.InfoFormat("Exiting ParticipantDBRepo.findOneByName with value {0}", null);
            return null;
        }
    }
}
