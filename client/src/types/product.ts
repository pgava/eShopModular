export interface IProductCart {
    quantity: number;
    product: IProduct;
}

export interface IProduct {
    id: number;
    name: string;
    price: number;
    imageUrl: string;
}