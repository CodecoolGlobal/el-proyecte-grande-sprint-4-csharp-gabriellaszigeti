import './App.css';
import React from 'react';
import Navbar from './components/Navbar';
import MainPage from './components/MainPage';
import Footer from './components/Footer';
import background from "./components/spacex.jpg";
import { Container } from 'reactstrap';

function App() {
    return (
        <Container style={{ backgroundImage: `url(${background})`, backgroundSize: 'cover', width:'100%' }}>
            <Navbar>
                </Navbar>
            <MainPage>
            </MainPage>
            <Footer>
                </Footer>
            </Container>
  );
}

export default App;
