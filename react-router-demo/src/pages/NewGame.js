import { useNavigate } from 'react-router-dom';
import GameForm from '../components/GameForm';

import useHttp from '../hooks/use-http';
import { addGame } from '../lib/api';
import { useEffect } from 'react';

const NewGame = () => {
    const { sendRequest, status } = useHttp(addGame);
    const navigate = useNavigate();

    useEffect(() => {
        if (status === 'completed') {
          navigate('/games');
        }
    }, [status, navigate]);

    const addGameHandler = (gameData) => {
        sendRequest(gameData);
    };

    return <GameForm onAddGame={addGameHandler} />;
};

export default NewGame;