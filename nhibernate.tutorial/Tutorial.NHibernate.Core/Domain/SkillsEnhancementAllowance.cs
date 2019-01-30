namespace Tutorial.NHibernate.Core.Domain
{
    public class SkillsEnhancementAllowance : Benefit
    {
        public int RemainingEntitlement { get; set; }
        public int Entitlement { get; set; }
    }
}
