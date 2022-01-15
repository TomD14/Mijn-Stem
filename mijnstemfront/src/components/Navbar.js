import React from "react";
import { Link } from "react-router-dom";
import "./Navbar.css";
import {getCookie} from "../Util";

function Navbar() {

    let x = getCookie("name");
    let image = getCookie("image")

    return <nav className="navbar bg-dark container-fluid">
        <h4><Link className="link" to="/">Home</Link></h4>
        <h4 className="account"><img className="profilepic rounded-2 mx-2" src={image}/>{x}</h4>
        <h4><Link className="link" to="/Account">Login</Link></h4>
    </nav>
}

export default Navbar;