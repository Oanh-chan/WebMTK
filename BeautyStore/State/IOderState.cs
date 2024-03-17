using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.State
{
    interface IOrderState
    {
        void ProcessOrder(int orderId);
        void CancelOrder(int orderId);
    }

}