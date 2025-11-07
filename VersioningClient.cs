// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.VersioningClient
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public class VersioningClient : ClientBase<IVersioningService>, IVersioningService
  {
    public static VersioningClient Create(
      string transportProtocol,
      string serverName,
      int port,
      string userName)
    {
      if (string.IsNullOrWhiteSpace(transportProtocol))
        throw new ArgumentException("The transport protocol can NOT be null or whitespace.", nameof (transportProtocol));
      if (string.IsNullOrWhiteSpace(serverName))
        throw new ArgumentException("The server name can NOT be null or whitespace.", nameof (serverName));
      if (string.IsNullOrWhiteSpace(userName))
        throw new ArgumentException("The user name can NOT be null or whitespace.", nameof (userName));
      VersioningClient versioningClient = new VersioningClient((Binding) WCFBindings.CreateEncryptedTcpBinding(TimeSpan.FromMinutes(1.0)), new EndpointAddress(new Uri(string.Format("{0}://{1}:{2}/ExternalVersioningService", (object) transportProtocol, (object) serverName, (object) port)), (EndpointIdentity) new DnsEndpointIdentity("localhost"), new AddressHeaderCollection()));
      WCFSecurity.SetClientCredentials(versioningClient.ClientCredentials, userName);
      return versioningClient;
    }

    public ICollection<ProductVersionDto> GetVersion(
      int? id = null,
      char? productId = null,
      Version currentVersion = null,
      DateTime? availabilityDate = null,
      bool isDeleted = false)
    {
      return this.Channel.GetVersion(id, productId, currentVersion, availabilityDate, isDeleted);
    }

    private VersioningClient(Binding binding, EndpointAddress endpointAddress)
      : base(binding, endpointAddress)
    {
    }
  }
}
