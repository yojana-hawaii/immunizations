namespace Domain.domain
{
    public class VaccineGroup
    {
        public int VaccineGroupId { get; set; }
        public string VaccineGroupCvx { get; set; }
        public string VaccineGroupName { get; set; }
        public string VaccineGroupDescription { get; set; }
        public DateOnly VisDate { get; set; }
    }
}
