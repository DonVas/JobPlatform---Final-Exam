using AutoMapper;

namespace JobPlatform.Web.ViewModels.Candidates
{
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class CandidateApplyInputModel : IMapFrom<Candidate>
    {
        [Required]
        public string Cv { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public string UserPhone { get; set; }

        public string JobId { get; set; }

        public string MotivationLetter { get; set; }

        public Address UserAddress { get; set; } = new Address();

    }
}
