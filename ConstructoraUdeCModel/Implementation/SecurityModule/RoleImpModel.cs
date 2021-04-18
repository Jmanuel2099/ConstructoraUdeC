using ConstructoraUdeCModel.DbModel.SecurityModel;
using ConstructoraUdeCModel.Mapper.SecurityModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraUdeCModel.Implementation.SecurityModule
{
    
    public class RoleImpModel
    {
        /// <summary>
        /// crea un nuevo registro en la base de datos
        /// </summary>
        /// <param name="dbModel">Recive un objeto que tiene la informacion de los roles </param>
        /// <returns>1:No hubo ningun error y se creo el registro. 2: existio alguna excepcion en el proseco de creacion. 3: no se pudo crear porque ya existe un registro en la db</returns>
        public int RecordCreation(RoleDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    ///verifica si el rol con el nombre ya existe en algun registro 
                    if (db.SEC_ROLE.Where(x => x.NAME.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }

                    RoleModelMapper mapper = new RoleModelMapper();
                    SEC_ROLE record = mapper.MapperT2T1(dbModel);
                    db.SEC_ROLE.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Actualizacion de un registro en la base de datos
        /// </summary>
        /// <param name="dbModel">Recive un objeto que tiene la informacion de los roles</param>
        /// <returns>1. cuando se actualizo sin ningun problema. 2: existio alguna excepcion en el proseso de actualizacion con la base de datos. 3. cuando no se encontro algun registro para la actualizacion, es decir, no existe el registro</returns>
        public int RecordUpdate(RoleDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.NAME = dbModel.Name;
                    record.REMOVED = dbModel.Removed;
                    record.DESCRIPTION = dbModel.Description;

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

        /// <summary>
        /// se eliminara un registro de forma logica, es decir se actualizara a removido en la base de datos 
        /// </summary>
        /// <param name="dbModel">Recive un objeto que tiene la informacion de los roles</param>
        /// <returns>1. cuando se removio logicamente sin ningun problema. 2: existio alguna excepcion en el proseso de eliminacion con la base de datos. 3. cuando no se encontro algun registro para la eliminacion, es decir, no existe el registro</returns>
        public int RecordRemove(RoleDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    //db.SEC_ROLE.Remove(record);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">representa el filtro por el que se buscaran los registros</param>
        /// <returns>una lista con los registros ya filtrados</returns>
        public IEnumerable<RoleDbModel> RecordList(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                /*var listLINQ = from role in db.SEC_ROLE
                               where !role.REMOVED && role.NAME.ToUpper().Contains(filter.ToUpper())
                               select role;*/
                var listaLambda = db.SEC_ROLE.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter)).ToList();
                RoleModelMapper mapper = new RoleModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleDbModel RecordSearch(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.SEC_ROLE.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    RoleModelMapper mapper = new RoleModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">el id del usuario para el que se necesita buscar sus roles</param>
        /// <returns>la lista de roles que estan seleccionados por el usuario</returns>
        public IEnumerable<RoleDbModel> RecordListByUser(int userId)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                var roleListDB = from role in db.SEC_ROLE
                                 where !role.REMOVED
                                 select role;
                //RoleModelMapper mapper = new RoleModelMapper();
                //var roleListDbModel = mapper.MapperT1T2(roleListDB);
                var roleListDbModel = new List<RoleDbModel>();

                foreach (var role in roleListDB)
                {
                    roleListDbModel.Add(new RoleDbModel()
                    {
                        Id = role.ID,
                        Name = role.NAME,
                        Description = role.DESCRIPTION,
                        Removed = role.REMOVED,
                        IsSelectedByUser = db.SEC_USER_ROLE.Where(x => x.ROLEID == role.ID && x.USERID == userId).Count() > 0
                    });
                }

                return roleListDbModel.ToList();
            }
        }
    }
}
