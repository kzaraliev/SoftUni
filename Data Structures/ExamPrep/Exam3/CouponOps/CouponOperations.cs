using System.Linq;

namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        Dictionary<string, Coupon> coupons = new Dictionary<string, Coupon>();
        Dictionary<string, Website> websites = new Dictionary<string, Website>();

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!websites.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            coupon.Website = website;
            coupons.Add(coupon.Code, coupon);
            websites[website.Domain].Coupons.Add(coupon);
        }

        public bool Exist(Website website)
        {
            return websites.ContainsKey(website.Domain);
        }

        public bool Exist(Coupon coupon)
        {
            return coupons.ContainsKey(coupon.Code);
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!websites.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            return websites[website.Domain].Coupons;
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return coupons
                .Select(c => c.Value)
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage);
        }

        public IEnumerable<Website> GetSites()
        {
            return websites.Values;
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            return websites
                .Select(w => w.Value)
                .OrderBy(w => w.UsersCount)
                .ThenByDescending(w => w.Coupons.Count);
        }

        public void RegisterSite(Website website)
        {
            if (websites.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            websites.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!coupons.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            Coupon coupon = coupons[code];
            websites[coupon.Website.Domain].Coupons.Remove(coupon);
            coupons.Remove(code);

            return coupon;
        }

        public Website RemoveWebsite(string domain)
        {
            if (!websites.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            List<Coupon> couponsOfCurrentDoctor = websites[domain].Coupons;

            foreach (var coupon in couponsOfCurrentDoctor)
            {
                coupons.Remove(coupon.Code);
            }

            Website website = websites[domain];
            websites.Remove(domain);

            return website;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!websites.ContainsKey(website.Domain) && !coupons.ContainsKey(coupon.Code) || !websites[website.Domain].Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }

            websites[website.Domain].Coupons.Remove(coupon);
            coupons.Remove(coupon.Code);
        }
    }
}
