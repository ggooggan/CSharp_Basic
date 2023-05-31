using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class ExecuteTest
    {
        public ExecuteTest()
        {

        }

        public void FailExecute()
        {
            int[] array = new int[] { 2, 3, 4, 5 };
            int a = array[200];
        }
    }
}
