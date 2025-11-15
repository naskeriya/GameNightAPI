async function fetchGames(filters = {}) {
  const params = new URLSearchParams(filters);
  const res = await fetch('http://localhost:5093/api/games/filter?' + params.toString());
  if (!res.ok) {
    console.error('Failed to fetch games');
    return [];
  }
  return await res.json();
}

function createCard(game) {
  return `
    <div class="card">
      <h3>${game.name}</h3>
      <p>${game.description}</p>
      <p><strong>Players:</strong> ${game.minPlayers} - ${game.maxPlayers}</p>
      <p><strong>Age:</strong> ${game.age}+</p>
      <p><strong>Duration:</strong> ${game.minDuration} - ${game.maxDuration}</p>
      <p><strong>Mood:</strong> ${game.mood}</p>
      <p><strong>Difficulty:</strong> ${game.difficulty}</p>
    </div>
  `;
}

  async function renderGames(filters = {}) {
    const results = document.getElementById('results');
    results.innerHTML = '<p>Loading...</p>';

    try {
      const games = await fetchGames(filters);

      results.innerHTML = '';

      if (games.length === 0) {
        results.textContent = 'No games found.';
        return;
      }

      results.innerHTML = games.map(game => createCard(game)).join("");
    } catch (error) {
      results.textContent = 'Error.';
      console.error(error);
    }
  }

window.addEventListener('load', () => renderGames());

document.getElementById('searchBtn').addEventListener('click', async () => {
  const players = parseInt(document.getElementById('players').value) || null;
  const mood = document.getElementById('mood').value || null;
  const difficulty = document.getElementById('difficulty').value || null;
  const age = parseInt(document.getElementById('age').value) || null;
  const minDuration = parseInt(document.getElementById('minDuration').value) || null;
  const maxDuration = parseInt(document.getElementById('maxDuration').value) || null;
  const filters = {};
  if (players) filters.players = players;
  if (mood) filters.mood = mood;
  if (difficulty) filters.difficulty = difficulty;
  if (age) filters.age = age;
  if (minDuration) filters.minDuration = minDuration;
  if (maxDuration) filters.maxDuration = maxDuration;


  renderGames(filters);
});
