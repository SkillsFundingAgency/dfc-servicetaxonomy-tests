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
        [StepArgumentTransformation]
        public string TransformHumanReadableIntegerExpression(string expression)
        {
            switch ( expression.ToLower())
            {
                case constants.published:
                case constants.publish:
                    expression = constants.publish;
                    break;
                case constants.draft:
                case constants.preview:
                    expression = constants.preview;
                    break;
                default:
                    break;
            }
            return expression;
        }
    }
}
