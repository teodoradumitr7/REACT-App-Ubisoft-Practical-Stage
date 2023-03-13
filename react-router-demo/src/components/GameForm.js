import { useRef } from "react";
import Card from "./UI/Card";
import classes from "./GameForm.module.css";

const GameForm = (props) => {
  const nameInputRef = useRef();
  const editionInputRef = useRef();
  const storageInputRef = useRef();
  const launchDateInputRef = useRef();
  const multiplayerInputRef = useRef();
  const genreInputRef = useRef();


  function submitFormHandler(event) {
    event.preventDefault();

    const enteredName = nameInputRef.current.value;
    const enteredEdition=editionInputRef.current.value;
    const enteredStorage=storageInputRef.current.value;
    const launchDateEdition=launchDateInputRef.current.value;
    const enteredMultiplayer=multiplayerInputRef.current.value;
    const enteredGenre=genreInputRef.current.value;

    // optional: Could validate here

    props.onAddGame({ gameName: enteredName, edition: enteredEdition,storage:enteredStorage,launchDate:launchDateEdition,multyplayer:enteredMultiplayer,genre:enteredGenre});
  }

  return (
    <>
      <Card>
        <form className={classes.form} onSubmit={submitFormHandler}>
          <div className={classes.control}>
            <label htmlFor="name">Game name</label>
            <input type="text" game_name="name" ref={nameInputRef} />
          </div>

          <div className={classes.control}>
            <label htmlFor="name">Edition</label>
            <input type="text" edition="edition" ref={editionInputRef} />
          </div>
          <div className={classes.control}>
            <label htmlFor="name">Storage</label>
            <input type="text" id="storage" ref={storageInputRef} />
          </div>
          <div className={classes.control}>
            <label htmlFor="name">Launch date</label>
            <input type="text" id="launchDate" ref={launchDateInputRef} />
          </div>
          <div className={classes.control}>
            <label htmlFor="name">Multiplayer</label>
            <input type="text" id="multiplayer" ref={multiplayerInputRef} />
          </div>
          <div className={classes.control}>
            <label htmlFor="name">Genre</label>
            <input type="text" id="genre" ref={genreInputRef} />
          </div>

          <div className={classes.actions}>
            <button className="btn">Add Game</button>
          </div>
        </form>
      </Card>
    </>
  );
};

export default GameForm;