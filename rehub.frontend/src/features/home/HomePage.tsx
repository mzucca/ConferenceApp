import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Container, Header, Segment, Image } from "semantic-ui-react";
import { useStore } from '../../app/stores/store';
import LoginForm from '../users/LoginForm';
import RegisterForm from '../users/RegisterForm';
import { useTranslation } from 'react-i18next';

export default observer(function HomePage() {
    const { userStore, modalStore } = useStore();
    const { t } = useTranslation();
    return (
        <Segment inverted textAlign='center' vertical className='masthead' >
            <Container text>
                <Header as='h1' inverted>
                    <Image size='massive' src='/assets/logo.png' alt='logo' style={{ marginBottom: 12 }} />
                    {t('welcome')}
                </Header>
                {userStore.isLoggedIn ? (
                    <>
                        <Header as='h2' inverted content={`Welcome back ${userStore.user?.displayName}`} />
                        <Button as={Link} to='/activities' size='huge' inverted>
                            Go to activities!
                        </Button>
                    </>
                ) : (
                    <>
                        <Button primary onClick={() => modalStore.openModal(<LoginForm />)} size='huge' inverted>
                            {t('login')}
                        </Button>
                        <Button secondary onClick={() => modalStore.openModal(<RegisterForm />)} size='huge' inverted>
                            {t('register')}
                        </Button>
                    </>
                )}
            </Container>
        </Segment>
    )
})