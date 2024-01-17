namespace Ryuk.Helper
{
    public static class Rounding
    {
        /// <summary>
        /// Rundet Werte mit Dezimalstellen entsprechend auf
        /// </summary>
        /// <param name="input">Wert, der aufgerundet werden soll</param>
        /// <param name="places">Anzahl der Dezimalstellen</param>
        /// <returns>Gerundeter Wert mit Anzahl der Dezimalstellen</returns>
        /// <example>
        /// var x = 2.122
        /// x = RoundUp(x, 2) // x = 2,13
        /// </example>
        public static decimal RoundUp(decimal input, int places)
        {
            decimal multiplier = (decimal)Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }

        /// <summary>
        /// Rundet Werte mit Dezimalstellen entsprechend ab
        /// </summary>
        /// <param name="input">Wert, der abgerundet werden soll</param>
        /// <param name="places">Anzahl der Dezimalstellen</param>
        /// <returns>Gerundeter Wert mit Anzahl der Dezimalstellen</returns>
        /// <example>
        /// var x = 2.129
        /// x = RoundDown(x, 2) // x = 2,12
        /// </example>
        public static decimal RoundDown(decimal input, int places)
        {
            decimal multiplier = (decimal)Math.Pow(10, Convert.ToDouble(places));
            return Math.Floor(input * multiplier) / multiplier;
        }
    }
}
