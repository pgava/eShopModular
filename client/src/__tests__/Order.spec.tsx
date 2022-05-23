import React from 'react';
import { render, cleanup} from '@testing-library/react';
import {OrderContextType} from "../context/order-context";
import {Order} from "../components/Order";  
        
const mockedUsedNavigate = jest.fn();

jest.mock('react-router-dom', () => ({
    ...jest.requireActual('react-router-dom') as any,
    useNavigate: () => mockedUsedNavigate,
}));

jest.mock('../context', () => ({
    useOrderValue: () => {
        return {
            incProduct: (id: number) => {},
            decProduct: (id: number) => {}
        } as OrderContextType
    }
}));

beforeEach(cleanup); // clean the DOM!

describe('<Order />', () => {
    describe('Success', () => {
        it('renders the cart', () => {
            const { queryByTestId } = render(
                <Order order={{
                    totalCost: 1,
                    products: [{
                        quantity: 1,
                        product: {
                            id: 1,
                            name: 'pr1',
                            price: 1
                        }
                    }],
                    exchangeRate: 1,
                    currency: '$',
                    shippingCost: 0
                }} />
            );
            expect(queryByTestId('order')).toBeTruthy();
        });
        
    });
});

