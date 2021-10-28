import * as React from 'react';
import Box from '@mui/material/Box';
import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';
import { useState, useEffect } from 'react';



export default function DiscoverView() {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [pictures, setPictures] = useState([]);

    useEffect(() => {
        fetch("http://localhost:3001/api/pictures")
            .then(response => response.json())
            .then((result) => {
                setIsLoaded(true);
                setPictures(result);
            },
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )
    },
        [])

    if (error) {
        return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
        return <div>Loading...</div>;
    } else {

        return (
            <Box sx={{ width: 500, height: 450, overflowY: 'scroll' }}>
                <ImageList variant="masonry" cols={3} gap={8}>
                    {pictures.map((item) => (
                        <h1>test</h1>
                        //<ImageListItem key={item.img}>
                        //    <img
                        //        src={`${item.route}?w=248&fit=crop&auto=format`}
                        //        alt={item.title}
                        //        loading="lazy"
                        //    />
                        //</ImageListItem>
                    ))}
                </ImageList>
            </Box>
        );
    }
}


// export default function DiscoverView() {
//     return (
//         <div className="images-center">
//             <article class="image-container">
//             </article>
//         </div>
//     )
// }
