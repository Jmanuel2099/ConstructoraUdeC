using ConstructoraUdeCController.DTO.SecurityModule;
using ConstructoraUdeCController.Mapper.SecurityModule;
using ConstructoraUdeCModel.DbModel.SecurityModel;
using ConstructoraUdeCModel.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCController.Implementation.SecurityModule
{
    public class RoleImpController
    {
        private RoleImpModel model;

        public RoleImpController()
        {
            model = new RoleImpModel();
        }

        public int RecordCreation(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }
        public int RecordRemove(RoleDTO dto)
        {
            RoleDTOMapper mapper = new RoleDTOMapper();
            RoleDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<RoleDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public RoleDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }
}
