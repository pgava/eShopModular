import React, {useContext, useState} from "react";
import {OrderContext} from "../../context";
import {OrderContextType} from "../../context/order-context";
import {useShippingCost} from "../../hooks";
import {Order} from "../Order"
import {orderApi} from "../../constants";
import {roundPrice} from "../../helpers";
        
export const CartContent = () => {
    const { order, removeProducts } = useContext(OrderContext) as OrderContextType;
    const { shippingCost } = useShippingCost(order);
    const [message, setMessage] = useState<string>('There no products in the cart');
    
    const placeOrder = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(order)
        };
        fetch(`${orderApi}`, requestOptions)
            .then(data => {
                setMessage('Order has been submitted. Thank you!!!');
                removeProducts();
            })
            .catch((err) => {
                    console.log(err.message);
                });
    }
    
    return (
    <section  className="content">
        {order.totalCost > 0 ?
            <div className="container-fluid">
                <div className="row mb-3">
                    <div className="col-12">
                        <h3>Order</h3>
                    </div>
                </div>
                <Order order={order} />
                <div className="row mt-5">
                    <div className="col-2">
                        <div>
                            <p>Products cost: {order.currency}{roundPrice(order.totalCost * order.exchangeRate)}</p>
                            <p>Shipping cost: {order.currency}{roundPrice(shippingCost * order.exchangeRate)}</p>
                            <hr />
                            <p>Total: {order.currency}{roundPrice((order.totalCost + shippingCost) * order.exchangeRate)}</p>
                        </div>
                    </div>
                    <div className="col-10">
                    </div>
                </div>
                <div className="row">
                    <div className="col-2">
                        <button type="button" className="btn btn-sm btn-warning"
                                onClick={() => placeOrder()}
                                data-testid="place-order-submit">
                            Place Order
                        </button>
                    </div>
                </div>
            </div>
            : 
            <h4>{message}</h4>}
    </section>
);
}
    
        
