import React  from "react";
import {useOrderValue} from "../context";
import {OrderContextType} from "../context/order-context";
import {IOrder} from "../types/order";
import {FaMinusCircle, FaPlusCircle} from "react-icons/fa";
import {roundPrice} from "../helpers";

interface IOrderProperties {
    order: IOrder
}
export const Order = (props: IOrderProperties) => {
    const { incProduct, decProduct } = useOrderValue() as OrderContextType;

    return (
        <>
        {props.order.products &&
            props.order.products.map((key) => (
            <div key={key.product.id} className="row mb-2 cart-content" data-testid="order">
                <div className="col-2">
                    <img src="/images/product.jpg" alt="generic product" />
                </div>
                <div className="col-2">
                    <h5>{key.product.name}</h5>
                </div>
                <div className="col-2">
                    <h5>{props.order.currency}{roundPrice(key.product.price * props.order.exchangeRate)}</h5>
                </div>
                <div className="col-2">
                    <span className="product-minus" role="button" onClick={() => decProduct(key.product.id)}><FaMinusCircle /></span>
                    <span className="product-price">{key.quantity}</span>
                    <span className="product-plus" role="button" onClick={() => incProduct(key.product.id)}><FaPlusCircle /></span>
                </div>

            </div>
        ))}
        </>    
    );
}