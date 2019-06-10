using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace webAppApi.Iterator
{


    /// <summary>
    /// The 'ConcreteIterator' class
    /// </summary>
    /// <summary>
    /// The 'Iterator' abstract class
    /// </summary>

    abstract class Iterator

    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
}
