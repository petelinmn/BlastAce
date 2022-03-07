namespace Consent.Api.Consent
{
    public class ConsentActor
    {
        void Consent()
        {

        }
    }

    public class ConsentRequest
    { 
        public string UserId { get; set; }
        public int AppId { get; set; }
        public int PolicyId { get; set; }
    }
}
