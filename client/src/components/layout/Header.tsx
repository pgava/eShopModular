import React from "react";
import {Countries} from "../Countries";
import {Cart} from "../Cart";
import {Logo} from "../Logo";

export const Header = () => {
    return (
  <header className="header" data-testid="header">
      <nav>
          <div className="logo">
              <Logo/>
          </div>
          <div className="countries">
              <ul>
                  <li>
                      <Countries />
                  </li>
              </ul>
          </div>
          <div className="cart">
              <ul>
                  <li>
                      <Cart />
                  </li>
              </ul>
          </div>
      </nav>
  </header>          
    );
};