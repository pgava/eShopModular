import React from 'react';
import { render, cleanup} from '@testing-library/react';
import { Cart } from '../components/Cart';
import {OrderContextType} from "../context/order-context";
import {SelectedCountryContextType} from "../context/selected-country-context";
import {Product} from "../components/Product";
import {IProduct} from "../types/product";  
        
const mockedUsedNavigate = jest.fn();

jest.mock('react-router-dom', () => ({
    ...jest.requireActual('react-router-dom') as any,
    useNavigate: () => mockedUsedNavigate,
}));

jest.mock('../context', () => ({
    useOrderValue: () => {
        return {
            addProduct: (product: IProduct) => {}
        } as OrderContextType
    },
    useSelectedCountryValue: () => {
        return {
            selectedCountry: {}
        } as SelectedCountryContextType
    },
}));

beforeEach(cleanup); // clean the DOM!

describe('<Product />', () => {
    describe('Success', () => {
        it('renders the cart', () => {
            const { queryByTestId } = render(
                <Product product={{
                    id: 1,
                    price: 10,
                    name: "pr1"
                }} />
            );
            expect(queryByTestId('product')).toBeTruthy();
        });
        
    });
});

