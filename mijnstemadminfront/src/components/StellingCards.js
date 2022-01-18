import React, {useRef} from "react";
import axios from "axios";
import {Button, Card} from "react-bootstrap";
import {List} from "@mui/material";

const TestData =
    [
        {userId: '1273872',antwoord: 'Eens'},
        {userId: '3423453',antwoord: 'Oneens'},
        {userId: '454355354',antwoord: 'Oneens'},
        {userId: '435453454',antwoord: 'Eens'},
        {userId: '54435454534',antwoord: 'Oneens'},
        {userId: '4534545',antwoord: 'Eens'},
        {userId: '1235476773872',antwoord: 'Eens'},
        {userId: '12723456783872',antwoord: 'Eens'},
        {userId: '42069',antwoord: 'Oneens'}
    ]




class StellingCards extends React.Component{
    state = {
        stellingId: '',
        naam: '',
        beschrijving: '',
        stellingen: [],
        antwoorden: [],
        BarGraphData: []
    };


    componentDidMount = () => {
        this.getStellingen()
    };

    deleteStelling = (stellingId) => {
        axios.delete('https://localhost:8080/api/Stellingen/' + stellingId)
            .then(() => {
                window.location.reload();
            });
    };

    getStellingen = () => {
        axios.get('https://localhost:8080/api/Stellingen/')
            .then((response) => {
                const data = response.data;
                this.setState({stellingen: data});
                console.log(data);
            })
            .catch((e) => {
                console.log(e);
                alert('FUCK');
            });
    };

    getAnswers = (antwoorden) => {
        let groupBy = function(xs, key) {
            return xs.reduce(function(rv, x) {
                (rv[x[key]] = rv[x[key]] || []).push(x);
                return rv;
            }, {});
        };
        const resultaat = groupBy(antwoorden, "antwoord");
        // console.log(resultaat);
        //
        // Object.keys(resultaat).map(key =>(
        //    this.state.BarGraphData.add(resultaat.title, resultaat.length),
        //     console.log(this.state.BarGraphData)))

        return(
            <div>
                {Object.keys(resultaat).map(key => (
                    <div key={key}>Aantal {key}: {resultaat[key].length}</div>
                ))}
            </div>
        )

    }

    displayStellingen = (stellingen) => {
        if (!stellingen.length) return null;

        return stellingen.map((stelling, index) => (
            <div key={index}>
                <Card className="mb-3">
                    <Card.Body>
                        <Card.Title>{stelling.title}</Card.Title>
                        <Card.Text>{stelling.beschrijving}
                            {this.getAnswers(stelling.antwoorden)}

                        </Card.Text>
                        <Card.Footer><Button onClick={() => {this.deleteStelling(stelling.stellingId)}}>delete</Button></Card.Footer>
                    </Card.Body>
                </Card>
            </div>
        ));
    };

    render() {
        return(
            <div>
                {this.displayStellingen(this.state.stellingen)}
            </div>
        )
    }

}

export default StellingCards;