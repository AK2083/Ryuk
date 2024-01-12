namespace Ryuk.Model
{
    public interface IInputParameter
    {
        /// <summary>
        /// Voraussichtlicher Jahresarbeitslohn ohne sonstige Bezüge und ohne Vergütung für 
        /// mehrjährige Tätigkeit in Cent. Anmerkung: Die Eingabe dieses Feldes (ggf. 0) ist 
        /// erforderlich bei Eingaben zu sonstigen Bezügen (Felder SONSTB, VMT oder VKAPA).
        /// </summary>
        /// <remarks>
        /// Sind in einem vorangegangenen Abrechnungszeitraum bereits sonstige Bezüge gezahlt worden, 
        /// so sind sie dem voraussichtlichen Jahresarbeitslohn hinzuzurechnen.Vergütungen für mehrjährige 
        /// Tätigkeit aus einem vorangegangenen Abrechnungszeitraum werden in voller Höhe hinzugerechnet.
        /// </remarks>
        public decimal JRE4 { get; set; }

        /// <summary>
        /// Merker für die Vorsorgepauschale
        /// <list>
        ///     <item>
        ///         <term>0</term>
        ///         <description>der Arbeitnehmer ist in der gesetzlichen Rentenversicherung 
        ///         oder einer berufsständischen Versorgungseinrichtung
        ///         pflichtversichert oder bei Befreiung von der Versicherungspflicht
        ///         freiwillig versichert, es gilt die allgemeine Beitragsbemessungsgrenze (BBG West)</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>der Arbeitnehmer ist in der gesetzlichen Rentenversicherung 
        ///         oder einer berufsständischen Versorgungseinrichtung pflichtversichert 
        ///         oder bei Befreiung von der Versicherungspflicht freiwillig versichert,
        ///          es gilt die Beitragsbemessungsgrenze Ost (BBG Ost)</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>wenn nicht 0 oder 1</description>
        ///     </item>
        /// </list>
        /// </summary>
        public int KRV { get; set; }

        /// <summary>
        /// Kassenindividueller Zusatzbeitragssatz bei einem gesetzlich 
        /// krankenversicherten Arbeitnehmer in Prozent (bspw. 1,30 für
        /// 1,30 %) mit 2 Dezimalstellen. Es ist der volle Zusatzbeitragssatz
        /// anzugeben. Die Aufteilung in Arbeitnehmer- und Arbeitgeberanteil
        /// erfolgt im Programmablauf
        /// </summary>
        public decimal KVZ { get; set; }

        /// <summary>
        /// 1, wenn bei der sozialen Pflegeversicherung die Besonderheiten in 
        /// Sachsen zu berücksichtigen sind bzw.zu berücksichtigen wären
        /// </summary>
        public decimal PVS { get; set; }

        /// <summary>
        /// 1, wenn der Arbeitnehmer den Zuschlag zur sozialen
        /// Pflegeversicherung zu zahlen hat
        /// </summary>
        public int PVZ { get; set; }

        /// <summary>
        /// Lohnzahlungszeitraum:
        /// <list>
        ///     <item>
        ///         <term>1</term>
        ///         <description>Jahr</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>Monat</description>
        ///     </item>
        ///     <item>
        ///         <term>3</term>
        ///         <description>Woche</description>
        ///     </item>
        ///     <item>
        ///         <term>3</term>
        ///         <description>Tag</description>
        ///     </item>
        /// </list>
        /// </summary>
        public int LZZ { get; set; }

        /// <summary>
        /// Steuerpflichtiger Arbeitslohn für den Lohnzahlungszeitraum vor Berücksichtigung des Versorgungsfreibetrags 
        /// und des Zuschlags zum Versorgungsfreibetrag, des Altersentlastungsbetrags und des als elektronisches 
        /// Lohnsteuerabzugsmerkmal festgestellten oder in der Bescheinigung für den Lohnsteuerabzug 2021 für den 
        /// Lohnzahlungszeitraum eingetragenen Freibetrags bzw. Hinzurechnungsbetrags in Cent.
        /// </summary>
        public decimal RE4 { get; set; }

        /// <summary>
        /// In RE4 enthaltene Versorgungsbezüge in Cent (ggf. 0) ggf. unter Berücksichtigung 
        /// einer geänderten Bemessungsgrundlage nach § 19 Absatz 2 Satz 10 und 11 EStG
        /// </summary>
        /// <seealso cref="RE4"/>
        public decimal VBEZ { get; set; }

        /// <summary>
        /// Der als elektronisches Lohnsteuerabzugsmerkmal für den Arbeitgeber nach 
        /// § 39e EStG festgestellte oder in der Bescheinigung für den Lohnsteuerabzug 2021 
        /// eingetragene Freibetrag für den Lohnzahlungszeitraum in Cent
        /// </summary>
        public decimal LZZFREIB { get; set; }

        /// <summary>
        /// Der als elektronisches Lohnsteuerabzugsmerkmal für den Arbeitgeber nach 
        /// § 39e EStG festgestellte oder in der Bescheinigung für den Lohnsteuerabzug 2021 
        /// eingetragene Hinzurechnungsbetrag für den Lohnzahlungszeitraum in Cent
        /// </summary>
        public decimal LZZHINZU { get; set; }

        /// <summary>
        /// 1, wenn die Anwendung des Faktorverfahrens gewählt wurde (nur in Steuerklasse IV)
        /// </summary>
        public int AF { get; set; }

        /// <summary>
        /// eingetragener Faktor mit drei Nachkommastellen
        /// </summary>
        public decimal F { get; set; }

        /// <summary>
        /// Jahr, in dem der Versorgungsbezug erstmalig gewährt wurde; werden mehrere 
        /// Versorgungsbezüge gezahlt, wird aus Vereinfachungsgründen für die Berechnung 
        /// das Jahr des ältesten erstmaligen Bezugs herangezogen; auf die Möglichkeit der 
        /// getrennten Abrechnung verschiedenartiger Bezüge (§ 39e Absatz 5a EStG) 
        /// wird im Übrigen verwiesen.
        /// </summary>
        public int VJAHR { get; set; }

        /// <summary>
        /// Versorgungsbezug im Januar 2005 bzw. für den ersten vollen Monat, wenn 
        /// der Versorgungsbezug erstmalig nach Januar 2005 gewährt wurde, in Cent
        /// </summary>
        public decimal VBEZM { get; set; }

        /// <summary>
        /// Voraussichtliche Sonderzahlungen von Versorgungsbezügen im Kalenderjahr
        /// des Versorgungsbeginns bei Versorgungsempfängern ohne Sterbegeld, 
        /// Kapitalauszahlungen/Abfindungen in Cent
        /// </summary>
        public decimal VBEZS { get; set; }

        /// <summary>
        /// Zahl der Monate, für die im Kalenderjahr Versorgungsbezüge 
        /// gezahlt werden [nur erforderlich bei Jahresberechnung (LZZ = 1)]
        /// </summary>
        /// <seealso cref="LZZ"/>
        public int ZMVB { get; set; }

        /// <summary>
        /// 1, wenn das 64. Lebensjahr vor Beginn des Kalenderjahres vollendet wurde, 
        /// in dem der Lohnzahlungszeitraum endet (§ 24a EStG)
        /// </summary>
        public int ALTER1 { get; set; }

        /// <summary>
        /// Auf die Vollendung des 64. Lebensjahres folgendes Kalenderjahr 
        /// (erforderlich, wenn ALTER1 = 1)
        /// </summary>
        public int AJAHR { get; set; }

        /// <summary>
        /// In VKAPA und VMT enthaltene Entschädigungen nach § 24 Nummer 1 EStG in Cent
        /// </summary>
        public decimal ENTSCH { get; set; }

        /// <summary>
        /// Steuerklasse
        /// <list>
        ///     <item>
        ///         <term>1</term>
        ///         <description>I</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>II</description>
        ///     </item>
        ///     <item>
        ///         <term>3</term>
        ///         <description>III</description>
        ///     </item>
        ///     <item>
        ///         <term>4</term>
        ///         <description>IV</description>
        ///     </item>
        ///     <item>
        ///         <term>5</term>
        ///         <description>V</description>
        ///     </item>
        ///     <item>
        ///         <term>6</term>
        ///         <description>VI</description>
        ///     </item>
        /// </list>
        /// </summary>
        public int STKL { get; set; }

        /// <summary>
        /// Zahl der Freibeträge für Kinder 
        /// (eine Dezimalstelle, nur bei Steuerklassen I, II, III und IV)
        /// </summary>
        public decimal ZKF { get; set; }

        /// <summary>
        /// Entlastungsbetrag für Alleinerziehende in Euro
        /// </summary>
        public decimal EFA { get; set; }

        /// <summary>
        /// <list>
        ///     <item>
        ///         <term>0</term>
        ///         <description>gesetzlich krankenversicherte Arbeitnehmer</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>ausschließlich privat krankenversicherte Arbeitnehmer ohne Arbeitgeberzuschuss</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>ausschließlich privat krankenversicherte Arbeitnehmer mit Arbeitgeberzuschuss</description>
        ///     </item>
        /// </list>
        /// </summary>
        public int PKV { get; set; }

        /// <summary>
        /// Dem Arbeitgeber mitgeteilte Beiträge des Arbeitnehmers für eine private 
        /// Basiskranken- bzw. Pflege-Pflichtversicherung im Sinne des 
        /// § 10 Absatz 1 Nummer 3 EStG in Cent; der Wert ist unabhängig vom 
        /// Lohnzahlungszeitraum immer als Monatsbetrag anzugeben
        /// </summary>
        public decimal PKPV { get; set; }

        /// <summary>
        /// Entschädigungen und Vergütung für mehrjährige Tätigkeit ohne 
        /// Kapitalauszahlungen und ohne Abfindungen bei Versorgungsbezügen 
        /// in Cent (ggf. 0)
        /// </summary>
        public decimal VMT { get; set; }

        /// <summary>
        /// Entschädigungen/Kapitalauszahlungen/Abfindungen/Nachzahlungen bei 
        /// Versorgungsbezügen für mehrere Jahre in Cent (ggf. 0)
        /// </summary>
        public decimal VKAPA { get; set; }

        /// <summary>
        /// Religionsgemeinschaft des Arbeitnehmers lt. elektronischer
        /// Lohnsteuerabzugsmerkmale oder der Bescheinigung für den
        /// Lohnsteuerabzug 2021 (bei keiner Religionszugehörigkeit = 0)
        /// </summary>
        public decimal R { get; set; }

        /// <summary>
        /// Sonstige Bezüge (ohne Vergütung aus mehrjähriger Tätigkeit) 
        /// einschließlich Sterbegeld bei Versorgungsbezügen sowie
        /// Kapitalauszahlungen/Abfindungen, soweit es sich nicht um Bezüge
        /// für mehrere Jahre handelt, in Cent(ggf. 0)
        /// </summary>
        public decimal SONSTB { get; set; }

        /// <summary>
        /// In JRE4 enthaltene Versorgungsbezüge in Cent (ggf. 0)
        /// </summary>
        public decimal JVBEZ { get; set; }

        /// <summary>
        /// Jahreshinzurechnungsbetrag für die Ermittlung der Lohnsteuer für 
        /// die sonstigen Bezüge nach Maßgabe der elektronischen
        /// Lohnsteuerabzugsmerkmale nach § 39e EStG oder der Eintragung
        /// auf der Bescheinigung für den Lohnsteuerabzug 2021 in Cent (ggf. 0)
        /// </summary>
        public decimal JFREIB { get; set; }

        /// <summary>
        /// Jahresfreibetrag für die Ermittlung der Lohnsteuer für die sonstigen 
        /// Bezüge nach Maßgabe der elektronischen
        /// Lohnsteuerabzugsmerkmale nach § 39e EStG oder der Eintragung
        /// auf der Bescheinigung für den Lohnsteuerabzug 2021 in Cent (ggf. 0)
        /// </summary>
        public decimal JHINZU { get; set; }

        /// <summary>
        /// In JRE4 enthaltene Entschädigungen nach § 24 Nummer 1 EStG in Cent
        /// </summary>
        public decimal JRE4ENT { get; set; }

        /// <summary>
        /// In SONSTB enthaltene Versorgungsbezüge einschließlich Sterbegeld in Cent(ggf. 0)
        /// </summary>
        public decimal VBS { get; set; }

        /// <summary>
        /// Sterbegeld bei Versorgungsbezügen sowie
        /// Kapitalauszahlungen/Abfindungen, soweit es sich nicht um Bezüge
        /// für mehrere Jahre handelt(in SONSTB enthalten), in Cent
        /// </summary>
        public decimal STERBE { get; set; }

        /// <summary>
        /// In SONSTB enthaltene Entschädigungen nach § 24 Nummer 1 EStG in Cent
        /// </summary>
        public decimal SONSTENT { get; set; }

        /// <summary>
        /// Nicht zu besteuernde Vorteile bei Vermögensbeteiligungen (§ 19a
        /// Absatz 1 Satz 4 EStG) in Cent
        /// </summary>
        public decimal MBV { get; set; }
    }
}