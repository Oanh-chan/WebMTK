using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.State
{
    public class OrderState : IOrderState
    {
        private readonly BeautyStoreEntities1 db;

        public OrderState(BeautyStoreEntities1 db)
        {
            this.db = db;
        }

        public void ProcessOrder(int orderId)
        {
            var order = db.Orders.FirstOrDefault(o => o.IdOrder == orderId);
            if (order != null)
            {
                order.StatusOrder = 3; // Thay đổi trạng thái của đơn hàng thành "đã xác nhận "
                db.SaveChanges();
            }
        }

        public void CancelOrder(int orderId)
        {
            var order = db.Orders.FirstOrDefault(o => o.IdOrder == orderId);
            if (order != null)
            {
                order.StatusOrder = 2; // Thay đổi trạng thái của đơn hàng thành "Đã hủy"
                db.SaveChanges();
            }
        }

    }

}