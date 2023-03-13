import { Link } from "react-router-dom";

import classes from "./DeveloperItem.module.css";

const DeveloperItem = (props) => {
  return (
    <li className={classes.item}>
      <figure>
        <blockquote>
          <p>{props.developerName}</p>
        </blockquote>
        <figcaption>{props.idDeveloper}</figcaption>
      </figure>
    </li>
  );
};

export default DeveloperItem;
