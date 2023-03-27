using System.Linq;
using System.Text;
using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ImportDto;
using CarDealer;
using Newtonsoft.Json;

namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            List<Country> countries = new List<Country>();

            var countriesDto = xmlHelper.Deserializer<ImportCountriesDto[]>(xmlString, "Countries");

            foreach (var dto in countriesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country()
                {
                    CountryName = dto.CountryName,
                    ArmySize = dto.ArmySize
                };

                countries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }
            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            var manufacturersDto = xmlHelper.Deserializer<ImportManufacturersDto[]>(xmlString, "Manufacturers");

            foreach (var dto in manufacturersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer()
                {
                    ManufacturerName = dto.ManufacturerName,
                    Founded = dto.Founded
                };

                if (manufacturers.Any(m => m.ManufacturerName == manufacturer.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string[] founded = manufacturer.Founded.Split(", ");
                string printFounded = $"{founded[founded.Length - 2]}, {founded[founded.Length - 1]}";

                manufacturers.Add(manufacturer);
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, printFounded));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            List<Shell> shells = new List<Shell>();

            var shellsDto = xmlHelper.Deserializer<ImportShellsDto[]>(xmlString, "Shells");

            foreach (var dto in shellsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell()
                {
                    ShellWeight = dto.ShellWeight,
                    Caliber = dto.Caliber
                };
                
                shells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Gun> guns = new List<Gun>();

            var gunsDto = JsonConvert.DeserializeObject<ImportGunsDto[]>(jsonString);

            foreach (var dto in gunsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object gunType;
                var isValidType = Enum.TryParse(typeof(GunType), dto.GunType, out gunType);
                
                if (!isValidType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun()
                {
                    ManufacturerId = dto.ManufacturerId,
                    GunWeight = dto.GunWeight,
                    BarrelLength = dto.BarrelLength,
                    NumberBuild = dto.NumberBuild,
                    Range = dto.Range,
                    GunType = (GunType)gunType,
                    ShellId = dto.ShellId,
                };

                foreach (var dtoCountry in dto.Countries)
                {
                    var countryGun = new CountryGun()
                    {
                        CountryId = dtoCountry.Id,
                        Gun = gun
                    };

                    gun.CountriesGuns.Add(countryGun);
                }

                guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(guns);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
