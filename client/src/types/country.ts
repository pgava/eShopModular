export interface ICountry {
    id: number;
    countryName: string;
    currency: string;
    exchangeRate: number;
}

export const defaultCountry : ICountry = {
    id: 0,
    countryName: 'Select country',
    currency: '$',
    exchangeRate: 1
}
