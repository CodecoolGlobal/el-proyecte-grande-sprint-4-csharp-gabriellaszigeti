import Footer from './components/Footer';
import React from 'react';
import Navbar from './components/Navbar';
import MainPage from './components/MainPage';
import background from "./components/spacex.jpg";
import { Container } from 'reactstrap';
import './App.css';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import DiscoverView from './components/DiscoverView';

function App() {
    return (
        <Container style={{ backgroundImage: `url(${background})`, backgroundSize: 'cover', width: '100%', minHeight:'750px' }}>
            <Navbar />
            <BrowserRouter>
                    <Route path="/" component={MainPage} exact />
                    <Route path="/discover" component={DiscoverView} exact />
            </BrowserRouter>
            <Footer />
        </Container>
    );
}
export default App;

