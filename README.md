# dfc-servicetaxonomy-tests

## Introduction

Test suite for regression test of Service Taxonomy Editor

### Local config

Create local config file: appsettings.local.json

Event Store and SQL Server checks can be disabled for locally hosted


```
{
  "Config": {
    "CaptureScreenshots": "false",
    "Environment": "local"
  },
  "TaxonomyApi": {
    "BaseUrl": "###########################",
    "SubscriptionKey": "###########################"
  },
  "ContentApi": {
    "BaseUrl": "###########################",
    "BaseUrlDraft": "###########################",
    "SubscriptionKey": "###########################"
  },
  "JobProfileApi": {
    "BaseUrl": "###########################",
    "SubscriptionKey": "###########################"
  },
  "EscoApi": {
    "BaseUrl": "http://ec.europa.eu/esco/api"
  },
  "Neo4J": {
    "GraphName": "###########################",
    "GraphNameDraft": "###########################",
    "Url": "###########################",
    "UrlDraft": "###########################",
    "Url1": "",
    "UrlDraft1": "",
    "Uid": "###########################",
    "Password": "###########################",
    "UidDraft": "###########################",
    "PasswordDraft": "###########################"

  },
  "Editor": {
    "BaseUrl": "###########################",
    "Uid": "###########################",
    "Password": "###########################"
  },
  "SqlServer": {
    "ChecksEnabled": "true",
    "ConnectionString": "###########################"
  },
  "EventStore": {
    "CheckEvents": "true",
    "BaseUrl": "###########################",
    "Key": "###########################"
  },
  "EventGrid": {
    "PublishEvents": "true",
    "ContentType": "*",
    "TopicEndpoint": "###########################",
    "AegSasKey": "###########################"
  }
}
```