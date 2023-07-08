﻿using PharmacyApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.DAL
{
    public class UnitOfWork : IDisposable
    {
        private DbContext db = TransitClass.DbContext;
        private PharmaciesRepository pharmRepository;
        private StoresRepository storesRepository;
        private ConsignmentsRepository consRepository;
        private MedicamentsRepository medRepository;

        public PharmaciesRepository Pharmacies
        {
            get
            {
                if (pharmRepository == null)
                    pharmRepository = new PharmaciesRepository(db);
                return pharmRepository;
            }
        }

        public StoresRepository Stores
        {
            get
            {
                if (storesRepository == null)
                    storesRepository = new StoresRepository(db);
                return storesRepository;
            }
        }

        public ConsignmentsRepository Consignments
        {
            get
            {
                if (consRepository == null)
                    consRepository = new ConsignmentsRepository(db);
                return consRepository;
            }
        }

        public MedicamentsRepository Medicaments
        {
            get
            {
                if (medRepository == null)
                    medRepository = new MedicamentsRepository(db);
                return medRepository;
            }
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
