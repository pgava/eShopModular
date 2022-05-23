import React from 'react';
import {Header} from "./components/layout/Header";
import {ProductsContent} from "./components/layout/ProductsContent";
import {CartContent} from "./components/layout/CartContent";
import {
    BrowserRouter,
    Routes,
    Route,
} from "react-router-dom";
import {OrderProvider, SelectedCountryProvider} from "./context";

export const App = () => (
    <OrderProvider>
        <SelectedCountryProvider>
            <div className="App">
                <BrowserRouter>
                    <Header />
                    <Routes>
                        <Route path="/" element={<ProductsContent />} />
                        <Route path="/checkout" element={<CartContent />} />
                    </Routes>
                </BrowserRouter>
            </div>
        </SelectedCountryProvider>
    </OrderProvider>
);
