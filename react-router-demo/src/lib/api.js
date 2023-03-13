const BASE_URL = "https://localhost:44323";

export async function getAllGames() {
  const response = await fetch(`${BASE_URL}/api/Games`);
  const data = await response.json();

  if (!response.ok) {
    throw new Error(data.message || "Could not fetch games.");
  }

  return data;
}

export async function getAllUsers() {
  const response = await fetch(`${BASE_URL}/api/Users`);
  const data = await response.json();

  if (!response.ok) {
    throw new Error(data.message || "Could not fetch users.");
  }

  return data;
}

export async function getAllPlatforms() {
  const response = await fetch(`${BASE_URL}/api/Platforms`);
  const data = await response.json();

  if (!response.ok) {
    throw new Error(data.message || "Could not fetch platforms.");
  }

  return data;
}
export async function getAllDevelopers() {
  const response = await fetch(`${BASE_URL}/api/Developers`);
  const data = await response.json();

  if (!response.ok) {
    throw new Error(data.message || "Could not fetch developers.");
  }

  return data;
}

export async function getSingleGame(gameId) {
  const response = await fetch(`${BASE_URL}/api/Games/${gameId}`);
  const data = await response.json();

console.log("api"+ gameId);

  if (!response.ok) {
    throw new Error(data.message || "Could not fetch game.");
  }

  return data;
}

export async function getSinglePlatform(platformId) {
  const response = await fetch(`${BASE_URL}/api/Platforms/${platformId}`);
  const data = await response.json();

  if (!response.ok) {
    throw new Error(data.message || "Could not fetch platform.");
  }

  return data;
}

export async function addGame(gameData) {
  const response = await fetch(`${BASE_URL}/games`, {
    method: "POST",
    body: JSON.stringify(gameData),
    headers: {
      "Content-Type": "application/json",
    },
  });
  const data = await response.json();

  if (!response.ok) {
    throw new Error(data.message || "Could not create game.");
  }

  return null;
}
