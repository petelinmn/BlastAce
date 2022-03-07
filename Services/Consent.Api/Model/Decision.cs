namespace Consent.Api.Model
{
    public class Decision
    {
        public int Id { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
        //public List<PolicySign> PolicySigns { get; set; }
    }

    /*public class PolicySign
    {
        public int Id { get; set; }
        public Decision Decision { get; set; }
        public string FieldType { get; set; }
        public string FieldName { get; set; }
    }*/
}
