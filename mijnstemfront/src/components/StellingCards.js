import {Card} from "react-bootstrap";
import * as React from "react";
import {Button} from "@mui/material";

export function TextCard() {
    const [selectedValue, setSelectedValue] = React.useState('');
    const handleChange = (event) => {
        setSelectedValue(event.target.value);
    };

    const handleClick = (event) => {
        event.preventDefault();
        console.log(selectedValue);
    }
    return(
        <Card className="mt-5">
            <Card.Body>
                <Card.Title>Text Test</Card.Title>
                <Card.Text>Dit is test text voor mijn Stelling</Card.Text>
            </Card.Body>
            <Card.Footer>
                <textarea onChange={handleChange} className="form-control mb-2" id="TextAnswer"></textarea>
                <div style={{ display: "flex" }}>
                    <Button style={{ marginLeft: "auto" }} onClick={handleClick}>Submit</Button>
                </div>
            </Card.Footer>
        </Card>
    )
}