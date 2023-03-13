import classes from "./GameItemDetails.module.css";

const GameItemDetails = (props) => {
  return (
    <>
      <figure className={classes.game}>
        <p>{props.game.game_name}</p>
        <figcaption>{props.game.edition}</figcaption>
        <figcaption>{props.game.storage}</figcaption>
        <figcaption>{props.game.launch_date}</figcaption>
        <figcaption>{props.game.multiplayer}</figcaption>
        <figcaption>{props.game.genre}</figcaption>
      </figure>
      <ul className={classes.game}>
        <p>Developers:</p>
        {props.game.developersNames.map((x) => (
          <li>{x}</li>
        ))}
      </ul>
      <ul className={classes.game}>
        <p>Platforms:</p>
        {props.game.platformNames.map((x) => (
          <li>{x}</li>
        ))}
      </ul>
    </>
  );
};

export default GameItemDetails;