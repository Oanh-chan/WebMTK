using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.Models
{
    public interface IPrototype<T>
    {
        T Clone();
    }

}