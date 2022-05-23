import React, {useContext, useEffect} from "react";
import { useNavigate } from "react-router-dom";
import {FaShoppingCart} from "react-icons/fa";
import {OrderContextType} from "../context/order-context";
import {useSelectedCountryValue, useOrderValue} from "../context";
import {SelectedCountryContextType} from "../context/selected-country-context";
import {roundPrice} from "../helpers";

export const Cart = () => {
    const navigate = useNavigate();
    const { order, setCurrency } = useOrderValue() as OrderContextType;
    const { selectedCountry } = useSelectedCountryValue() as SelectedCountryContextType;
    
    useEffect(() =>{
        if (order) {
            setCurrency(selectedCountry.currency, selectedCountry.exchangeRate);
        }
            
    }, [selectedCountry]);
    
    const routeChange = () =>{
        navigate('/checkout');
    }
    
    return (
        <div role="button" onClick={routeChange} data-testid="cart">
            <FaShoppingCart />
            <span>{order && order.currency}{order && roundPrice(order.totalCost * order.exchangeRate)}</span>
        </div>        
    );
}