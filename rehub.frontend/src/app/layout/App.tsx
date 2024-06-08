import { Container} from 'semantic-ui-react';
import 'semantic-ui-css/semantic.min.css'
import NavBar from './NavBar';
import { Outlet } from 'react-router-dom';
import { observer } from 'mobx-react-lite';

function App() {
  return (
    <>
    <NavBar />
    <Container style={{marginTop: '5em'}}>
        <Outlet />
    </Container>
    </>
  )
}
export default observer(App);

