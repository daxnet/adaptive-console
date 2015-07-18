using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcfEditor.Domain;
using AdaptiveConsole;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            EditorProject project = EditorProject.Create();
            project.Name = "test project";
            project.ApplicationProviderSettings = new ApplicationProviderSettings();
            project.ApplicationProviderSettings.Logo = "logo";
            project.ApplicationProviderSettings.Description = "desc";

            project.ApplicationContractSettings = new ApplicationContractSettings();

            OptionSetting optionSetting1 = new OptionSetting(project);
            optionSetting1.PropertyName = "Method";
            optionSetting1.Attributes = new OptionAttribute();
            optionSetting1.Attributes.Name = "/nologo";
            ContractSetting contractSetting1 = new ContractSetting(project);
            contractSetting1.Name = "CalcContract";
            contractSetting1.Attributes = new OptionContractAttribute();
            contractSetting1.Attributes.Argument = "/method;/m";
            contractSetting1.ContractOptionSettings = new ContractOptionSettings();
            contractSetting1.ContractOptionSettings.Add(optionSetting1);

            project.ApplicationContractSettings.Add(contractSetting1);
            project.ApplicationContractSettings.Add(contractSetting1);

            project.ReferencedAssembliesSettings = new ReferencedAssembliesSettings();
            project.ReferencedAssembliesSettings.Add("System.dll");
            project.ReferencedAssembliesSettings.Add("System.Windows.Forms.dll");

            EditorProject.Save("C:\\editorproject.xml", project);

            //EditorProject project = EditorProject.Load("C:\\editorproject.xml");
        }
    }
}
