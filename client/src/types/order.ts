import {IProductCart} from "./product";

export interface IOrder {
    totalCost: number;
    shippingCost: number;
    currency: string;
    exchangeRate: number;
    products: IProductCart[];
}