using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Footballers.Shared;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonersAndMailsDto
    {
        [Required]
        [MinLength(GlobalConstants.PrisonerFullNameMinLength)]
        [MaxLength(GlobalConstants.PrisonerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PrisonerNicknameRegex)]
        public string Nickname { get; set; }

        [Required]
        [Range(GlobalConstants.PrisonerMinAge, GlobalConstants.PrisonerMaxAge)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), GlobalConstants.PrisonerBailMinValue, GlobalConstants.PrisonerBailMaxValue)]
        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public MailsPrisoner[] Mails { get; set; }
    }

    public class MailsPrisoner
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.MailAddressRegex)]
        public string Address { get; set; }
    }
}
