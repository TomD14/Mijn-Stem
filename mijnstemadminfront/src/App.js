import React from "react";
import {BrowserRouter as Router, Routes, Route} from "react-router-dom"
import Navbar from "./components/Navbar";
import Home from "./components/Home";
import CreateStelling from "./components/CreateStelling";
import Stellingen from "./components/Stellingen";

function App() {
  return (
      //Navbar
      <Router>
          <Navbar />
          <Routes>

          <Route exact path="/" element={<Home/>}>
          </Route>

          <Route exact path="/Stellingen" element={<Stellingen/>}>
          </Route>

          <Route exact path="/Create" element={<CreateStelling />}>
          </Route>

          </Routes>
      </Router>
  )
}

export default App;
