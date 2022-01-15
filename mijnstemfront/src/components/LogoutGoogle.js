import React from "react";
import {GoogleLogout} from 'react-google-login';

const clientId = '971269523830-o75o0ndgk23kji4nqeo3jrq69u66jg80.apps.googleusercontent.com';

function Logout() {
    const onSucces = () => {
        alert('You have logged out');

        document.cookie = "name=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
        document.cookie = "account=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
        document.cookie = "image=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
        window.location.reload();
    };


    return (
        <div>
            <GoogleLogout
            clientId={clientId}
            buttonText="Logout"
            onLogoutSuccess={onSucces}
            />
        </div>
    )
}

export default Logout;