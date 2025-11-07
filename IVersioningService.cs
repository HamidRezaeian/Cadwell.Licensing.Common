// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.IVersioningService
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Collections.Generic;
using System.ServiceModel;

#nullable disable
namespace Cadwell.Licensing.Common
{
  [ServiceContract]
  public interface IVersioningService
  {
    [OperationContract]
    ICollection<ProductVersionDto> GetVersion(
      int? id = null,
      char? productId = null,
      Version currentVersion = null,
      DateTime? availabilityDate = null,
      bool isDeleted = false);
  }
}
