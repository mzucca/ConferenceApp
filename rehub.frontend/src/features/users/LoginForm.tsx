import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import { Button, Divider, Header, Label, Segment } from "semantic-ui-react";
import MyTextInput from "../../app/common/form/MyTextInput";
import { useStore } from "../../app/stores/store";
import { useTranslation } from 'react-i18next';
import { GoogleLogin } from "@react-oauth/google";

export default observer(function LoginForm() {
    const { userStore } = useStore();
    const { t } = useTranslation();

    return (
            <Formik
                initialValues={{ email: '', password: '', error: null }}
                onSubmit={(values, { setErrors }) =>
                    userStore.login(values).catch(error => setErrors({ error: 'Invalid email or password' }))}
            >
                {({ handleSubmit, isSubmitting, errors }) => (
                    <Segment>
                        <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                            <Header as='h2' content='Login to Reactivities' color="teal" textAlign="center" />
                            <MyTextInput placeholder="Email" name='email' />
                            <MyTextInput placeholder="Password" name='password' type='password' />
                            <ErrorMessage name='error' render={() => 
                                <Label style={{ marginBottom: 10 }} basic color='red' content={errors.error} />} />
                            <Button loading={isSubmitting} positive content='Login' type="submit" fluid />
                        </Form>
                        <Divider horizontal>Or</Divider>
                            <GoogleLogin 
                        onSuccess={credentialResponse => {
                            userStore.externalLogin('google', credentialResponse.credential!);
                        }}
                        onError={()=>console.log('Login Failure')}
                            />
                    </Segment>
                )}
            </Formik>

    )
})