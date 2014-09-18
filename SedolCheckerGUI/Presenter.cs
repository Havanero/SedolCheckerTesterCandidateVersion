namespace SedolCheckerGUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SedolValidatorBusinessLogic;

    public class Presenter
    {
        IView View { get; set; }

        public Presenter(IView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("View not initialized.");
            }

            View = view;
        }

        public void OnValidate()
        {
            var input = View.InputSedol;

            var validator = new SedolValidator();
            var result = validator.ValidateSedol(input);

            View.IsValid = result.IsValidSedol;
            View.IsUserDefined = result.IsUserDefined;
            View.ValidationDetails = result.ValidationDetails;
        }
    }
}
