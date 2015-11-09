using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Alekseev
{
    public class Employee
    {
        private readonly int empid;
        private string name;
        private string adress;        
        private PaymentClassification classification;
        private PaymentSchedule schedule;
        private PaymentMethod method;
        private Affliation affliation;

        public Employee(int empid, string name, string adress)
        {
            this.empid = empid;
            this.name = name;
            this.adress = adress;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Adress
        {
            get { return adress; }
        }
        public int EmpId
        {
            get { return empid; }
        }
        public PaymentClassification Classification
        {
            get { return classification; }
            set { classification = value; }
        }
        public PaymentSchedule Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }
        public PaymentMethod Method
        {
            get { return method; }
            set { method = value; }
        }
        public Affliation Affliation
        {
            get { return affliation; }
            set { affliation = value; }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Emp#: ").Append(empid).Append("  ");
            builder.Append(name).Append("  ");
            builder.Append(adress).Append("  ");
            builder.Append("Paid ").Append(classification).Append("  ");
            builder.Append(schedule);
            builder.Append(" by ").Append(method);
            return builder.ToString();
        }
    }
    public interface Transaction
    {
        void Execute();
    }
}
