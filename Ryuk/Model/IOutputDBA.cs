namespace Ryuk.Model
{
    public interface IOutputDBA
    {
        /// <summary>
        /// Verbrauchter Freibetrag bei Berechnung des laufenden Arbeitslohns, in Cent
        /// </summary>
        public decimal VFRB { get; set; }

        /// <summary>
        /// Verbrauchter Freibetrag bei Berechnung des voraussichtlichen Jahresarbeitslohns, in Cent
        /// </summary>
        public decimal VFRBS1 { get; set; }

        /// <summary>
        /// Verbrauchter Freibetrag bei Berechnung der sonstigen Bezüge, in Cent
        /// </summary>
        public decimal VFRBS2 { get; set; }

        /// <summary>
        /// Für die weitergehende Berücksichtigung des Steuerfreibetrags nach 
        /// dem DBA Türkei verfügbares ZVE über dem Grundfreibetrag bei der 
        /// Berechnung des laufenden Arbeitslohns, in Cent
        /// </summary>
        public decimal WVFRB { get; set; }

        /// <summary>
        /// Für die weitergehende Berücksichtigung des Steuerfreibetrags 
        /// nach dem DBA Türkei verfügbares ZVE über dem Grundfreibetrag bei 
        /// der Berechnung der sonstigen Bezüge, in Cent
        /// </summary>
        public decimal WVFRBM { get; set; }

        /// <summary>
        /// Für die weitergehende Berücksichtigung des Steuerfreibetrags 
        /// nach dem DBA Türkei verfügbares ZVE über dem Grundfreibetrag 
        /// bei der Berechnung des voraussichtlichen Jahresarbeitslohns, 
        /// in Cent
        /// </summary>
        public decimal WVFRBO { get; set; }
    }
}
