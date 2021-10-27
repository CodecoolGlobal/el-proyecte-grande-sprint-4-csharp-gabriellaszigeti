import * as React from 'react';
import FavoriteIcon from '@mui/icons-material/Favorite';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import RestoreIcon from '@mui/icons-material/Restore';
import LocationOnIcon from '@mui/icons-material/LocationOn';


export default function Footer() {

    return (
      <div className="footer">
      <BottomNavigationAction label="Recents" icon={<RestoreIcon />} />
    <BottomNavigationAction label="Favorites" icon={<FavoriteIcon />} />
    <BottomNavigationAction label="Nearby" icon={<LocationOnIcon />} />
    </div>
          );
        }