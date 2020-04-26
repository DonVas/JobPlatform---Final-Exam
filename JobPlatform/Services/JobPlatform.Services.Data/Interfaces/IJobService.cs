using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPlatform.Services.Data.Interfaces
{
    public interface IJobService
    {
        Task AddJob(
            string companyId,
            string companyEmail,
            string jobTitle,
            string jobCategory,
            string locationCity,
            string jobType,
            string description);

        Task EditJob(
            string jobId,
            string companyEmail,
            string jobTitle,
            string jobCategory,
            string locationCity,
            string jobType,
            string description);

        IEnumerable<T> GetAllJobs<T>();

        Task<bool> DeleteJobById(string id);

        T GetJobById<T>(string id);

        Task<bool> AddCandidate(string jobId, string userId, string cv, string motivationLetter);
    }
}
