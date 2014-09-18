namespace SedolCheckerGUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IView
    {
        string InputSedol { get; }
        bool IsValid { set; }
        bool IsUserDefined { set; }
        string ValidationDetails { set; }
    }
}
