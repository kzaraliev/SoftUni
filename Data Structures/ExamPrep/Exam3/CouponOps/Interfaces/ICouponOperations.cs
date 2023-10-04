namespace CouponOps.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ICouponOperations
    {
        void RegisterSite(Website website);

        void AddCoupon(Website website, Coupon coupon);

        Website RemoveWebsite(string domain);

        Coupon RemoveCoupon(string code);

        bool Exist(Website website);

        bool Exist(Coupon coupon);

        IEnumerable<Website> GetSites();

        IEnumerable<Coupon> GetCouponsForWebsite(Website website);

        void UseCoupon(Website website, Coupon coupon);

        IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc();

        IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc();
    }
}
