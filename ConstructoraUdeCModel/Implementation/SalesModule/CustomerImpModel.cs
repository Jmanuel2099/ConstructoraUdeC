using ConstructoraUdeCModel.DbModel.SalesModule;
using ConstructoraUdeCModel.Mapper.SalesModule;
using ConstructoraUdeCModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConstructoraUdeCModel.Implementation.SalesModule
{
    public class CustomerImpModel
    {
        public int RecordCreation(CustomerDbModel dbModel)
        {

            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                try
                {
                    ///verifica si el Cliente con el nombre ya existe en algun registro 
                    if (db.CUSTOMER.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    CustomerDbModelMapper mapper = new CustomerDbModelMapper();
                    CUSTOMER record = mapper.MapperT2T1(dbModel);
                    db.CUSTOMER.Add(record);

                    FINANCIAL_INFORMATION infoFinancial = new FINANCIAL_INFORMATION()
                    {
                        INCOME_TOTAL = 0,
                        WORK_DATE = "",
                        TIME_CURRENTE_JOB = "",
                        FAMILY_REFERENCE_NAME = "",
                        FAMILY_REFERENCE_PHONE = "",
                        PERSONAL_REFERENCE = "",
                        PERSONAL_REFERENCE_PHONE = "",
                        CUSTOMER = dbModel.Id
                    };

                    db.FINANCIAL_INFORMATION.Add(infoFinancial);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }
        public int RecordUpdate(CustomerDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.CUSTOMER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.DOCUMENT = dbModel.Document;
                    record.NAME = dbModel.Name;
                    record.LASTNAME = dbModel.LastName;
                    record.PHONE = dbModel.Phone;
                    record.PHOTO = dbModel.Photo;
                    record.BIRTHDATE = dbModel.Date;
                    record.EMAIL = dbModel.Email;
                    record.ADDRESS = dbModel.Address;
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

        public int RecordRemove(CustomerDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.CUSTOMER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
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
        public IEnumerable<CustomerDbModel> RecordList(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.CUSTOMER.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter)).ToList();
                CustomerDbModelMapper mapper = new CustomerDbModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public CustomerDbModel RecordSearch(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.CUSTOMER.Where(x => !x.REMOVED && x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    CustomerDbModelMapper mapper = new CustomerDbModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
        public IEnumerable<CustomerDbModel> RecordListByCity(String CityName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.CUSTOMER.Where(x => !x.REMOVED && x.CITY1.NAME.ToUpper().Contains(CityName)).ToList();
                CustomerDbModelMapper mapper = new CustomerDbModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }
        public IEnumerable<CustomerDbModel> RecordListByCountry(String CountryName)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.CUSTOMER.Where(x => !x.REMOVED && x.CITY1.COUNTRY1.NAME.ToUpper().Contains(CountryName)).ToList();
                CustomerDbModelMapper mapper = new CustomerDbModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public int RecordCreationInfoFinancial(InfoFinancialDbModel dbModel)
        {

            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {

                try
                {
                    ///verifica si el registro con el nombre ya existe en algun registro 
                    if (db.FINANCIAL_INFORMATION.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    InfoFinancialDbModelMapper mapper = new InfoFinancialDbModelMapper();
                    FINANCIAL_INFORMATION record = mapper.MapperT2T1(dbModel);
                    db.FINANCIAL_INFORMATION.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdateInfoFinancial(InfoFinancialDbModel dbModel)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                try
                {
                    var record = db.FINANCIAL_INFORMATION.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.INCOME_TOTAL = dbModel.IncommeTotal;
                    record.WORK_DATE = dbModel.WorkDate;
                    record.TIME_CURRENTE_JOB = dbModel.TimeCurrentJob;
                    record.FAMILY_REFERENCE_NAME = dbModel.FamiliyRefName;
                    record.FAMILY_REFERENCE_PHONE = dbModel.FamilyRefPhone;
                    record.PERSONAL_REFERENCE = dbModel.PersonalRefName;
                    record.PERSONAL_REFERENCE_PHONE = dbModel.PersonalRefPhone;
                    record.CUSTOMER = dbModel.CustomerId;

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

        public IEnumerable<InfoFinancialDbModel> RecordListInfoFinancial(String filter)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var listaLambda = db.FINANCIAL_INFORMATION.Where(x => x.CUSTOMER1.NAME.ToUpper().Contains(filter)).ToList();
                InfoFinancialDbModelMapper mapper = new InfoFinancialDbModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public InfoFinancialDbModel RecordSearchInfoFinancial(int id)
        {
            using (ConstructoraUdeCEntities db = new ConstructoraUdeCEntities())
            {
                var record = db.FINANCIAL_INFORMATION.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    InfoFinancialDbModelMapper mapper = new InfoFinancialDbModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
