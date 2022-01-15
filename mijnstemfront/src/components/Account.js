import React from "react";
import LoginGoogle from "./LoginGoogle";
import LogoutGoogle from "./LogoutGoogle";
import {getCookie} from "../Util";

function Account() {

    let x = getCookie("name")

    return <div className= 'container'>

        <h1>Home page</h1>
        {x ? <LogoutGoogle/>:
            <LoginGoogle/>
        }

    </div>
}

export default Account;