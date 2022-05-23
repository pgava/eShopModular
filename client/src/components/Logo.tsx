import React from "react";
import { useNavigate } from "react-router-dom";

export const Logo = () => {
    const navigate = useNavigate();
    const routeChange = () =>{
        navigate('/');
    }
    return (
        <div role="button" onClick={routeChange} data-testid="logo">
            <img src="/images/logo.png" alt="eshop" />
        </div>        
    );
}