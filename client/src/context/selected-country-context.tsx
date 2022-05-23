import React, { createContext, useState, useContext} from 'react';
import {defaultCountry, ICountry} from "../types/country";
import PropTypes from "prop-types";

export type SelectedCountryContextType = {
  selectedCountry: ICountry;
  saveCountry: (country: ICountry) => void;
};

export const SelectedCountryContext = createContext<SelectedCountryContextType | null>(null);

// @ts-ignore
export const SelectedCountryProvider = ({ children }) => {
  const [selectedCountry, setSelectedCountry] = useState(defaultCountry);
  const saveCountry = (country: ICountry) => {
    setSelectedCountry({
      ...country
    });
  };

  return <SelectedCountryContext.Provider value={{ selectedCountry, saveCountry }}>{children}</SelectedCountryContext.Provider>;
  
};

export const useSelectedCountryValue = () => useContext(SelectedCountryContext);

SelectedCountryProvider.propTypes = {
  children: PropTypes.node.isRequired,
};
