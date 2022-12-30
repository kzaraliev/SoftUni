using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository boothRepository;

        public Controller()
        {
            boothRepository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = boothRepository.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            boothRepository.AddModel(booth);

            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);


            if (delicacyTypeName == nameof(Gingerbread))
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);
                if (delicacy != null)
                {
                    return $"{delicacyName} is already added in the pastry shop!";
                }

                IDelicacy gingerBread = new Gingerbread(delicacyName);
                booth.DelicacyMenu.AddModel(gingerBread);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);
                if (delicacy != null)
                {
                    return $"{delicacyName} is already added in the pastry shop!";
                }

                IDelicacy stolen = new Stolen(delicacyName);
                booth.DelicacyMenu.AddModel(stolen);
            }
            else
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size);

            if (cocktail != null)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            if (cocktailTypeName == nameof(Hibernation))
            {
                ICocktail hibernation = new Hibernation(cocktailName, size);
                booth.CocktailMenu.AddModel(hibernation);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                ICocktail mulledWine = new MulledWine(cocktailName, size);
                booth.CocktailMenu.AddModel(mulledWine);
            }

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> booths = boothRepository.Models.ToList();

            booths = booths.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople).OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).ToList();

            if (booths.Count == 0)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            IBooth boothToReserve = booths[0];
            boothToReserve.ChangeStatus();
            return $"Booth {boothToReserve.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            string[] orderParts = order.Split("/");

            string itemTypeName = orderParts[0];
            string itemName = orderParts[1];
            int amountOfOrder = int.Parse(orderParts[2]);
            string sizeForCocktail = "";

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                sizeForCocktail = orderParts[3];
            }


            if (itemTypeName != nameof(Hibernation) && itemTypeName != nameof(MulledWine) && itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen))
            {
                return $"{itemTypeName} is not recognized type!";
            }
            

            if (booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == sizeForCocktail && c.GetType().Name == itemTypeName) != null)
            {
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c =>
                    c.Name == itemName && c.Size == sizeForCocktail && c.GetType().Name == itemTypeName);

                double priceForOrder = cocktail.Price * amountOfOrder;
                booth.UpdateCurrentBill(priceForOrder);

                return $"Booth {boothId} ordered {amountOfOrder} {itemName}!";
            }

            if (booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName && d.GetType().Name == itemTypeName) != null)
            {
                IDelicacy delicacy =
                    booth.DelicacyMenu.Models.FirstOrDefault(
                        d => d.Name == itemName && d.GetType().Name == itemTypeName);

                double priceForOrder = delicacy.Price * amountOfOrder;
                booth.UpdateCurrentBill(priceForOrder);

                return $"Booth {boothId} ordered {amountOfOrder} {itemName}!";
            }

            if (sizeForCocktail != "")
            {
                return $"There is no {sizeForCocktail} {itemName} available!";
            }

            return $"There is no {itemTypeName} {itemName} available!";
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }
    }
}
