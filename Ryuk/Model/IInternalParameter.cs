namespace Ryuk.Model
{
    public interface IInternalParameter
    {
        /// <summary>
        /// Allgemeine Beitragsbemessungsgrenze in der allgemeinen 
        /// Rentenversicherung in Euro
        /// </summary>
        public decimal BBGRV { get; set; }

        /// <summary>
        /// Beitragssatz des Arbeitnehmers in der allgemeinen gesetzlichen 
        /// Rentenversicherung(4 Dezimalstellen)
        /// </summary>
        public decimal RVSATZAN { get; set; }

        /// <summary>
        /// Teilbetragssatz der Vorsorgepauschale für die Rentenversicherung 
        /// (2 Dezimalstellen)
        /// </summary>
        public decimal TBSVORV { get; set; }

        /// <summary>
        /// Beitragsbemessungsgrenze in der gesetzlichen 
        /// Krankenversicherung und der sozialen Pflegeversicherung in Euro
        /// </summary>
        public decimal BBGKVPV { get; set; }

        /// <summary>
        /// Beitragssatz des Arbeitnehmers zur Krankenversicherung 
        /// (5 Dezimalstellen)
        /// </summary>
        public decimal KVSATZAN { get; set; }

        /// <summary>
        /// Beitragssatz des Arbeitgebers zur Krankenversicherung unter 
        /// Berücksichtigung des durchschnittlichen Zusatzbeitragssatzes für die
        /// Ermittlung des Arbeitgeberzuschusses(5 Dezimalstellen)
        /// </summary>
        public decimal KVSATZAG { get; set; }

        /// <summary>
        /// Beitragssatz des Arbeitgebers zur Pflegeversicherung 
        /// (5 Dezimalstellen)
        /// </summary>
        public decimal PVSATZAG { get; set; }

        /// <summary>
        /// Beitragssatz des Arbeitnehmers zur Pflegeversicherung 
        /// (5 Dezimalstellen)
        /// </summary>
        public decimal PVSATZAN { get; set; }

        /// <summary>
        /// Erster Grenzwert in Steuerklasse V/VI in Euro
        /// </summary>
        public decimal W1STKL5 { get; set; }

        /// <summary>
        /// Zweiter Grenzwert in Steuerklasse V/VI in Euro
        /// </summary>
        public decimal W2STKL5 { get; set; }

        /// <summary>
        /// Dritter Grenzwert in Steuerklasse V/VI in Euro
        /// </summary>
        public decimal W3STKL5 { get; set; }

        /// <summary>
        /// Grundfreibetrag in Euro
        /// </summary>
        public decimal GFB { get; set; }

        /// <summary>
        /// Freigrenze für den Solidaritätszuschlag in Euro
        /// </summary>
        public decimal SOLZFREI { get; set; }

        /// <summary>
        /// Auf einen Jahreslohn hochgerechnetes RE4 in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        /// <seealso cref="InputParameter.RE4" />
        public decimal ZRE4J { get; set; }

        /// <summary>
        /// Auf einen Jahreslohn hochgerechnetes VBEZ in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        /// <seealso cref="InputParameter.VBEZ"/>
        public decimal ZVBEZJ { get; set; }

        /// <summary>
        /// Auf einen Jahreslohn hochgerechneter LZZFREIB in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        /// <seealso cref="InputParameter.LZZFREIB"/>
        public decimal JLFREIB { get; set; }

        /// <summary>
        /// Auf einen Jahreslohn hochgerechneter LZZHINZU in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        /// <seealso cref="InputParameter.LZZHINZU"/>
        public decimal JLHINZU { get; set; }

        /// <summary>
        /// Nummer der Tabellenwerte für Versorgungsparameter
        /// </summary>
        public int J { get; set; }

        /// <summary>
        /// Bemessungsgrundlage für den Versorgungsfreibetrag in Cent
        /// </summary>
        public decimal VBEZB { get; set; }

        /// <summary>
        /// Maßgeblicher maximaler Versorgungsfreibetrag in Euro
        /// </summary>
        public decimal HFVB { get; set; }

        /// <summary>
        /// Zuschlag zum Versorgungsfreibetrag in Euro
        /// </summary>
        public decimal FVBZ { get; set; }

        /// <summary>
        /// Versorgungsfreibetrag in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal FVB { get; set; }

        /// <summary>
        /// Versorgungsfreibetrag in Euro, Cent(2 Dezimalstellen) für die 
        /// Berechnung der Lohnsteuer für den sonstigen Bezug
        /// </summary>
        public decimal FVBSO { get; set; }

        /// <summary>
        /// Zuschlag zum Versorgungsfreibetrag in Euro für die 
        /// Berechnung der Lohnsteuer beim sonstigen Bezug
        /// </summary>
        public decimal FVBZSO { get; set; }

        /// <summary>
        /// Maßgeblicher maximaler Zuschlag zum Versorgungsfreibetrag in Euro, 
        /// Cent(2 Dezimalstellen)
        /// </summary>
        public decimal HFVBZ { get; set; }

        /// <summary>
        /// Maßgeblicher maximaler Zuschlag zum Versorgungsfreibetrag in Euro, 
        /// Cent(2 Dezimalstellen) für die Berechnung der Lohnsteuer für den sonstigen Bezug
        /// </summary>
        public decimal HFVBZSO { get; set; }

        /// <summary>
        /// Bemessungsgrundlage für den Versorgungsfreibetrag in Cent für den sonstigen Bezug
        /// </summary>
        public decimal VBEZBSO { get; set; }

        /// <summary>
        /// Merker für Berechnung Lohnsteuer für mehrjährige Tätigkeit
        /// <list>
        ///     <item>
        ///         <term>0</term>
        ///         <description>normale Steuerberechnung</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>Steuerberechnung für mehrjährige Tätigkeit</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>Ermittlung der Vorsorgepauschale ohne Entschädigungen i.S.d. § 24 Nummer 1 EStG</description>
        ///     </item>
        /// </list>
        /// </summary>
        public int KENNVMT { get; set; }

        /// <summary>
        /// Altersentlastungsbetrag in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal ALTE { get; set; }

        /// <summary>
        /// Nummer der Tabellenwerte für Parameter bei Altersentlastungsbetrag
        /// </summary>
        public int K { get; set; }

        /// <summary>
        /// Bemessungsgrundlage für Altersentlastungsbetrag in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal BMG { get; set; }

        /// <summary>
        /// Maximaler Altersentlastungsbetrag in Euro
        /// </summary>
        public decimal HBALTE { get; set; }

        /// <summary>
        /// Auf einen Jahreslohn hochgerechnetes RE4 in Euro, Cent (2 Dezimalstellen) 
        /// nach Abzug der Freibeträge nach § 39b Absatz 2 Satz 3 und 4 EStG
        /// </summary>
        public decimal ZRE4 { get; set; }

        /// <summary>
        /// Auf einen Jahreslohn hochgerechnetes RE4, ggf. nach Abzug der Entschädigungen 
        /// i.S.d. § 24 Nummer 1 EStG in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal ZRE4VP { get; set; }

        /// <summary>
        /// Auf einen Jahreslohn hochgerechnetes VBEZ abzüglich FVB in Euro, 
        /// Cent (2 Dezimalstellen)
        /// </summary>
        public decimal ZVBEZ { get; set; }

        /// <summary>
        /// Arbeitnehmer-Pauschbetrag/Werbungskosten-Pauschbetrag in Euro
        /// </summary>
        public decimal ANP { get; set; }

        /// <summary>
        /// Kennzahl für die Einkommensteuer-Tarifarten:
        /// <list>
        ///     <item>
        ///         <term>1</term>
        ///         <description>Grundtarif</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>Splittingverfahren</description>
        ///     </item>
        /// </list>
        /// </summary>
        public int KZTAB { get; set; }

        /// <summary>
        /// Sonderausgaben-Pauschbetrag in Euro
        /// </summary>
        public decimal SAP { get; set; }

        /// <summary>
        /// Summe der Freibeträge für Kinder in Euro
        /// </summary>
        public decimal KFB { get; set; }

        /// <summary>
        /// Vorsorgepauschale mit Teilbeträgen für die Rentenversicherung 
        /// sowie die gesetzliche Kranken- und soziale Pflegeversicherung nach 
        /// fiktiven Beträgen oder ggf. für die private Basiskrankenversicherung und 
        /// private Pflege-Pflichtversicherung in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal VSP { get; set; }

        /// <summary>
        /// Vorsorgepauschale mit Teilbeträgen für die Rentenversicherung 
        /// sowie der Mindestvorsorgepauschale für die Kranken- und 
        /// Pflegeversicherung in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal VSPN { get; set; }

        /// <summary>
        /// Zwischenwert 1 bei der Berechnung der Vorsorgepauschale 
        /// in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal VSP1 { get; set; }

        /// <summary>
        /// Zwischenwert 2 bei der Berechnung der Vorsorgepauschale 
        /// in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal VSP2 { get; set; }

        /// <summary>
        /// Vorsorgepauschale mit Teilbeträgen für die gesetzliche Kranken- 
        /// und soziale Pflegeversicherung nach fiktiven Beträgen oder ggf. für 
        /// die private Basiskrankenversicherung und private 
        /// Pflege-Pflichtversicherung in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal VSP3 { get; set; }

        /// <summary>
        /// Höchstbetrag der Mindestvorsorgepauschale für die Kranken- und 
        /// Pflegeversicherung in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal VHB { get; set; }

        /// <summary>
        /// Zu versteuerndes Einkommen in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal ZVE { get; set; }

        /// <summary>
        /// Zu versteuerndes Einkommen gem. § 32a Absatz 1 und 5 EStG in 
        /// Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal X { get; set; }

        /// <summary>
        /// Gem. § 32a Absatz 1 EStG (6 Dezimalstellen)
        /// </summary>
        public decimal Y { get; set; }

        /// <summary>
        /// Tarifliche Einkommensteuer in Euro
        /// </summary>
        public decimal ST { get; set; }

        /// <summary>
        /// Rechenwert in Gleitkommadarstellung
        /// </summary>
        public decimal RW { get; set; }

        /// <summary>
        /// Zwischenfeld zu X für die Berechnung der Steuer nach § 39b Absatz 2 Satz 7 EStG in Euro
        /// </summary>
        public decimal ZZX { get; set; }

        /// <summary>
        /// Zwischenfeld zu X für die Berechnung der Steuer nach § 39b Absatz 2 Satz 7 EStG in Euro
        /// </summary>
        public decimal ZX { get; set; }

        /// <summary>
        /// Zwischenfeld zu X für die Berechnung der Steuer nach § 39b Absatz 2 Satz 7 EStG in Euro
        /// </summary>
        public decimal HOCH { get; set; }

        /// <summary>
        /// Zwischenfeld zu X für die Berechnung der Steuer nach § 39b Absatz 2 Satz 7 EStG in Euro
        /// </summary>
        public decimal VERGL { get; set; }

        /// <summary>
        /// Tarifliche Einkommensteuer auf das 1,25-fache ZX in Euro
        /// </summary>
        public decimal ST1 { get; set; }

        /// <summary>
        /// Tarifliche Einkommensteuer auf das 0,75-fache ZX in Euro
        /// </summary>
        public decimal ST2 { get; set; }

        /// <summary>
        /// Differenz zwischen ST1 und ST2 in Euro
        /// </summary>
        public decimal DIFF { get; set; }

        /// <summary>
        /// Mindeststeuer für die Steuerklassen V und VI in Euro
        /// </summary>
        public decimal MIST { get; set; }

        /// <summary>
        /// Feste Tabellenfreibeträge (ohne Vorsorgepauschale) in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal ZTABFB { get; set; }

        /// <summary>
        /// Zwischenfeld zur Ermittlung der Steuer auf Vergütungen für mehrjährige Tätigkeit in Euro
        /// </summary>
        public decimal STOVMT { get; set; }

        /// <summary>
        /// Jahreslohnsteuer in Euro
        /// </summary>
        public decimal LSTJAHR { get; set; }

        /// <summary>
        /// Jahreswert, dessen Anteil für einen Lohnzahlungszeitraum 
        /// in UPANTEIL errechnet werden soll, in Cent
        /// </summary>
        public decimal JW { get; set; }

        /// <summary>
        /// Auf den Lohnzahlungszeitraum entfallender Anteil von 
        /// Jahreswerten auf ganze Cent abgerundet
        /// </summary>
        public decimal ANTEIL1 { get; set; }

        /// <summary>
        /// Jahreswert der berücksichtigten Beiträge zur privaten 
        /// Basis-Krankenversicherung und privaten Pflege-Pflichtversicherung 
        /// (ggf. auch die Mindestvorsorgepauschale) in Cent
        /// </summary>
        public decimal VKV { get; set; }

        /// <summary>
        /// Jahressteuer nach § 51a EStG, aus der Solidaritätszuschlag und 
        /// Bemessungsgrundlage für die Kirchenlohnsteuer ermittelt werden, in Euro
        /// </summary>
        public decimal JBMG { get; set; }

        /// <summary>
        /// Solidaritätszuschlag auf die Jahreslohnsteuer in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal SOLZJ { get; set; }

        /// <summary>
        /// Zwischenwert für den Solidaritätszuschlag auf die Jahreslohnsteuer 
        /// in Euro, Cent (2 Dezimalstellen)
        /// </summary>
        public decimal SOLZMIN { get; set; }

        /// <summary>
        /// Zwischenfelder der Jahreslohnsteuer in Cent
        /// </summary>
        public decimal LSTSO { get; set; }

        /// <summary>
        /// Zwischenfelder der Jahreslohnsteuer in Cent
        /// </summary>
        public decimal LSTOSO { get; set; }

        /// <summary>
        /// Bemessungsgrundlage des Solidaritätszuschlags zur Prüfung der
        /// Freigrenze beim Solidaritätszuschlag für sonstige Bezüge(ohne
        /// Vergütung für mehrjährige Tätigkeit) in Euro
        /// </summary>
        public decimal SOLZSBMG { get; set; }

        /// <summary>
        /// Zu versteuerndes Einkommen für die Ermittlung der
        /// Bemessungsgrundlage des Solidaritätszuschlags zur Prüfung der
        /// Freigrenze beim Solidaritätszuschlag für sonstige Bezüge(ohne
        /// Vergütung für mehrjährige Tätigkeit) in Euro, Cent(2 Dezimalstellen)
        /// </summary>
        public decimal SOLZSZVE { get; set; }

        /// <summary>
        /// Bemessungsgrundlage des Solidaritätszuschlags für die Prüfung der
        /// Freigrenze beim Solidaritätszuschlag für die Vergütung für
        /// mehrjährige Tätigkeit in Euro
        /// </summary>
        public decimal SOLZVBMG { get; set; }

        /// <summary>
        /// Zwischenfelder der Jahreslohnsteuer in Cent
        /// </summary>
        public decimal LST1 { get; set; }

        /// <summary>
        /// Zwischenfelder der Jahreslohnsteuer in Cent
        /// </summary>
        public decimal LST2 { get; set; }

        /// <summary>
        /// Zwischenfelder der Jahreslohnsteuer in Cent
        /// </summary>
        public decimal LST3 { get; set; }
    }
}