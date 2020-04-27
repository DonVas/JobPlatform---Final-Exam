using System.Collections.Generic;
using System.Threading.Tasks;
using JobPlatform.Services.Mapping;

namespace JobPlatform.Services.Data
{
    using System;
    using System.Linq;

    using JobPlatform.Data.Common.Repositories;
    using JobPlatform.Data.Models;
    using JobPlatform.Data.Models.Enums;
    using JobPlatform.Services.Data.Interfaces;

    public class JobService : IJobService
    {
        private readonly IDeletableEntityRepository<Job> jobRepository;
        private readonly IDeletableEntityRepository<Company> companyRepository;
        private readonly IDeletableEntityRepository<Candidate> candidateRepository;
        private readonly IRepository<JobCandidate> jobCRepository;

        public JobService(
            IDeletableEntityRepository<Job> jobRepository,
            IDeletableEntityRepository<Company> companyRepository,
            IDeletableEntityRepository<Candidate> candidateRepository,
            IRepository<JobCandidate> jobCRepository)
        {
            this.jobRepository = jobRepository;
            this.companyRepository = companyRepository;
            this.candidateRepository = candidateRepository;
            this.jobCRepository = jobCRepository;
        }

        public async Task AddJob(
            string companyId,
            string companyEmail,
            string jobTitle,
            string jobCategory,
            string locationCity,
            string jobType,
            string description)
        {
            var company = this.companyRepository.All().FirstOrDefault(x => x.Id == companyId);

            if (company == null)
            {
                return;
            }

            var job = new Job()
            {
            CompanyId = companyId,
            CompanyEmail = companyEmail,
            JobType = Enum.Parse<JobType>(jobType),
            JobCategory = Enum.Parse<JobCategory>(jobCategory),
            LocationCity = Enum.Parse<LocationCity>(locationCity),
            JobTitle = jobTitle,
            Description = description,
            };

            await this.jobRepository.AddAsync(job);
            await this.jobRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllJobs<T>()
        {
            return this.jobRepository.All().To<T>().ToList();
        }

        public async Task<bool> DeleteJobById(string id)
        {
            var job = this.jobRepository.All().FirstOrDefault(x => x.Id == id);
            if (job == null)
            {
                return false;
            }

            this.jobRepository.Delete(job);
            await this.jobRepository.SaveChangesAsync();

            return true;
        }

        public T GetJobById<T>(string id)
        {
            return this.jobRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }

        public async Task EditJob(
            string jobId,
            string companyEmail,
            string jobTitle,
            string jobCategory,
            string locationCity,
            string jobType,
            string description)
        {
            var job = this.jobRepository.All().FirstOrDefault(x => x.Id == jobId);

            if (job == null)
            {
                return;
            }

            job.CompanyEmail = companyEmail;
            job.JobType = Enum.Parse<JobType>(jobType);
            job.JobCategory = Enum.Parse<JobCategory>(jobCategory);
            job.LocationCity = Enum.Parse<LocationCity>(locationCity);
            job.JobTitle = jobTitle;
            job.Description = description;

            this.jobRepository.Update(job);
            await this.jobRepository.SaveChangesAsync();
        }

        public async Task<bool> AddCandidate(string jobId, string userId, string cv, string motivationLetter)
        {
            var job = this.jobRepository.All().FirstOrDefault(x => x.Id == jobId);
            var candidate = new Candidate(cv, motivationLetter, userId);
            await this.candidateRepository.AddAsync(candidate);

            if (job != null)
            {
                var jobCandidate = new JobCandidate() { CandidateId = candidate.Id, JobId = job.Id };
                await this.jobCRepository.AddAsync(jobCandidate);
                await this.jobCRepository.SaveChangesAsync();
                job.Candidates.Add(jobCandidate);
                this.jobRepository.Update(job);
                await this.jobRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
