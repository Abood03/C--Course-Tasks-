using System;
using System.Collections.Generic;
using System.Text;

namespace Task07_NestedTypes_Debugging
{
    public class Company
    {
        private string s = "Company class";

        public class Department
        {
            public void Printst(Company co)
            {
                Console.WriteLine(co.s);
            }
        }
    }
}
