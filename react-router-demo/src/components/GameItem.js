import { Link } from "react-router-dom";

import classes from "./GameItem.module.css";

const GameItem = (props) => {
  return (
    <li className={classes.item}>
      <figure>
        <blockquote>
          <p>{props.name}</p>
        </blockquote>
        <figcaption>{props.edition}</figcaption>
        <figcaption>{props.storage}</figcaption>
      <figcaption>{props.launch_date}</figcaption>
      <figcaption>{props.multiplayer}</figcaption>
      <figcaption>{props.genre}</figcaption>
      </figure>
      <Link className="btn" to={`/games/${props.id_game}`}>
        View game details
      </Link>
    </li>
  );
};

export default GameItem;
