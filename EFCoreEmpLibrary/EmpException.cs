using System;

namespace EFCoreEmpLibrary
{
    public class EmpException : Exception
    {
        public EmpException(string errMsg) : base(errMsg)
        {

        }
    }
}
