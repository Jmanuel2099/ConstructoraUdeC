namespace ConstructoraUdeCController.DTO.SalesModule
{
    public class InfoFinancialDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int incommeTotal;

        public int IncommeTotal
        {
            get { return incommeTotal; }
            set { incommeTotal = value; }
        }

        private string workDate;

        public string WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private string timeCurrentJob;

        public string TimeCurrentJob
        {
            get { return timeCurrentJob; }
            set { timeCurrentJob = value; }
        }

        private string familiyRefName;

        public string FamiliyRefName
        {
            get { return familiyRefName; }
            set { familiyRefName = value; }
        }

        private string familyRefPhone;

        public string FamilyRefPhone
        {
            get { return familyRefPhone; }
            set { familyRefPhone = value; }
        }

        private string personalRefName;

        public string PersonalRefName
        {
            get { return personalRefName; }
            set { personalRefName = value; }
        }

        private string personalRefPhone;

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

        private CustomerDTO customer;

        public CustomerDTO Customer
        {
            get { return customer; }
            set { customer = value; }
        }
    }
}
