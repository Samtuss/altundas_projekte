/**
 * quiz.js
 * Zustand und Logik des Quiz – kein DOM hier, nur pure Daten.
 * Alle UI-Updates laufen über Callback-Funktionen, die in main.js gesetzt werden.
 */

const quiz = (() => {

  // ── State ────────────────────────────────────────────────
  let state = {
    questions:  [],
    current:    0,
    score:      0,
    answered:   false,
    settings: {
      amount:     '10',
      category:   '',
      difficulty: '',
      language:   'de',
    },
  };

  // ── Getters ──────────────────────────────────────────────

  function getState()           { return { ...state }; }
  function getCurrentQuestion() { return state.questions[state.current] ?? null; }
  function isFinished()         { return state.current >= state.questions.length; }
  function getProgress()        { return state.questions.length > 0
    ? state.current / state.questions.length
    : 0;
  }

  // ── Actions ──────────────────────────────────────────────

  /** Speichert Einstellungen vom Start-Screen. */
  function setSettings({ amount, category, difficulty, language }) {
    state.settings = { amount, category, difficulty, language };
  }

  /** Lädt neue Fragen und setzt den Quiz-Zustand zurück. */
  async function start() {
    const questions = await fetchQuestions(state.settings);
    state.questions = questions;
    state.current   = 0;
    state.score     = 0;
    state.answered  = false;
  }

  /**
   * Wertet eine gewählte Antwort aus.
   * @param {string} answer - Die gewählte Antwort
   * @returns {{ correct: boolean, correctAnswer: string }}
   */
  function answer(answer) {
    if (state.answered) return null;

    const q       = getCurrentQuestion();
    const correct = answer === q.correct;

    state.answered = true;
    if (correct) state.score++;

    return { correct, correctAnswer: q.correct };
  }

  /** Geht zur nächsten Frage oder beendet das Quiz. */
  function next() {
    state.current++;
    state.answered = false;
  }

  /**
   * Gibt eine Bewertungsnachricht basierend auf dem Ergebnis zurück.
   * @returns {string}
   */
  function getResultMessage(language = state.settings.language) {
    const pct = state.score / state.questions.length;
    const messages = {
      de: [
        { test: pct => pct === 1, value: 'Perfekt! Alle richtig! 🎯' },
        { test: pct => pct >= 0.8, value: 'Hervorragend!' },
        { test: pct => pct >= 0.6, value: 'Gut gemacht!' },
        { test: pct => pct >= 0.4, value: 'Nicht schlecht.' },
        { test: () => true, value: 'Weiter üben!' },
      ],
      en: [
        { test: pct => pct === 1, value: 'Perfect! All correct! 🎯' },
        { test: pct => pct >= 0.8, value: 'Excellent!' },
        { test: pct => pct >= 0.6, value: 'Well done!' },
        { test: pct => pct >= 0.4, value: 'Not bad.' },
        { test: () => true, value: 'Keep practicing!' },
      ],
    };

    return messages[language]?.find(entry => entry.test(pct))?.value
      ?? messages.de[messages.de.length - 1].value;
  }

  // ── Public API ───────────────────────────────────────────
  return {
    getState,
    getCurrentQuestion,
    isFinished,
    getProgress,
    setSettings,
    start,
    answer,
    next,
    getResultMessage,
  };

})();
