import React, { Component } from 'react';
import { Container, Col, Row } from 'reactstrap';
import { NavMenu } from './NavMenu';
import OpenNav from './openNav';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <NavMenu />
                <Container fluid className='w-full'>
                    <Row>
                        <Col xs="auto" className='p-0'>
                            <OpenNav />
                        </Col>
                        <Col xs="auto" className='p-0'>
                            <Container>
                                {this.props.children}
                            </Container>
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}
