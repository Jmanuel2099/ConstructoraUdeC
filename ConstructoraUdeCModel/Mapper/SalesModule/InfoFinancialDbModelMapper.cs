using ConstructoraUdeCModel.DbModel.SalesModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Mapper.SalesModule
{
    public class InfoFinancialDbModelMapper: GeneralMapper<FINANCIAL_INFORMATION, InfoFinancialDbModel>
    {
        public override InfoFinancialDbModel MapperT1T2(FINANCIAL_INFORMATION input)
        {
            CustomerDbModelMapper infoFinanMapper = new CustomerDbModelMapper();

            return new InfoFinancialDbModel
            {
                Id = input.ID,
                IncommeTotal = (int)input.INCOME_TOTAL,
                WorkDate = input.WORK_DATE,
                TimeCurrentJob = input.TIME_CURRENTE_JOB,
                FamiliyRefName = input.FAMILY_REFERENCE_NAME,
                FamilyRefPhone = input.FAMILY_REFERENCE_PHONE,
                PersonalRefName = input.PERSONAL_REFERENCE,
                PersonalRefPhone = input.PERSONAL_REFERENCE_PHONE,
                Customer = infoFinanMapper.MapperT1T2(input.CUSTOMER1)
            };
        }
        public override IEnumerable<InfoFinancialDbModel> MapperT1T2(IEnumerable<FINANCIAL_INFORMATION> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override FINANCIAL_INFORMATION MapperT2T1(InfoFinancialDbModel input)
        {
            return new FINANCIAL_INFORMATION
            {
                ID = input.Id,
                INCOME_TOTAL = input.IncommeTotal,
                WORK_DATE = input.WorkDate,
                TIME_CURRENTE_JOB = input.TimeCurrentJob,
                FAMILY_REFERENCE_NAME = input.FamiliyRefName,
                FAMILY_REFERENCE_PHONE = input.FamilyRefPhone,
                PERSONAL_REFERENCE = input.PersonalRefName,
                PERSONAL_REFERENCE_PHONE = input.PersonalRefPhone,
                CUSTOMER = input.CustomerId
            };
        }
        public override IEnumerable<FINANCIAL_INFORMATION> MapperT2T1(IEnumerable<InfoFinancialDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
