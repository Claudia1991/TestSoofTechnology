using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SooftApi.Server
{
    public class Proxy
    {
        #region Properties
        private bool isMook;
        #endregion

        #region Constructor
        public Proxy(bool isMook)
        {
            this.isMook = isMook;
        }
        #endregion

        #region Methods
        public void Execute()
        {

        }

        public void ExecuteWithoutMock()
        {

        }

        public void ExecuteMock()
        {

        }
        #endregion
    }
}
