import { styled } from "@mui/material/styles";
import Button from "@mui/material/Button";
import Stack from "@mui/material/Stack";
import React, { useState } from "react";

const Input = styled("input")({
  display: "none",
});

export default function UploadButtons() {
  const [selectedFile, setSelectedFile] = useState();
  const [isFilePicked, setIsFilePicked] = useState(false);
  const changeHandler = (event) => {
    setSelectedFile(event.target.files[0]);
    setIsFilePicked(true);
  };

  const Input = styled('input')({
    display: 'none',
  });

  const handleSubmission = () => {
    const formData = new FormData();

    formData.append("Image", selectedFile);

    fetch("api/pictures", {
      method: "POST",
      body: formData,
    })
      .then((response) => response.json())
      .then((result) => {
        console.log("Success:", result);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  };
  return (
<div>
        <label htmlFor="contained-button-file">
        <Input accept="image/*" id="contained-button-file" type="file" name="file" onChange={changeHandler} />
        <Button variant="contained" component="span" style={{ backgroundColor: 'black', width: '60%', height: '30%' }}>
          Upload
        </Button>
      </label>
      <br/>
			<Button variant="contained" style={{ backgroundColor: 'black', width: '60%', height: '30%' }} onClick={handleSubmission} >Submit</Button>
  </div>
	)
};

