import { Link } from "react-router-dom";

import classes from "./PlatformItem.module.css";

const PlatformItem = (props) => {
  return (
    <li className={classes.item}>
      <figure>
        <blockquote>
          <p>{props.platformName}</p>
        </blockquote>
      </figure>
    </li>
  );
};

export default PlatformItem;
