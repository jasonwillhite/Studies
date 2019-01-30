namespace Tutorial.NHibernate.Core.Domain
{
    public class Leave : Benefit
    {
        public LeaveType Type { get; set; }
        public int AvailableEntitlement { get; set; }
        public int RemainingEntitlement { get; set; }
    }
}
