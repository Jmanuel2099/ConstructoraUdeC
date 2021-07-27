using ConstructoraUdeCController.DTO.ParametersModule;
using ConstructoraUdeCController.Mapper.ParametersModule;
using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Implementation.ParametersModule;
using System.Collections.Generic;

namespace ConstructoraUdeCController.Implementation.ParametersModule
{
    public class BlockImpController
    {
        private BlockImpModel model;

        public BlockImpController()
        {
            model = new BlockImpModel();
        }

        public int RecordCreation(BlockDTO dto)
        {
            BlockDTOMapper mapper = new BlockDTOMapper();
            BlockDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        public int RecordUpdate(BlockDTO dto)
        {
            BlockDTOMapper mapper = new BlockDTOMapper();
            BlockDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(BlockDTO dto)
        {
            BlockDTOMapper mapper = new BlockDTOMapper();
            BlockDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<BlockDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public BlockDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(record);
        }

        public IEnumerable<BlockDTO> RecordListByProject(string projectName)
        {
            var list = model.RecordListByProject(projectName);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public IEnumerable<BlockDTO> RecordListByProject(int projectId)
        {
            var list = model.RecordListByProject(projectId);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public IEnumerable<BlockDTO> RecordListByCity(string projectCityName)
        {
            var list = model.RecordListByCity(projectCityName);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public IEnumerable<BlockDTO> RecordListByCity(int projectCityId)
        {
            var list = model.RecordListByCity(projectCityId);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public IEnumerable<BlockDTO> RecordListByCountry(string projecCountrytName)
        {
            var list = model.RecordListByCountry(projecCountrytName);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public IEnumerable<BlockDTO> RecordListByCountry(int projecCountrytId)
        {
            var list = model.RecordListByCountry(projecCountrytId);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }
    }
}
