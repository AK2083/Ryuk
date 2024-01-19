using Misa;
using Ryuk.Helper;
using Ryuk.Model;
using Ryuk.Model.Implementations;

namespace Ryuk
{
    [WorkflowValidity("01.07.2023")]
    public class WageTaxWorkflow2023b
    {
        public IInternalParameter InternalPara { get; set; }
        public IInputParameter InputPara { get; set; }
        public IOutputParameter OutputPara { get; set; }
        public IOutputDBA OutputDBASE { get; set; }

        public WageTaxWorkflow2023b(IInputParameter input)
        {
            InputPara = input;
            InternalPara = new InternalParameter();
            OutputPara = new OutputParameter();
            OutputDBASE = new OutputDBA();
        }

        /// <summary>
        /// Initialisieren der Lohnsteuerberechnung
        /// </summary>
        public void Init()
        {
            MPARA();
            MRE4JL();

            InternalPara.VBEZBSO = 0;
            InternalPara.KENNVMT = 0;

            MRE4();
            MRE4ABZ();
            MBERECH();
            MSONST();
            MVMT();
        }

        /// <summary>
        /// Zuweisung von Werten für bestimmte Sozialversicherungsparameter
        /// </summary>
        private void MPARA()
        {
            //Parameter Rentenversicherung
            if (InputPara.KRV < 2)
            {
                InternalPara.BBGRV = InputPara.KRV == 0 ? 87600 : 85200;
                InternalPara.RVSATZAN = 0.093m;
                InternalPara.TBSVORV = 1.00m;
            }

            InternalPara.BBGKVPV = 59850;
            //Parameter Krankenversicherung / Pflegeversicherung
            InternalPara.KVSATZAN = InputPara.KVZ / 2 / 100 + 0.07m;
            InternalPara.KVSATZAG = 0.008m + 0.07m;

            if (InputPara.LZZ == 1)
            {
                if (InputPara.PVS == 1)
                {
                    InternalPara.PVSATZAN = 0.021125m;
                    InternalPara.PVSATZAG = 0.011125m;
                }
                else
                {
                    InternalPara.PVSATZAN = 0.016125m;
                    InternalPara.PVSATZAG = 0.016125m;
                }

                InternalPara.PVSATZAN = InputPara.PVZ == 1 ? InternalPara.PVSATZAN + 0.00475m : InternalPara.PVSATZAN;
            }
            else
            {
                if (InputPara.PVS == 1)
                {
                    InternalPara.PVSATZAN = 0.022m;
                    InternalPara.PVSATZAG = 0.012m;
                }
                else
                {
                    InternalPara.PVSATZAN = 0.017m;
                    InternalPara.PVSATZAG = 0.017m;
                }

                InternalPara.PVSATZAN = InputPara.PVZ == 1 ? InternalPara.PVSATZAN + 0.006m : InternalPara.PVSATZAN;
            }

            //Grenzwerte für die Steuerklassen V / VI
            InternalPara.W1STKL5 = 12485;
            InternalPara.W2STKL5 = 31404;
            InternalPara.W3STKL5 = 222260;
            //Grundfreibetrag
            InternalPara.GFB = 10908;
            //Freigrenze SolZ
            InternalPara.SOLZFREI = 17543;
        }

        /// <summary>
        /// Ermittlung des Jahresarbeitslohns und der Freibeträge
        /// § 39b Absatz 2 Satz 2 EStG
        /// </summary>
        private void MRE4JL()
        {
            switch (InputPara.LZZ)
            {
                case 1:
                    InternalPara.ZRE4J = InputPara.RE4 / 100;
                    InternalPara.ZVBEZJ = InputPara.VBEZ / 100;
                    InternalPara.JLFREIB = InputPara.LZZFREIB / 100;
                    InternalPara.JLHINZU = InputPara.LZZHINZU / 100;
                    break;
                case 2:
                    InternalPara.ZRE4J = InputPara.RE4 * 12 / 100;
                    InternalPara.ZVBEZJ = InputPara.VBEZ * 12 / 100;
                    InternalPara.JLFREIB = InputPara.LZZFREIB * 12 / 100;
                    InternalPara.JLHINZU = InputPara.LZZHINZU * 12 / 100;
                    break;
                case 3:
                    InternalPara.ZRE4J = InputPara.RE4 * 360 / 7 / 100;
                    InternalPara.ZVBEZJ = InputPara.VBEZ * 360 / 7 / 100;
                    InternalPara.JLFREIB = InputPara.LZZFREIB * 360 / 7 / 100;
                    InternalPara.JLHINZU = InputPara.LZZHINZU * 360 / 7 / 100;
                    break;
                default:
                    InternalPara.ZRE4J = InputPara.RE4 * 360 / 100;
                    InternalPara.ZVBEZJ = InputPara.VBEZ * 360 / 100;
                    InternalPara.JLFREIB = InputPara.LZZFREIB * 360 / 100;
                    InternalPara.JLHINZU = InputPara.LZZHINZU * 360 / 100;
                    break;
            }

            InputPara.F = InputPara.AF == 0 ? 1 : InputPara.F;
        }

        #region MRE4
        /// <summary>
        /// Freibeträge für Versorgungsbezüge, Altersentlastungsbetrag
        /// (§ 39b Absatz 2 Satz 3 EStG)
        /// </summary>
        private void MRE4()
        {
            if (InternalPara.ZVBEZJ == 0)
            {
                InternalPara.FVBZ = 0;
                InternalPara.FVB = 0;
                InternalPara.FVBZSO = 0;
                InternalPara.FVBSO = 0;
            }
            else
            {
                if (InputPara.VJAHR < 2006)
                    InternalPara.J = 1;
                else
                    InternalPara.J = InputPara.VJAHR < 2040 ? InputPara.VJAHR - 2004 : 36;

                if (InputPara.LZZ == 1)
                {
                    InternalPara.VBEZB = InputPara.VBEZM * InputPara.ZMVB + InputPara.VBEZS;
                    InternalPara.HFVB = TABS.TAB2[InternalPara.J] / 12 * InputPara.ZMVB;
                    InternalPara.FVBZ = Math.Ceiling(TABS.TAB3[InternalPara.J] / 12 * InputPara.ZMVB);
                }
                else
                {
                    InternalPara.VBEZB = InputPara.VBEZM * 12 + InputPara.VBEZS;
                    InternalPara.HFVB = TABS.TAB2[InternalPara.J];
                    InternalPara.FVBZ = TABS.TAB3[InternalPara.J];
                }

                InternalPara.FVB = Rounding.RoundUp(InternalPara.VBEZB * TABS.TAB1[InternalPara.J] / 100, 2);
                InternalPara.FVB = InternalPara.FVB > InternalPara.HFVB ? InternalPara.HFVB : InternalPara.FVB;
                InternalPara.FVB = InternalPara.FVB > InternalPara.ZVBEZJ ? InternalPara.ZVBEZJ : InternalPara.FVB;

                InternalPara.FVBSO =
                    Rounding.RoundUp(InternalPara.FVB * InternalPara.VBEZBSO * TABS.TAB1[InternalPara.J] / 100, 2);
                InternalPara.FVBSO = InternalPara.FVBSO > TABS.TAB2[InternalPara.J]
                    ? TABS.TAB2[InternalPara.J]
                    : InternalPara.FVBSO;

                InternalPara.HFVBZSO = (InternalPara.VBEZB + InternalPara.VBEZBSO) / 100 - InternalPara.FVBSO;

                InternalPara.FVBZSO = Math.Ceiling(InternalPara.FVBZ + InternalPara.VBEZBSO / 100);
                InternalPara.FVBZSO = InternalPara.FVBZSO > InternalPara.HFVBZSO
                    ? Math.Ceiling(InternalPara.HFVBZSO)
                    : InternalPara.FVBZSO;
                InternalPara.FVBZSO = InternalPara.FVBZSO > TABS.TAB3[InternalPara.J]
                    ? TABS.TAB3[InternalPara.J]
                    : InternalPara.FVBZSO;

                InternalPara.HFVBZ = InternalPara.VBEZB / 100 - InternalPara.FVB;

                InternalPara.FVBZ = InternalPara.FVBZ > InternalPara.HFVBZ
                    ? Math.Ceiling(InternalPara.HFVBZ)
                    : InternalPara.FVBZ;
            }

            MRE4ALTE();
        }

        /// <summary>
        /// Altersentlastungsbetrag (§ 39b Absatz 2 Satz 3 EStG)
        /// </summary>
        private void MRE4ALTE()
        {
            if (InputPara.ALTER1 == 0)
                InternalPara.ALTE = 0;
            else
            {
                if (InputPara.AJAHR < 2006)
                    InternalPara.K = 1;
                else if (InputPara.AJAHR < 2040)
                    InternalPara.K = InputPara.AJAHR - 2004;
                else
                    InternalPara.K = 36;

                InternalPara.BMG = InternalPara.ZRE4J - InternalPara.ZVBEZJ;
                InternalPara.ALTE = Math.Ceiling(InternalPara.BMG * TABS.TAB4[InternalPara.K]);
                InternalPara.HBALTE = TABS.TAB5[InternalPara.K];

                InternalPara.ALTE = InternalPara.ALTE > InternalPara.HBALTE ? InternalPara.HBALTE : InternalPara.ALTE;
            }
        }
        #endregion

        /// <summary>
        /// Ermittlung des Jahresarbeitslohns nach Abzug der 
        /// Freibeträge nach § 39b Absatz 2 Satz 3 und 4 EStG
        /// </summary>
        private void MRE4ABZ()
        {
            InternalPara.ZRE4 = InternalPara.ZRE4J - InternalPara.FVB - InternalPara.ALTE - InternalPara.JLFREIB + InternalPara.JLHINZU;
            InternalPara.ZRE4 = InternalPara.ZRE4 < 0 ? 0 : InternalPara.ZRE4;
            InternalPara.ZRE4VP = InternalPara.KENNVMT == 2 ? InternalPara.ZRE4VP - InputPara.ENTSCH / 100 : InternalPara.ZRE4J;
            InternalPara.ZVBEZ = InternalPara.ZVBEZJ - InternalPara.FVB;
            InternalPara.ZVBEZ = InternalPara.ZVBEZ < 0 ? 0 : InternalPara.ZVBEZ;
        }

        #region MBERECH
        private void MBERECH()
        {
            //Ermittlung der festen Tabellenfreibeträge(ohne Vorsorgepauschale)
            MZTABFB();

            OutputDBASE.VFRB = (InternalPara.ANP + InternalPara.FVB + InternalPara.FVBZ) * 100;

            //Ermittlung der Jahreslohnsteuer für die Lohnsteuerberechnung
            MLSTJAHR();

            OutputDBASE.WVFRB = (InternalPara.ZVE - InternalPara.GFB) * 100;
            OutputDBASE.WVFRB = OutputDBASE.WVFRB < 0 ? 0 : OutputDBASE.WVFRB;
            InternalPara.LSTJAHR = (int)(InternalPara.ST * InputPara.F);

            UPLSTLZZ();
            UPVKVLZZ();

            if (InputPara.ZKF > 0)
            {
                //Berechnung der Tabellenfreibeträge mit Freibeträgen für Kinder für die
                //Bemessungsgrundlage KiSt und SOLZ
                InternalPara.ZTABFB += InternalPara.KFB;
                MRE4ABZ();

                //Ermittlung der Jahreslohnsteuer mit Freibeträgen für Kinder als
                //Jahresbemessungsgrundlage KiSt und SOLZ
                MLSTJAHR();

                InternalPara.JBMG = InternalPara.ST * InputPara.F;
            }
            else
                InternalPara.JBMG = InternalPara.LSTJAHR;

            MSOLZ();
        }

        /// <summary>
        /// Ermittlung der festen Tabellenfreibeträge (ohne Vorsorgepauschale)
        /// </summary>
        private void MZTABFB()
        {
            InternalPara.ANP = 0;

            // Mögliche Begrenzung des Zuschlags zum Versorgungsfreibetrag, und
            // Festlegung und Begrenzung Werbungskosten - Pauschbetrag für 
            // Versorgungsbezüge
            if (InternalPara.ZVBEZ >= 0)
            {
                if (InternalPara.ZVBEZ < InternalPara.FVBZ)
                    InternalPara.FVBZ = InternalPara.ZVBEZ;
            }

            // Festlegung ArbeitnehmerPauschbetrag für 
            // aktiven Lohn mit möglicher Begrenzung
            if (InputPara.STKL < 6)
            {
                if (InternalPara.ZVBEZ > 0)
                    InternalPara.ANP = InternalPara.ZVBEZ - InternalPara.FVBZ < 102 ? Math.Ceiling(InternalPara.ZVBEZ - InternalPara.FVBZ) : 102;
            }
            else
            {
                InternalPara.FVBZ = 0;
                InternalPara.FVBZSO = 0;
            }

            if (InputPara.STKL < 6)
            {
                if (InternalPara.ZRE4 > InternalPara.ZVBEZ)
                {
                    InternalPara.ANP = InternalPara.ZRE4 - InternalPara.ZVBEZ < 1230 ?
                        Math.Ceiling(InternalPara.ANP + InternalPara.ZRE4 - InternalPara.ZVBEZ) :
                        InternalPara.ANP + 1230;
                }
            }

            InternalPara.KZTAB = 1;

            switch (InputPara.STKL)
            {
                case 1:
                    InternalPara.SAP = 36;
                    InternalPara.KFB = InputPara.ZKF * 8952;
                    break;
                case 2:
                    InputPara.EFA = 4260;
                    InternalPara.SAP = 36;
                    InternalPara.KFB = InputPara.ZKF * 8952;
                    break;
                case 3:
                    InternalPara.KZTAB = 2;
                    InternalPara.SAP = 36;
                    InternalPara.KFB = InputPara.ZKF * 8952;
                    break;
                case 4:
                    InternalPara.SAP = 36;
                    InternalPara.KFB = InputPara.ZKF * 4476;
                    break;
                case 5:
                    InternalPara.SAP = 36;
                    InternalPara.KFB = 0;
                    break;
                default:
                    InternalPara.KFB = 0;
                    break;
            }

            // Berechnung der Tabellenfreibeträge ohne Freibeträge für Kinder für die Lohnsteuerberechnung
            InternalPara.ZTABFB = InputPara.EFA + InternalPara.ANP + InternalPara.SAP + InternalPara.FVBZ;
        }

        #region MLSTJAHR
        /// <summary>
        /// Ermittlung Jahreslohnsteuer
        /// </summary>
        private void MLSTJAHR()
        {
            UPEVP();

            //Ermittlung der Steuer bei Vergütung für mehrjährige Tätigkeit
            if (InternalPara.KENNVMT != 1)
            {
                InternalPara.ZVE = InternalPara.ZRE4 - InternalPara.ZTABFB - InternalPara.VSP;
                UPMLST();
            }
            else
            {
                InternalPara.ZVE = InternalPara.ZRE4 - InternalPara.ZTABFB - InternalPara.VSP - InputPara.VMT / 100 - InputPara.VKAPA / 100;

                //Sonderfall des negativen verbleibenden zvE nach § 34 Absatz 1 Satz 3 EStG
                if (InternalPara.ZVE < 0)
                {
                    InternalPara.ZVE = (InternalPara.ZVE + InputPara.VMT / 100 + InputPara.VKAPA / 100) / 5;
                    UPMLST();
                    InternalPara.ST *= 5;
                }
                else
                {
                    //Steuerberechnung ohne Einkünfte nach § 34 EStG
                    UPMLST();
                    InternalPara.STOVMT = InternalPara.ST;

                    // Steuerberechnung mit Einkünften nach§ 34 EStG
                    InternalPara.ZVE += (InputPara.VMT + InputPara.VKAPA) / 500;
                    UPMLST();
                    InternalPara.ST = (InternalPara.ST - InternalPara.STOVMT) * 5 + InternalPara.STOVMT;
                }
            }
        }

        private void UPMLST()
        {
            InternalPara.ZVE = InternalPara.ZVE < 1 ? 0 : InternalPara.ZVE;
            InternalPara.X = InternalPara.ZVE < 1 ? 0 : Math.Floor(InternalPara.ZVE / InternalPara.KZTAB);

            if (InputPara.STKL < 5)
                UPTAB();
            else
                MST5_6();
        }

        /// <summary>
        /// Tarifliche Einkommensteuer (§ 32a EStG)
        /// </summary>
        private void UPTAB()
        {
            if (InternalPara.X < InternalPara.GFB + 1)
            {
                InternalPara.ST = 0;
            }
            else if (InternalPara.X < 16000)
            {
                InternalPara.Y = (InternalPara.X - InternalPara.GFB) / 10000;
                InternalPara.RW = InternalPara.Y * 979.18m;
                InternalPara.RW += 1400;
                InternalPara.ST = Math.Floor(InternalPara.RW * InternalPara.Y);
            }
            else if (InternalPara.X < 62810)
            {
                InternalPara.Y = (InternalPara.X - 15999) / 10000;
                InternalPara.RW = InternalPara.Y * 192.59m;
                InternalPara.RW += 2397;
                InternalPara.RW *= InternalPara.Y;
                InternalPara.ST = Math.Floor(InternalPara.RW + 966.53m);
            }
            else if (InternalPara.X < 277826)
            {
                InternalPara.ST = Math.Floor(InternalPara.X * 0.42m - 9972.98m);
            }
            else
            {
                InternalPara.ST = Math.Floor(InternalPara.X * 0.45m - 18307.73m);
            }

            InternalPara.ST *= InternalPara.KZTAB;
        }

        /// <summary>
        /// Lohnsteuer für die Steuerklassen V und VI (§ 39b Absatz 2 Satz 7 EStG)
        /// </summary>
        private void MST5_6()
        {
            InternalPara.ZZX = InternalPara.X;

            if (InternalPara.ZZX > InternalPara.W2STKL5)
            {
                InternalPara.ZX = InternalPara.W2STKL5;
                UP5_6();

                if (InternalPara.ZZX > InternalPara.W3STKL5)
                {
                    InternalPara.ST = Math.Floor(InternalPara.ST + (InternalPara.W3STKL5 - InternalPara.W2STKL5) * 0.42m);
                    InternalPara.ST = Math.Floor(InternalPara.ST + (InternalPara.ZZX - InternalPara.W3STKL5) * 0.45m);
                }
                else
                    InternalPara.ST = Math.Floor(InternalPara.ST + (InternalPara.ZZX - InternalPara.W2STKL5) * 0.42m);
            }
            else
            {
                InternalPara.ZX = InternalPara.ZZX;
                UP5_6();

                if (InternalPara.ZZX > InternalPara.W1STKL5)
                {
                    InternalPara.VERGL = InternalPara.ST;
                    InternalPara.ZX = InternalPara.W1STKL5;
                    UP5_6();
                    InternalPara.HOCH = Math.Floor(InternalPara.ST + (InternalPara.ZZX - InternalPara.W1STKL5) * 0.42m);

                    InternalPara.ST = InternalPara.HOCH < InternalPara.VERGL ? InternalPara.HOCH : InternalPara.VERGL;
                }
            }
        }

        private void UP5_6()
        {
            InternalPara.X = InternalPara.ZX * 1.25m;
            UPTAB();
            InternalPara.ST1 = InternalPara.ST;
            InternalPara.X = InternalPara.ZX * 0.75m;
            UPTAB();
            InternalPara.ST2 = InternalPara.ST;
            InternalPara.DIFF = (InternalPara.ST1 - InternalPara.ST2) * 2;
            InternalPara.MIST = Math.Floor(InternalPara.ZX * 0.14m);
            InternalPara.ST = InternalPara.MIST > InternalPara.DIFF ? InternalPara.MIST : InternalPara.DIFF;
        }

        /// <summary>
        /// Ermittlung der Vorsorgepauschale
        /// </summary>
        private void UPEVP()
        {
            if (InputPara.KRV > 1)
                InternalPara.VSP1 = 0;
            else
            {
                InternalPara.ZRE4VP = InternalPara.ZRE4VP > InternalPara.BBGRV ?
                    InternalPara.BBGRV :
                    InternalPara.ZRE4VP;

                InternalPara.VSP1 = InternalPara.TBSVORV * InternalPara.ZRE4VP;
                InternalPara.VSP1 *= InternalPara.RVSATZAN;
            }

            InternalPara.VSP2 = 0.12m * InternalPara.ZRE4VP;
            InternalPara.VHB = InputPara.STKL == 3 ? 3000 : 1900;
            InternalPara.VSP2 = InternalPara.VSP2 > InternalPara.VHB ? InternalPara.VHB : InternalPara.VSP2;
            InternalPara.VSPN = Math.Ceiling(InternalPara.VSP1 + InternalPara.VSP2);
            MVSP();
            InternalPara.VSP = InternalPara.VSPN > InternalPara.VSP ? InternalPara.VSPN : InternalPara.VSP;
        }

        /// <summary>
        /// Vorsorgepauschale (§ 39b Absatz 2 Satz 5 Nummer 3 EStG) 
        /// Vergleichsberechnung zur Mindestvorsorgepauschale
        /// </summary>
        private void MVSP()
        {
            InternalPara.ZRE4VP = InternalPara.ZRE4VP > InternalPara.BBGKVPV ? InternalPara.BBGKVPV : InternalPara.ZRE4VP;

            if (InputPara.PKV > 0)
            {
                if (InputPara.STKL == 6)
                    InternalPara.VSP3 = 0;
                else
                {
                    InternalPara.VSP3 = InputPara.PKPV * 12 / 100;
                    InternalPara.VSP3 = InputPara.PKV == 2 ?
                        InternalPara.VSP3 - InternalPara.ZRE4VP * (InternalPara.KVSATZAG + InternalPara.PVSATZAG) :
                        InternalPara.VSP3;
                }
            }
            else
                InternalPara.VSP3 = InternalPara.ZRE4VP * (InternalPara.KVSATZAN + InternalPara.PVSATZAN);

            InternalPara.VSP = Math.Ceiling(InternalPara.VSP3 + InternalPara.VSP1);
        }
        #endregion

        #region UPLSTLZZ
        /// <summary>
        /// Ermittlung des Anteils der Jahreslohnsteuer für den Lohnzahlungszeitraum
        /// </summary>
        private void UPLSTLZZ()
        {
            InternalPara.JW = InternalPara.LSTJAHR * 100;

            // Ermittlung des Anteils der Jahreslohnsteuer
            // für den Lohnzahlungszeitraum
            UPANTEIL();

            OutputPara.LSTLZZ = InternalPara.ANTEIL1;
        }

        /// <summary>
        /// Anteil von Jahresbeträgen für einen LZZ(§ 39b Absatz 2 Satz 9 EStG)
        /// </summary>
        private void UPANTEIL()
        {
            switch (InputPara.LZZ)
            {
                case 1:
                    InternalPara.ANTEIL1 = InternalPara.JW;
                    break;
                case 2:
                    InternalPara.ANTEIL1 = Math.Floor(InternalPara.JW / 12);
                    break;
                case 3:
                    InternalPara.ANTEIL1 = Math.Floor(InternalPara.JW * 7 / 360);
                    break;
                default:
                    InternalPara.ANTEIL1 = Math.Floor(InternalPara.JW / 360);
                    break;
            }
        }
        #endregion

        #region UPVKVLZZ
        private void UPVKVLZZ()
        {
            UPVKV();
            InternalPara.JW = InternalPara.VKV;

            //Ermittlung des Anteils der berücksichtigten privaten
            //Kranken- und Pflegeversicherungsbeiträge für den Lohnzahlungszeitraum
            UPANTEIL();

            OutputPara.VKVLZZ = InternalPara.ANTEIL1;
        }

        /// <summary>
        /// Ermittlung des Jahreswertes der berücksichtigten privaten Kranken- 
        /// und Pflegeversicherungsbeiträge
        /// </summary>
        private void UPVKV()
        {
            if (InputPara.PKV > 0)
            {
                InternalPara.VKV = InternalPara.VSP2 > InternalPara.VSP3 ?
                    InternalPara.VSP2 * 100 :
                    InternalPara.VSP3 * 100;
            }
            else
                InternalPara.VKV = 0;
        }
        #endregion

        /// <summary>
        /// Solidaritätszuschlag
        /// </summary>
        private void MSOLZ()
        {
            InternalPara.SOLZFREI *= InternalPara.KZTAB;

            if (InternalPara.JBMG > InternalPara.SOLZFREI)
            {
                InternalPara.SOLZJ = Rounding.RoundDown(InternalPara.JBMG * 5.5m / 100, 2);
                InternalPara.SOLZMIN = (InternalPara.JBMG - InternalPara.SOLZFREI) * 11.9m / 100;
                InternalPara.SOLZJ = InternalPara.SOLZMIN < InternalPara.SOLZJ ? InternalPara.SOLZMIN : InternalPara.SOLZJ;
                InternalPara.JW = InternalPara.SOLZJ * 100;

                UPANTEIL();

                OutputPara.SOLZLZZ = InternalPara.ANTEIL1;
            }
            else
                OutputPara.SOLZLZZ = 0;

            // Aufteilung des Betrages nach § 51a EStG 
            // auf den LZZ für die Kirchensteuer
            if (InputPara.R > 0)
            {
                InternalPara.JW = InternalPara.JBMG * 100;
                UPANTEIL();
                OutputPara.BK = InternalPara.ANTEIL1;
            }
            else
                OutputPara.BK = 0;
        }
        #endregion

        #region MSONST
        /// <summary>
        /// Berechnung sonstiger Bezüge nach § 39b Absatz 3 Satz 1 bis 8 EStG
        /// </summary>
        private void MSONST()
        {
            InputPara.LZZ = 1;
            InputPara.ZMVB = InputPara.ZMVB == 0 ? 12 : InputPara.ZMVB;

            if (InputPara.SONSTB == 0 && InputPara.MBV == 0)
            {
                OutputPara.VKVSONST = 0;
                InternalPara.LSTSO = 0;
                OutputPara.STS = 0;
                OutputPara.SOLZS = 0;
                OutputPara.BKS = 0;
            }
            else
            {
                MOSONST();
                UPVKV();

                OutputPara.VKVSONST = InternalPara.VKV;
                InternalPara.ZRE4J = (InputPara.JRE4 + InputPara.SONSTB) / 100;
                InternalPara.ZVBEZJ = (InputPara.JVBEZ + InputPara.VBS) / 100;
                InternalPara.VBEZBSO = InputPara.STERBE;

                MRE4SONST();
                MLSTJAHR();

                OutputDBASE.WVFRBM = (InternalPara.ZVE - InternalPara.GFB) * 100;
                OutputDBASE.WVFRBM = OutputDBASE.WVFRBM < 0 ? 0 : OutputDBASE.WVFRBM;

                UPVKV();
                OutputPara.VKVSONST = InternalPara.VKV - OutputPara.VKVSONST;
                InternalPara.LSTSO = InternalPara.ST * 100;
                OutputPara.STS = Math.Ceiling((InternalPara.LSTSO - InternalPara.LSTOSO) * InputPara.F);

                //OutputPara.STS = OutputPara.STS < 0 ? 0 : OutputPara.STS;
                STSMIN();
            }
        }

        private void STSMIN()
        {
            if (OutputPara.STS < 0)
            {
                if (InputPara.MBV != 0)
                {
                    OutputPara.LSTLZZ = OutputPara.LSTLZZ + OutputPara.STS;
                    OutputPara.LSTLZZ = OutputPara.LSTLZZ < 0 ? 0 : OutputPara.LSTLZZ + OutputPara.STS;

                    OutputPara.SOLZLZZ = Math.Ceiling(OutputPara.SOLZLZZ + OutputPara.STS * 5.5m / 100);
                    OutputPara.SOLZLZZ = OutputPara.SOLZLZZ < 0 ? 0 : OutputPara.SOLZLZZ;

                    OutputPara.BK = OutputPara.BK + OutputPara.STS;
                    OutputPara.BK = OutputPara.BK < 0 ? 0 : OutputPara.BK;
                }

                // Negative Lohnsteuer auf sonstigen Bezug wird nicht zugelassen.
                OutputPara.STS = 0;
                OutputPara.SOLZS = 0;
            }
            else
            {
                MSOLZSTS();
            }

            OutputPara.BKS = InputPara.R > 0 ? OutputPara.STS : 0;
        }

        /// <summary>
        /// Sonderberechnung ohne sonstige Bezüge für Berechnung bei sonstigen
        /// Bezügen oder Vergütung für mehrjährige Tätigkeit
        /// </summary>
        private void MOSONST()
        {
            InternalPara.ZRE4J = InputPara.JRE4 / 100;
            InternalPara.ZVBEZJ = InputPara.JVBEZ / 100;
            InternalPara.JLFREIB = InputPara.JFREIB / 100;
            InternalPara.JLHINZU = InputPara.JHINZU / 100;

            MRE4();
            MRE4ABZ();

            InternalPara.ZRE4VP -= InputPara.JRE4ENT / 100;

            MZTABFB();

            OutputDBASE.VFRBS1 = (InternalPara.ANP + InternalPara.FVB + InternalPara.FVBZ) * 100;
            MLSTJAHR();
            OutputDBASE.WVFRBO = (InternalPara.ZVE - InternalPara.GFB) * 100;
            OutputDBASE.WVFRBO = OutputDBASE.WVFRBO < 0 ? 0 : OutputDBASE.WVFRBO;

            InternalPara.LSTOSO = InternalPara.ST * 100;
        }

        /// <summary>
        /// Sonderberechnung mit sonstigen Bezügen für Berechnung bei sonstigen
        /// Bezügen oder Vergütung für mehrjährige Tätigkeit
        /// </summary>
        private void MRE4SONST()
        {
            MRE4();

            InternalPara.FVB = InternalPara.FVBSO;

            MRE4ABZ();

            InternalPara.ZRE4VP = InternalPara.ZRE4VP +
                InputPara.MBV / 100 -
                InputPara.JRE4ENT / 100 -
                InputPara.SONSTENT / 100;
            InternalPara.FVBZ = InternalPara.FVBZSO;

            MZTABFB();

            OutputDBASE.VFRBS2 = (InternalPara.ANP + InternalPara.FVB + InternalPara.FVBZ) * 100 - OutputDBASE.VFRBS1;
        }

        /// <summary>
        /// Berechnung des SolZ auf sonstige Bezüge
        /// </summary>
        private void MSOLZSTS()
        {
            InternalPara.SOLZSZVE = InputPara.ZKF > 0 ? InternalPara.ZVE - InternalPara.KFB : InternalPara.ZVE;
            InternalPara.X = InternalPara.SOLZSZVE < 1 ? 0 : Math.Floor(InternalPara.SOLZSZVE / InternalPara.KZTAB);
            InternalPara.SOLZSZVE = InternalPara.SOLZSZVE < 1 ? 0 : InternalPara.SOLZSZVE;

            if (InputPara.STKL < 5)
                UPTAB();
            else
                MST5_6();

            InternalPara.SOLZSBMG = Math.Floor(InternalPara.ST * InputPara.F);

            OutputPara.SOLZS = InternalPara.SOLZSBMG > InternalPara.SOLZFREI
                ? Rounding.RoundDown(OutputPara.STS * 5.5m / 100, 2)
                : 0;
        }
        #endregion

        #region MVMT
        /// <summary>
        /// Berechnung der Entschädigung und Vergütung für mehrjährige
        /// Tätigkeit nach § 39b Absatz 3 Satz 9 und 10 EStG
        /// </summary>
        private void MVMT()
        {
            InputPara.VKAPA = InputPara.VKAPA < 0 ? 0 : InputPara.VKAPA;

            if (InputPara.VMT + InputPara.VKAPA > 0)
            {
                //Steuerberechnung ohne Vergütung für mehrjährige Tätigkeit
                if (InternalPara.LSTSO == 0)
                {
                    MOSONST();
                    InternalPara.LST1 = InternalPara.LSTOSO;
                }
                else
                    InternalPara.LST1 = InternalPara.LSTSO;

                // Vergleichsberechnung der Vergütung für mehrjährige
                // Tätigkeit als sonstiger Bezug
                InternalPara.VBEZBSO = InputPara.STERBE + InputPara.VKAPA;
                InternalPara.ZRE4J = (InputPara.JRE4 + InputPara.SONSTB + InputPara.VMT + InputPara.VKAPA) / 100;
                InternalPara.ZVBEZJ = (InputPara.JVBEZ + InputPara.VBS + InputPara.VKAPA) / 100;
                InternalPara.KENNVMT = 2;
                MRE4SONST();

                MLSTJAHR();
                InternalPara.LST3 = InternalPara.ST * 100;

                //Steuerberechnung mit Vergütung für mehrjährige Tätigkeit
                MRE4ABZ();
                InternalPara.ZRE4VP -= InputPara.JRE4ENT / 100 - InputPara.SONSTENT / 100;
                InternalPara.KENNVMT = 1;
                MLSTJAHR();
                InternalPara.LST2 = InternalPara.ST * 100;

                OutputPara.STV = InternalPara.LST2 - InternalPara.LST1;
                InternalPara.LST3 -= InternalPara.LST1;
                OutputPara.STV = InternalPara.LST3 < OutputPara.STV ? InternalPara.LST3 : OutputPara.STV;
                // Negative Steuer auf mehrjährigen Bezug wird nicht zugelassen.
                OutputPara.STV = OutputPara.STV < 0 ? 0 : Math.Floor(OutputPara.STV * InputPara.F);
                InternalPara.SOLZVBMG = OutputPara.STV / 100 + InternalPara.JBMG;
                OutputPara.SOLZV = InternalPara.SOLZVBMG > InternalPara.SOLZFREI ?
                    Rounding.RoundDown(OutputPara.STV * 5.5m / 100, 2) :
                    0;
                OutputPara.BKV = InputPara.R > 0 ? OutputPara.STV : 0;
            }
            else
            {
                OutputPara.STV = 0;
                OutputPara.SOLZV = 0;
                OutputPara.BKV = 0;
            }
        }
        #endregion
    }
}