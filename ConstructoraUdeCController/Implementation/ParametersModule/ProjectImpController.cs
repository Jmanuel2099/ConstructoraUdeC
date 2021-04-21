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
    public class ProjectImpController
    {
        private ProjectImpModel model;

        public ProjectImpController()
        {
            model = new ProjectImpModel();
        }

        public int RecordCreation(ProjectDTO dto)
        {
            ProjectDTOMapper mapper = new ProjectDTOMapper();
            ProjectDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }

        public int RecordUpdate(ProjectDTO dto)
        {
            ProjectDTOMapper mapper = new ProjectDTOMapper();
            ProjectDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(ProjectDTO dto)
        {
            ProjectDTOMapper mapper = new ProjectDTOMapper();
            ProjectDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<ProjectDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            ProjectDTOMapper mapper = new ProjectDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public ProjectDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            ProjectDTOMapper mapper = new ProjectDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }
}
