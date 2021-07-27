using ConstructoraUdeCController.DTO.SalesModule;
using ConstructoraUdeCController.Mapper.SalesModule;
using ConstructoraUdeCController.Services;
using ConstructoraUdeCModel.DbModel.SalesModule;
using ConstructoraUdeCModel.Implementation.SalesModule;
using System;
using System.Collections.Generic;

namespace ConstructoraUdeCController.Implementation.SalesModule
{
    public class RequestImpController
    {
        private RequestImpModel model;

        public RequestImpController()
        {
            model = new RequestImpModel();
        }

        public int RecordCreation(RequestDTO dto)
        {
            RequestDTOMapper mapper = new RequestDTOMapper();
            RequestDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(RequestDTO dto)
        {
            RequestDTOMapper mapper = new RequestDTOMapper();
            RequestDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(RequestDTO dto)
        {
            RequestDTOMapper mapper = new RequestDTOMapper();
            RequestDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }
        public IEnumerable<RequestDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            RequestDTOMapper mapper = new RequestDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public RequestDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            RequestDTOMapper mapper = new RequestDTOMapper();
            return mapper.MapperT1T2(record);
        }
        public IEnumerable<StatusRequestDTO> RecordListStatus(string filter)
        {
            var list = model.RecordListStatus(filter);
            StatusRequestDTOMapper mapper = new StatusRequestDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public StatusRequestDTO RecordSearchStatus(int id)
        {
            var record = model.RecordSearchStatus(id);
            if (record == null)
            {
                return null;
            }
            StatusRequestDTOMapper mapper = new StatusRequestDTOMapper();
            return mapper.MapperT1T2(record);
        }
        public int changeStatusRequest(int idRequest, int newIdStatus, string statusName, string toEmail, string toName)
        {
            var response = model.changeStatusRequest(idRequest, newIdStatus);
            if (response == 1)
            {
                String content = String.Format("Hola,{0}" +
                " <br />Su solicitud ha sido {1}. " +
                "<br /> Cordial saludo. ", toName, statusName);
                new Notifications().SendEmail("Respuesta a solicitud", content, toName, toEmail);
            }
            return response;
        }
    }
}
