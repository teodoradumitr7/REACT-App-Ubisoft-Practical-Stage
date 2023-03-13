import { useEffect } from "react";
import DeveloperList from "../components/DeveloperList";
import useHttp from "../hooks/use-http";
import { getAllDevelopers } from "../lib/api";

const Developers = () => {
  const {
    sendRequest,
    status,
    data: loadedDevelopers,
    error,
  } = useHttp( getAllDevelopers, true);

  useEffect(() => {
    sendRequest();
  }, [sendRequest]);

  if (status === "pending") {
    return (
      <div className="centered">
        <p>Loading...</p>
      </div>
    );
  }

  if (error) {
    return <p className="centered focused">{error}</p>;
  }

  if (
    status === "completed" &&
    (!loadedDevelopers || loadedDevelopers.length === 0)
  ) {
    return <p>No developers</p>;
  }

  return <DeveloperList developers={loadedDevelopers} />;
};

export default Developers;
