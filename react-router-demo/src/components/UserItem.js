import { Link } from "react-router-dom";

import classes from "./UserItem.module.css";

const UserItem = (props) => {
  return (
    <li className={classes.item}>
      <figure>
        <blockquote>
          <p>{props.username}</p>
        </blockquote>
        <figcaption>{props.game_name}</figcaption>
      </figure>
    </li>
  );
};

export default UserItem;
