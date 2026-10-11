using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenwiederholungStrategyPattern
{
    public class HtmlFormatierer : IBestellFormatierer
    {
        public string Formatiere(Bestellung bestellung)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<table>");
            sb.AppendLine($"\t<tr>");
            sb.AppendLine($"\t\t<td> {bestellung.Kunde}<td>");
            sb.AppendLine($"\t\t<td> {bestellung.Artikel}<td>");
            sb.AppendLine($"\t\t<td> {bestellung.Gesamtbetrag}<td>");
            sb.AppendLine($"\t<tr>");
            sb.AppendLine($"<table>");

            return sb.ToString();
        }
    }
}
