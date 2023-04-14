using System;
using System.Collections.Generic;
using ConcursInotMPP.model;
using log4net;

namespace ConcursInotMPP.repository
{

    public class UserDBRepository : IUserRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantDbRepository");
        IDictionary<String, string> props;
        
        public UserDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating ParticipantDbRepository ");
            this.props = props;
        }

        public void Add(User elem)
        {
            throw new NotImplementedException();
        }

        public User Delete(User elem)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User elem)
        {
            throw new NotImplementedException();
        }

        public User FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}