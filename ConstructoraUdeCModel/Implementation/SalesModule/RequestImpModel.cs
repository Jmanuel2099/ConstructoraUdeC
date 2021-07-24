using ConstructoraUdeCModel.DbModel.SalesModule;
using ConstructoraUdeCModel.Mapper.SalesModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Implementation.SalesModule
{
    public class RequestImpModel
    {
        public int RecordCreation(RequestDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    ///verifica si el SOLICITUD con el nombre ya existe en algun registro 
                    if (db.REQUEST.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    RequestDbModelMapper mapper = new RequestDbModelMapper();
                    REQUEST record = mapper.MapperT2T1(dbModel);
                    db.REQUEST.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }
        public int RecordUpdate(RequestDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.REQUEST.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.REQUEST_DATE = dbModel.RequestDate;
                    record.OFFER = dbModel.Offer;
                    record.STATUS_REQUEST = dbModel.StatusRequestId;
                    record.CUSTOMER = dbModel.CustomerId;
                    record.PROPERTY = dbModel.PropertyId;

                    db.Entry(record).State = EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }
        public int RecordRemove(RequestDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.REQUEST.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }

                    //record.REMOVED = true;
                    db.REQUEST.Remove(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }
        public IEnumerable<RequestDbModel> RecordList(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.REQUEST.Where(x => x.CUSTOMER1.NAME.ToUpper().Contains(filter)).ToList();
                RequestDbModelMapper mapper = new RequestDbModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public RequestDbModel RecordSearch(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.REQUEST.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    RequestDbModelMapper mapper = new RequestDbModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }

        public IEnumerable<StatusRequestDbModel> RecordListStatus(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.STATUS_REQUEST.Where(x => x.NAME.ToUpper().Contains(filter)).ToList();
                StatusRequestDbModelMapper mapper = new StatusRequestDbModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public StatusRequestDbModel RecordSearchStatus(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.STATUS_REQUEST.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    StatusRequestDbModelMapper mapper = new StatusRequestDbModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
