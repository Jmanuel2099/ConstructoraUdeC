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
    public class PropertyImpController
    {
        private PropertyImpModel model;

        public PropertyImpController()
        {
            model = new PropertyImpModel();
        }

        public int RecordCreation(PropertyDTO dto)
        {
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            PropertyDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        public int RecordUpdate(PropertyDTO dto)
        {
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            PropertyDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(PropertyDTO dto)
        {
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            PropertyDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<PropertyDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public PropertyDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(record);
        }

        public IEnumerable<PropertyDTO> RecordListByBlock(string blockName)
        {
            var list = model.RecordListByBlock(blockName);
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public IEnumerable<PropertyDTO> RecordListByProject(string projectName)
        {
            var list = model.RecordListByProject(projectName);
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public IEnumerable<PropertyDTO> RecordListByCity(string citytName)
        {
            var list = model.RecordListByCity(citytName);
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public IEnumerable<PropertyDTO> RecordListByCountry(string countrytName)
        {
            var list = model.RecordListByCountry(countrytName);
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(list);
        }
    }
}
