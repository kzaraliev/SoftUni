using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, Deliverer> deliverersById = new Dictionary<string, Deliverer>();
        private Dictionary<string, Package> packagesById = new Dictionary<string, Package>();
        private Dictionary<string, string> packagesByDeliverer = new Dictionary<string, string>();

        public void AddDeliverer(Deliverer deliverer)
        {
            deliverersById.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            packagesById.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!deliverersById.ContainsKey(deliverer.Id) || !packagesById.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }
            packagesByDeliverer.Add(package.Id, deliverer.Id);
        }

        public bool Contains(Deliverer deliverer)
        {
            return deliverersById.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packagesById.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return deliverersById.Values;
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            var deliverersByPackageId = new Dictionary<string,int>();

            foreach (var package in packagesByDeliverer)
            {
                if (!deliverersByPackageId.ContainsKey(package.Value))
                {
                    deliverersByPackageId.Add(package.Value, 0);
                }
                deliverersByPackageId[package.Value] += 1;
            }

            return deliverersByPackageId
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => deliverersById[kvp.Key].Name)
                .Select(kvp => deliverersById[kvp.Key]);
        }

        public IEnumerable<Package> GetPackages()
        {
            return packagesById.Values;
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {
            return packagesById.Values.OrderByDescending(p => p.Weight)
                .ThenBy(p => p.Receiver);
        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return packagesById
                .Where(p => !packagesByDeliverer.ContainsKey(p.Key))
                .Select(p => p.Value);
        }
    }
}
