import { useEffect } from "react";
import PlatformList from "../components/PlatformList";
import useHttp from "../hooks/use-http";
import { getAllPlatforms} from "../lib/api";

const Platforms = () => {
  const { sendRequest, status, data: loadedPlatforms, error } = useHttp(
    getAllPlatforms,
      true
  );
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
    (!loadedPlatforms || loadedPlatforms.length === 0)
  ) {
    return <p>No platforms</p>;
  }

  return <PlatformList platforms={loadedPlatforms} />;
};

export default Platforms;
