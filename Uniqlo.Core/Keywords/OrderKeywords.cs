using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Core.Keywords
{
    public class OrderKeywords
    {
        public const string CreateSuccess = "order_create_success";
        public const string CreateFailure = "order_create_failure";
        public const string UpdateSuccess = "order_update_success";
        public const string UpdateFailure = "order_update_failure";
        public const string DeleteSuccess = "order_delete_success";
        public const string DeleteFailure = "order_delete_failure";


        public const string OrderItemEmpty = "order_item_empty";
        public const string OrderProductOutOfStock = "order_product_out_of_stock";
        public const string OrderCancelSuccess = "order_cancel_successful";

        public const string OrderCannotCancel = "order_cannot_cancel";

        public const string OrderCanceled = "order_canceled";
        public const string OrderConfirmed = "order_confirmed";
        public const string OrderCompleted = "order_completed";
        public const string OrderShipping = "order_shipping";
    }
}
