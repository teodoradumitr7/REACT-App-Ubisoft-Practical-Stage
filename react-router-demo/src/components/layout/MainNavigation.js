import { NavLink } from "react-router-dom";

import classes from "./MainNavigation.module.css";

const MainNavigation = () => {
  return (
    <header className={classes.header}>
      <div className={classes.logo}>T.A.D.A's Game Library</div>
      <img class={classes.logo_img} src="./logo192.png"></img>
      <nav className={classes.nav}>
        <ul>
        <li>
            <NavLink to='/games' className={(navData) => navData.isActive ? classes.active : '' } >
              Games
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/users"
              className={(navData) => (navData.isActive ? classes.active : "")}
            >
              Users
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/platforms"
              className={(navData) => (navData.isActive ? classes.active : "")}
            >
              Platforms
            </NavLink>
          </li>
          <li>
            <NavLink
              to="/developers"
              className={(navData) => (navData.isActive ? classes.active : "")}
            >
              Developers
            </NavLink>
          </li>

          <li>
            <NavLink
              to="/new-game"
              className={(navData) => (navData.isActive ? classes.active : "")}
            >
              Add game
            </NavLink>
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default MainNavigation;
