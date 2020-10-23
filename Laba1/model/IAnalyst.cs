using System;
using System.Collections.Generic;
using System.Text;

namespace Laba1.model
{
    interface IAnalyst
    {
        public Dictionary<Place, int> FreqAnal();
    }
}
