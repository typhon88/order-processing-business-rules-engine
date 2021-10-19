using BusinessRulesEngine.Models;
using System.Collections.Generic;

namespace BusinessRulesEngine.Interfaces
{
    public interface IMembershipService
    {
        IReadOnlyCollection<Membership> ProcessedMemberships { get; }

        void StartProcessing();
    }
}