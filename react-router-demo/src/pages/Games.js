import { useEffect } from "react";
import GameList from "../components/GameList";
import useHttp from '../hooks/use-http';
import { getAllGames, getSingleGame } from '../lib/api';


const Games = () => {
    const { sendRequest, status, data: loadedGames, error } = useHttp(
        getAllGames,
        true
    );


    useEffect(() => {
        sendRequest();
    }, [sendRequest]);

    if (status === 'pending') {
        return (
          <div className='centered'>
            <p>Loading...</p>
          </div>
        );
    }

    if (error) {
        return <p className='centered focused'>{error}</p>;
    }

    if (status === 'completed' && (!loadedGames || loadedGames.length === 0)) {
        return <p>No games</p>;
    }

    return <GameList games={loadedGames} />;
};

export default Games;