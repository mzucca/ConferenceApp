import {Button, Container, Dropdown, Menu, Image} from "semantic-ui-react";
import { Link, NavLink } from "react-router-dom";
import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";
import { useTranslation } from 'react-i18next';
import LanguageSwitcher from "./LanguageSwitcher";
import { Role } from "../models/roles";

export default observer(function NavBar() {
    const {userStore: {user, logout}} = useStore();
    const { t } = useTranslation();
    return (
        <Menu inverted fixed='bottom'>
            <Container>
                <Menu.Item as={NavLink} to='/' header>
                    <img src='/assets/logo.png' alt='logo' style={{marginRight: 10}}/>
                    RiHub
                </Menu.Item>
                <Menu.Item as={NavLink} to='/activities' name={t('sessions')} />
                <Menu.Item as={NavLink} to='/errors' name={t('errors')} />
                <Menu.Item>
                    <Button as={NavLink} to='/createActivity' positive content={t('createSession')} />
                </Menu.Item>
                {user?.role === Role.ADMIN &&
                    <Menu.Item>
                        <Button as={NavLink} to='/admin' positive content='Admin' />
                    </Menu.Item>
                }
                <Menu.Item position='right'>
                    <Image avatar spaced='right' src={user?.image || '/assets/user.png'} />
                    <Dropdown pointing='top left' text={user?.displayName}>
                        <Dropdown.Menu>
                            <Dropdown.Item as={Link} to={`/profiles/${user?.username}`} text='My Profile' icon='user' />
                            <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                        </Dropdown.Menu>
                    </Dropdown>
                    <LanguageSwitcher />
                </Menu.Item>
            </Container>
        </Menu>
    )
})