import { Order } from "../types/order";
import { Product } from "../types/product";
import { useState } from "react";
import { useAddOrder } from "../hooks/orderHooks";
import { OrderState } from "../types/orderState";

type Args = {
    product: Product;
};

const Orders = ({ product }: Args) => {
    const addOrderMutation = useAddOrder();
    const emptyOrder = {
        orderId: "",
        productId: product.productId,
        customerId: "",
        productCount: 0,
        orderPrice: product.price * product.quantity,
        orderStatus: OrderState.OrderPlaced,
    }

    const [orderItem, setOrder] = useState<Order>(emptyOrder);

    const onOrderSubmitClick = () => {
        addOrderMutation.mutate(orderItem);
        setOrder(emptyOrder);
      };

      return (
        <>          
          <div className="row">
            <div className="col-4">
              <b>Quantity:</b>
            </div>
            <div className="col-4">
              <input
                id="productCount"
                className="h-100"
                type="number"
                value={orderItem.productCount}
                onChange={(e) =>
                    setOrder({ ...orderItem, productCount: parseInt(e.target.value) })
                }
                placeholder="Quantity"
              ></input>
            </div>
            <div className="col-2">
              <button
                className="btn btn-primary"
                onClick={() => onOrderSubmitClick()}
              >
                Order
              </button>
            </div>
          </div>
        </>
      );
}

export default Orders;