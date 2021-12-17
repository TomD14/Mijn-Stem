import React, { Component } from 'react';
import GoogleLogin from 'react-google-login'

export class Stellingen extends Component {
    static displayName = Stellingen.name;


    responseGoogle = (response) => {
        console.log(response);
        console.log(response.profileObj);
    }

    render() {
        return (
            <>
                <GoogleLogin
                    clientId="971269523830-ck3bmh0egrll1krm28u9vgdao58ghqlu.apps.googleusercontent.com"
                    buttonText="Login"
                    onSucces={this.responseGoogle}
                    onFailure={this.responseGoogle}
                    coockiePolicy={'single_host_origin'}
                />
            </>
        )
    }
}


export default Stellingen
