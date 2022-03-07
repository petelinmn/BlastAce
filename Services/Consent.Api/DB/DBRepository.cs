using Consent.Api.Dto;
using Consent.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Consent.Api.DB
{
    public class DBRepository : IDBRepository
    {
        private readonly ApplicationContext _context;

        public DBRepository(ApplicationContext context)
        {
            _context = context;
        }

        //App
        public async Task<IEnumerable<App>> GetApps()
        {
            return await _context.Apps.ToListAsync();
        }

        public async Task<App?> GetApp(int app_id)
        {
            return await _context.Apps.FindAsync(app_id);
        }

        public async Task<int> AddApp(App app)
        {
            await _context.Apps.AddAsync(app);
            _context.SaveChanges();

            return app.Id;
        }

        //Flow
        public async Task<IEnumerable<Flow>> GetFlows()
        {
            return await _context.Flows.ToListAsync();
        }

        public async Task<Flow?> GetFlow(int app_id)
        {
            return await _context.Flows.FindAsync(app_id);
        }

        public async Task<int> AddFlow(Flow app)
        {
            await _context.Flows.AddAsync(app);
            _context.SaveChanges();

            return app.Id;
        }

        //Policy
        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task<Policy?> GetPolicy(int app_id)
        {
            return await _context.Policies.FindAsync(app_id);
        }

        public async Task<int> AddPolicy(Policy app)
        {
            await _context.Policies.AddAsync(app);
            _context.SaveChanges();

            return app.Id;
        }

        //AppPolicy
        public async Task<IEnumerable<AppPolicy>> GetAppPolicies()
        {
            return await _context.AppPolicies.ToListAsync();
        }

        public async Task<AppPolicy?> GetAppPolicy(int app_id)
        {
            return await _context.AppPolicies.FindAsync(app_id);
        }

        public async Task<int> AddAppPolicy(AppPolicyDto appPolicyDto)
        {
            var appPolicy = new AppPolicy()
            {
                AppId = appPolicyDto.appId,
                FlowId = appPolicyDto.flowId,
                PolicyId = appPolicyDto.policyId
            };

            await _context.AppPolicies.AddAsync(appPolicy);
            _context.SaveChanges();

            return appPolicy.Id;
        }

        //Decision
        public async Task<IEnumerable<Decision>> GetDecisions()
        {
            return await _context.Decisions.ToListAsync();
        }

        public async Task<Decision?> GetDecision(int app_id)
        {
            return await _context.Decisions.FindAsync(app_id);
        }

        public async Task<int> AddDecision(Decision app)
        {
            await _context.Decisions.AddAsync(app);
            _context.SaveChanges();

            return app.Id;
        }
    }
}
