import React from "react";
import TopNavbar from "./components/TopNavbar";
import HomePage from "./pages/Home"
import StellingenPage from "./pages/Stellingen"
import {BrowserRouter, Routes, Route, Navigate} from 'react-router-dom';

function App() {
  return (
      <>
          <BrowserRouter>
              <React.Fragment>
              <TopNavbar />
              <main>
                  <Routes>
                      <Route path="/Home" exact={true} component={HomePage}/>
                      <Route path="/Stelling" component={StellingenPage}/>
                  </Routes>
              </main>
              </React.Fragment>
          </BrowserRouter>
      </>
  );
}

export default App;
