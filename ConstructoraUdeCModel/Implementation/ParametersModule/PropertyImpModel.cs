using ConstructoraUdeCModel.DbModel.ParametersModule;
using ConstructoraUdeCModel.Mapper.ParametersModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Implementation.ParametersModule
{
    public class PropertyImpModel
    {
        public int RecordCreation(PropertyDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    ///verifica si el PAIS con el nombre ya existe en algun registro 
                    if (db.PROPERTY.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    PropertyModelMapper mapper = new PropertyModelMapper();
                    PROPERTY record = mapper.MapperT2T1(dbModel);
                    db.PROPERTY.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(PropertyDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.PROPERTY.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.CODE = dbModel.Code;
                    record.IDENTIFICATION = dbModel.Identification;
                    record.VALUE = dbModel.Val;
                    record.STATUS = dbModel.Status;
                    record.BLOCK = dbModel.BlockId;
                    record.REMOVED = dbModel.Removed;

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

        public int RecordRemove(PropertyDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.PROPERTY.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.REMOVED = true;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<PropertyDbModel> RecordList(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROPERTY.Where(x => !x.REMOVED && x.IDENTIFICATION.ToUpper().Contains(filter)).ToList();
                PropertyModelMapper mapper = new PropertyModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public PropertyDbModel RecordSearch(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.PROPERTY.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    PropertyModelMapper mapper = new PropertyModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }

        public IEnumerable<PropertyDbModel> RecordListByBlock(String blockName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROPERTY.Where(x => !x.REMOVED && x.BLOCK1.NAME.ToUpper().Contains(blockName)).ToList();
                PropertyModelMapper mapper = new PropertyModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<PropertyDbModel> RecordListByProject(String projectName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROPERTY.Where(x => !x.REMOVED && x.BLOCK1.PROJECT1.NAME.ToUpper().Contains(projectName)).ToList();
                PropertyModelMapper mapper = new PropertyModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<PropertyDbModel> RecordListByCity(String cityName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROPERTY.Where(x => !x.REMOVED && x.BLOCK1.PROJECT1.CITY1.NAME.ToUpper().Contains(cityName)).ToList();
                PropertyModelMapper mapper = new PropertyModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<PropertyDbModel> RecordListByCountry(String countryName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROPERTY.Where(x => !x.REMOVED && x.BLOCK1.PROJECT1.CITY1.COUNTRY1.NAME.ToUpper().Contains(countryName)).ToList();
                PropertyModelMapper mapper = new PropertyModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
    }
}
