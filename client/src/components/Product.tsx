import React from "react";
import {useOrderValue, useSelectedCountryValue} from "../context";
import {SelectedCountryContextType} from "../context/selected-country-context";
import {OrderContextType} from "../context/order-context";
import {IProduct} from "../types/product";
import {roundPrice} from "../helpers";

interface IProductProperties {
    product: IProduct
}
export const Product = (props: IProductProperties) => {
    const { selectedCountry } = useSelectedCountryValue() as SelectedCountryContextType;
    const { addProduct } = useOrderValue() as OrderContextType;

    return (
        <div className="product" data-testid="product">
            <p className="product-title">{props.product.name}</p>
            <img src="/images/product.jpg" alt="generic product" />
            <div className="product-add">
                <span>Price: {selectedCountry.currency}{roundPrice(props.product.price * selectedCountry.exchangeRate)}</span>
                <button type="button" className="btn btn-sm btn-outline-primary"
                    onClick={() => addProduct(props.product)}
                    data-testid="add-product-submit">
                    Add Product
                </button>
            </div>
        </div>        
    );
}