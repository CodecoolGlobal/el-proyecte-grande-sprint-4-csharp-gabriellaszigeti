import Footer from './components/Footer';
import React from 'react';
import Navbar from './components/Navbar';
import MainPage from './components/MainPage';
import background from "./components/spacex.jpg";
import { Container } from 'reactstrap';
import './App.css';
import {Route, Switch } from 'react-router-dom';
import Login from "./components/Login";
import Signup from "./components/Signup";

function App() {
    return (
        <Container style={{ backgroundImage: `url(${background})`, backgroundSize: 'cover', width: '100%', height: '100vh' }}>
            <Navbar />
                    <Route path="/" component={MainPage} exact />
                    <Route exact path="/login" component={Login} />
                    <Route exact path="/signup" component={Signup} />
            <Footer />
        </Container>
    );
}
export default App;

