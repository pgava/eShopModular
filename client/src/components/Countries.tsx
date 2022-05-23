import React, {ChangeEvent, useContext} from "react";
import {useCountries} from "../hooks";
import {useSelectedCountryValue} from "../context";
import {SelectedCountryContextType} from "../context/selected-country-context";

export const Countries = () => {
    const { countries } = useCountries();
    const { selectedCountry, saveCountry } = useSelectedCountryValue() as SelectedCountryContextType;
    
    const change = (event: ChangeEvent<HTMLSelectElement>) => {
        const country = countries.find(x => x.id === Number(event.target.value));
        
        if (country) {
            saveCountry(country);
        }
    }
    
    return (
        <select onChange={change} value={selectedCountry.id} data-testid="countries">
            {countries &&
                countries.map(({ id, countryName }) => (
                    <option key={id} value={id}>
                        {countryName}
                    </option>
                ))}
        </select>        
    );
}