using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Tutorial.NHibernate.Core.Domain;

namespace Tutorial.NHibernate.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void EmployeeIsEntitledToPaidLeave()
        {
            var employee = new Employee
            {
                Leaves = new List<Leave>
                {
                    new Leave
                    {
                        Type = LeaveType.Paid,
                        AvailableEntitlement = 15
                    }
                }
            };


            var paidLeave = employee.Leaves.FirstOrDefault(x => x.Type == LeaveType.Paid);
            Assert.That(paidLeave, Is.Not.Null);
            Assert.That(paidLeave.AvailableEntitlement, Is.EqualTo(15));
            Assert.That(true, Is.EqualTo(true));
        }

        [Test]
        public void EmployeeIsEntitledToPaidLeave2()
        {
            var employee = new Employee
            {
                Leaves = new List<Leave>
                {
                    new Leave
                    {
                        Type = LeaveType.Paid,
                        AvailableEntitlement = 15
                    }
                }
            };


            var paidLeave = employee.Leaves.FirstOrDefault(x => x.Type == LeaveType.Paid);
            Assert.That(paidLeave, Is.Not.Null);
            Assert.That(paidLeave.AvailableEntitlement, Is.EqualTo(15));
        }
    }
}
