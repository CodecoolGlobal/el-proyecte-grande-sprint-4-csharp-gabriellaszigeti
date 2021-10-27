import Footer from './components/Footer';
import React from 'react';
import Navbar from './components/Navbar';
import MainPage from './components/MainPage';
import background from "./components/spacex.jpg";
import { Container } from 'reactstrap';
import './App.css';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

function App() {
    return (
        <Container style={{ backgroundImage: `url(${background})`, backgroundSize: 'cover', width: '100%' }}>
            <Navbar />
            <BrowserRouter>
                <Switch>
                    <Route path="/" component={MainPage} exact />
                </Switch>
            </BrowserRouter>
            <Footer />
        </Container>
    );
}
export default App;
