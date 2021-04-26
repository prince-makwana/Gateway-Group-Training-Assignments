using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAppTest.CustomAttribute
{
    class TestOrderAttribute : Attribute
    {
        public int Sequence { get; set; }

        public TestOrderAttribute(int sequence)
        {
            Sequence = sequence;
        }
    }
}
