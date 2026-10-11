/**
 * ui.js
 * Alle DOM-Manipulationen – kein Quiz-State-Zugriff direkt,
 * nur Render-Funktionen die Daten als Parameter empfangen.
 */

const ui = (() => {
  let currentLanguage = 'de';

  const texts = {
    de: {
      tagline: 'Powered by Open Trivia DB',
      amountLabel: 'Anzahl Fragen',
      difficultyLabel: 'Schwierigkeit',
      categoryLabel: 'Kategorie',
      startQuiz: 'Quiz starten',
      loading: 'Fragen werden geladen…',
      questionCounter: (current, total) => `Frage ${current} von ${total}`,
      score: score => `Punkte: ${score}`,
      questionNumber: current => `Frage ${current}`,
      next: 'Weiter →',
      resultButton: 'Ergebnis anzeigen',
      resultLabel: 'Dein Ergebnis',
      playAgain: 'Nochmal spielen',
      settings: 'Einstellungen',
      feedbackCorrect: '✓ Richtig!',
      feedbackWrong: correct => `✗ Falsch – ${correct}`,
    },
    en: {
      tagline: 'Powered by Open Trivia DB',
      amountLabel: 'Number of questions',
      difficultyLabel: 'Difficulty',
      categoryLabel: 'Category',
      startQuiz: 'Start quiz',
      loading: 'Loading questions…',
      questionCounter: (current, total) => `Question ${current} of ${total}`,
      score: score => `Score: ${score}`,
      questionNumber: current => `Question ${current}`,
      next: 'Next →',
      resultButton: 'Show result',
      resultLabel: 'Your result',
      playAgain: 'Play again',
      settings: 'Settings',
      feedbackCorrect: '✓ Correct!',
      feedbackWrong: correct => `✗ Wrong – ${correct}`,
    },
  };

  const categoryOptions = [
    { value: '', de: 'Beliebig', en: 'Any' },
    { value: '9', de: 'Allgemeinwissen', en: 'General Knowledge' },
    { value: '10', de: 'Bücher', en: 'Books' },
    { value: '11', de: 'Film', en: 'Film' },
    { value: '12', de: 'Musik', en: 'Music' },
    { value: '14', de: 'Fernsehen', en: 'Television' },
    { value: '15', de: 'Videospiele', en: 'Video Games' },
    { value: '17', de: 'Wissenschaft & Natur', en: 'Science & Nature' },
    { value: '18', de: 'Computer', en: 'Computers' },
    { value: '19', de: 'Mathematik', en: 'Mathematics' },
    { value: '20', de: 'Mythologie', en: 'Mythology' },
    { value: '21', de: 'Sport', en: 'Sports' },
    { value: '22', de: 'Geographie', en: 'Geography' },
    { value: '23', de: 'Geschichte', en: 'History' },
    { value: '25', de: 'Kunst', en: 'Art' },
    { value: '27', de: 'Tiere', en: 'Animals' },
  ];

  const difficultyOptions = [
    { value: '', de: 'Beliebig', en: 'Any' },
    { value: 'easy', de: 'Leicht', en: 'Easy' },
    { value: 'medium', de: 'Mittel', en: 'Medium' },
    { value: 'hard', de: 'Schwer', en: 'Hard' },
  ];

  function setLanguage(lang) {
    currentLanguage = lang;
    document.documentElement.lang = lang;
    document.getElementById('btn-lang-de').classList.toggle('active', lang === 'de');
    document.getElementById('btn-lang-en').classList.toggle('active', lang === 'en');

    document.querySelector('header .tagline').textContent = texts[lang].tagline;
    document.querySelector('label[for="s-amount"]').textContent = texts[lang].amountLabel;
    document.querySelector('label[for="s-difficulty"]').textContent = texts[lang].difficultyLabel;
    document.querySelector('label[for="s-category"]').textContent = texts[lang].categoryLabel;
    document.getElementById('btn-start').textContent = texts[lang].startQuiz;
    document.getElementById('screen-loading').querySelector('.muted').textContent = texts[lang].loading;
    document.querySelector('.result-label').textContent = texts[lang].resultLabel;
    document.getElementById('btn-restart').textContent = texts[lang].playAgain;
    document.getElementById('btn-home').textContent = texts[lang].settings;
    document.getElementById('btn-next').textContent = texts[lang].next;

    const categorySelect = document.getElementById('s-category');
    categoryOptions.forEach((option, index) => {
      categorySelect.options[index].textContent = option[lang];
    });

    const difficultySelect = document.getElementById('s-difficulty');
    difficultyOptions.forEach((option, index) => {
      difficultySelect.options[index].textContent = option[lang];
    });
  }

  function getLanguage() {
    return currentLanguage;
  }

  function setNextButtonText(isLast) {
    document.getElementById('btn-next').textContent = isLast ? texts[currentLanguage].resultButton : texts[currentLanguage].next;
  }

  function translateDifficulty(diff) {
    const map = {
      de: { easy: 'Leicht', medium: 'Mittel', hard: 'Schwer' },
      en: { easy: 'Easy', medium: 'Medium', hard: 'Hard' },
    };
    return map[currentLanguage][diff] ?? diff;
  }

  // ── Screen-Wechsel ───────────────────────────────────────

  /**
   * Aktiviert einen Screen und blendet alle anderen aus.
   * @param {'start'|'loading'|'quiz'|'result'} name
   */
  function showScreen(name) {
    document.querySelectorAll('.screen').forEach(el => {
      el.classList.toggle('active', el.id === `screen-${name}`);
    });
  }

  // ── Start Screen ─────────────────────────────────────────

  /** Liest die Einstellungen aus den Formularfeldern. */
  function getSettings() {
    return {
      amount:     document.getElementById('s-amount').value,
      category:   document.getElementById('s-category').value,
      difficulty: document.getElementById('s-difficulty').value,
    };
  }

  /** Zeigt eine Fehlermeldung auf dem Start-Screen. */
  function setStartError(message) {
    document.getElementById('start-error').textContent = message;
  }

  function clearStartError() {
    document.getElementById('start-error').textContent = '';
  }

  // ── Quiz Screen ───────────────────────────────────────────

  /**
   * Rendert eine Frage inkl. Antwort-Buttons.
   * @param {Object} question   - Frage-Objekt aus quiz.js
   * @param {number} index      - 0-basierter Index der Frage
   * @param {number} total      - Gesamtanzahl Fragen
   * @param {number} score      - Aktueller Punktestand
   * @param {Function} onAnswer - Callback(answer: string)
   */
  function renderQuestion(question, index, total, score, onAnswer) {
    const text = texts[currentLanguage];
    document.getElementById('progress-bar').style.width = `${(index / total) * 100}%`;
    document.getElementById('q-counter').textContent = text.questionCounter(index + 1, total);
    document.getElementById('q-score').textContent   = text.score(score);

    // Frage-Meta
    document.getElementById('q-num').textContent = text.questionNumber(index + 1);
    const diffBadge = document.getElementById('q-difficulty');
    diffBadge.textContent  = translateDifficulty(question.difficulty);
    diffBadge.className    = `diff-badge ${question.difficulty}`;

    document.getElementById('q-category').textContent = question.category;
    document.getElementById('q-text').textContent     = question.question;

    // Antwort-Buttons
    const grid = document.getElementById('answers-grid');
    grid.innerHTML = '';

    question.answers.forEach(answer => {
      const btn = document.createElement('button');
      btn.className   = 'answer-btn';
      btn.textContent = answer;
      btn.addEventListener('click', () => onAnswer(answer));
      grid.appendChild(btn);
    });

    // Feedback zurücksetzen
    clearFeedback();
  }

  /**
   * Markiert Antworten als richtig/falsch und zeigt Feedback.
   * @param {string}  selected      - Gewählte Antwort
   * @param {string}  correctAnswer - Korrekte Antwort
   * @param {boolean} isCorrect
   */
  function showAnswerFeedback(selected, correctAnswer, isCorrect) {
    const buttons = document.querySelectorAll('.answer-btn');

    buttons.forEach(btn => {
      btn.disabled = true;
      if (btn.textContent === correctAnswer) {
        btn.classList.add('correct');
      } else if (btn.textContent === selected && !isCorrect) {
        btn.classList.add('wrong');
      }
    });

    const feedbackEl = document.getElementById('feedback-text');
    feedbackEl.textContent = isCorrect
      ? texts[currentLanguage].feedbackCorrect
      : texts[currentLanguage].feedbackWrong(correctAnswer);
    feedbackEl.className = `feedback-text ${isCorrect ? 'correct' : 'wrong'}`;

    document.getElementById('btn-next').classList.remove('hidden');
  }

  function clearFeedback() {
    const feedbackEl = document.getElementById('feedback-text');
    feedbackEl.textContent = '';
    feedbackEl.className = 'feedback-text';
    document.getElementById('btn-next').classList.add('hidden');
  }

  // ── Result Screen ─────────────────────────────────────────

  /**
   * Rendert das Ergebnis.
   * @param {number} score
   * @param {number} total
   * @param {string} message
   */
  function renderResult(score, total, message) {
    document.getElementById('r-score').textContent   = score;
    document.getElementById('r-total').textContent   = `/${total}`;
    document.getElementById('r-message').textContent = message;
  }

  // ── Helpers ───────────────────────────────────────────────

  function difficultyLabel(diff) {
    const map = { easy: 'Leicht', medium: 'Mittel', hard: 'Schwer' };
    return map[diff] ?? diff;
  }

  // ── Public API ────────────────────────────────────────────
  return {
    showScreen,
    getSettings,
    setStartError,
    clearStartError,
    renderQuestion,
    showAnswerFeedback,
    renderResult,
    setLanguage,
    getLanguage,
    setNextButtonText,
  };

})();
