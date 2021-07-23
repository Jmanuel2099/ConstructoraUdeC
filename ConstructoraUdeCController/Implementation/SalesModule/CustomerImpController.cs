using ConstructoraUdeCController.DTO.SalesModule;
using ConstructoraUdeCController.Mapper.SalesModule;
using ConstructoraUdeCModel.DbModel.SalesModule;
using ConstructoraUdeCModel.Implementation.SalesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Implementation.SalesModule
{
    public class CustomerImpController
    {
        private CustomerImpModel model;
        public CustomerImpController()
        {
            model = new CustomerImpModel();
        }

        public int RecordCreation(CustomerDTO dto)
        {
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            CustomerDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        public int RecordUpdate(CustomerDTO dto)
        {
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            CustomerDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(CustomerDTO dto)
        {
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            CustomerDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }
        public IEnumerable<CustomerDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public CustomerDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            CustomerDTOMapper mapper = new CustomerDTOMapper();
            return mapper.MapperT1T2(record);
        }

        public IEnumerable<CustomerDTO> RecordListByCity(string cityName)
        {
            var list = model.RecordListByCity(cityName);
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public IEnumerable<CustomerDTO> RecordListByCountry(string countryName)
        {
            var list = model.RecordListByCountry(countryName);
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public int RecordCreationInfoFinancial(InfoFinancialDTO dto)
        {
            InfoFinancialDTOMapper mapper = new InfoFinancialDTOMapper();
            InfoFinancialDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreationInfoFinancial(dbModel);
        }

        public int RecordUpdateInfoFinancial(InfoFinancialDTO dto)
        {
            InfoFinancialDTOMapper mapper = new InfoFinancialDTOMapper();
            InfoFinancialDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdateInfoFinancial(dbModel);
        }

        public InfoFinancialDTO RecordSearchInfoFinancial(int id)
        {
            var record = model.RecordSearchInfoFinancial(id);
            if (record == null)
            {
                return null;
            }

            InfoFinancialDTOMapper mapper = new InfoFinancialDTOMapper();
            return mapper.MapperT1T2(record);
        }
        public IEnumerable<InfoFinancialDTO> RecordListInfoFinancial(string filter)
        {
            var list = model.RecordListInfoFinancial(filter);
            InfoFinancialDTOMapper mapper = new InfoFinancialDTOMapper();
            return mapper.MapperT1T2(list);
        }
    }
}
