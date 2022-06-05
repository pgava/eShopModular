import React from 'react';
import {render, cleanup, fireEvent} from '@testing-library/react';
import {SelectedCountryContextType} from "../context/selected-country-context";
import {ICountry} from "../types/country";
import {Countries} from "../components/Countries";
import {useCountries} from "../hooks";

        
const mockedUsedNavigate = jest.fn();
const mockedSaveCountry = jest.fn();

jest.mock('react-router-dom', () => ({
    ...jest.requireActual('react-router-dom') as any,
    useNavigate: () => mockedUsedNavigate,
}));

jest.mock('../context', () => ({
    useSelectedCountryValue: () => {
        return {
            selectedCountry: {},
            saveCountry: (country: ICountry) => {mockedSaveCountry()}
        } as SelectedCountryContextType
    }
}));

jest.mock('../hooks', () => ({
    useCountries: () => {
        return {
            countries: [{
                id: 1,
                countryName: 'aa',
                currency: '$',
                exchangeRate: 1
            }] as ICountry[]
        }
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
        it('renders the countries and accepts a change', () => {
            const { queryByTestId } = render(
                <Countries />
            );
            const select = queryByTestId('countries');
            expect(select).toBeTruthy();
            if (select) {
                fireEvent.change(select, {
                    target: {value: '1'}
                });
                expect(mockedSaveCountry).toHaveBeenCalledTimes(1);
            }
        });
    });
});

