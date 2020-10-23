using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLine.CustomExceptions
{
    public class ElementAlreadyExistsException : Exception
    {
        public ElementAlreadyExistsException()
        {

        }

        public ElementAlreadyExistsException(string name)
            : base(String.Format("Element already exists: {0}", name))
        {

        }
    }
}
