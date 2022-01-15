import React from "react";
import { Link } from "react-router-dom";
import "./Navbar.css";

function Navbar() {
    return <nav className="navbar bg-dark container-fluid">
        <h4><Link className="link ms-5" to="/">Home</Link></h4>
        <h4><Link className="link" to="/Stellingen">Stellingen</Link></h4>
        <h4><Link className="link me-5" to="/Create">Create Stellingen</Link></h4>
    </nav>
}

export default Navbar;