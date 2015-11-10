using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_Alekseev;


namespace PayrollTest_Alekseev
{
    [TestClass]
    public class PayrollTest_Alekseev
    {
      [TestMethod]
        public void TestEmployee()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob", e.Name);
            Assert.AreEqual("Home", e.Adress);
            Assert.AreEqual(empId, e.EmpId);
        }
      [TestMethod]
      public void TestEmployeeToString()
      {
          Employee e = new Employee(1, "Bob", "Home");
          Assert.AreEqual("Emp#: 1  Bob  Home  Paid    by ",e.ToString());          
      }    
      [TestMethod]
      public void TestAddSalariedEmployee()
      {
          int empId = 1;
          AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
          t.Execute();
          Employee e = PayrollDatabase.GetEmployee(empId);
          Assert.AreEqual("Bob", e.Name);
          PaymentClassification pc = e.Classification;
          Assert.IsTrue(pc is SalariedClassification);
          SalariedClassification sc = pc as SalariedClassification;
          Assert.AreEqual(1000.00, sc.Salary, .001);
          PaymentSchedule ps = e.Schedule;
          Assert.IsTrue(ps is MonthlySchedule);
          PaymentMethod pm = e.Method;
          Assert.IsTrue(pm is HoldMethod);
      }
        [TestMethod]
      public void TestAddHourlyEmployee()
      {
          int empId = 1;
          AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob", "Home", 200.00);
          t.Execute();
          Employee e = PayrollDatabase.GetEmployee(empId);
          Assert.AreEqual("Bob", e.Name);
          PaymentClassification pc = e.Classification;
          Assert.IsTrue(pc is HourlyClassification);
          HourlyClassification sc = pc as HourlyClassification;
          Assert.AreEqual(200.00, sc.HourlyRate, .001);
          PaymentSchedule ps = e.Schedule;
          Assert.IsTrue(ps is WeeklySchedule);
          PaymentMethod pm = e.Method;
          Assert.IsTrue(pm is HoldMethod);
      }
        [TestMethod]
        public void TestAddCommisionedEmployee()
        {
            int empId = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Bob", "Home", 1000.00, 200.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            CommissionedClassification sc = pc as CommissionedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            Assert.AreEqual(200.00, sc.CommissionRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is CommissionedSchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
    }
}
