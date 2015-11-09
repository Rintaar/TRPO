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
      

    }
}
