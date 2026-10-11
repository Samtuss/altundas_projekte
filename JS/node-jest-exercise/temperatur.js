// ============================================================
// temperatur.js – Funktionen zur Temperaturumrechnung & -analyse
// ============================================================

function celsiusToFahrenheit(celsius) {
  if (typeof celsius !== 'number') {
    throw new Error('Ungültige Eingabe: Zahl erwartet');
  }
  return celsius * 9 / 5 + 32;
}

function fahrenheitToCelsius(fahrenheit) {
  if (typeof fahrenheit !== 'number') {
    throw new Error('Ungültige Eingabe: Zahl erwartet');
  }
  return (fahrenheit - 32) * 5 / 9;
}

function classifyTemperature(celsius) {
  if (typeof celsius !== 'number') {
    throw new Error('Ungültige Eingabe: Zahl erwartet');
  }
  if (celsius < 0) return 'eisig';
  if (celsius < 10) return 'kalt';
  if (celsius < 20) return 'mild';
  if (celsius < 30) return 'warm';
  return 'heiß';
}

function analyzeTemperatures(temps) {
  if (!Array.isArray(temps) || temps.length === 0) {
    return { min: null, max: null, average: null, count: 0 };
  }
  const min = Math.min(...temps);
  const max = Math.max(...temps);
  const average = temps.reduce((sum, t) => sum + t, 0) / temps.length;
  return {
    min,
    max,
    average: Math.round(average * 100) / 100,
    count: temps.length,
  };
}

function findExtremes(temps) {
  if (!Array.isArray(temps) || temps.length === 0) return [];
  const avg = temps.reduce((s, t) => s + t, 0) / temps.length;
  const threshold = 10;
  return temps.filter(t => Math.abs(t - avg) > threshold);
}

module.exports = {
  celsiusToFahrenheit,
  fahrenheitToCelsius,
  classifyTemperature,
  analyzeTemperatures,
  findExtremes,
};
