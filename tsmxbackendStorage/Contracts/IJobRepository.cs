using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Contracts
{
    public interface IJobRepository 
    {
        public Task<IEnumerable<JobLog>> getJob();
        public Task<bool> createJob(JobLog dataJob);
        public Task<IEnumerable<JobLog>> getJobStatus(string status);
      


    }
}
