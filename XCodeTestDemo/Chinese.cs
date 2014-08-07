using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCodeTestDemo
{
    class Chinese : IHuman
    {
        #region IHuman Members

        public void eat()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IHello Members

        public void SatHello()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
