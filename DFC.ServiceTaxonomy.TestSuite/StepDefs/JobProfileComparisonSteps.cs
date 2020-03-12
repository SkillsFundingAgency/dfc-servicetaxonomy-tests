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


        [Then(@"The output for each API matches for all job profiles")]
        public void ThenTheOutputForEachAPIMatchesForAllJobProfiles()
        {
            //List<JobProfileSummary> allJobProfiles = (List<JobProfileSummary>)context["AllJobProfiles"];

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

            List<Dictionary<String, String>> allDicts = new List<Dictionary<String, String>>();
            List<Dictionary<String, String>> allNewDicts = new List<Dictionary<String, String>>();
            List<Dictionary<String, String>> allcheckStatusDicts = new List<Dictionary<String, String>>();
            List<Dictionary<String, String>> allDetails = new List<Dictionary<String, String>>();


            Dictionary<String, String> longestList = new Dictionary<string, string>();
            

            int max = 2000;
            int count = 0;
            foreach ( var jobProfile in allJobProfiles)
            {
                Dictionary<string, String> structure = new Dictionary<string, string>();
                Dictionary<string, String> newStructure = new Dictionary<string, string>();
                Dictionary<string, String> checkStatus = new Dictionary<string, string>();
                Dictionary<string, String> details = new Dictionary<string, string>();
                //  get source job profile data

                var responseSourceData = RestHelper.Get("https://pp.api.nationalcareers.service.gov.uk/job-profiles/" + jobProfile.title /*jobProfile.url*/, context.GetJobProfileApiHeaders());

                //  get test subject job profile data
                string unslug = char.ToUpper(jobProfile.title[0])  +  jobProfile.title.Replace("-"," ").Substring(1);
                if (unslug == "Mp") unslug = "MP";
                if (unslug == "Border force officer") unslug = "Border Force officer";
                
                var responseTestData = RestHelper.Get(context.GetTaxonomyUri("JobProfileDetail", unslug),context.GetTaxonomyApiHeaders() );

                structure.Add("JobProfile", jobProfile.title);// url.Substring(jobProfile.url.LastIndexOf('/')));
                newStructure.Add("JobProfile", jobProfile.title);//.url.Substring(jobProfile.url.LastIndexOf('/')));
                checkStatus.Add("JobProfile", jobProfile.title);//.url.Substring(jobProfile.url.LastIndexOf('/')));
                details.Add("JobProfile", jobProfile.title);//.url.Substring(jobProfile.url.LastIndexOf('/')));

                if (responseTestData.StatusCode == HttpStatusCode.OK)
                    {
                        // compare data
                        JObject diffs = FindDiff(JToken.Parse(responseSourceData.Content), JToken.Parse(responseTestData.Content), structure, newStructure, checkStatus, details);
                        //exploreJsonObject(JToken.Parse(responseSourceData.Content), 0, "$", JObject.Parse(responseTestData) );
              //          string output = diffs.ToString();
              //         Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
              //          Console.WriteLine(output);
                    }

                if (structure.Count > longestList.Count)
                {
                    longestList = structure;
                }

                allDicts.Add(structure);
                allNewDicts.Add(newStructure);
                allcheckStatusDicts. Add(checkStatus);
                allDetails.Add(details);
                count++;
                if (count > max) break;
            }

   
            foreach ( var kv in allDicts[0])
            {
                Console.Write(kv.Key +", STAX,");
            }
            Console.WriteLine();
            foreach (var item in allDicts)
            {
                Dictionary<String, String> newItem = new Dictionary<string, string>();
                foreach ( var dict in allNewDicts)
                {
                    if (dict["JobProfile"] == item["JobProfile"])
                    {
                        newItem = dict;
                        break;
                    }
                }
                foreach (var kv in longestList)
                {
                    Console.Write( (item.ContainsKey(kv.Key) ? item[kv.Key] : "NOVALUE") + ",");
                    Console.Write( (newItem.ContainsKey(kv.Key) ? newItem[kv.Key] : "NOVALUE") + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");


            var customTableStyles = new List<CustomTableStyle>
            {
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"font-family", "Comic Sans MS" },{"font-size","15px"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Table, InlineStyleValueList = new Dictionary<string, string>{{"background-color", "white" }}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Tr, InlineStyleValueList =new Dictionary<string, string>{{"color","Blue"},{"font-size","10px"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Th,ClassNameList = new List<string>{"normal","underline"}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Th,InlineStyleValueList =new Dictionary<string, string>{{ "background-color", "gray"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.Td, InlineStyleValueList  =new Dictionary<string, string>{{"color","black"},{"font-size","15px"}}},
                new CustomTableStyle{CustomTableStylePosition = CustomTableStylePosition.TdGood, InlineStyleValueList  =new Dictionary<string, string>{{"color","green"},{"font-size","15px"}}},
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


            var sb = new StringBuilder();

            sb.Append($"<table{(string.IsNullOrEmpty(tableCss) ? "" : $" class=\"{tableCss}\"")}{(string.IsNullOrEmpty(tableInlineCss) ? "" : $" style=\"{tableInlineCss}\"")}>");


            sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");

            Console.Write("FieldName,");
            sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}FieldName</th>");
            foreach (var dict in allDicts)
            {
                string jp = dict["JobProfile"];
                Console.Write(jp + ",Stax Api,Status,");
                sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}>{jp}</th>");
                sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}>STax API</th>");
                sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}>Status</th>");
            }
            sb.Append("</tr>");

            Console.WriteLine();
            foreach ( var item in longestList.Where( item => item.Key != "JobProfile") )
            {
                sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");

                Console.Write(item.Key + ",");
                sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")}{(string.IsNullOrEmpty(tdInlineCss) ? "" : $" style=\"{tdInlineCss}\"")}>{item.Key}</td>");
                foreach ( var dict in allDicts)
                {
                    Dictionary<String, String> newItem = new Dictionary<string, string>();
                    foreach (var newDict in allNewDicts)
                    {
                        if (dict["JobProfile"] == newDict["JobProfile"])
                        {
                            newItem = newDict;
                            break;
                        }
                    }
                    Dictionary<String, String> newCheck = new Dictionary<string, string>();
                    foreach (var newDict in allcheckStatusDicts)
                    {
                        if (dict["JobProfile"] == newDict["JobProfile"])
                        {
                            newCheck = newDict;
                            break;
                        }
                    }
                    Dictionary<String, String> newDetails = new Dictionary<string, string>();
                    foreach ( var newDets in allDetails)
                    {
                        if (dict["JobProfile"] == newDets["JobProfile"])
                        {
                            newDetails = newDets;
                            break;
                        }

                    }
                    string jp = dict["JobProfile"];
                    Console.Write( ( dict.ContainsKey(item.Key)? dict[item.Key] : "N/A") + ",");
                    Console.Write((newItem.ContainsKey(item.Key) ? newItem[item.Key] : "N/A") + ",");
                    Console.Write((newCheck.ContainsKey(item.Key) ? newCheck[item.Key] : "???") + ",");
                    sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")}{(string.IsNullOrEmpty(tdInlineCss) ? "" : $" style=\"{tdInlineCss}\"")}>{ (dict.ContainsKey(item.Key) ? dict[item.Key] : "N/A")}</td>");
                    sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")} Title=\"{(newDetails.ContainsKey(item.Key)? newDetails[item.Key].Replace("\"", "&quot;") :"")}\" {(string.IsNullOrEmpty(tdInlineCss) ? "" : $" style=\"{tdInlineCss}\"")}>{ (newItem.ContainsKey(item.Key) ? newItem[item.Key] : "N/A")}</td>");
                    sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")}{(string.IsNullOrEmpty(tdInlineCss) ? "" : $" style=\"{(newCheck.ContainsKey(item.Key) && newCheck[item.Key]=="Match"? tdInlineCssGood :  tdInlineCss)}\"")}>{ (newCheck.ContainsKey(item.Key) ? newCheck[item.Key] : "???")}</td>");

                }
                sb.Append("</tr>");
                Console.WriteLine();
            }

            sb.Append("</table>");

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(sb);

            string path = @"D:\wamp64\www\jobprofiles\comparison.html";

            if (File.Exists(path))
            {
                File.Delete(@"D:\wamp64\www\jobprofiles\comparison.html");
            }
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, sb.ToString()) ;
            }



        }

        [Given(@"I compare actor")]
        public void GivenICompareActor()
        {

            string url = "https://pp.api.nationalcareers.service.gov.uk/job-profiles/actor";
            string sitUrl = "https://sit.api.nationalcareersservice.org.uk/job-profiles/Actor";
            var responseSourceData = RestHelper.Get(url, context.GetJobProfileApiHeaders());
            Dictionary<string, String> structure = new Dictionary<string, string>();
            Dictionary<string, String> newStructure = new Dictionary<string, string>();
            Dictionary<string, String> checkStatus = new Dictionary<string, string>();
            Dictionary<string, String> details = new Dictionary<string, string>();
            var responseTestData = RestHelper.Get("https://sit.api.nationalcareersservice.org.uk/servicetaxonomy/getjobprofilebytitle/Execute/Actor" , context.GetTaxonomyApiHeaders());

            // compare data
            JObject diffs = FindDiff(JToken.Parse(responseSourceData.Content), JToken.Parse(responseTestData.Content),structure,newStructure, checkStatus, details);
            //exploreJsonObject(JToken.Parse(responseSourceData.Content), 0, "$", JObject.Parse(responseTestData) );
            string output = diffs.ToString();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(output);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            foreach ( var item in structure)
            {
                Console.WriteLine(item.Key + "," + item.Value);
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
            return ( success ? (JToken)replacedValue : source );
        }

        public JObject FindDiff(JToken Current, JToken Model, Dictionary<string,string> structure, Dictionary<string, string> modelStructure, Dictionary<string, string> checkStatus, Dictionary<string,string> details, string key = "", string path = "")
        {
            var diff = new JObject();
            JArray newModel = new JArray();
            bool replacementsMade = false;
            string detailsString = "";
            // exception handling

            detailsString = Current.ToString() + "\n\n-------vs--------\n\n" + (Model == null? " ... " :Model.ToString());
            details.Add(path + (path.Length > 0 ? "." : "") + key, detailsString);

            switch (Current.Type)
            {
                case JTokenType.Array:
                    var current = Current as JArray;

                    structure.Add(path + (path.Length > 0 ? "." : "") + key, "[" + current.Count + "]");
                    //structure.Add(path + (path.Length > 0 ? "." : "") + key, "[" + current.Count + "]");

                    if (Model != null)
                    {
                        if (Model.Type == JTokenType.Array)
                        {
                            var model = Model as JArray;
                            modelStructure.Add(path + (path.Length > 0 ? "." : "") + key, "[" + model.Count + "]");
                        }
                        else
                        {
                            modelStructure.Add(path + (path.Length > 0 ? "." : "") + key, "STRING" + (Model.ToString().ToLower() == "todo" ? "_TODO" : (Model.ToString().Length == 0 ? "_EMPTY" : "")));
                        }
                    }
                    else
                    {
                        modelStructure.Add(path + (path.Length > 0 ? "." : "") + key, "MISSING");
                    }




                    break;
                case JTokenType.Object:
                    break;
                default:
                    structure.Add(path + (path.Length > 0 ? "." : "") + key, "STRING" + (Current.ToString().Length == 0 ? "_EMPTY" : ""));
                    if (Model != null)
                    {
                        if (Model.Type == JTokenType.Array)
                        {
                            var model = Model as JArray;
                            modelStructure.Add(path + (path.Length > 0 ? "." : "") + key, "[" + model.Count + "]");
                        }
                        else
                        {
                            modelStructure.Add(path + (path.Length > 0 ? "." : "") + key, "STRING" + (Model.ToString().ToLower() == "todo" ? "_TODO" : (Model.ToString().Length == 0 ? "_EMPTY" : "")));
                        }
                    }
                    else
                    {
                        modelStructure.Add(path + (path.Length > 0 ? "." : "") + key, "MISSING");
                    }
                    break;

            }
            switch (key)
            {
                // SIMPLE SKIPS
       //         case "AlternativeTitle":
                case "LastUpdatedDate":
       //         case "ONetOccupationalCode":
                case "Skills":
                case "Url":
                    return diff;

                // SINGLE VALUE REPLACEMENTS
                case "DigitalSkillsLevel":
                case "Overview":
                case "EntryRequirementPreface":
                case "Location":
                case "Environment":
                    JToken newToken = ReplaceTags(Model, out replacementsMade);
                    diff["REPLACETAGSTEXT"] = newToken; 
                    Model = newToken;
                    break;

                // ARRAY REPLACEMENTS
                case "ProfessionalAndIndustryBodies":
                case "CareerTips":
                case "FurtherInformation":
                case "AdditionalInformation":

                case "EntryRequirements":
                case "RelevantSubjects":
 //               case "Volunteering":
                case "DirectApplication":
 //               case "OtherRoutes":

                    if (key == "RelevantSubjects")
                    {
                        Console.WriteLine("");

                    }
                    foreach (var item in Model)
                    {
                        newModel.Add(ReplaceTags(item, out replacementsMade));
                    }
                    diff["REPLACETAGSARRAY"] = newModel;
                    Model = newModel;
                    break;

                case "CareerPathAndProgression":
                case "Volunteering":
                case "OtherRoutes":
                    if (Current.Type == JTokenType.Array)
                    {
                        JArray newCurrent = new JArray();
                        string singleItem = "";
                        foreach ( var item in Current)
                        {
                            singleItem += item.ToString();
                        }
                        newCurrent.Add((JToken)singleItem);
                        diff["SINGLEARRAYITEM"] = newCurrent;
                        Current = newCurrent;
                        foreach (var item in Model)
                        {
                            newModel.Add(ReplaceTags(item, out replacementsMade));
                        }
                        diff["REPLACETAGSARRAY"] = newModel;
                        Model = newModel;
                    }
                    break;

                default:
                    break;
            }


            if (JToken.DeepEquals(Current, Model))
            {
                checkStatus.Add(path + (path.Length > 0 ? "." : "") + key, "Match" + (replacementsMade ? "(WithMods)" : ""));
                return diff;
            };
            switch (Current.Type)
            {
                case JTokenType.Object:
                    {
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
                        foreach (var k in removedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["-"] = Model[k]
                            };
                        }
                        var potentiallyModifiedKeys = current.Properties().Select(c => c.Name).Except(addedKeys);//.Except(unchangedKeys);
                        foreach (var k in potentiallyModifiedKeys)
                        {
                            diff[k] = FindDiff(current[k], model[k], structure,  modelStructure, checkStatus, details, k, path + (path.Length > 0?".":"") + k);
                        }
                    }
                    break;
                case JTokenType.Array:
                    {
                        var current = Current as JArray;
                        var model = Model as JArray;
                        //structure.Add(path + (path.Length > 0 ? "." : "") + key, "[" + current.Count + "]");
                        if (model != null)
                        {
                            diff["+"] = new JArray(current.Except(model));
                            diff["-"] = new JArray(model.Except(current));
                            checkStatus.Add(path + (path.Length > 0 ? "." : "") + key, "Mismatch");
                        }
                        else
                        {
                            diff["-"] = new JArray(current);
                            checkStatus.Add(path + (path.Length > 0 ? "." : "") + key, "Missing");
                        }
                        
                    }
                    break;
                default:
                    //  var parentProperty = Current.Ancestors<JProperty>()
                    //        .FirstOrDefault();

                    // alternatively, if you know it'll be a property:
                    //structure.Add(path + (path.Length > 0 ? "." : "") + key, "STRING_" + Current.ToString().Length);
                    var parentProperty2 = ((JProperty)Current.Parent);

                    checkStatus.Add(path + (path.Length > 0 ? "." : "") + key, "StrMismatch");
                    diff["+"] = Current;
                    diff["-"] = Model;
                    break;
            }

            return diff;
        }


        [Given(@"mock test step")]
        public void GivenMockTestStep(string multilineText)
        {
            var responseSourceData = RestHelper.Get("https://sit.api.nationalcareersservice.org.uk/job-profiles/bottler", context.GetJobProfileApiHeaders());

            var responseTestData = multilineText;
            Dictionary<string, String> structure = new Dictionary<string, string>();
            Dictionary<string, String> newStructure = new Dictionary<string, string>();
            Dictionary<string, String> checkStatus = new Dictionary<string, string>();
            Dictionary<string, String> details = new Dictionary<string, string>();
            var tempString = "{  \"SalaryStarter\": \"13500\", \"SalaryExperienced\": \"24000\", \"LastUpdatedDate\": \"ToDo\", \"MinimumHours\": 41.0, \"RelatedCareers\": [ \"ToDo\" ], \"Soc\": \"9134\", \"Title\": \"Bottler\", \"Overview\":\"<p>Bottlers fill, pack and operate bottling machinery in food, drink and bottling factories.</p>\", \"WorkingPattern\": \"evenings / weekends\", \"AlternativeTitle\": \"canning and bottling operative, canningoperative, canning and bottling worker, canner\", \"WorkingHoursDetails\": \"a week\", \"Url\": \"https://pp.api.nationalcareers.service.gov.uk/job-profiles/bottler\", \"WhatYouWillDo\": { \"WYDDayToDayTasks\": [ \"<p>keeping machinery clean and sterile, to meet high standards of food safety</p>\", \"<p>setting up machines and starting the bottling process</p>\", \"<p>making sure bottles or jars are correctly filled andlabelled</p>\", \"<p>reporting more serious machinery problems to your line manager or a technician</p>\", \"<p>sorting out any problems with the production line so bottling is not held up</p>\" ], \"WorkingEnvironment\": { \"Environment\": \"<p>Your working environment may be noisy.</p>\", \"Uniform\": \"\", \"Location\": \"<p>You could work in a factory.</p>\" } }, \"ONetOccupationalCode\": \"ToDo\", \"MaximumHours\": 43.0, \"WhatItTakes\": { \"Skills\": [ \"ToDo\" ], \"DigitalSkillsLevel\": \"<p>to be able to carry out basic tasks on a computer or hand-held device</p>\" }, \"CareerPathAndProgression\": { \"CareerPathAndProgression\": [ \"<p>With experience, you could progress to team supervisor or manager.</p>\" ] }, \"WorkingPatternDetails\": \"on shifts\", \"HowToBecome\": { \"EntryRoutes\": { \"University\": { \"AdditionalInformation\": [ \"ToDo\" ], \"EntryRequirements\": [ \"ToDo\",\"flippy\" ], \"RelevantSubjects\": [ \"ToDo\" ], \"FurtherInformation\": [ \"ToDo\" ], \"EntryRequirementPreface\": [ \"ToDo\" ] } }, \"EntryRouteSummary\": \"ToDo\", \"MoreInformation\": { \"Registration\": [ \"ToDo\" ], \"FurtherInformation\": [ \"\" ], \"ProfessionalAndIndustryBodies\": [ \"\" ], \"CareerTips\": [ \"\" ] } }}";
            dynamic sourceObject = JsonConvert.DeserializeObject(responseSourceData.Content);

            //exploreObject(sourceObject, 0, "TOP");

            JObject diffs = FindDiff(JToken.Parse(responseTestData), JToken.Parse(tempString), structure, newStructure, checkStatus, details);
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
