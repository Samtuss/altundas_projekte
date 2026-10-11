/**
 * main.js
 * Einstiegspunkt: verbindet Quiz-Logik (quiz.js) mit der UI (ui.js).
 * Hier laufen alle Event-Handler und der App-Flow.
 */

// ── Start-Button ─────────────────────────────────────────────
document.getElementById('btn-start').addEventListener('click', async () => {
  ui.clearStartError();

  const settings = ui.getSettings();
  settings.language = ui.getLanguage();
  quiz.setSettings(settings);

  ui.showScreen('loading');

  try {
    await quiz.start();
    renderCurrentQuestion();
    ui.showScreen('quiz');
  } catch (error) {
    ui.showScreen('start');
    ui.setStartError(error.message);
  }
});

// ── Language Switch ──────────────────────────────────────────
document.getElementById('btn-lang-de').addEventListener('click', () => {
  ui.setLanguage('de');
});

document.getElementById('btn-lang-en').addEventListener('click', () => {
  ui.setLanguage('en');
});

// ── Weiter-Button ─────────────────────────────────────────────
document.getElementById('btn-next').addEventListener('click', () => {
  quiz.next();

  if (quiz.isFinished()) {
    showResult();
  } else {
    renderCurrentQuestion();
  }
});

// ── Nochmal spielen ───────────────────────────────────────────
document.getElementById('btn-restart').addEventListener('click', async () => {
  ui.showScreen('loading');

  try {
    const settings = ui.getSettings();
    settings.language = ui.getLanguage();
    quiz.setSettings(settings);

    await quiz.start();               // gleiche Einstellungen, neue Fragen
    renderCurrentQuestion();
    ui.showScreen('quiz');
  } catch (error) {
    ui.showScreen('start');
    ui.setStartError(error.message);
  }
});

// ── Zurück zu Einstellungen ───────────────────────────────────
document.getElementById('btn-home').addEventListener('click', () => {
  ui.showScreen('start');
});

// ── Initialisierung ───────────────────────────────────────────
ui.setLanguage('de');

// ── Hilfsfunktionen ───────────────────────────────────────────

/** Rendert die aktuelle Frage und setzt den Answer-Callback. */
function renderCurrentQuestion() {
  const state    = quiz.getState();
  const question = quiz.getCurrentQuestion();

  ui.renderQuestion(
    question,
    state.current,
    state.questions.length,
    state.score,
    handleAnswer,
  );
}

/** Wird aufgerufen, wenn der User eine Antwort wählt. */
function handleAnswer(selectedAnswer) {
  const result = quiz.answer(selectedAnswer);
  if (!result) return;   // bereits beantwortet

  const state = quiz.getState();
  ui.showAnswerFeedback(selectedAnswer, result.correctAnswer, result.correct);

  // Weiter-Button-Text anpassen (letzte Frage → Ergebnis)
  const isLast = state.current + 1 >= state.questions.length;
  ui.setNextButtonText(isLast);
}

/** Zeigt den Ergebnis-Screen. */
function showResult() {
  const state = quiz.getState();
  ui.renderResult(state.score, state.questions.length, quiz.getResultMessage());
  ui.showScreen('result');
}
