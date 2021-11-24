import * as React from 'react';
import Box from '@mui/material/Box';
import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';
import { useState, useEffect } from 'react';
import axios from "axios";



export default function Register() {

    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    //const [state, setState] = useState({
    //    name: "",
    //    email: "",
    //    password: ""
    //})

    const handleUsername = (e) => {
        setName(e.target.value);
    };

    const handleEmail = (e) => {
        setEmail(e.target.value);
    };

    const handlePassword = (e) => {
        setPassword(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const user = { Email: email,  Username : name,  Password: password};
        axios.post("/api/authentication", user)
            .then(function (response) {
                console.log(response);
            })


        if (name === '' || email === '' || password === '') {
            console.log("please fill in all data");
        } else {
            console.log("registration success!");
        }
    };


    return (

        <div className="form">
            <div>
                <h1>User Registration</h1>
            </div>
            <div className="messages">
            </div>

            <form >
                <label className="label">Name</label>
                <input onChange={handleUsername} className="input"
                    value={name} type="text" />

                <label className="label">Email</label>
                <input onChange={handleEmail} className="input"
                    value={email} type="email" />

                <label className="label">Password</label>
                <input onChange={handlePassword} className="input"
                    value={password} type="password" />

                <button className="btn" type="submit" onClick={handleSubmit}>
                    Submit
                </button>
            </form>
        </div>
    )
}
