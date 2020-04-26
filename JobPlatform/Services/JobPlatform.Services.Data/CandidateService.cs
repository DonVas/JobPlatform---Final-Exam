namespace JobPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPlatform.Data.Common.Repositories;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Services.Mapping;

    public class CandidateService : ICandidateService
    {
        private readonly IDeletableEntityRepository<Candidate> candidateRepository;

        public CandidateService(IDeletableEntityRepository<Candidate> candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }

        public async Task<string> AddCandidate(string cv, string motivationLetter, string userId)
        {
            var candidate = new Candidate(cv, motivationLetter, userId);

            await this.candidateRepository.AddAsync(candidate);
            await this.candidateRepository.SaveChangesAsync();
            return candidate.UserId;
        }

        public T GetCandidateByUserId<T>(string id)
        {
            return this.candidateRepository.All().Where(x => x.UserId == id).To<T>().FirstOrDefault();
        }

        public T GetCandidateById<T>(string id)
        {
            return this.candidateRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }


        public IEnumerable<T> GetAllCandidates<T>()
        {
            return this.candidateRepository.All().To<T>().ToList();
        }
    }
}
