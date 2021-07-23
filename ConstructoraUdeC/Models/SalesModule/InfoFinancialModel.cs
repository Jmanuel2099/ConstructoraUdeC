using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Models.SalesModule
{
    public class InfoFinancialModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int incommeTotal;
        [DisplayName("Total de ingresos")]
        public int IncommeTotal
        {
            get { return incommeTotal; }
            set { incommeTotal = value; }
        }

        private string workDate;
        [DisplayName("Datos del trabajo")]
        [MaxLength(100)]
        public string WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private string timeCurrentJob;
        [DisplayName("Tiempo en el actual trabajo")]
        [MaxLength(10)]
        public string TimeCurrentJob
        {
            get { return timeCurrentJob; }
            set { timeCurrentJob = value; }
        }

        private string familiyRefName;
        [DisplayName("Nombre de referencia Familiar")]
        [MaxLength(50)]
        public string FamiliyRefName
        {
            get { return familiyRefName; }
            set { familiyRefName = value; }
        }

        private string familyRefPhone;
        [DisplayName("Telefono de referencia familiar")]
        [MaxLength(100)]
        public string FamilyRefPhone
        {
            get { return familyRefPhone; }
            set { familyRefPhone = value; }
        }

        private string personalRefName;
        [DisplayName("Nombre de referencia personal")]
        [MaxLength(100)]
        public string PersonalRefName
        {
            get { return personalRefName; }
            set { personalRefName = value; }
        }

        private string personalRefPhone;
        [DisplayName("Telefono de referencia persona")]
        [MaxLength(100)]
        public string PersonalRefPhone
        {
            get { return personalRefPhone; }
            set { personalRefPhone = value; }
        }

        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private CustomerModel customer;

        public CustomerModel Customer
        {
            get { return customer; }
            set { customer = value; }
        }
    }
}