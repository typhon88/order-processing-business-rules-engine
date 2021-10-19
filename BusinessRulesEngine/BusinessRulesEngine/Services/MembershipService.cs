using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessRulesEngine.Services
{
    public class MembershipService : IMembershipService
    {
        Queue<Membership> _memberships = new Queue<Membership>();
        IList<Membership> _processedMemberships = new List<Membership>();
        int _numberOfProcessedMemberships = 0;

        public IReadOnlyCollection<Membership> ProcessedMemberships => _processedMemberships.ToList();

        public void AddForProcessing(Membership membership)
        {
            _memberships.Enqueue(membership);
        }

        bool ProcessNext()
        {
            var membership = _memberships.Dequeue();

            if (membership is not null)
            {
                // TODO Add some processing logic

                _processedMemberships.Add(membership);
                _numberOfProcessedMemberships++;
            }

            return _memberships.Count > 0;
        }

        public int StartProcessing()
        {
            while (ProcessNext())
            {
            }

            return _numberOfProcessedMemberships;
        }
    }
}
