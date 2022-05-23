import { useState, useEffect } from 'react';
import {ICountry, defaultCountry} from "../types/country";
import {countriesApi, productsApi, shippingCostApi} from "../constants";
import {IProduct} from "../types/product";
import {IOrder} from "../types/order";

export const useCountries = () => {
    const [countries, setCountries] = useState<ICountry[]>([]);

    useEffect(() => {
        fetch(`${countriesApi}`)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(
                        `This is an HTTP error: The status is ${response.status}`
                    );
                }
                return response.json();
            })
            .then((actualData) => {
                actualData.unshift(defaultCountry)
                setCountries(actualData);
                }
            )
            .catch((err) => {
                console.log(err.message);
            });
    }, []);

    return { countries };
};

export const useProducts = () => {
    const [products, setProducts] = useState<IProduct[]>([]);

    useEffect(() => {
        fetch(`${productsApi}`)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(
                        `This is an HTTP error: The status is ${response.status}`
                    );
                }
                return response.json();
            })
            .then((actualData) => {
                setProducts(actualData);
                }
            )
            .catch((err) => {
                console.log(err.message);
            });
    }, []);

    return { products };
};

export const useShippingCost = (order: IOrder) => {
    const [shippingCost, setShippingCost] = useState<number>(0);

    useEffect(() => {
        fetch(`${shippingCostApi}/${order.totalCost}`)
            .then((response) => {
                if (!response.ok) {
                    throw new Error(
                        `This is an HTTP error: The status is ${response.status}`
                    );
                }
                return response.json();
            })
            .then((actualData) => {
                setShippingCost(actualData);
                }
            )
            .catch((err) => {
                console.log(err.message);
            });
    }, [order.totalCost]);

    return { shippingCost };
};
