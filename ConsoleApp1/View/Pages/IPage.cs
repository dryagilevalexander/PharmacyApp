using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Pages
{
    public interface IPage
    {
        public string Create();
        public void Dispose();
    }
}
