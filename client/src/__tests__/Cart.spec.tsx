import React from 'react';
import { render, cleanup} from '@testing-library/react';
import { Cart } from '../components/Cart';
import {OrderContextType} from "../context/order-context";
import {SelectedCountryContextType} from "../context/selected-country-context";  
        
const mockedUsedNavigate = jest.fn();

jest.mock('react-router-dom', () => ({
    ...jest.requireActual('react-router-dom') as any,
    useNavigate: () => mockedUsedNavigate,
}));

jest.mock('../context', () => ({
    useOrderValue: () => {
        return {
            order: {},
            setCurrency: (currency: string, rate: number) => {}
        } as OrderContextType
    },
    useSelectedCountryValue: () => {
        return {
            selectedCountry: {}
        } as SelectedCountryContextType
    },
}));

beforeEach(cleanup); // clean the DOM!

describe('<Cart />', () => {
    describe('Success', () => {
        it('renders the cart', () => {
            const { queryByTestId } = render(
                <Cart />
            );
            expect(queryByTestId('cart')).toBeTruthy();
        });
        
    });
});

