using DFC.ServiceTaxonomy.TestSuite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class TaxonomyScenarioContextExtension
    {
        #region contants

        const string GetAllOccupations = "getalloccupations";
        const string GetAllSkills = "getallskills";
        const string GetSkillById = "getskillbyid";
        const string GetSkillsForOccupation = "getskillsforoccupation";
        const string GetSkillsGapForOccupationAndGivenSkills = "getskillsgapforoccupationandgivenskills";
        const string GetJobProfileDetail = "jobprofiledetail";
        const string GetSkillByLabelSearch = "getskillsbylabelsearch";
        const string GetOccupationByLabelSearch = "getoccupationsbylabelsearch";
        const string GetOccupationsWithMatchingSkills = "getoccupationswithmatchingskills";
        const string GetJobProfileSummary = "getjobprofilesummary";

        const string UriGetAllOccupations = "GetAllOccupations/Execute/";
        const string UriGetAllSkills = "GetAllSkills/Execute/";
        const string UriGetSkillById = "GetSkillById/Execute";
        const string UriGetSkillsForOccupation = "GetAllSkillsForOccupation/Execute";
        const string UriGetSkillsGapForOccupationAndGivenSkills = "GetSkillsGapForOccupationAndGivenSkills/Execute";
        const string UriGetJobProfileDetail = "GetJobProfileByTitle/Execute/";
        const string UriGetSkillByLabelSearch = "GetSkillsByLabel/Execute/";
        const string UriGetOccupationByLabelSearch = "GetOccupationsByLabel/Execute/";
        const string UriGetOccupationsWithMatchingSkills = "GetOccupationsWithMatchingSkills/Execute/";
        const string UriGetSTAXJobProfileSummary = "GetJobProfilesSummary/Execute/";

        const string UriJobProfileSummary = "summary";

        const string keyEscoData = "EscoItemList";
        const string keyOccupationData = "EscoOccupationList";
        const string keySkillData = "EscoSkillList";
        const string keyListOfStrings = "EscoListOfStrings";
        const string keyExpectedRecordCount = "ExpectedRecordCount";

     #endregion



    public static string GetTaxonomyUri(this ScenarioContext context, string resource, string param = "")
        {
            switch (resource.ToLower())
            {
                case GetAllSkills:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetAllSkills}";
                case GetAllOccupations:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetAllOccupations}";
                case GetSkillById:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetSkillById}";
                case GetSkillsForOccupation:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetSkillsForOccupation}";
                case GetSkillsGapForOccupationAndGivenSkills:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetSkillsGapForOccupationAndGivenSkills}";
                case GetJobProfileDetail:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetJobProfileDetail}/{param}";
                case GetSkillByLabelSearch:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetSkillByLabelSearch}/{param}";
                case GetOccupationByLabelSearch:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetOccupationByLabelSearch}/{param}";
                case GetOccupationsWithMatchingSkills:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetOccupationsWithMatchingSkills}/{param}";
                case GetJobProfileSummary:
                    return $"{context.GetEnv().taxonomyApiBaseUrl}/servicetaxonomy/{UriGetSTAXJobProfileSummary}/{param}";
                default:
                    return "";
            }
        }

        public static Dictionary<string, string> GetGraphSyncPartSettings(this ScenarioContext context)
        {
            return new Dictionary<string, string>()
            {
                { "NodeNameTransform", @"$""{ContentType}"""},
                { "PropertyNameTransform",@"$""{Value}"""},
                { "IDPropertyName", "uri" },
                { "GenerateIDValue", @"$""http://nationalcareers.service.gov.uk/{Value.ToLowerInvariant()}/{Guid.NewGuid()}""" }
            };
        }

        public static string GetJobProfileUri(this ScenarioContext context, string resource)
        {
            switch (resource.ToLower())
            {
                case "summary":
                    return context.GetEnv().jobProfileApiBaseUrl + "/" + UriJobProfileSummary;
                default:
                    return context.GetEnv().jobProfileApiBaseUrl + "/" + resource;
            }
        }

        #region envsettings
        public static string GetEscoApiBaseUrl(this ScenarioContext context) { return context.GetEnv().escoApiBaseUrl; }

        public static string GetTaxonomyApiBaseUrl(this ScenarioContext context) { return context.GetEnv().taxonomyApiBaseUrl; }
        public static string GetTaxonomySubscriptionKey(this ScenarioContext context) { return context.GetEnv().taxonomySubscriptionKey; }

        public static string GetJobProfileApiBaseUrl(this ScenarioContext context) { return context.GetEnv().jobProfileApiBaseUrl; }
        public static string GetJobProfileSubscriptionKey(this ScenarioContext context) { return context.GetEnv().jobProfileSubscriptionKey; }

        public static string GetEditorBaseUrl(this ScenarioContext context) { return context.GetEnv().editorBaseUrl; }
        public static string GetEditorUid(this ScenarioContext context) { return context.GetEnv().editorUid; }
        public static string GetEditorPassword(this ScenarioContext context) { return context.GetEnv().editorPassword; }

        public static string GetNeo4JUrl(this ScenarioContext context) { return context.GetEnv().neo4JUrl; }
        public static string GetNeo4JUid(this ScenarioContext context) { return context.GetEnv().neo4JUid; }
        public static string GetNeo4JPassword(this ScenarioContext context) { return context.GetEnv().neo4JPassword; }

        #endregion

        public static string GetSkillOrKnowlegeFromSkillTypeUri(this ScenarioContext context, string uri)
        {
            return (uri.Contains("knowledge") ? "knowledge" : "competency");
        }

        public static string SetEscoResponseDataGetSkillOrKnowlegeFromSkillTypeUri(this ScenarioContext context, string uri)
        {
            return (uri.Contains("knowledge") ? "knowledge" : "competency");
        }

        public static void SetEscoItemListData( this ScenarioContext context, IList<EscoDataItem> escoData)
        {
             context.Set<IList<EscoDataItem>>(escoData, keyEscoData);
        }
        public static IList<EscoDataItem> GetEscoItemListData(this ScenarioContext context)
        {
            return (context.ContainsKey(keyEscoData) ? context.Get<IList<EscoDataItem>>(keyEscoData) : null);
        }

        public static void SetOccupationListData(this ScenarioContext context, IList<Occupation> occupations)
        {
            context.Set<IList<Occupation>>(occupations, keyOccupationData);
        }

        public static void StoreUri(this ScenarioContext context, string newUri, string tag,  string type,  Object model , TeardownOption teardownOption)
        {
            var dataItems = GetDataItems(context);
            dataItems.Add(new _DataItem(newUri, tag, type, model, teardownOption) );
            context[constants.dataItems] = dataItems;
        }

        public static void StoreUri(this ScenarioContext context, string newUri, string tag = "")
        {
            StoreUri(context, newUri, tag, string.Empty, null, TeardownOption.None);
        }

        public static bool RelateDataItems(this ScenarioContext context, int parentRef, int childRef, string title, string relationshipType)
        {
            var dataItems = GetDataItems(context);
            try
            {
                dataItems[parentRef].linkedItems.Add(new _LinkedItem( title, relationshipType, dataItems[childRef]));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to add relationship: {e.Message}");
                
            }
            return true;
        }

        public static List <_DataItem> GetDataItems(this ScenarioContext context)
        {
            List<_DataItem> dataItems = context.ContainsKey(constants.dataItems) ? (List<_DataItem>)context[constants.dataItems] : new List<_DataItem>(); ;
            return dataItems;
        }

        public static string GetLatestUri(this ScenarioContext context)
        {
            var dataItems = GetDataItems(context);
            if (dataItems.Count == 0)
                return "";

            return dataItems.Last().Uri;
        }

        public static string ConvertUriToDraft(this ScenarioContext context, string uri)
        {
            return uri.ToLower().Replace(context.GetEnv().contentApiBaseUrl.ToLower(), context.GetEnv().contentApiDraftBaseUrl.ToLower());
        }

        public static string GetUri(this ScenarioContext context, int index)
        {
            var dataItems = GetDataItems(context);
            if (dataItems.Count < index - 1)
                return "";

            return dataItems[index].Uri;
        }

        public static string GetUri(this ScenarioContext context, string tag)
        {
            string uri = "";
            try
            {
                uri = GetDataItems(context).Where(d => d.Tag == tag).FirstOrDefault().Uri;
            }
            catch { }
            return uri;
        }

        public static string GetDraftUri(this ScenarioContext context, int index)
        {
            return ConvertUriToDraft(context, GetUri(context, index));
        }

        public static int GetNumberOfStoredUris(this ScenarioContext context)
        {
            var dataItems = GetDataItems(context);
            return dataItems.Count;
        }

        public static string GenerateUri(this ScenarioContext context, string contentType, string graph = constants.publish)
        {
            return $"{GetContentPath(context, graph)}/{contentType}/{Guid.NewGuid().ToString()}".ToLower();
        }

        public static string GetContentPath(this ScenarioContext context, string graph)
        {
            switch (graph)
            {
                case constants.publish:
                    return context.GetEnv().contentApiBaseUrl;
                case constants.preview:
                    return context.GetEnv().contentApiDraftBaseUrl;
                default:
                    return string.Empty;
            }
        }
        public static string GetContentUri(this ScenarioContext context, string contentType)
        {
            return $"{context.GetEnv().contentApiBaseUrl}/{contentType}";
        }

        public static string GetDraftContentUri(this ScenarioContext context, string contentType)
        {
            return $"{context.GetEnv().contentApiDraftBaseUrl}/{contentType}";
        }

        public static void StoreContentItemIndexList(this ScenarioContext context, List<ContentItemIndexRow> list)
        {
            context[constants.contentItemIndexes] = list;
        }

        public static List<ContentItemIndexRow> GetContentItemIndexList(this ScenarioContext context)
        {
            return context.ContainsKey(constants.contentItemIndexes) ? (List<ContentItemIndexRow>)context[constants.contentItemIndexes]
                                                                     : new List<ContentItemIndexRow>();
        }

        public static void StoreContentItemId(this ScenarioContext context, string newId)
        {
            List<string> uris;
            int count = (context.ContainsKey(constants.contentIdCount) ? (int)context[constants.contentIdCount] : 0);
            if (count == 0)
            {
                //initialise
                uris = new List<string>();
            }
            else
            {
                //retreive
                uris = (List<string>)context[constants.contentIds];
            }
            uris.Add(newId);
            count++;
            context[constants.contentIdCount] = count;
            context[constants.contentIds] = uris;
        }

        private static List<string> GetIds(this ScenarioContext context)
        {
            //expect zero based index
            List<string> ids = (context.ContainsKey(constants.contentIds) ? (List<string>)context[constants.contentIds] : new List<string>());
            return ids;
        }

        public static string GetContentItemId(this ScenarioContext context, int index)
        {
            //expect zero based index
            var ids = GetIds(context);

            if (ids.Count < index + 1)
            {
                return "";
            }
            return ids[index];
        }

        public static int GetNumberOfStoredContentIds(this ScenarioContext context)
        {
            //expect zero based index
            var ids = GetIds(context);
            return ids.Count;
        }

        public static void StoreRecordId(this ScenarioContext context, string newId)
        {
            int count = (context.ContainsKey(constants.recordIdCount) ? (int)context[constants.recordIdCount] : 0);
            var ids = GetIds(context);
            ids.Add(newId);
            count++;
            context[constants.recordIdCount] = count;
            context[constants.recordIds] = ids;
        }

        public static string GetId(this ScenarioContext context, int index)
        {
            //expect zero based index
            var ids = GetIds(context);

            if (ids.Count < index + 1 )
            {
                return "";
            }
            return ids[index];
        }

        public static IList<Occupation> GetOccupationListData(this ScenarioContext context)
        {
            return (context.ContainsKey(keyOccupationData) ? context.Get<IList<Occupation>>(keyOccupationData) : null);
        }

        public static int GetOccupationCount(this ScenarioContext context)
        {
            return (context.ContainsKey(keyOccupationData) ? context.Get<IList<Occupation>>(keyOccupationData).Count : 0);
        }

        public static void SetSkillListData(this ScenarioContext context, IList<Skill> skills)
        {
            context.Set<IList<Skill>>(skills, keySkillData);
        }

        public static IList<Skill> GetSkillListData(this ScenarioContext context)
        {
            return (context.ContainsKey(keySkillData) ? context.Get<IList<Skill>>(keySkillData) : null);
        }

        public static int GetSkillCount(this ScenarioContext context)
        {
            return (context.ContainsKey(keySkillData) ? context.Get<IList<Skill>>(keySkillData).Count : 0);
        }

        public static void SetExpectedRecordCount(this ScenarioContext context, int recordCount)
        {
            context.Set<int>(recordCount, keyExpectedRecordCount);
        }

        public static int GetExpectedRecordCount(this ScenarioContext context)
        {
            return (context.ContainsKey(keyExpectedRecordCount) ? context.Get<int>(keyExpectedRecordCount) : 0);
        }
        
        public static void SetEditorFields( this ScenarioContext context, Dictionary<string,string> vars, bool intial = false)
        {
            if (!context.ContainsKey(constants.requestVariables) || intial)
            {
                context[constants.requestVariables] = vars;
            }
            else
            {
                context[constants.requestVariablesUpdated] = vars;
            }
        }

        public static Dictionary<string,string> GetEditorFields( this ScenarioContext context, bool intial = false)
        {
            Dictionary<string, string> vars;
            if (context.ContainsKey(constants.requestVariablesUpdated) && !intial)
            {
                vars = ( Dictionary<string,string>) context[constants.requestVariablesUpdated];
            }
            else if (context.ContainsKey(constants.requestVariables))
            {
                vars = (Dictionary<string, string>)context[constants.requestVariables];
            }
            else 
            {
                vars = new Dictionary<string, string>();
            }
            return vars;
        }

        public static Dictionary<string,string> GetTaxonomyApiHeaders(this ScenarioContext context)
        {
            return context.ContainsKey(constants.securityHeader) ? 
                        (Dictionary < string,string >) context[constants.securityHeader] :
                        new Dictionary<string, string>(){
                                  { "Content-Type", "application/json" }, 
                                  { "Ocp-Apim-Subscription-Key", context.ContainsKey(constants.securityHeader)? (string) context[constants.securityHeader] : context.GetTaxonomySubscriptionKey() } 
                             };
        }

        public static Dictionary<string, string> GetJobProfileApiHeaders(this ScenarioContext context)
        {
            return new Dictionary<string, string>(){
                                                        { "Content-Type", "application/json" },
                                                        { "Ocp-Apim-Subscription-Key", context.GetJobProfileSubscriptionKey() },
                                                        { "version", "v1" }
                                                   };
        }

        public static Dictionary<string, string> GetContentApiHeaders(this ScenarioContext context)
        {
            return new Dictionary<string, string>(){
                                                        { "Content-Type", "application/json" },
                                                        { "Ocp-Apim-Subscription-Key", context.GetEnv().contentApiSubscriptionKey }
                                                   };
        }


    }
}
