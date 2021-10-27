import Footer from './components/Footer';
import React from 'react';
import Navbar from './components/Navbar';
import MainPage from './components/MainPage';
import background from "./components/spacex.jpg";
import { Container } from 'reactstrap';

function App() {
    return (
        <Container style={{ backgroundImage: `url(${background})`, backgroundSize: 'cover', width:'100%' }}>
            <Navbar>
                </Navbar>
            <MainPage>
            </MainPage>
                <Footer/>
            </Container>
  );
}
export default App;
