using System.Collections.Generic;

namespace WebTeploobmenApp.Models
{
    public class CalcViewModel : Formulas.Data
    {
        public double[,] ResultTable { get; set; }
        public List<double> PositionsY { get; set; }
        public List<double> TempMaterial { get; set; }
        public List<double> TempGas { get; set; }
        public List<double> TempRaznitsa { get; set; }
    }
}
