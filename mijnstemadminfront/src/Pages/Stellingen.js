import React from "react";
import axios from "axios";

class Stellingen extends React.Component {

    state = {
        stellingen: []
    }

    componentDidMount() {
        this.getStellingenPosts();
    }

    getStellingenPosts = () => {
        axios.get('/api')
            .then((response) => {
            const data = response.data;
            this.setState({stellingen: data});
            console.log("Data recieved");
            })
            .catch(() => {
               alert("ALERT!");
            });
    }
}

