import React from "react";
import {BrowserRouter as Router, Routes, Route} from "react-router-dom"
import Navbar from "./components/Navbar";
import Home from "./components/Home";
import Account from "./components/Account";

function App() {
    return (
        //Navbar
        <Router>
            <Navbar />
            <Routes>

                <Route exact path="/" element={<Home/>}>
                </Route>

                <Route exact path="/Account" element={<Account/>}>
                </Route>

            </Routes>
        </Router>
    )
}

export default App;
