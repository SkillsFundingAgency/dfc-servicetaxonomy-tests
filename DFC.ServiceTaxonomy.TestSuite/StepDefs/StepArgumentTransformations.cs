using DFC.ServiceTaxonomy.TestSuite.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{
    [Binding]
    public sealed class StepArgumentTransformations
    {
        private ScenarioContext _context;

        public StepArgumentTransformations( ScenarioContext context )
        {
            _context = context;
        }

        [StepArgumentTransformation]
        public string TransformHumanReadableIntegerExpression(string expression)
        {
            switch ( expression.ToLower())
            {
                //case constants.published:
                case constants.publish:
                    expression = constants.publish;
                    break;
                //case constants.draft:
                case constants.preview:
                    expression = constants.preview;
                    break;
                case "draft discarded":
                    expression = "draft-discarded";
                    break;

                default:
                    break;
            }
            return _context.ReplaceTokensInString(expression);
        }
    }
}
