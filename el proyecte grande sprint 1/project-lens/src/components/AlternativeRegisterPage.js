import axios from "axios";
import * as React from 'react';
import { useState } from 'react';


export default function Register() {

    const [username, setuserName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    //const [state, setState] = useState({
    //    name: "",
    //    email: "",
    //    password: ""
    //})

    const handleUsername = (e) => {
        setuserName(e.target.value);
    };

    const handleEmail = (e) => {
        setEmail(e.target.value);
    };

    const handlePassword = (e) => {
        setPassword(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const user = { Email: email, Username: username, Password: password };
        axios.post("/api/authentication", user)
            .then(function (response) {
                console.log(response);
            })
        if (username === '' || email === '' || password === '') {
            console.log("please fill in all data");
        } else {
            console.log("registration success!");
        }
    };

    const checkIfUserRegistered = (e) => {
        e.preventDefault();
        let partialUserData = { Email: email, Username: username}
        axios.post("/api/authentication/user-validation", partialUserData)
            .then(function (response) {
                if (response.data === "False") {
                    handleSubmit(e);
                } else {
                    alert("username or email already registered");
                }
                
        })
    }


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
                    value={username} type="text" />

                <label className="label">Email</label>
                <input onChange={handleEmail} className="input"
                    value={email} type="email" />

                <label className="label">Password</label>
                <input onChange={handlePassword} className="input"
                    value={password} type="password" />

                <button className="btn" type="submit" onClick={checkIfUserRegistered}>
                    Submit
                </button>
            </form>
        </div>
    )
}
