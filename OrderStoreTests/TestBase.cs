using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreTests
{
    public  abstract class TestBase
    {
        protected void Delay(int delay = 10)
        {
            Task.Delay(delay);
        }
    }
}
