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
    public class ProjectImpModel
    {
        public int RecordCreation(ProjectDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    ///verifica si el PAIS con el nombre ya existe en algun registro 
                    if (db.PROJECT.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    ProjectModelMapper mapper = new ProjectModelMapper();
                    PROJECT record = mapper.MapperT2T1(dbModel);
                    db.PROJECT.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(ProjectDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.PROJECT.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.CODE = dbModel.Code;
                    record.NAME = dbModel.Name;
                    record.DESCRIPTION = dbModel.Description;
                    record.IMAGE = dbModel.Image;
                    record.CITY = dbModel.CityId;
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

        public int RecordRemove(ProjectDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.PROJECT.Where(x => x.ID == dbModel.Id).FirstOrDefault();
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

        public IEnumerable<ProjectDbModel> RecordList(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROJECT.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter)).ToList();
                ProjectModelMapper mapper = new ProjectModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public ProjectDbModel RecordSearch(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.PROJECT.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    ProjectModelMapper mapper = new ProjectModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }

        public IEnumerable<ProjectDbModel> RecordListByCity(String CityName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROJECT.Where(x => !x.REMOVED && x.CITY1.NAME.ToUpper().Contains(CityName)).ToList();
                ProjectModelMapper mapper = new ProjectModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public IEnumerable<ProjectDbModel> RecordListByCountry(String CountryName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.PROJECT.Where(x => !x.REMOVED && x.CITY1.COUNTRY1.NAME.ToUpper().Contains(CountryName)).ToList();
                ProjectModelMapper mapper = new ProjectModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

    }
}
