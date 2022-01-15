import React from "react";
import {TextCard} from "./StellingCards";
import { RadioCard } from "./RadioCard";
import { EensOneensCard } from "./EensOneensCard";

function Home() {

    return <div className= 'container'>
        <h1 className="mt-3">Stelling page</h1>
        <hr className="container hrStyling mb-5" />
        <div>
            <RadioCard/>
            <EensOneensCard/>
            {/*<TextCard/>*/}
            {/*<TextCard/>*/}
        </div>
    </div>
}

export default Home;