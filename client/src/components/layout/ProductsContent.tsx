import React from "react";
import {useProducts} from "../../hooks";
import {Product} from "../Product";

export const ProductsContent = () => {
    const { products } = useProducts();

    return (
        <section className="content">
            <div className="container-fluid">
                <div className="row">
                    {products &&
                        products.map((key) => (
                            <div key={key.id} className="col-4 mb-4">
                                <Product product={key} />
                            </div>
                        ))}
                </div>
            </div>
        </section>
    );
}

    
        
