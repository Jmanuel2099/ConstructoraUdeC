using ConstructoraUdeC.Models.SalesModule;
using ConstructoraUdeCController.DTO.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructoraUdeC.Mapper.SalesModule
{
    public class InfoFinancialModelMapper : GeneralMapper<InfoFinancialDTO, InfoFinancialModel>
    {
        public override InfoFinancialModel MapperT1T2(InfoFinancialDTO input)
        {
            //var cityAction = input.CITY;
            CustomerModelMapper infoFinanMapper = new CustomerModelMapper();

            return new InfoFinancialModel
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
        public override IEnumerable<InfoFinancialModel> MapperT1T2(IEnumerable<InfoFinancialDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override InfoFinancialDTO MapperT2T1(InfoFinancialModel input)
        {
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
                CustomerId = input.CustomerId
            };
        }
        public override IEnumerable<InfoFinancialDTO> MapperT2T1(IEnumerable<InfoFinancialModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}