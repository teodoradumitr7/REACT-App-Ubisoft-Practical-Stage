import { useLocation, useNavigate } from "react-router-dom";
import GameItem from "./GameItem";
import classes from "./GameList.module.css";

const sortGames = (games, ascending) => {
  return games.sort((gameA, gameB) => {
    if (ascending) {
      return gameA.game_name > gameB.game_name ? 1 : -1;
    } else {
      return gameA.game_name < gameB.game_name ? 1 : -1;
    }
  });
};

const GameList = (props) => {
  const navigate = useNavigate();
  const location = useLocation();

  const queryParams = new URLSearchParams(location.search);

  const isSortingAscending = queryParams.get("sort") === "asc";

  const sortedGames = sortGames(props.games, isSortingAscending);

  const changeSortingHandler = () => {
    navigate(
      `${location.pathname}?sort=${isSortingAscending ? "desc" : "asc"}`
    );
  };

  return (
    <>
      <div className={classes.sorting}>
        <button onClick={changeSortingHandler}>
          Sort {isSortingAscending ? "Descending" : "Ascending"}
        </button>
      </div>
      <ul className={classes.list}>
        {sortedGames.map((game) => (
          <GameItem
            key={game.id_game}
            id_game={game.id_game}
            name={game.game_name}
            edition={game.edition}
            storage={game.storage}
            launch_date={game.launch_date}
            multiplayer={game.multiplayer}
            genre={game.genre}
          />
        ))}
      </ul>
    </>
  );
};

export default GameList;
