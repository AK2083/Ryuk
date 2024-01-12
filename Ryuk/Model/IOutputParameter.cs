namespace Ryuk.Model
{
    public interface IOutputParameter
    {
        /// <summary>
        /// Für den Lohnzahlungszeitraum einzubehaltende Lohnsteuer in Cent
        /// </summary>
        public decimal LSTLZZ { get; set; }

        /// <summary>
        /// Für den Lohnzahlungszeitraum berücksichtigte Beiträge des 
        /// Arbeitnehmers zur privaten Basis-Krankenversicherung und privaten 
        /// Pflege-Pflichtversicherung (ggf. auch die Mindestvorsorgepauschale) 
        /// in Cent beim laufenden Arbeitslohn. Für Zwecke der 
        /// Lohnsteuerbescheinigung sind die einzelnen Ausgabewerte 
        /// außerhalb des eigentlichen Lohnsteuerberechnungsprogramms zu 
        /// addieren; hinzuzurechnen sind auch die Ausgabewerte VKVSONST.
        /// </summary>
        public decimal VKVLZZ { get; set; }

        /// <summary>
        /// Für den Lohnzahlungszeitraum einzubehaltender 
        /// Solidaritätszuschlag in Cent
        /// </summary>
        public decimal SOLZLZZ { get; set; }

        /// <summary>
        /// Bemessungsgrundlage für die Kirchenlohnsteuer in Cent
        /// </summary>
        public decimal BK { get; set; }

        /// <summary>
        /// Für den Lohnzahlungszeitraum berücksichtigte Beiträge des 
        /// Arbeitnehmers zur privaten Basis-Krankenversicherung und privaten
        /// Pflege-Pflichtversicherung(ggf.auch die Mindestvorsorgepauschale)
        /// in Cent bei sonstigen Bezügen. Der Ausgabewert kann auch negativ 
        /// sein.Für tarifermäßigt zu besteuernde Vergütungen für mehrjährige
        /// Tätigkeiten enthält der PAP keinen entsprechenden Ausgabewert.
        /// </summary>
        public decimal VKVSONST { get; set; }

        /// <summary>
        /// Lohnsteuer für sonstige Bezüge (ohne Vergütung für mehrjährige 
        /// Tätigkeit) in Cent
        /// </summary>
        public decimal STS { get; set; }

        /// <summary>
        /// Solidaritätszuschlag für sonstige Bezüge (ohne Vergütung für 
        /// mehrjährige Tätigkeit) in Cent
        /// </summary>
        public decimal SOLZS { get; set; }

        /// <summary>
        /// Bemessungsgrundlage der sonstigen Bezüge (ohne Vergütung für 
        /// mehrjährige Tätigkeit) für die Kirchenlohnsteuer in Cent
        /// </summary>
        public decimal BKS { get; set; }

        /// <summary>
        /// Lohnsteuer für die Vergütung für mehrjährige Tätigkeit in Cent
        /// </summary>
        public decimal STV { get; set; }

        /// <summary>
        /// Solidaritätszuschlag für die Vergütung für mehrjährige Tätigkeit in 
        /// Cent
        /// </summary>
        public decimal SOLZV { get; set; }

        /// <summary>
        /// Bemessungsgrundlage der Vergütung für mehrjährige Tätigkeit für 
        /// die Kirchenlohnsteuer in Cent
        /// </summary>
        public decimal BKV { get; set; }
    }
}
