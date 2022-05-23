import React, { createContext, useState, useContext} from 'react';
import {IOrder} from "../types/order";
import PropTypes from "prop-types";
import {IProduct} from "../types/product";

export const defaultOrder : IOrder = {
  currency: '$',
  exchangeRate: 1,
  totalCost: 0,
  shippingCost: 0,
  products: []
}

export type OrderContextType = {
  order: IOrder;
  addProduct: (product: IProduct) => void;
  removeProducts: () => void;
  incProduct: (id: number) => void;
  decProduct: (id: number) => void;
  setCurrency: (currency: string, rate: number) => void;
};

export const OrderContext = createContext<OrderContextType | null>(null);

// @ts-ignore
export const OrderProvider = ({ children }) => {
  const [order, setOrder] = useState(defaultOrder);
  
  const addProduct = (product: IProduct) => {
    order.totalCost += product.price;
    
    const savedProduct = order.products.find(x => x.product.id === product.id);
    if (savedProduct) {
      savedProduct.quantity += 1;
    }
    else {
      order.products.push({
        quantity: 1,
        product
      });  
    }
    
    setOrder({
      ...order
    });
  };
  const removeProducts = () => {
    order.totalCost = 0;
    order.products = [];
    
    setOrder({
      ...order
    });
  };
  const incProduct = (id: number) => {
    const product = order.products.find(x => x.product.id === id);
    
    if (product) {
      order.totalCost += product.product.price
      product.quantity += 1;
    }

    setOrder({
      ...order
    });
  };
  const decProduct = (id: number) => {
    const product = order.products.find(x => x.product.id === id);

    if (product) {
      order.totalCost -= product.product.price
      product.quantity -= 1;
      
      if (product.quantity === 0) {
        order.products = order.products.filter(o =>  {
          return o.product.id !== product.product.id;
        });
      }
    }

    setOrder({
      ...order
    });
  };
  const setCurrency = (currency: string, rate: number) => {
    order.exchangeRate = rate;
    order.currency = currency;

    setOrder({
      ...order
    });
  };
  
  return <OrderContext.Provider value={{ order, addProduct, removeProducts, incProduct, decProduct, setCurrency }}>{children}</OrderContext.Provider>;
  
};

export const useOrderValue = () => useContext(OrderContext);

OrderProvider.propTypes = {
  children: PropTypes.node.isRequired,
};
