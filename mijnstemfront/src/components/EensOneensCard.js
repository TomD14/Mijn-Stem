import {Card} from "react-bootstrap";
import * as React from "react";
import axios from "axios";
import {useEffect} from "react";
import {FormControlLabel, Radio, RadioGroup} from "@mui/material";
import {getCookie} from "../Util";

export function EensOneensCard() {
    const [selectedValue, setSelectedValue] = React.useState('');


    const handleChange = (event) => {
        setSelectedValue(event.target.value);
    };

    const controlProps = (item) => ({
        checked: selectedValue === item,
        onChange: handleChange,
        value: item,
        name: 'answer',
        inputProps: {'aria-label': item},
    });

    const [state, setState] = React.useState({
            stellingen: [],
            userId: '',
        }
    )
    const handleClick = (stellingId) => {
        axios({
            method: 'put',
            url: 'https://localhost:8080/api/StellingAntwoord/' + stellingId,
            dataType: "json",
            data: {Antwoord: selectedValue,UserId: getCookie("account")},
        }).then(() =>{
            window.location.reload();
        }).catch(e => {
            console.log(e);
        });
    }

    const getStellingen = () => {
        axios.get('https://localhost:8080/api/StellingAntwoord/EensOn, ' + getCookie("account"))
            .then((response) => {
                const data = response.data;
                setState({stellingen: data});
                console.log(state);
            })
            .catch((e) => {
                console.log(e);
                alert('Failed to get data');
            });
    };

    useEffect( () => getStellingen(), [setState]);

    const displayRadioCard = (stellingen) => {

        return stellingen.map((stelling, index) => (

            <div key={index}>
                <Card className="mb-3">
                    <Card.Body>
                        <Card.Title>{stelling.title}</Card.Title>
                        <Card.Text>{stelling.beschrijving}</Card.Text>
                    </Card.Body>
                    <Card.Footer>
                        <RadioGroup className="mb-2" row aria-label="antwoord" name="row-radio-buttons-group">
                            <FormControlLabel control={<Radio {...controlProps('Oneens')}/>} label="Oneens" labelPlacement="bottom"/>
                            <FormControlLabel control={<Radio {...controlProps('Eens')}/>} label="Eens" labelPlacement="bottom"/>
                        </RadioGroup>
                        <button onClick={() => handleClick(stelling.stellingId)}>Test</button>
                    </Card.Footer>
                </Card>
            </div>
        ));
    }

    return (
        <div>
            {displayRadioCard(state.stellingen)}
        </div>
    );
}