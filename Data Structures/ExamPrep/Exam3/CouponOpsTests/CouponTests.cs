using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using CouponOps;
using CouponOps.Models;

[TestFixture]
public class CouponTests
{

    private CouponOperations couponOperations;
    private Website w1;
    private Website w2;
    private Website w3;
    private Website w4;
    private Website w5;
    private Website w6;
    private Coupon c1;
    private Coupon c2;
    private Coupon c3;
    private Coupon c4;
    private Coupon c5;

    [SetUp]
    public void Setup()
    {
        this.couponOperations = new CouponOperations();
        this.w1 = new Website("a", 1);
        this.w2 = new Website("b", 2);
        this.w3 = new Website("c", 2);
        this.w4 = new Website("d", 4);
        this.w5 = new Website("e", 5);
        this.w6 = new Website("f", 6);
        this.c1 = new Coupon("a", 1, 3);
        this.c2 = new Coupon("b", 1, 2);
        this.c3 = new Coupon("c", 1, 1);
        this.c4 = new Coupon("d", 2, 3);
        this.c5 = new Coupon("e", 0, 3);
    }

    [Test]
    public void TestRegisterWebsite()
    {
        this.couponOperations.RegisterSite(w1);

        Assert.True(this.couponOperations.Exist(w1));
    }

    [Test]
    public void TestRegisteringWebsiteTwiceThrowException()
    {
        this.couponOperations.RegisterSite(w1);
        Assert.Throws<ArgumentException>(() => this.couponOperations.RegisterSite(w1));
    }

    [Test]
    public void TestRegisteringManyWebsites()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RegisterSite(w2);
        this.couponOperations.RegisterSite(w3);

        Assert.True(this.couponOperations.GetSites().Count() == 3);
    }

    [Test]
    public void TestAddingCoupon()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);

        Assert.True(this.couponOperations.Exist(c1));
    }

    [Test]
    public void TestAddingCouponTwice()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        Assert.Throws<ArgumentException>(() => this.couponOperations.AddCoupon(w1, c1));
    }

    [Test]
    public void TestAddingCouponForNonExistentSite()
    {
        this.couponOperations.RegisterSite(w2);
        Assert.Throws<ArgumentException>(() => this.couponOperations.AddCoupon(w1, c1));
    }

    [Test]
    public void TestRemoveWebsite()
    {
        this.couponOperations.RegisterSite(w1);
        var w = this.couponOperations.RemoveWebsite(w1.Domain);

        Assert.AreSame(w1, w);
    }

    [Test]
    public void TestRemoveWebsiteTwiceThrowException()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RemoveWebsite(w1.Domain);
        Assert.Throws<ArgumentException>(() => this.couponOperations.RemoveWebsite(w1.Domain));
    }

    [Test]
    public void TestRemoveWebsiteAndAddingAgain()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RemoveWebsite(w1.Domain);
        this.couponOperations.RegisterSite(w1);

        Assert.True(this.couponOperations.Exist(w1));
    }

    [Test]
    public void TestRemoveCoupon()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.RemoveCoupon(c1.Code);

        Assert.False(this.couponOperations.Exist(c1));
    }

    [Test]
    public void TestRemoveCouponTwiceThrowException()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.RemoveCoupon(c1.Code);

        Assert.Throws<ArgumentException>(() => this.couponOperations.RemoveCoupon(c1.Code));
    }


    [Test]
    public void TestRemoveCouponAndAddingAgain()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.RemoveCoupon(c1.Code);
        this.couponOperations.AddCoupon(w1, c1);

        Assert.True(this.couponOperations.Exist(c1));
    }

    [Test]
    public void TestExistWebsite()
    {
        this.couponOperations.RegisterSite(w1);
        Assert.True(this.couponOperations.Exist(w1));
    }

    [Test]
    public void TestExistWebsiteNotAddingAnything()
    {
        Assert.False(this.couponOperations.Exist(w1));
    }

    [Test]
    public void TestExistWebsiteBeforeAndAfter()
    {
        Assert.False(this.couponOperations.Exist(w1));
        this.couponOperations.RegisterSite(w1);
        Assert.True(this.couponOperations.Exist(w1));
    }

    [Test]
    public void TestExistCoupon()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        Assert.True(this.couponOperations.Exist(c1));
    }

    [Test]
    public void TestExistCouponNotAddingAnything()
    {
        Assert.False(this.couponOperations.Exist(c1));
    }

    [Test]
    public void TestExistCouponBeforeAndAfter()
    {
        Assert.False(this.couponOperations.Exist(c1));
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        Assert.True(this.couponOperations.Exist(w1));
    }

    [Test]
    public void TestGetCouponsForWebsite()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w1, c2);

        var res = this.couponOperations.GetCouponsForWebsite(w1);
        var expected = new List<Coupon>() { c2, c1 };
        CollectionAssert.AreEquivalent(expected, res);
    }

    [Test]
    public void TestGetCouponsForWebsite1()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w1, c2);
        this.couponOperations.RemoveCoupon(c2.Code);

        var res = this.couponOperations.GetCouponsForWebsite(w1);
        var expected = new List<Coupon>() { c1 };
        CollectionAssert.AreEquivalent(expected, res);
    }

    [Test]
    public void TestGetCouponsForWebsite2()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w1, c2);
        this.couponOperations.RemoveWebsite(w1.Domain);

        Assert.Throws<ArgumentException>(() => this.couponOperations.GetCouponsForWebsite(w1));
    }

    [Test]
    public void TestUseCoupon()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RegisterSite(w2);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w2, c2);

        this.couponOperations.UseCoupon(w1, c1);

        Assert.False(this.couponOperations.Exist(c1));
    }

    [Test]
    public void TestUseCoupon1()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RegisterSite(w2);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w2, c2);

        this.couponOperations.UseCoupon(w1, c1);
        Assert.Throws<ArgumentException>(() => this.couponOperations.UseCoupon(w1, c1));
    }

    [Test]
    public void TestUseCoupon2()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RegisterSite(w2);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w2, c2);

        Assert.Throws<ArgumentException>(() => this.couponOperations.UseCoupon(w1, c2));
    }

    [Test]
    public void TestUseCoupon3()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RegisterSite(w2);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w2, c2);
        this.couponOperations.UseCoupon(w1, c1);
        this.couponOperations.AddCoupon(w1, c1);

        Assert.True(this.couponOperations.Exist(c1));
        this.couponOperations.UseCoupon(w1, c1);
        Assert.False(this.couponOperations.Exist(c1));
    }

    [Test]
    public void TestGetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w1, c2);
        this.couponOperations.AddCoupon(w1, c3);
        this.couponOperations.AddCoupon(w1, c4);
        this.couponOperations.AddCoupon(w1, c5);

        var res = this.couponOperations.GetCouponsOrderedByValidityDescAndDiscountPercentageDesc();
        var expected = new List<Coupon>() { c4, c1, c5, c2, c3 };
        CollectionAssert.AreEqual(res, expected);
    }

    [Test]
    public void TestGetCouponsOrderedByValidityDescAndDiscountPercentageDesc1()
    {
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w1, c4);
        this.couponOperations.AddCoupon(w1, c5);

        var res = this.couponOperations.GetCouponsOrderedByValidityDescAndDiscountPercentageDesc();
        var expected = new List<Coupon>() { c4, c1, c5 };
        CollectionAssert.AreEqual(res, expected);
    }

    /*
     *  private CouponOperations couponOperations;
        private Website w1 = new Website("a", 1);
        private Website w2 = new Website("b", 2);
        private Website w3 = new Website("c", 3);
        private Website w4 = new Website("d", 4);
        private Website w5 = new Website("e", 5);
        private Website w6 = new Website("f", 6);
        private Coupon c1 = new Coupon("a", 1, 3);
        private Coupon c2 = new Coupon("b", 1, 2);
        private Coupon c3 = new Coupon("c", 1, 1);
        private Coupon c4 = new Coupon("d", 2, 3);
        private Coupon c5 = new Coupon("e", 0, 3);
     */

    [Test]
    public void TestGetWebsitesOrderedByUserCountAndCouponsCountDesc()
    {
        this.couponOperations.RegisterSite(w3);
        this.couponOperations.RegisterSite(w4);
        this.couponOperations.RegisterSite(w5);
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RegisterSite(w2);

        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w2, c2);
        this.couponOperations.AddCoupon(w3, c3);
        this.couponOperations.AddCoupon(w3, c4);
        this.couponOperations.AddCoupon(w3, c5);

        var res = this.couponOperations.GetWebsitesOrderedByUserCountAndCouponsCountDesc();
        var expected = new List<Website>() { w1, w3, w2, w4, w5 };
        CollectionAssert.AreEqual(res, expected);
    }

    [Test]
    public void TestGetWebsitesOrderedByUserCountAndCouponsCountDesc1()
    {
        this.couponOperations.RegisterSite(w3);
        this.couponOperations.RegisterSite(w4);
        this.couponOperations.RegisterSite(w5);
        this.couponOperations.RegisterSite(w1);
        this.couponOperations.RegisterSite(w2);

        this.couponOperations.AddCoupon(w1, c1);
        this.couponOperations.AddCoupon(w2, c2);
        this.couponOperations.AddCoupon(w2, c3);
        this.couponOperations.AddCoupon(w2, c4);
        this.couponOperations.AddCoupon(w2, c5);

        var res = this.couponOperations.GetWebsitesOrderedByUserCountAndCouponsCountDesc();
        var expected = new List<Website>() { w1, w2, w3, w4, w5 };
        CollectionAssert.AreEqual(res, expected);
    }


    [Test]
    public void RegisterSitePerf()
    {
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.RegisterSite(new Website(i.ToString(), i));
        }

        Stopwatch sw = new Stopwatch();

        sw.Start();
        this.couponOperations.RegisterSite(new Website("test", 1));
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void AddCouponPerf()
    {
        this.couponOperations.RegisterSite(w1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.AddCoupon(w1, new Coupon(i.ToString(), i, i));
        }

        Stopwatch sw = new Stopwatch();

        sw.Start();
        this.couponOperations.AddCoupon(w1, new Coupon("test", 0, 0));
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }


    [Test]
    public void RemoveWebsitePef()
    {
        this.couponOperations.RegisterSite(w1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.RegisterSite(new Website(i.ToString(), i));
        }
        Stopwatch sw = new Stopwatch();

        sw.Start();
        this.couponOperations.RemoveWebsite(w1.Domain);
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestUseCouponPerf()
    {
        this.couponOperations.RegisterSite(w1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.RegisterSite(new Website(i.ToString(), i));
        }
        this.couponOperations.AddCoupon(w1, c1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.AddCoupon(w1, new Coupon(i.ToString(), i, i));
        }
        Stopwatch sw = new Stopwatch();

        sw.Start();
        this.couponOperations.UseCoupon(w1, c1);
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestGetCouponsOrderedByValidityDescAndDiscountPercentageDescPerf()
    {
        this.couponOperations.RegisterSite(w1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.RegisterSite(new Website(i.ToString(), i));
        }
        this.couponOperations.AddCoupon(w1, c1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.AddCoupon(w1, new Coupon(i.ToString(), i, i));
        }
        Stopwatch sw = new Stopwatch();

        sw.Start();
        this.couponOperations.GetCouponsOrderedByValidityDescAndDiscountPercentageDesc();
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestGetWebsitesOrderedByUserCountAndCouponsCountDescPerf()
    {
        this.couponOperations.RegisterSite(w1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.RegisterSite(new Website(i.ToString(), i));
        }
        this.couponOperations.AddCoupon(w1, c1);
        for (int i = 0; i < 10000; i++)
        {
            this.couponOperations.AddCoupon(w1, new Coupon(i.ToString(), i, i));
        }
        Stopwatch sw = new Stopwatch();

        sw.Start();
        this.couponOperations.GetWebsitesOrderedByUserCountAndCouponsCountDesc();
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

}
