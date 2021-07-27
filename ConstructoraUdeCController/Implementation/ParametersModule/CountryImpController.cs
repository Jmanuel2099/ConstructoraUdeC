using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.Mapper.ParametersModule;
using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Implementation.ParametersModule;
using System.Collections.Generic;

namespace ConstructoraUdeCController.Implementation.ParametersModule
{
    public class CountryImpController
    {
        private CountryImpModel model;

        public CountryImpController()
        {
            model = new CountryImpModel();
        }

        public int RecordCreation(CountryDTO dto)
        {
            CountryDTOMapper mapper = new CountryDTOMapper();
            CountryDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        public int RecordUpdate(CountryDTO dto)
        {
            CountryDTOMapper mapper = new CountryDTOMapper();
            CountryDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(CountryDTO dto)
        {
            CountryDTOMapper mapper = new CountryDTOMapper();
            CountryDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<CountryDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            CountryDTOMapper mapper = new CountryDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public CountryDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            CountryDTOMapper mapper = new CountryDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }
}
