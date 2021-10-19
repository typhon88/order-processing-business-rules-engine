using BusinessRulesEngine.Models;
using System.Collections.Generic;

namespace BusinessRulesEngine.Interfaces
{
    public interface IMembershipService
    {
        IReadOnlyCollection<Membership> ProcessedMemberships { get; }

        int StartProcessing();

        void AddForProcessing(Membership membership);
    }
}