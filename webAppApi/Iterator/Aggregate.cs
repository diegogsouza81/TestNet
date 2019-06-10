using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAppApi.Iterator
{
        abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }
}