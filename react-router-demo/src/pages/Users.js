import { useEffect } from "react";
import UserList from "../components/UserList";
import useHttp from '../hooks/use-http';
import { getAllUsers } from '../lib/api';

const Users = () => {
    const { sendRequest, status, data: loadedUsers, error } = useHttp(
        getAllUsers,
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

    if (status === 'completed' && (!loadedUsers || loadedUsers.length === 0)) {
        return <p>No games</p>;
    }

    return <UserList users={loadedUsers} />;
};

export default Users;