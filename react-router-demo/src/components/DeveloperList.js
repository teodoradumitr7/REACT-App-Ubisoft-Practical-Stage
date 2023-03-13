import { useLocation, useNavigate } from "react-router-dom";
import DeveloperItem from "./DeveloperItem";
import classes from "./DeveloperList.module.css";

const sortDevelopers = (developers, ascending) => {
  return developers.sort((developerA, developerB) => {
    if (ascending) {
      return developerA.developerName > developerB.developerName ? 1 : -1;
    } else {
      return developerA.developerName < developerB.developerName ? 1 : -1;
    }
  });
};

const DeveloperList = (props) => {
  const navigate = useNavigate();
  const location = useLocation();

  const queryParams = new URLSearchParams(location.search);

  const isSortingAscending = queryParams.get("sort") === "asc";

  const sortedDevelopers = sortDevelopers(props.developers, isSortingAscending);

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
        {sortedDevelopers.map((developer) => (
          <DeveloperItem
            key={developer.idDeveloper}
            idDeveloper={developer.idDeveloper}
            developerName={developer.developerName}
    
          />
        ))}
      </ul>
    </>
  );
};

export default DeveloperList;
