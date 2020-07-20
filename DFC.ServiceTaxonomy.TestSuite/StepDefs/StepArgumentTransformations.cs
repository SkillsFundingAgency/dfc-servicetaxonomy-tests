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
                    expression = constants.publish;
                    break;
                case constants.draft:
                    expression = constants.preview;
                    break;
                default:
                    break;
            }
            return expression;
        }
    }
}
