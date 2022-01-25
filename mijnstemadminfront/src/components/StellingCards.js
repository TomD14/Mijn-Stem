import React from "react";
import axios from "axios";
import {Button, Card} from "react-bootstrap";
import {
    XYPlot,
    VerticalGridLines,
    HorizontalGridLines,
    XAxis,
    YAxis,
    VerticalBarSeries,
    VerticalBarSeriesCanvas,
} from "react-vis";
import {forEach} from "react-bootstrap/ElementChildren";

class StellingCards extends React.Component{
    state = {
        stellingId: '',
        naam: '',
        beschrijving: '',
        stellingen: [],
        antwoorden: [],
        useCanvas: false
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
            //     data.map((stelling, keys) => (
            //         this.state.antwoorden = stelling.antwoorden
            // ))

            })
            .catch((e) => {
                console.log(e);
                alert('FUCK');
            });
    };

    // createAnswerGraph = (antwoorden) => {
    //     if (antwoorden === undefined){
    //         return[]
    //     }
    //
    //     let groupBy = function(xs, key) {
    //         return xs.reduce(function(rv, z) {
    //             (rv[z[key]] = rv[z[key]] || []).push(z);
    //             return rv;
    //         }, {});
    //     };
    //     const eindstand = groupBy(antwoorden, "antwoord");
    //
    //     if (eindstand["Eens"] || eindstand["Oneens"] === undefined){
    //         return[]
    //     }
    //     // console.log(eindstand["Eens"].length)
    //     return[
    //         {x: "Eens", y: eindstand["Eens"].length},
    //         {x: "Oneens", y: eindstand["Oneens"].length}
    //     ]
    //
    //
    // }

    getAnswers = (antwoorden) => {
        if (antwoorden === null)
        {
            return null
        }
        let groupBy = function (xs, key) {
            return xs.reduce(function (rv, x) {
                (rv[x[key]] = rv[x[key]] || []).push(x);
                return rv;
            }, {});
        };
        const resultaat = groupBy(antwoorden, "antwoord");



        Object.keys(resultaat).map(key => (
            console.log(resultaat),
            this.state.antwoorden.push({x: {key},y: resultaat[key].length}),
            console.log(this.state.antwoorden)
            )
        )

        return (
            <div>
                {Object.keys(resultaat).map(key => (
                    <div key={key}>Aantal {key}: {resultaat[key].length}</div>
                ))}
            </div>
        )
    }

    displayStellingen = (stellingen) => {
        if (!stellingen.length) return null;

        const {useCanvas} = this.state;
        const BarSeries = useCanvas ? VerticalBarSeriesCanvas : VerticalBarSeries;

        return stellingen.map((stelling, index) => (
            <div key={index}>
                <Card className="mb-3">
                    <Card.Body>
                        <Card.Title>{stelling.title}</Card.Title>
                        <Card.Text>{stelling.beschrijving}
                            {this.getAnswers(stelling.antwoorden)}</Card.Text>
                        <XYPlot
                            className="clustered-stacked-bar-chart-example"
                            xType="ordinal"
                            stackBy="y"
                            width={300}
                            height={300}
                        >
                            <VerticalGridLines />
                            <HorizontalGridLines />
                            <XAxis />
                            <YAxis />
                            <BarSeries
                                cluster="2015"
                                color="#12939A"
                                data = {this.state.antwoorden}
                            />
                        </XYPlot>
                        <Card.Footer><Button onClick={() => {this.deleteStelling(stelling.stellingId)}}>delete</Button></Card.Footer>
                    </Card.Body>
                </Card>
            </div>
        ));
    };

    render()

    {
        return(
            <div>

                {this.displayStellingen(this.state.stellingen)}
            </div>
        )
    }

}

export default StellingCards;