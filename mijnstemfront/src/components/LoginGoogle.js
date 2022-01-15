import React from 'react';
import GoogleLogin from 'react-google-login';

const clientId = '971269523830-o75o0ndgk23kji4nqeo3jrq69u66jg80.apps.googleusercontent.com';

function LoginGoogle(){


    const onSucces = (res) => {
      console.log('[Login succes] current', res.profileObj);
      const {googleId, imageUrl, name} = res.profileObj;

        const now = new Date();
        const time = now.getTime();
        const expireTime = time + 1000 * 36000;
        now.setTime(expireTime);

        document.cookie = `account=${googleId}; expires=${now.toUTCString()};`;
        document.cookie = `image=${imageUrl}; expires=${now.toUTCString()};`;
        document.cookie = `name=${name}; expires=${now.toUTCString()};`;
        window.location.reload();
    };
    
    const onFailure = (res) => {
      console.log('[Login failed] res', res);
    };

    return (
        <div>
            <GoogleLogin
                clientId={clientId}
                buttonText="Login"
                onSuccess={onSucces}
                onFailure={onFailure}
                cookiePolicy={'single_host_origin'}
                style={{ marginTop: '100px'}}
                isSignedIn={true}
            />
        </div>
    )
}

export  default LoginGoogle;