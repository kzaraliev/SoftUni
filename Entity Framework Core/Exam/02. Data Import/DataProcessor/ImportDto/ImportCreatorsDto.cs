using Boardgames.Data.Models.Enums;
using Boardgames.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorsDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(GlobalConstants.CreatorFirstNameMin)]
        [MaxLength(GlobalConstants.CreatorFirstNameMax)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [MinLength(GlobalConstants.CreatorLastNameMin)]
        [MaxLength(GlobalConstants.CreatorLastNameMax)]
        public string LastName { get; set; }

        [XmlArray("Boardgames")]
        public ImportBoardgames[] Boardgames { get; set; }
    }

    [XmlType("Boardgame")]
    public class ImportBoardgames
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.BoardgameNameMin)]
        [MaxLength(GlobalConstants.BoardgameNameMax)]
        public string Name { get; set; }

        [XmlElement("Rating")]
        [Required]
        [Range(GlobalConstants.BoardgameRatingMin, GlobalConstants.BoardgameRatingMax)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Required]
        [Range(GlobalConstants.BoardgameYearPublishedMin, GlobalConstants.BoardgameYearPublishedMax)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Required]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; }
    }
}
