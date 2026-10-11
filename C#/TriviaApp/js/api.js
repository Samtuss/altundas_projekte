/**
 * api.js
 * Kommunikation mit der Open Trivia DB API.
 * Doku: https://opentdb.com/api_config.php
 */

const API_BASE = 'https://opentdb.com/api.php';

/**
 * Holt Fragen von der API.
 *
 * @param {Object} options
 * @param {number}  options.amount     - Anzahl Fragen (1–50)
 * @param {string}  options.category   - Kategorie-ID (leer = beliebig)
 * @param {string}  options.difficulty - 'easy' | 'medium' | 'hard' | '' (beliebig)
 * @returns {Promise<Array>} Array mit formatierten Frage-Objekten
 */
async function fetchQuestions({ amount = 10, category = '', difficulty = '', language = 'de' } = {}) {
  const params = new URLSearchParams({
    amount,
    encode: 'url3986',       // RFC-3986-URL-Encoding; Sonderzeichen sicher übertragen
    language,
  });

  if (category)   params.set('category',   category);
  if (difficulty) params.set('difficulty', difficulty);

  const response = await fetch(`${API_BASE}?${params.toString()}`);

  if (!response.ok) {
    throw new Error(`Netzwerkfehler: ${response.status} ${response.statusText}`);
  }

  const data = await response.json();

  // API Response Codes (0 = OK, Rest = Fehler)
  switch (data.response_code) {
    case 0:
      break;
    case 1:
      throw new Error(language === 'en'
        ? 'Not enough questions for these settings. Try different options.'
        : 'Nicht genug Fragen für diese Einstellungen. Probiere andere Optionen.');
    case 2:
      throw new Error(language === 'en'
        ? 'Invalid parameters. Please check your settings.'
        : 'Ungültige Parameter. Bitte überprüfe deine Einstellungen.');
    case 5:
      throw new Error(language === 'en'
        ? 'Too many requests. Please wait 5 seconds and try again.'
        : 'Zu viele Anfragen. Bitte warte 5 Sekunden und versuche es erneut.');
    default:
      throw new Error(language === 'en'
        ? 'Unknown API error. Please try again later.'
        : 'Unbekannter API-Fehler. Bitte versuche es später erneut.');
  }

  return data.results.map(formatQuestion);
}

/**
 * Wandelt eine rohe API-Frage in ein sauberes Objekt um.
 * Antworten werden zufällig gemischt.
 *
 * @param {Object} raw - Rohes Frage-Objekt von der API
 * @returns {Object} Formatiertes Frage-Objekt
 */
function formatQuestion(raw) {
  const correct  = decodeURIComponent(raw.correct_answer);
  const wrongs   = raw.incorrect_answers.map(a => decodeURIComponent(a));
  const answers  = shuffle([correct, ...wrongs]);

  return {
    question:   decodeURIComponent(raw.question),
    category:   decodeURIComponent(raw.category),
    difficulty: raw.difficulty,       // 'easy' | 'medium' | 'hard'
    type:       raw.type,             // 'multiple' | 'boolean'
    correct,
    answers,
  };
}

/**
 * Fisher-Yates Shuffle – mischt ein Array zufällig.
 *
 * @param {Array} array
 * @returns {Array} neues, gemischtes Array
 */
function shuffle(array) {
  const arr = [...array];
  for (let i = arr.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [arr[i], arr[j]] = [arr[j], arr[i]];
  }
  return arr;
}
