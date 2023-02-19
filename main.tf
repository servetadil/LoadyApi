provider "azurerm" {
	version = "3.44.1"
	features {}
}

resource "azurerm_resource_group" "loady_rg" {
    name = "loadymainrg"
    location =  "West Europe"
}

resource "azurerm_container_group" "loady_cg" {
  name                = "loadyapi"
  location            = azurerm_resource_group.loady_rg.location
  resource_group_name = azurerm_resource_group.loady_rg.name
  ip_address_type     = "Public"
  dns_name_label      = "loadyassesment"
  os_type             = "Linux"

  container {
        name    = "loadyapi"
        image   = "servetadil/loadyapiassesment"
        cpu = "1"
        memory = "1"
        ports {
            port = 80
            protocol = "TCP"
        }
  }
}

resource "azurerm_cosmosdb_account" "cosmosdb" {
  name                = "loadyapidb-driver-storage"
  location            = azurerm_resource_group.loady_rg.location
  resource_group_name = azurerm_resource_group.loady_rg.name
  offer_type          = "Standard"
  kind                = "MongoDB"

  enable_automatic_failover = true

  capabilities {
    name = "EnableAggregationPipeline"
  }

  capabilities {
    name = "mongoEnableDocLevelTTL"
  }

  capabilities {
    name = "MongoDBv3.4"
  }

  capabilities {
    name = "EnableMongo"
  }

  consistency_policy {
    consistency_level       = "BoundedStaleness"
    max_interval_in_seconds = 300
    max_staleness_prefix    = 100000
  }

  geo_location {
    location          = "westeurope"
    failover_priority = 0
  }
}