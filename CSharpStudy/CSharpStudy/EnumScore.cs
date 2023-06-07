using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    public enum EnumScore
    {
        [Description("score 1")]
        SCORE01,
        [Description("score 2")]
        SCORE02,
        [Description("score 3")]
        SCORE03,
    }

    public enum EnumTEST
    {
        [Description("TEST 1")]
        TEST01,
        [Description("TEST 2")]
        TEST02,
        [Description("TEST 3")]
        TEST03,
    }
}
