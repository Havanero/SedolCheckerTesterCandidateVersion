using fit;
using fitlibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedolAcceptanceTests
{
    public class SedolAutomation:DoFixture
    {
        public string InputSedol { get; set; }

        [Description("Empty string or string other than 7 characters long.")]
        Fixture EmptyStringOrStringOtherThan7CharactersLong()
        {
            return new SedolScenarios();
        }

        [Description("7-characters long input with incorrect checksum digit")]
        Fixture Seven_CharactersLongInputWithIncorrectChecksumDigit()
        {

            return new SedolScenarios();
        }

        [Description("Valid SEDOL that is not defined by the end user (leading character is not 9).")]
        Fixture ValidSedolThatIsNotDefinedByTheEndUser_LeadingCharacterIsNot9()
        {

            return new SedolScenarios();
        }

        [Description("Valid End User Defined SEDOL (leading character is 9).")]
        Fixture ValidEndUserDefinedSEDOL_LeadingCharacterIs9()
        {

            return new SedolScenarios();
        }
    }

}
