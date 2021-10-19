namespace BusinessRulesEngine.Models
{
    public class Membership
    {
        public Membership(MembershipType Type)
        {
            this.Type = Type;
        }

        public MembershipType Type { get; set; }

        public enum MembershipType
        {
            New,
            Upgrade
        }
    }
}
