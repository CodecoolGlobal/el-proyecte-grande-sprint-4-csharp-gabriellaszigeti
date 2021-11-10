import React, { useState } from 'react';

export default function FileUploadPage() {

	const [selectedFile, setSelectedFile] = useState();
	const [isFilePicked, setIsFilePicked] = useState(false);

	const changeHandler = (event) => {
		setSelectedFile(event.target.files[0]);
		setIsFilePicked(true);
	};

	const handleSubmission = () => {
		const formData = new FormData();

		formData.append('Image', selectedFile);
		console.log(selectedFile);

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
	<div>
		<input type="file" name="file" onChange={changeHandler} />
		{isFilePicked ? (
			<div>
			</div>
		) : (
			<p>Select a file to show details</p>
		)}
		<div>
			<button onClick={handleSubmission}>Submit</button>
		</div>
	</div>
	)
};
