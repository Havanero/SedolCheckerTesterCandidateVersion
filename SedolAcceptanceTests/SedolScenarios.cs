using fit;
using fitlibrary;
using NUnit.Framework; 
using SedolValidatorBusinessLogic;
using SedolValidatorInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedolAcceptanceTests
{
    class SedolScenarios:ColumnFixture
    {
        
        private string _validationMessage;
        private ISedolValidationResult validationResult;
        
        public string InputSedol(string input)
        {           
            var validator = new SedolValidator();

            validationResult = validator.ValidateSedol(input);
            _validationMessage = validationResult.ValidationDetails;            

            return _validationMessage;

        }

        public SedolScenarios()
        {

        }              
                
        public bool IsSedolValid()
        {
            return validationResult.IsValidSedol;
        }

        public bool IsSEDOLUser_Defined()
        {                     
            return validationResult.IsUserDefined;
        }        

                  
        
    }
}
