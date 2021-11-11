import * as React from 'react';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Button from '@mui/material/Button';
import { Link } from 'react-router-dom';
import UploadButton from './UploadButton';

export default function SimpleContainer() {
    return (
        <React.Fragment>
            <CssBaseline />
            <Container maxWidth="sm">
                <Box sx={{ height: '85vh' }} style={{
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'center',
                    flexDirection: 'row',
                }} >
                    <Box sx={{ height: '200px', width: '500px', backgroundColor: 'white', opacity: '80%' }} style={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        flexDirection: 'row',
                        borderRadius: '10px',

                    }}>
                        <UploadButton/>
                    </Box>
                </Box>
            </Container>
        </React.Fragment>
    );
}


