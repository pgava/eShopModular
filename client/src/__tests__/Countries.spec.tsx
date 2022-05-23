import React from 'react';
import { render, cleanup} from '@testing-library/react';
import {SelectedCountryContextType} from "../context/selected-country-context";
import {ICountry} from "../types/country";
import {Countries} from "../components/Countries";  
        
const mockedUsedNavigate = jest.fn();

jest.mock('react-router-dom', () => ({
    ...jest.requireActual('react-router-dom') as any,
    useNavigate: () => mockedUsedNavigate,
}));

jest.mock('../context', () => ({
    useSelectedCountryValue: () => {
        return {
            selectedCountry: {},
            saveCountry: (country: ICountry) => {}
        } as SelectedCountryContextType
    },
}));

beforeEach(cleanup); // clean the DOM!

describe('<Countries />', () => {
    describe('Success', () => {
        it('renders the countries', () => {
            const { queryByTestId } = render(
                <Countries />
            );
            expect(queryByTestId('countries')).toBeTruthy();
        });
        
    });
});

