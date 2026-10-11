namespace WebAppWarenkorb
{
    public class WarenkorbService
    {
        private readonly List<Produkt> _produkte = new();
        private int _nextId = 1; // damit man bei 1 mit der Nummerierung beginnt

        public WarenkorbService()
        {
            // vordefiniert Werte
            Add("Apfel", 0.80m);
            Add("Brot", 2.50m);
            Add("Milch", 1.20m);
        }

        public IReadOnlyList<Produkt> GetAll()
        {
            return _produkte.AsReadOnly();
        }

        public Produkt? GetById(int id)
        {
            return _produkte.FirstOrDefault(p => p.Id == id);
        }

        public Produkt Add(string name, decimal preis)
        {
            var produkt = new Produkt
            {
                Id = _nextId++,
                Name = name,
                Preis = preis
            };
            _produkte.Add(produkt);
            return produkt;
        }

        public bool Remove(int id)
        {
            var produkt = GetById(id);
            if (produkt == null)
                return false;

            _produkte.Remove(produkt);
            return true;
        }

        public decimal GetTotal()
        {
            return _produkte.Sum(p => p.Preis);
        }
    }
}
