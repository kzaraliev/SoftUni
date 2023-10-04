using System.Collections.Generic;

namespace CouponOps.Models
{
    public class Website
    {
        public Website(string domain, int usersCount)
        {
            this.Domain = domain;
            this.UsersCount = usersCount;
            Coupons = new List<Coupon>();
        }

        public string Domain { get; set; }
        public int UsersCount { get; set; }
        public List<Coupon> Coupons { get; set; }
    }
}
