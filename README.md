# dfc-servicetaxonomy-tests

## Introduction

Test suite for regression test of Service Taxonomy Editor

### Local config

Create local config file: appsettings.local.json

Event Store and SQL Server checks can be disabled for locally hosted

Currently there is no support for preview / published graph hosted in a single neo4j enterprise instance 

```
{
  "TaxonomyApi": {
    "BaseUrl": "################",
    "SubscriptionKey": "####################"
  },
  "ContentApi": {
    "BaseUrl": "########################",
    "BaseUrlDraft": "#######################",
    "SubscriptionKey": "##############################"
  },
  "JobProfileApi": {
    "BaseUrl": "#########################",
    "SubscriptionKey": "#########################"
  },
  "EscoApi": {
    "BaseUrl": "############################"
  },
  "Neo4J": {
    "Url": "############################",
    "UrlDraft": "#############################",
    "Uid": "#####",
    "Password": "#############"
  },
  "Editor": {
    "BaseUrl": "##########################",
    "Uid": "###############",
    "Password": "#####################"
  },
  "SqlServer": {
    "ChecksEnabled": "true",
    "ConnectionString": "#########################"
  },
  "EventStore": {
    "CheckEvents": "true",
    "BaseUrl": "#######################################",
    "Key": "#######################################"
  }
}
```