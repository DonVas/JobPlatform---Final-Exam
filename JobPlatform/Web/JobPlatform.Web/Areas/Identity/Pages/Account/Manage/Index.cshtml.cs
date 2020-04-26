namespace JobPlatform.Web.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IFileService fileService;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IFileService fileService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.fileService = fileService;
        }

        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string ProfilePicture { get; set; }

        [BindProperty]
        [AllowNull]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile PictureFile { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Middle Name")]
            public string MiddleName { get; set; }

            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Family Name")]
            public string FamilyName { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
            public DateTime? Birthdate { get; set; }

            [Required]
            [MaxLength(50)]
            public string City { get; set; }

            [Required]
            [MaxLength(50)]
            public string Region { get; set; }

            [Required]
            [MaxLength(50)]
            public string Country { get; set; }

            [Required]
            [MaxLength(50)]
            public string PostCode { get; set; }

            [Required]
            [MaxLength(500)]
            public string StreetAddress { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            this.ProfilePicture = user.ProfilePicture;

            await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostPictureUploadAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            if (this.PictureFile != null)
            {
                await this.fileService.UploadProfileImageAsync(this.PictureFile, user.Id);

                this.ProfilePicture = user.ProfilePicture;
            }

            var result = await this.userManager.UpdateAsync(user);

            // However, it always succeeds inspite of not updating the database
            if (!result.Succeeded)
            {
                var userId = await this.userManager.GetUserIdAsync(user);
                throw new InvalidOperationException($"Unexpected error occurred for user with ID '{userId}'.");
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your picture has been updated";

            return this.RedirectToPage();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await this.userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            user.FirstName = this.Input.FirstName;
            user.MiddleName = this.Input.MiddleName;
            user.FamilyName = this.Input.FamilyName;
            if (user.Address == null)
            {
               user.Address = new Address(this.Input.City, this.Input.Region, this.Input.PostCode, this.Input.StreetAddress, this.Input.Country);
            }
            else
            {
                user.Address.Country = this.Input.Country;
                user.Address.City = this.Input.City;
                user.Address.PostCode = this.Input.PostCode;
                user.Address.Region = this.Input.Region;
                user.Address.StreetAddress = this.Input.StreetAddress;
            }

            if (this.Input.Birthdate != null)
            {
                DateTime res;
                DateTime.TryParse(this.Input.Birthdate.ToString(), out res);
                user.Birthdate = res;
            }

            var result = await this.userManager.UpdateAsync(user);

            // However, it always succeeds inspite of not updating the database
            if (!result.Succeeded)
            {
                var userId = await this.userManager.GetUserIdAsync(user);
                throw new InvalidOperationException($"Unexpected error occurred for user with ID '{userId}'.");
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            var birthdate = user.Birthdate;
            this.ProfilePicture = user.ProfilePicture;
            this.Email = await this.userManager.GetEmailAsync(user);
            this.Username = await this.userManager.GetUserNameAsync(user);
            this.Input = new InputModel
            {
                Birthdate = birthdate,
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                FamilyName = user.FamilyName,
                Country = user.Address.Country,
                StreetAddress = user.Address.StreetAddress,
                City = user.Address.City,
                PostCode = user.Address.PostCode,
                Region = user.Address.Region,
            };
        }
    }
}
