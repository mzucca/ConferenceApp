import { Button, Container, Menu } from "semantic-ui-react";
import { NavLink } from "react-router-dom";

export default function NavBar() {
    return (
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item as={NavLink} to='/' header>
                    <img src="/assets/LOGO_white_01.svg" alt="logo" style={{marginRight: '10px'}}/>
                </Menu.Item>
                <Menu.Item as={NavLink} to='/sessions' name='Appointments' />
                <Menu.Item>
                    <Button positive content="Create Appointment" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}