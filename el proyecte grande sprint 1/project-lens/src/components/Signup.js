import * as React from 'react';
import axios from "axios";
import { useState } from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';

function Copyright(props) {
  return (
    <Typography variant="body2" color="text.secondary" align="center" {...props}>
      {'Copyright © '}
      <Link color="inherit" href="https://mui.com/">
        Project Lens
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

const theme = createTheme();

export default function SignUp() {

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
            alert("Successfully Registered!")
        }
    };

    const checkIfUserRegistered = (e) => {
        e.preventDefault();
        let partialUserData = { Email: email, Username: username }
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
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="false">
      <Box sx={{ height: '85vh' }} style={{
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'center',
                    flexDirection: 'row',
                }} >
                  <Box sx={{ height: '48%', width: '40%', backgroundColor: 'white', opacity: '100%' }} style={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        flexDirection: 'row',
                        borderRadius: '10px',

                    }}>
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            width: '60%'
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Sign up
          </Typography>
              <Box component="form" noValidate onSubmit={checkIfUserRegistered} sx={{ mt: 1 }}>
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                        required
                        fullWidth
                        id="username"
                        label="Username"
                        name="username"
                        autoComplete="username"
                        value={username}
                        onChange={handleUsername}

                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="email"
                  label="Email Address"
                  name="email"
                autoComplete="email"
                value={email}
                onChange={handleEmail}

                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="password"
                  label="Password"
                  type="password"
                  id="password"
                autoComplete="new-password"
                value={password}
                onChange={handlePassword}
                />
              </Grid>
              <Grid item xs={12}>
                <FormControlLabel
                  control={<Checkbox value="allowExtraEmails" color="primary" />}
                  label="I want to receive inspiration, marketing promotions and updates via email."
                />
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </Button>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <Link href="#" variant="body2">
                  Already have an account? Sign in
                </Link>
              </Grid>
            </Grid>
        <Copyright sx={{ mt: 5 }} />
          </Box>
        </Box>
        </Box>
        </Box>
      </Container>
    </ThemeProvider>
  );
}