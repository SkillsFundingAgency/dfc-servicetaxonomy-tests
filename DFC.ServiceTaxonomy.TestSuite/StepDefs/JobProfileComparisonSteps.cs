using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using DFC.ServiceTaxonomy.TestSuite.Interfaces;
using DFC.ServiceTaxonomy.TestSuite.Models;
using DFC.ServiceTaxonomy.SharedResources.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DFC.ServiceTaxonomy.TestSuite.StepDefs
{

    public static class EnumerableExtension
    {
        public static string ToHtmlTable<T>(this IEnumerable<T> list, List<string> headerList, List<CustomTableStyle> customTableStyles, params Func<T, object>[] columns)
        {
            if (customTableStyles == null)
                customTableStyles = new List<CustomTableStyle>();

            var tableCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Table).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var trCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Tr).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var thCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Th).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var tdCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Td).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";

            var tableInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Table).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var trInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Tr).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var thInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Th).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var tdInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Td).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";

            var sb = new StringBuilder();

            sb.Append($"<table{(string.IsNullOrEmpty(tableCss) ? "" : $" class=\"{tableCss}\"")}{(string.IsNullOrEmpty(tableInlineCss) ? "" : $" style=\"{tableInlineCss}\"")}>");
            if (headerList != null)
            {
                sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");
                foreach (var header in headerList)
                {
                    sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}>{header}</th>");
                }
                sb.Append("</tr>");
            }
            foreach (var item in list)
            {
                sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");
                foreach (var column in columns)
                    sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")}{(string.IsNullOrEmpty(tdInlineCss) ? "" : $" style=\"{tdInlineCss}\"")}>{column(item)}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        public class CustomTableStyle
        {
            public CustomTableStylePosition CustomTableStylePosition { get; set; }

            public List<string> ClassNameList { get; set; }
            public Dictionary<string, string> InlineStyleValueList { get; set; }
        }

        public enum CustomTableStylePosition
        {
            Table,
            Tr,
            Th,
            Td
        }
    }

    [Binding]
    public sealed class JobProfileComparisonSteps
    {

        public class CustomTableStyle
        {
            public CustomTableStylePosition CustomTableStylePosition { get; set; }

            public List<string> ClassNameList { get; set; }
            public Dictionary<string, string> InlineStyleValueList { get; set; }
        }

        public enum CustomTableStylePosition
        {
            Table,
            Tr,
            Th,
            Td,
            TdGood
        }

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        private int comparisonCount = 0;
        private string JobProfileName = "";
        public JobProfileComparisonSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I have got a list of all available job profile from the existing API")]
        public void GivenIHaveGotAListOfAllAvailableJobProfileFromTheExistingAPI()
        {
            var response = RestHelper.Get(context.GetJobProfileUri("summary"), context.GetJobProfileApiHeaders());
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JArray responseData = JArray.Parse(response.Content);
            var allJobProfiles = responseData.ToObject<List<JobProfileSummary>>();

            context["AllJobProfiles"] = allJobProfiles;
        }

        [Given(@"I have got a list of all available job profile from the new API")]
        public void GivenIHaveGotAListOfAllAvailableJobProfileFromTheNewAPI()
        {
            var response = RestHelper.Get(context.GetTaxonomyUri("GetJobProfileSummary"), context.GetTaxonomyApiHeaders());
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            JArray responseData = JArray.Parse(response.Content);
            var allJobProfiles = responseData.ToObject<List<JobProfileSummary>>();

            context["AllSTAXJobProfiles"] = allJobProfiles;
        }

        [Then(@"The existing and new job profile summaries are comparable")]
        public void ThenTheExistingAndNewJobProfileSummariesAreComparable()
        {
            string padding = "--------------------------------------------------------------------------------------------------------------------------------------------------------";
            List<JobProfileSummary> existingList = (List<JobProfileSummary>)context["AllJobProfiles"];
            List<JobProfileSummary> newList = (List<JobProfileSummary>)context["AllSTAXJobProfiles"];
            int totalFailed = 0;
            //existingList.Count.Should().Be(newList.Count);
            
            // not all are present yet, so drive the checks from the new list

            foreach ( var item in newList)
            {
                bool checksOK = true;
                bool matched, lastUpdateDateCheck, titleCheck, uriCheck;
                matched = lastUpdateDateCheck = titleCheck = uriCheck = false;
                string canonicalName = item.url.Substring(item.url.LastIndexOf('/'));
                var match = existingList.Where(u => u.url.EndsWith(canonicalName)).FirstOrDefault();

                // check titles match
                matched = ( match != null );

                if (matched)
                {
                    // check last updated is not null
                    lastUpdateDateCheck = item.lastUpdated != null;

                    //title check
                    titleCheck = item.title == match.title;

                    //uri check
                    uriCheck = false;

                    checksOK = (matched && lastUpdateDateCheck && titleCheck && uriCheck);
                }
                else
                {
                    Console.WriteLine("");
                }
                Console.WriteLine("Check for {0}{1} is Match {2} \tTitle {3}\tLastUpdate {4}\turi {5}", item.title
                                                                                                      , padding.Substring(0,50-item.title.Length)
                                                                                                      , matched.ToString()
                                                                                                      ,titleCheck
                                                                                                      , lastUpdateDateCheck
                                                                                                      , uriCheck);
                if (!checksOK) totalFailed++;
            }
            Console.WriteLine("Total Checked: {0} Total Failed {1}", newList.Count, totalFailed);
        }

        [Then(@"The output for each API matches for all job profiles NEW VERSION")]
        public void ThenTheOutputForEachAPIMatchesForAllJobProfilesNEWVERSION()
        {
            List<JobProfileSummary> allJobProfiles = new List<JobProfileSummary>();

            JobProfileSummary jps = new JobProfileSummary();

            // jps = new JobProfileSummary();  jps.title ="admin-assistant"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "admin-assistant"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "border-force-officer"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "cabin-crew"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "care-worker"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "construction-labourer"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "electrician"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "emergency-medical-dispatcher"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "farmer"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "mp"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "personal-assistant"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "plumber"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "police-officer"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "postman-or-postwoman"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "primary-school-teacher"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "sales-assistant"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "social-worker"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "train-driver"; allJobProfiles.Add(jps);
            jps = new JobProfileSummary(); jps.title = "waiter"; allJobProfiles.Add(jps);

            List<Dictionary<String, comparedItem>> allComparisons = new List<Dictionary<String, comparedItem>>();

            int max = 2000;
            int count = 0;
            foreach (var jobProfile in allJobProfiles)
            {
                Dictionary<String, comparedItem> comparedItems = new Dictionary<String, comparedItem>();
                comparedItem headerItem = new comparedItem();
                //  get source job profile data

                var responseSourceData = RestHelper.Get( context.GetJobProfileApiBaseUrl() + "/" + jobProfile.title /*jobProfile.url*/, context.GetJobProfileApiHeaders());

                //  get test subject job profile data
                string unslug = char.ToUpper(jobProfile.title[0]) + jobProfile.title.Replace("-", " ").Substring(1);
                if (unslug == "Mp") unslug = "MP";
                if (unslug == "Border force officer") unslug = "Border Force officer";

                var responseTestData = RestHelper.Get(context.GetTaxonomyUri("JobProfileDetail", unslug), context.GetTaxonomyApiHeaders());

                headerItem.Name = jobProfile.title;
                comparedItems["JobProfile"] = headerItem;

                //compReports.
                if (responseTestData.StatusCode == HttpStatusCode.OK)
                {
                    // compare data
                    JObject diffs = FindDiff(JToken.Parse(responseSourceData.Content), JToken.Parse(responseTestData.Content), comparedItems);
                    //exploreJsonObject(JToken.Parse(responseSourceData.Content), 0, "$", JObject.Parse(responseTestData) );
                    //          string output = diffs.ToString();
                    //         Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                    //          Console.WriteLine(output);
                }


                allComparisons.Add(comparedItems);
                count++;
                if (count > max) break;
            }

            var customTableStyles = new List<CustomTableStyle>
            {
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"font-family", "Arial" },{"font-size","15px"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"background-color", "white" }}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Tr, InlineStyleValueList =new Dictionary<string, string>{{"color","Blue"},{"font-size","10px"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Th,ClassNameList = new List<string>{"normal","underline"}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Th,InlineStyleValueList =new Dictionary<string, string>{{ "background-color", "gray"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Td, InlineStyleValueList  =new Dictionary<string, string>{{"color","black"},{"font-size","15px"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.TdGood, InlineStyleValueList  =new Dictionary<string, string>{{"color","black"},{"font-size","15px"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.TdGood, InlineStyleValueList  =new Dictionary<string, string>{{ "background-color", "palegreen"},{"font-size","15px"}}},
            };

            var tableCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Table).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var trCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Tr).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var thCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Th).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var tdCss = string.Join(" ", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Td).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";

            var tableInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Table).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var trInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Tr).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var thInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Th).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var tdInlineCss = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Td).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var tdInlineCssGood = string.Join(";", customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.TdGood).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";

            StringBuilder sb = new StringBuilder();

            sb.Append($"<table{(string.IsNullOrEmpty(tableCss) ? "" : $" class=\"{tableCss}\"")}{(string.IsNullOrEmpty(tableInlineCss) ? "" : $" style=\"{tableInlineCss}\"")}>");


            sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");

            Console.Write("FieldName,");
            sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}FieldName</th>");
            foreach (var dict in allComparisons)
            {
                string jp = dict["JobProfile"].Name;
                Console.Write(jp);
                sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}>{jp}</th>");
            }
            sb.Append("</tr>");

            Console.WriteLine();
            foreach (var item in allComparisons[0].Where(item => item.Key != "JobProfile"))
            {
                sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");

                Console.Write(item.Key + ",");
                sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")}{(string.IsNullOrEmpty(tdInlineCss) ? "" : $" style=\"{tdInlineCss}\"")}>{item.Key}</td>");
                foreach (var dict in allComparisons)
                {
                    string text = "???";
                    string cssFormat = tdInlineCss;
                    string toolTip = "" ;

                    if (dict.ContainsKey(item.Key))
                    {
                        toolTip = " Title=\"" + dict[item.Key].ComparisonId + ". [" + dict["Title"].Title + "]" + dict[item.Key].ComparisonDetail.Replace("\"", "&quot;") + "\" ";
                        text = "";// item.Value.ComparisonId + ". "; 
                        if (dict[item.Key].NewEmpty && dict[item.Key].OriginalEmpty)
                        {
                            text += "BothEmpty";
                            cssFormat = tdInlineCssGood.Replace("palegreen", "lightblue");
                        }
                        else if (dict[item.Key].ContentMatch)
                        {
                            text += "ContentMatch";
                            cssFormat = ( dict[item.Key].SourceManipulated ? tdInlineCssGood.Replace("palegreen", "olive") :
                                                        ( ! dict[item.Key].Manipulated ? tdInlineCssGood : tdInlineCssGood.Replace("palegreen", "darkgreen")  )
                                                        );
                        }
                        else if (dict[item.Key].ToDo)
                        {
                            text += "TODO";
                            cssFormat = tdInlineCssGood.Replace("palegreen", "red");
                        }
                        else if (dict[item.Key].NewEmpty && !dict[item.Key].OriginalEmpty)
                        {
                            text += "NewEmpty";
                            cssFormat = tdInlineCssGood.Replace("palegreen", "lightsalmon");
                        }

                        else if (dict[item.Key].SizesDiffer)
                        {
                            text += "SizesDiffer";
                            cssFormat = tdInlineCssGood.Replace("palegreen", "orange");
                        }
                        else if (dict[item.Key].FormatMatch)
                        {
                            text += "StructureMatch";
                            cssFormat = tdInlineCssGood.Replace("palegreen", "lightyellow");
                        }
 
                        //else if ()
                        else if (!dict[item.Key].Included)
                        {
                            text += "Missing";
                            cssFormat = tdInlineCssGood.Replace("palegreen", "lightgrey");
                        }
                        else
                        {
                            cssFormat = tdInlineCssGood.Replace("palegreen", "lightsalmon");
                            text += "Differs";
                        }
                    }
                    else
                    {
                        text += "Unknown";
                    }


                    sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")}{toolTip}{(string.IsNullOrEmpty(cssFormat) ? "" : $" style=\"{cssFormat}\"")}>{text}</td>");
                }
                sb.Append("</tr>");
                Console.WriteLine();
            }

            sb.Append("</table>");

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(sb);

            string path = @"D:\wamp64\www\jobprofiles\comparison3.html";

            if (File.Exists(path))
            {
                File.Delete(@"D:\wamp64\www\jobprofiles\comparison3.html");
            }
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, sb.ToString());
            }


        }



        [Given(@"I compare actor")]
        public void GivenICompareActor()
        {

            string url = context.GetJobProfileApiBaseUrl()  +"/actor";
            var responseSourceData = RestHelper.Get(url, context.GetJobProfileApiHeaders());


            Dictionary<string, comparedItem> comparison = new Dictionary<string, comparedItem>();

            
            var responseTestData = RestHelper.Get( context.GetTaxonomyApiBaseUrl() + "/getjobprofilebytitle/Execute/Actor" , context.GetTaxonomyApiHeaders());

            // compare data
            JObject diffs = FindDiff(JToken.Parse(responseSourceData.Content), JToken.Parse(responseTestData.Content), comparison);

            string output = diffs.ToString();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(output);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            foreach ( var item in comparison)
            {
                Console.WriteLine(item.Key + "," + item.Value.ContentMatch);
            }
        }


        private JToken ReplaceTags( JToken source, out bool replacementsMade) 
        {
            bool success = true;
            string replacedValue = "";
            string checkValue;
            string newLinkText = "";
            string PATTERN = @"(<a.*?>.*?</a>)";
            string href = "";
            replacementsMade = false;

            try
            {
                replacedValue = source.Value<string>();
                checkValue = replacedValue;
                replacedValue = replacedValue.Replace("<p>", "");
                replacedValue = replacedValue.Replace("</p>", "");
                replacedValue = replacedValue.Replace("<ul>", "");
                replacedValue = replacedValue.Replace("<li>", "");
                replacedValue = replacedValue.Replace("</li></ul>", "");
                replacedValue = replacedValue.Replace("</li>", "; ");
                replacementsMade = (checkValue != replacedValue);
                MatchCollection collection = Regex.Matches(replacedValue, PATTERN, RegexOptions.Singleline);

                foreach (Match match in collection)
                {
                    replacementsMade = true;
                    string a = match.Groups[1].Value;
                    Match m2 = Regex.Match(a, @"href=\""(.*?)\""", RegexOptions.Singleline);
                    if (m2.Success)
                    {
                        href = m2.Groups[1].Value; //= http://www.microsoft.com
                    }

                    string linkText = Regex.Replace(a, @"\s*<.*?>\s*", "", RegexOptions.Singleline); //= Microsoft

                    newLinkText = "[" + linkText + " | " + href + "]";
                    replacedValue = replacedValue.Replace(a, newLinkText);
                }
            }
            catch
            {
                success = false;
            }

            if (replacementsMade)
            {
                Console.WriteLine("123");
            }
            return ( success ? (JToken)replacedValue : source );
        }

        public class comparedItem
        {
            public string Path { get; set; }
            public string Name { get; set; }
            public bool Manipulated { get; set; } = false;
            public bool SourceManipulated { get; set; } = false;
            public bool Included { get; set; } = false;
            public bool FormatMatch { get; set; } = false;
            public bool ContentMatch { get; set; } = false;
            public bool OriginalEmpty { get; set; } = false;
            public bool NewEmpty { get; set; } = false;
            public bool NewTruncated { get; set; } = false;
            public bool SizesDiffer { get; set; } = false;
            public string OriginalFormat { get; set; }
            public string NewFormat { get; set; }
            public string ComparisonDetail { get; set; }
            public int ComparisonId { get; set; }
            public bool ToDo { get; set; }
            public string Title { get; set; }

        }



        public JObject FindDiff(JToken Current, JToken Model, Dictionary<string, comparedItem> comparisons, string key = "", string path = "")
        {
            var diff = new JObject();
            comparedItem comparison = new comparedItem();
            bool replacementsMade = false;
            int currentSize = 0;
            int modelSize = 0;
            //if object
            if (Current.Type == JTokenType.Object)
            {
                // go deeper
                var current = Current as JObject;
                var model = Model as JObject;
                var addedKeys = current.Properties().Select(c => c.Name).Except(model.Properties().Select(c => c.Name));
                var removedKeys = model.Properties().Select(c => c.Name).Except(current.Properties().Select(c => c.Name));
                var unchangedKeys = current.Properties().Where(c => JToken.DeepEquals(c.Value, Model[c.Name])).Select(c => c.Name);
                foreach (var k in addedKeys)
                {
                    diff[k] = new JObject
                    {
                        ["+"] = Current[k]
                    };
                }
                var potentiallyModifiedKeys = current.Properties().Select(c => c.Name).Except(addedKeys);//.Except(unchangedKeys);
                foreach (var k in potentiallyModifiedKeys)
                {
                    diff[k] = FindDiff(current[k], model[k], comparisons, k, path + (path.Length > 0 ? "." : "") + k);
                }
                return diff;
            }
            comparisonCount++;

            if ( comparisonCount == 353)
            {
                Console.WriteLine("DEBUGBREAKPOINT");
            }
            comparison.ComparisonId = comparisonCount;
            JToken originalModel = Model;
            JToken originalCurrent = Current;
            if (Current.Type == JTokenType.Array)
            {
                // is the current  empty
                comparison.OriginalEmpty = (Current.ToString().Length < 2);
                currentSize = Current.Count();
                comparison.OriginalFormat = "ARRAY";
            }
            else
            {
                comparison.OriginalEmpty = (Current.ToString().Length == 0);
                currentSize = Current.ToString().Length;
                comparison.OriginalFormat = "STRING";
                comparison.Title = Current.ToString();
            }
            if (Current.Type == JTokenType.Array)
            {
                comparison.OriginalEmpty = (Current.Count() == 0);
            }
            else
            {
                comparison.OriginalEmpty = (Current.ToString().Length == 0);
            }
            if (Model.Type == JTokenType.Array)
            {
                // is the  model empty
                comparison.NewEmpty = (Model.Count() == 0);
                comparison.NewTruncated = ( Model.Count() > 0 ? Current.Count() > Model.Count() : false );
                modelSize = Current.Count();
                comparison.NewFormat = "ARRAY";
                comparison.ToDo = (Model.Count() > 0 ? Model[0].ToString().ToLower() == "todo" : false);
            }
            else
            {
                comparison.ToDo = (originalModel.ToString().ToLower() == "todo");
                comparison.NewEmpty = (Model.ToString().Length == 0);
                comparison.NewTruncated = (Model.ToString().Length > 0 ?  Current.ToString().Length / Model.ToString().Length > 2 : false);
                modelSize = Current.ToString().Length;
                comparison.NewFormat = "STRING";
            }

            comparison.SizesDiffer = Model.ToString().Length != Current.ToString().Length;

            // does the new and old type match
            comparison.FormatMatch = ( Current.Type == Model.Type );

            
            switch (key)
            {
                case "CareerPathAndProgression":
                case "Volunteering":
                case "OtherRoutes":
                    // make any data manipilations required to Current
                    if (Current.Type == JTokenType.Array)
                    {
                        JArray newCurrent = new JArray();
                        string singleItem = "";
                        foreach (var item in Current)
                        {
                            singleItem += item.ToString();
                        }
                        newCurrent.Add((JToken)singleItem);
                        diff["SINGLEARRAYITEM"] = newCurrent;
                        Current = newCurrent;
                        comparison.SourceManipulated = true;
                    }
                break;
                default:
                    break;
            }

            // are any data manipilations required to Model
            switch (key)
            {
                case "DigitalSkillsLevel":
                case "Overview":
                case "EntryRequirementPreface":
                case "Location":
                case "Environment":
                case "Uniform":
                case "ProfessionalAndIndustryBodies":
                case "CareerTips":
                case "FurtherInformation":
                case "AdditionalInformation":
                case "EntryRequirements":
                case "RelevantSubjects":
                case "DirectApplication":
                case "CareerPathAndProgression":
                case "Volunteering":
                case "OtherRoutes":
                    if (key == "RelevantSubjects")
                    {
                        Console.WriteLine("");

                    }
                    JArray newModel = new JArray();
                    if (Model.Type == JTokenType.Array)
                    {
                        foreach (var item in Model)
                        {
                            newModel.Add(ReplaceTags(item, out replacementsMade));
                            comparison.Manipulated = replacementsMade;
                        }
                        diff["REPLACETAGSARRAY"] = newModel;
                        Model = newModel;
                    }
                    else if (Model.Type != JTokenType.Object)
                    {
                        Model = ReplaceTags(Model, out replacementsMade);
                        diff["REPLACETAGSSTRING"] = Model;
                    }

                    break;
                default:
                    break;
            }

            if ( Current.Type == JTokenType.Array && Model.Type != JTokenType.Array)
            {
                JArray newModel = new JArray();
                newModel.Add(Model.ToString());
                Model = newModel;
                comparison.Manipulated = true;
            }



            // do they match
            comparison.ContentMatch = JToken.DeepEquals(Current, Model);

           
            

            StringBuilder message = new StringBuilder();

            message.Append(path + "\n");
            message.Append("-------------------------------------------\n");
            message.Append($"Source Format: {comparison.OriginalFormat}({currentSize}) ");
            message.Append($"New Format   : {comparison.NewFormat}({modelSize}) ");
            message.Append($"source transformed: {comparison.SourceManipulated} ");
            message.Append($"Content transformed: {comparison.Manipulated} ");
            message.Append($"Content Match: {comparison.ContentMatch}\n");
            message.Append("\n");


            message.Append("Original:\n");
            message.Append($"{originalCurrent.ToString()}\n");
            if (comparison.SourceManipulated)
            {
                message.Append("Original (transformed):\n");
                message.Append($"{Current.ToString()}\n");
            }
            message.Append("New:\n");
            message.Append($"{originalModel.ToString()}\n");
            if (comparison.Manipulated)
            {
                message.Append("New (tranformed):\n");
                message.Append($"{Model.ToString()}\n");
            }

            comparison.ComparisonDetail = message.ToString();
            comparisons.Add(path, comparison);

            return diff;
        } 
                                   
     


        [Given(@"mock test step")]
        public void GivenMockTestStep(string multilineText)
        {
            var responseSourceData = RestHelper.Get( context.GetTaxonomyApiBaseUrl() + "/job-profiles/bottler", context.GetJobProfileApiHeaders());

            var responseTestData = multilineText;
            Dictionary<string, comparedItem> comparison = new Dictionary<string, comparedItem>();

            var tempString = "{  \"SalaryStarter\": \"13500\", \"SalaryExperienced\": \"24000\", \"LastUpdatedDate\": \"ToDo\", \"MinimumHours\": 41.0, \"RelatedCareers\": [ \"ToDo\" ], \"Soc\": \"9134\", \"Title\": \"Bottler\", \"Overview\":\"<p>Bottlers fill, pack and operate bottling machinery in food, drink and bottling factories.</p>\", \"WorkingPattern\": \"evenings / weekends\", \"AlternativeTitle\": \"canning and bottling operative, canningoperative, canning and bottling worker, canner\", \"WorkingHoursDetails\": \"a week\", \"Url\": \"https://pp.api.nationalcareers.service.gov.uk/job-profiles/bottler\", \"WhatYouWillDo\": { \"WYDDayToDayTasks\": [ \"<p>keeping machinery clean and sterile, to meet high standards of food safety</p>\", \"<p>setting up machines and starting the bottling process</p>\", \"<p>making sure bottles or jars are correctly filled andlabelled</p>\", \"<p>reporting more serious machinery problems to your line manager or a technician</p>\", \"<p>sorting out any problems with the production line so bottling is not held up</p>\" ], \"WorkingEnvironment\": { \"Environment\": \"<p>Your working environment may be noisy.</p>\", \"Uniform\": \"\", \"Location\": \"<p>You could work in a factory.</p>\" } }, \"ONetOccupationalCode\": \"ToDo\", \"MaximumHours\": 43.0, \"WhatItTakes\": { \"Skills\": [ \"ToDo\" ], \"DigitalSkillsLevel\": \"<p>to be able to carry out basic tasks on a computer or hand-held device</p>\" }, \"CareerPathAndProgression\": { \"CareerPathAndProgression\": [ \"<p>With experience, you could progress to team supervisor or manager.</p>\" ] }, \"WorkingPatternDetails\": \"on shifts\", \"HowToBecome\": { \"EntryRoutes\": { \"University\": { \"AdditionalInformation\": [ \"ToDo\" ], \"EntryRequirements\": [ \"ToDo\",\"flippy\" ], \"RelevantSubjects\": [ \"ToDo\" ], \"FurtherInformation\": [ \"ToDo\" ], \"EntryRequirementPreface\": [ \"ToDo\" ] } }, \"EntryRouteSummary\": \"ToDo\", \"MoreInformation\": { \"Registration\": [ \"ToDo\" ], \"FurtherInformation\": [ \"\" ], \"ProfessionalAndIndustryBodies\": [ \"\" ], \"CareerTips\": [ \"\" ] } }}";
            dynamic sourceObject = JsonConvert.DeserializeObject(responseSourceData.Content);

            //exploreObject(sourceObject, 0, "TOP");

            JObject diffs = FindDiff(JToken.Parse(responseTestData), JToken.Parse(tempString), comparison);
            //exploreJsonObject(JToken.Parse(responseSourceData.Content), 0, "$", JObject.Parse(responseTestData) );
            string output = diffs.ToString();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(output);
            return;
     
        }

        [Given(@"htmloutputtest")]
        public void GivenHtmloutputtest()
        {
            var dataList = new List<TestDataClass>
        {
            new TestDataClass {Name = "A", Lastname = "B", Other = "ABO"},
            new TestDataClass {Name = "C", Lastname = "D", Other = "CDO"},
            new TestDataClass {Name = "E", Lastname = "F", Other = "EFO"},
            new TestDataClass {Name = "G", Lastname = "H", Other = "GHO"}
        };

            var headerList = new List<string> { "Name", "Surname", "Merge" };

            var customTableStyle = new List<EnumerableExtension.CustomTableStyle>
        {
            new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"font-family", "Comic Sans MS" },{"font-size","15px"}}},
            new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"background-color", "yellow" }}},
            new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Tr, InlineStyleValueList =new Dictionary<string, string>{{"color","Blue"},{"font-size","10px"}}},
            new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Th,ClassNameList = new List<string>{"normal","underline"}},
            new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Th,InlineStyleValueList =new Dictionary<string, string>{{ "background-color", "gray"}}},
            new EnumerableExtension.CustomTableStyle{CustomTableStylePosition = EnumerableExtension.CustomTableStylePosition.Td, InlineStyleValueList  =new Dictionary<string, string>{{"color","Red"},{"font-size","15px"}}},
        };

            var htmlResult = dataList.ToHtmlTable(headerList, customTableStyle, x => x.Name, x => x.Lastname, x => $"{x.Name} {x.Lastname}");
            Console.WriteLine(htmlResult);
        }



    }

    public class TestDataClass
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Other { get; set; }
    }

    public class CompairisonItem
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Other { get; set; }
    }
}
