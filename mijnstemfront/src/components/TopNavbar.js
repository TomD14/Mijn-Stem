import React from "react";
import { NavLink } from 'react-router-dom'

const TopNavbar = props => (
    <header>
        <div className="TopNavbar__logo">
            <h1>Mijn Stem</h1>
        </div>
        <div className="TopNavbar__item">
            <ul>
                <li>
                    <NavLink to='/Home'>Home</NavLink>
                </li>
                <li>
                    <NavLink to='/Stellingen'>Stellingen</NavLink>
                </li>
            </ul>
        </div>
    </header>
)


export default TopNavbar;