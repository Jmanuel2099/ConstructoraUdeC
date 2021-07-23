using ConstructoraUdeCController.DTO.SalesModule;
using ConstructoraUdeCModel.DbModel.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Mapper.SalesModule
{
    public class InfoFinancialDTOMapper : GeneralMapper<InfoFinancialDbModel,InfoFinancialDTO>
    {
        public override InfoFinancialDTO MapperT1T2(InfoFinancialDbModel input)
        {
            //var cityAction = input.CITY;
            CustomerDTOMapper infoFinanMapper = new CustomerDTOMapper();

            return new InfoFinancialDTO
            {
                Id = input.Id,
                IncommeTotal = input.IncommeTotal,
                WorkDate = input.WorkDate,
                TimeCurrentJob = input.TimeCurrentJob,
                FamiliyRefName = input.FamiliyRefName,
                FamilyRefPhone = input.FamilyRefPhone,
                PersonalRefName = input.PersonalRefName,
                PersonalRefPhone = input.PersonalRefPhone,
                Customer = infoFinanMapper.MapperT1T2(input.Customer)
            };
        }
        public override IEnumerable<InfoFinancialDTO> MapperT1T2(IEnumerable<InfoFinancialDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override InfoFinancialDbModel MapperT2T1(InfoFinancialDTO input)
        {
            return new InfoFinancialDbModel
            {
                Id = input.Id,
                IncommeTotal = input.IncommeTotal,
                WorkDate = input.WorkDate,
                TimeCurrentJob = input.TimeCurrentJob,
                FamiliyRefName = input.FamiliyRefName,
                FamilyRefPhone = input.FamilyRefPhone,
                PersonalRefName = input.PersonalRefName,
                PersonalRefPhone = input.PersonalRefPhone,
                CustomerId = input.CustomerId
            };
        }
        public override IEnumerable<InfoFinancialDbModel> MapperT2T1(IEnumerable<InfoFinancialDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
