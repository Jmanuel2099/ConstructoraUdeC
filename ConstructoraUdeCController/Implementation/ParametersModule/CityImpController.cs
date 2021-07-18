using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.Mapper.ParametersModule;
using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Implementation.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Implementation.ParametersModule
{
    public class CityImpController
    {
        private CityImpModel model;

        public CityImpController()
        {
            model = new CityImpModel();
        }

        public int RecordCreation(CityDTO dto)
        {
            CityDTOMapper mapper = new CityDTOMapper();
            CityDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(CityDTO dto)
        {
            CityDTOMapper mapper = new CityDTOMapper();
            CityDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(CityDTO dto)
        {
            CityDTOMapper mapper = new CityDTOMapper();
            CityDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<CityDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            CityDTOMapper mapper = new CityDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public CityDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            CityDTOMapper mapper = new CityDTOMapper();
            return mapper.MapperT1T2(record);
        }

        public IEnumerable<CityDTO> RecordListByCountry(string filter)
        {
            var list = model.RecordListByCountry(filter);
            CityDTOMapper mapper = new CityDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public IEnumerable<CityDTO> RecordListByCountry(int countryId)
        {
            var list = model.RecordListByCountry(countryId);
            CityDTOMapper mapper = new CityDTOMapper();
            return mapper.MapperT1T2(list);
        }
    }
}
