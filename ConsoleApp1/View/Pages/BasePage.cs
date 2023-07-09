using PharmacyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Pages
{
    public abstract class BasePage: IDisposable
    {
        protected UnitOfWork _unitOfWork;
        public BasePage()
        {
            _unitOfWork = new UnitOfWork();
        }

        public abstract string Create();
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
