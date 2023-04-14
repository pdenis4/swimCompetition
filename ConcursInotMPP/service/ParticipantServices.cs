using System;
using System.Collections.Generic;
using ConcursInotMPP.model;
using ConcursInotMPP.repository;

namespace ConcursInotMPP.service
{
    public class ParticipantServices
    {
        private RegistrationDBRepository registrationRepository;
        private ParticipantDBRepository participantRepository;
        private TrialDBRepository trialRepository;
        
        public ParticipantServices(RegistrationDBRepository registrationRepository, ParticipantDBRepository participantRepository, TrialDBRepository trialRepository)
        {
            this.registrationRepository = registrationRepository;
            this.participantRepository = participantRepository;
            this.trialRepository = trialRepository;
        }

        public void RegisterParticipant(string name, string email, string age, Trial trial)
        {
            Participant participant = new Participant(name, email, Int32.Parse(age));
            participantRepository.Add(participant);

            Participant partWithId = participantRepository.FindOneByName(name);
            Registration registration = new Registration(partWithId, trial);
            registrationRepository.Add(registration);
        }
        
        public IList<Participant> GetParticipantsByTrial(int trialId) 
        {
            IList<Registration> registrationsWithSpecificTrial = registrationRepository.FilterByTrial(trialId);

            //for every user, check every registration with trial; add if registration has user too
            IList<Participant> participants = new List<Participant>();
            foreach (Registration registration in registrationsWithSpecificTrial) 
            {
                Participant participant = registration.Participant;
                if (!participants.Contains(participant))
                    participants.Add(participant);
            }
            
            return participants;
        }
        
        public IList<Trial> GetTrials() {
            IList<Trial> trials = new List<Trial>();
            foreach (Trial trial in trialRepository.FindAll())
                trials.Add(trial);
            
            return trials;
        }
        
        public IList<Participant> GetParticipants() {
            IList<Participant> participants = new List<Participant>();
            foreach (Participant participant in participantRepository.FindAll())
                participants.Add(participant);
            
            return participants;
        }
    }
}