import { styled } from '@mui/material/styles';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import React, { useState } from 'react';

const Input = styled('input')({
  display: 'none',
});

export default function UploadButtons() {
    const [selectedFile, setSelectedFile] = useState();
    const [isFilePicked, setIsFilePicked] = useState(false);
    const changeHandler = (event) => {
        setSelectedFile(event.target.files[0]);
        setIsFilePicked(true);
    };

    const handleSubmission = () => {
        const formData = new FormData();

        formData.append('Image', selectedFile);

        fetch(
            'api/pictures',
            {
                method: 'POST',
                body: formData,
            }
        )
            .then((response) => response.json())
            .then((result) => {
                console.log('Success:', result);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    };
    return (
 //       <div>
	//	<input type="file" name="file" onChange={changeHandler} />
	//	{isFilePicked ? (
	//		<div>
	//		</div>
	//	) : (
	//		<p>Select a file to show details</p>
	//	)}
	//	<div>
	//		<button onClick={handleSubmission}>Submit</button>
	//	</div>
	//</div>
        <Stack alignItems="center">
            <div>
            <label htmlFor="contained-button-file">
              <Input accept="image/*" id="contained-button-file" multiple type="file" name="file" onChange={changeHandler} />
                		{isFilePicked ? (
			            <div>
			            </div>
		            ) : (
			      <p>Select a file to show details</p>
                )}
                <div>
              <Button variant="contained" style={{ backgroundColor: 'black', width: '20em', height: '3em' }} component="span" onClick={handleSubmission}>
          Upload
                    </Button>
                    </div>
                </label>
            </div>
    </Stack>
    );
}