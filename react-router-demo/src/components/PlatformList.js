import { useLocation, useNavigate } from "react-router-dom";
import PlatformItem from "./PlatformItem";
import classes from "./PlatformList.module.css";

const sortPlatforms = (platforms, ascending) => {
  return platforms.sort((platformA, platformB) => {
    if (ascending) {
      return platformA.platformName > platformB.platformName ? 1 : -1;
    } else {
      return platformA.platformName < platformB.platformName ? 1 : -1;
    }
  });
};

const PlatformList = (props) => {
  const navigate = useNavigate();
  const location = useLocation();

  const queryParams = new URLSearchParams(location.search);

  const isSortingAscending = queryParams.get("sort") === "asc";

  const sortedPlatforms = sortPlatforms(props.platforms, isSortingAscending);

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
        {sortedPlatforms.map((platform) => (
          <PlatformItem
            key={platform.idPlatform}
            idPlatform={platform.idPlatform}
            platformName={platform.platformName}
          />
        ))}
      </ul>
    </>
  );
};

export default PlatformList;
