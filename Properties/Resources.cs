// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.Properties.Resources
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace Cadwell.Licensing.Common.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Cadwell.Licensing.Common.Properties.Resources.resourceMan == null)
          Cadwell.Licensing.Common.Properties.Resources.resourceMan = new ResourceManager("Cadwell.Licensing.Common.Properties.Resources", typeof (Cadwell.Licensing.Common.Properties.Resources).Assembly);
        return Cadwell.Licensing.Common.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Cadwell.Licensing.Common.Properties.Resources.resourceCulture;
      set => Cadwell.Licensing.Common.Properties.Resources.resourceCulture = value;
    }

    internal static string AnswerToLife
    {
      get => Cadwell.Licensing.Common.Properties.Resources.ResourceManager.GetString(nameof (AnswerToLife), Cadwell.Licensing.Common.Properties.Resources.resourceCulture);
    }
  }
}
