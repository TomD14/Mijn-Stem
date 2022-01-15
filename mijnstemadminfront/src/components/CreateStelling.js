import React, {useState} from "react";
import axios from "axios";
import {FormControlLabel, Radio, RadioGroup} from "@mui/material";

function CreateStelling() {

    const [input, setInput] = useState({
        title: '',
        beschrijving: '',
        type: ''
    })

    function handleChange(event) {
        const {name, value} = event.target;

        setInput(prevInput => {
            return {
                ...prevInput,
                [name]: value
            }
        })
    }

    function handleClick(event) {
        console.log(input);

        axios({
            method: 'post',
            url: 'https://localhost:8080/api/Stellingen',
            dataType: "json",
            data: {...input, antwoorden: []},
        }).then(() =>{
        }).catch(e => {
           console.log(e);
        });
    }



    const controlProps = (item) => ({
        checked: input.type === item,
        onChange: handleChange,
        value: item,
        name: 'type',
        inputProps: {'aria-label': item},
    });

    return <div className= 'container mt-3 mb-3'>
        <h1>Create Stelling page</h1>
        <form>
            <div className="form-group mb-3">
                <input onChange={handleChange} name="title" value={input.title} autoComplete="off" className="form-control" placeholder="Stelling naam"></input>
            </div>

            <div className="form-group mb-3">
                <textarea onChange={handleChange} name="beschrijving" value={input.beschrijving} autoComplete="off" className="form-control" placeholder="Beschrijving"></textarea>
            </div>

            <div className="form-group mb-3">
                <RadioGroup className="mb-2" row aria-label="antwoord" name="row-radio-buttons-group">
                    <FormControlLabel control={<Radio {...controlProps('Radio')}></Radio>} label="Radio" labelPlacement="bottom"></FormControlLabel>
                    <FormControlLabel control={<Radio {...controlProps('EensOn')}></Radio>} label="EensOn" labelPlacement="bottom"></FormControlLabel>
                    <FormControlLabel control={<Radio {...controlProps('Text')}></Radio>} label="Text" labelPlacement="bottom"></FormControlLabel>
                </RadioGroup>
            </div>

            <button onClick={handleClick} className="btn btn-lg btn-info">Add Stelling</button>
        </form>
    </div>
}

export default CreateStelling;