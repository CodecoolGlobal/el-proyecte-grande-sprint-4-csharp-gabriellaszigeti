import { styled } from "@mui/material/styles";
import Button from "@mui/material/Button";
import React, { useState } from "react";
import LoadingButton from "@mui/lab/LoadingButton"
import SendIcon from "@mui/icons-material/Send";


export default function UploadButtons() {
  const Input = styled("input")({
    display: "none",
  });

  const [loading, setLoading] = useState(false);
  const [selectedFile, setSelectedFile] = useState();
  const [isFilePicked, setIsFilePicked] = useState(false);

  const changeHandler = (event) => {
    setSelectedFile(event.target.files[0]);
    setIsFilePicked(true);
  };


  const handleSubmission = () => {
    setLoading(true);
    const formData = new FormData();

    formData.append("Image", selectedFile);

      fetch("api/pictures", {
      method: "POST",
      body: formData,
    })
      .then((response) => response.ok)
      .then((result) => {
        setLoading(false);
        console.log("Success:", result);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  };
  return (
    <div>
      <label htmlFor="contained-button-file">
        <Input
          accept="image/*"
          id="contained-button-file"
          type="file"
          name="file"
          onChange={changeHandler}
        />
        <Button
          className="uploadPageButton"
          variant="contained"
          component="span"
        >
          Upload
        </Button>
      </label>
      <br />
      <LoadingButton
        className="uploadPageButton"
        variant="contained"
        onClick={handleSubmission}
        endIcon={<SendIcon />}
        loading={loading}
        loadingPosition="end"
      >
        Submit
      </LoadingButton>
    </div>
  );
}
