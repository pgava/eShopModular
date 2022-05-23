import React from 'react';
import { render, cleanup, fireEvent } from '@testing-library/react';
import { Logo } from '../components/Logo';

const mockedUsedNavigate = jest.fn();

jest.mock('react-router-dom', () => ({
    ...jest.requireActual('react-router-dom') as any,
    useNavigate: () => mockedUsedNavigate,
}));

beforeEach(cleanup); // clean the DOM!

describe('<Logo />', () => {
    describe('Success', () => {
        it('renders the logo', () => {
            const { queryByTestId } = render(
                <Logo />
            );
            expect(queryByTestId('logo')).toBeTruthy();
        });
        
    });
});

