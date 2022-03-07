using Consent.Api.DB;
using Consent.Api.Dto;
using Consent.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Consent.Api.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IDBRepository _repository;

        public ApiController(ILogger<ApiController> logger, IDBRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //App
        [HttpGet("app")]
        public async Task<IEnumerable<App>> GetApps()
        {
            return await _repository.GetApps();
        }

        [HttpGet("app/{appId}")]
        public async Task<App?> GetApp([FromRoute] int appId)
        {
            return await _repository.GetApp(appId);
        }

        [HttpPut("app")]
        public async Task<int> AddApp([FromBody] App app)
        {
            return await _repository.AddApp(app);
        }

        //Flow
        [HttpGet("flow")]
        public async Task<IEnumerable<Flow>> GetFlows()
        {
            return await _repository.GetFlows();
        }

        [HttpGet("flow/{flowId}")]
        public async Task<Flow?> GetFlow([FromRoute] int flowId)
        {
            return await _repository.GetFlow(flowId);
        }

        [HttpPut("flow")]
        public async Task<int> AddFlow([FromBody] Flow flow)
        {
            return await _repository.AddFlow(flow);
        }


        //Policy
        [HttpGet("policy")]
        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            return await _repository.GetPolicies();
        }

        [HttpGet("policy/{policyId}")]
        public async Task<Policy?> GetPolicy([FromRoute] int policyId)
        {
            return await _repository.GetPolicy(policyId);
        }

        [HttpPut("policy")]
        public async Task<int> AddPolicy([FromBody] Policy policy)
        {
            return await _repository.AddPolicy(policy);
        }

        //AppPolicy
        [HttpGet("apppolicy")]
        public async Task<IEnumerable<AppPolicy>> GetAppPolicies()
        {
            return await _repository.GetAppPolicies();
        }
        
        [HttpGet("apppolicy/{appPolicyId}")]
        public async Task<AppPolicy?> GetAppPolicy([FromRoute] int appPolicyId)
        {
            return await _repository.GetAppPolicy(appPolicyId);
        }

        [HttpPut("apppolicy")]
        public async Task<int> AddAppPolicy([FromBody] AppPolicyDto policy)
        {
            return await _repository.AddAppPolicy(policy);
        }

        //Decision
        [HttpGet("decision")]
        public async Task<IEnumerable<Decision>> GetDecisions()
        {
            return await _repository.GetDecisions();
        }

        [HttpGet("decision/{decisionId}")]
        public async Task<Decision?> GetDecision([FromRoute] int decisionId)
        {
            return await _repository.GetDecision(decisionId);
        }

        [HttpPut("decision")]
        public async Task<int> AddDecision([FromBody] Decision flow)
        {
            return await _repository.AddDecision(flow);
        }
    }
}