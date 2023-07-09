using PharmacyApp.DAL.Repository;

namespace PharmacyApp.DAL
{
    public class UnitOfWork: IDisposable
    {
        private IDbContext _db;
        private PharmaciesRepository pharmRepository;
        private StoresRepository storesRepository;
        private ConsignmentsRepository consRepository;
        private MedicamentsRepository medRepository;

        public UnitOfWork()
        {
            _db = DbContext.GetInstance(); 
        }

        public PharmaciesRepository Pharmacies
        {
            get
            {
                if (pharmRepository == null)
                    pharmRepository = new PharmaciesRepository(_db);
                return pharmRepository;
            }
        }

        public StoresRepository Stores
        {
            get
            {
                if (storesRepository == null)
                    storesRepository = new StoresRepository(_db);
                return storesRepository;
            }
        }

        public ConsignmentsRepository Consignments
        {
            get
            {
                if (consRepository == null)
                    consRepository = new ConsignmentsRepository(_db);
                return consRepository;
            }
        }

        public MedicamentsRepository Medicaments
        {
            get
            {
                if (medRepository == null)
                    medRepository = new MedicamentsRepository(_db);
                return medRepository;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
