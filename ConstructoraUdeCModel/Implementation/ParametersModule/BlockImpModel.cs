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
    public class BlockImpModel
    {
        public int RecordCreation(BlockDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    ///verifica si el PAIS con el nombre ya existe en algun registro 
                    if (db.BLOCK.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    BlockModelMapper mapper = new BlockModelMapper();
                    BLOCK record = mapper.MapperT2T1(dbModel);
                    db.BLOCK.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(BlockDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.BLOCK.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.CODE = dbModel.Code;
                    record.NAME = dbModel.Name;
                    record.DESCRIPTION = dbModel.Description;
                    record.PROJECT = dbModel.ProjectId;
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

        public int RecordRemove(BlockDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.BLOCK.Where(x => x.ID == dbModel.Id).FirstOrDefault();
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

        public IEnumerable<BlockDbModel> RecordList(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.BLOCK.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter)).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public BlockDbModel RecordSearch(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.BLOCK.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    BlockModelMapper mapper = new BlockModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }

        public IEnumerable<BlockDbModel> RecordListByProject(String projectName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.BLOCK.Where(x => !x.REMOVED && x.PROJECT1.NAME.ToUpper().Contains(projectName)).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<BlockDbModel> RecordListByProject(int projectId)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.BLOCK.Where(x => !x.REMOVED && x.PROJECT == projectId).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<BlockDbModel> RecordListByCity(String projectCitytName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.BLOCK.Where(x => !x.REMOVED && x.PROJECT1.CITY1.NAME.ToUpper().Contains(projectCitytName)).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<BlockDbModel> RecordListByCity(int projectCitytId)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.BLOCK.Where(x => !x.REMOVED && x.PROJECT1.CITY == projectCitytId).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<BlockDbModel> RecordListByCountry(String projectCountrytName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.BLOCK.Where(x => !x.REMOVED && x.PROJECT1.CITY1.COUNTRY1.NAME.ToUpper().Contains(projectCountrytName)).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public IEnumerable<BlockDbModel> RecordListByCountry(int projectCountrytId)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.BLOCK.Where(x => !x.REMOVED && x.PROJECT1.CITY1.COUNTRY1.ID == projectCountrytId).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
    }
}
