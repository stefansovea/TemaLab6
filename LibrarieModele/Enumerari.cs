using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarieModele
{
    public enum ClasaBuget
    {
        HighEnd=1,
        MidEnd=2,
        LowEnd=3
    };
   
    [Flags]   
    public enum Optiuni
    {
        AerConditionat=1,
        CutieAutomata=2,
        Decapotabila=4,
        Navigatie=8,
        SonorizareBOSE=16
    };
}
