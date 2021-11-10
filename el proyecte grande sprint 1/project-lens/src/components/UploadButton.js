import * as React from 'react';
import { styled } from '@mui/material/styles';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';

const Input = styled('input')({
  display: 'none',
});

export default function UploadButtons() {
  return (
    <Stack alignItems="center">
      <label htmlFor="contained-button-file">
        <Input accept="image/*" id="contained-button-file" multiple type="file" />
        <Button variant="contained" style={{ backgroundColor: 'black', width: '20em', height: '3em'}} component="span">
          Upload
        </Button>
      </label>
    </Stack>
  );
}