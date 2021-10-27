import * as React from 'react';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Button from '@mui/material/Button';


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
                    <Button variant="contained" style={{ backgroundColor: 'gray', width: '40%', height: '10%' }}>Discover</Button>
                    </Box>
            </Container>
            </React.Fragment>
    );
}


