// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.Properties.Settings
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace Cadwell.Licensing.Common.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("net.tcp://licensing.cadwellservices.com:33334/ExternalLicensingService")]
    public string ServerUrl => (string) this[nameof (ServerUrl)];

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("net.tcp://licensesvrtest:33335/ExternalLicensingService")]
    public string TrainingServerUrl => (string) this[nameof (TrainingServerUrl)];
  }
}
