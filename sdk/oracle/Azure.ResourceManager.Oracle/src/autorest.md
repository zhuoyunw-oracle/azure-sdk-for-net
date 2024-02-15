# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Oracle
namespace: Azure.ResourceManager.Oracle
require: /Users/zhuoyunw/workspace/azure-rest-api-specs/specification/oracle/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

rename-mapping:
  DataCollectionOptions: DataCollectionConfig

#mgmt-debug:
#  show-serialized-names: true


format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag

directive:
  - remove-operation: GiVersions_Get
  - remove-operation: DbSystemShapes_Get
  - remove-operation: OracleSubscriptions_CreateOrUpdate
  - remove-operation: OracleSubscriptions_Delete
  - remove-operation: OracleSubscriptions_Update
  - remove-operation: OracleSubscriptions_ListCloudAccountDetails
  - remove-operation: OracleSubscriptions_ListSaasSubscriptionDetails
  # DnsPrivateViews ListByLocation is still generated even if removed here
  - remove-opeartion: DnsPrivateViews_ListByLocation
  - remove-operation: DnsPrivateViews_Get
  - remove-operation: DnsPrivateZones_ListByLocation
  - remove-operation: DnsPrivateZones_Get
  - remove-operation: VirtualNetworkAddresses_ListByCloudVmCluster
  - remove-operation: VirtualNetworkAddresses_Get
  - remove-operation: VirtualNetworkAddresses_Delete
  # Vnet Create API is still generated even if removed here
  - remove-opeartion: VirtualNetworkAddresses_CreateOrUpdate
  - remove-operation: DbNodes_ListByCloudVmCluster
  - remove-operation: DbNodes_Get
  - from: openapi.json
    where: $.definitions.CloudExadataInfrastructureProperties.properties.dataStorageSizeInTbs
    transform: >
      $['format'] = "double";
      $['type'] = "number";
  # The arrays are always read-only in the generated SDK even if it's defined as read & create in the specs, transform cannot help here 
  # - from: openapi.json
  #   where: $.definitions.CloudVmClusterProperties.properties
  #   transform: >
  #       $.sshPublicKeys = {
  #           "type": "array",
  #           "description": "The public key portion of one or more key pairs used for SSH access to the cloud VM cluster.",
  #           "items": {
  #             "type": "string"
  #           },
  #           "x-ms-mutability": [
  #               "read",
  #               "create"
  #           ]
  #       };
```