<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="0fea2c71-175e-4639-a9e7-350295c9a966" namespace="AdaptiveConsole.Config" xmlSchemaNamespace="urn:AdaptiveConsole.Config" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="AdaptiveConsoleConfiguration" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="adaptiveConsole">
      <attributeProperties>
        <attributeProperty name="Provider" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="provider" isReadOnly="false" documentation="Gets or sets the name of the type which represents the console application instance.">
          <type>
            <externalTypeMoniker name="/0fea2c71-175e-4639-a9e7-350295c9a966/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Repositories" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="repositories" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/0fea2c71-175e-4639-a9e7-350295c9a966/ContractRepositoryElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="ContractRepositoryElementCollection" xmlItemName="repository" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/0fea2c71-175e-4639-a9e7-350295c9a966/ContractRepositoryElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ContractRepositoryElement">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/0fea2c71-175e-4639-a9e7-350295c9a966/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Assembly" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="assembly" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/0fea2c71-175e-4639-a9e7-350295c9a966/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>