import { useLocation, useNavigate } from 'react-router-dom';
import UserItem from './UserItem';
import classes from './UserList.module.css';

const sortUsers = (users, ascending) => {
  return users.sort((userA, userB) => {
    if (ascending) {
      return userA.username > userB.username ? 1 : -1;
    } else {
      return userA.username < userB.username ? 1 : -1;
    }
  });
};

const UserList = (props) => {
  const navigate = useNavigate();
  const location = useLocation();

  const queryParams = new URLSearchParams(location.search);

  const isSortingAscending = queryParams.get('sort') === 'asc';

  const sortedUsers = sortUsers(props.users, isSortingAscending);

  const changeSortingHandler = () => {
    navigate(`${location.pathname}?sort=${(isSortingAscending ? 'desc' : 'asc')}`);
  };

  return (
    <>
      <div className={classes.sorting}>
        <button onClick={changeSortingHandler}>
          Sort {isSortingAscending ? 'Descending' : 'Ascending'}
        </button>
      </div>
      <ul className={classes.list}>
        {sortedUsers.map((user) => (
          <UserItem
            key={user.id_user}
            id_user={user.id_user}
            username={user.username}
            game_name={user.game_name}
            
          />
        ))}
      </ul>
    </>
  );
};

export default UserList;
