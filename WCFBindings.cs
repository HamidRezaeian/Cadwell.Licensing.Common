// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.WCFBindings
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public static class WCFBindings
  {
    public static CustomBinding CreateEncryptedTcpBinding(
      TimeSpan receiveTimeout,
      TransferMode transferMode = TransferMode.Buffered)
    {
      TimeSpan timeSpan = new TimeSpan(0, 1, 0);
      SecurityBindingElement transportBindingElement1 = (SecurityBindingElement) SecurityBindingElement.CreateUserNameOverTransportBindingElement();
      SslStreamSecurityBindingElement securityBindingElement = new SslStreamSecurityBindingElement();
      securityBindingElement.RequireClientCertificate = true;
      BinaryMessageEncodingBindingElement encodingBindingElement = new BinaryMessageEncodingBindingElement();
      encodingBindingElement.ReaderQuotas.MaxDepth = 100000000;
      encodingBindingElement.ReaderQuotas.MaxStringContentLength = 100000000;
      encodingBindingElement.ReaderQuotas.MaxArrayLength = 100000000;
      encodingBindingElement.ReaderQuotas.MaxBytesPerRead = 100000000;
      encodingBindingElement.ReaderQuotas.MaxNameTableCharCount = 100000000;
      TcpTransportBindingElement transportBindingElement2 = new TcpTransportBindingElement();
      transportBindingElement2.MaxReceivedMessageSize = 100000000L;
      transportBindingElement2.MaxBufferSize = 100000000;
      transportBindingElement2.MaxBufferPoolSize = 100000000L;
      transportBindingElement2.TransferMode = transferMode;
      BindingElementCollection bindingElementsInTopDownChannelStackOrder = new BindingElementCollection();
      bindingElementsInTopDownChannelStackOrder.Add((BindingElement) transportBindingElement1);
      bindingElementsInTopDownChannelStackOrder.Add((BindingElement) securityBindingElement);
      bindingElementsInTopDownChannelStackOrder.Add((BindingElement) encodingBindingElement);
      bindingElementsInTopDownChannelStackOrder.Add((BindingElement) transportBindingElement2);
      CustomBinding encryptedTcpBinding = new CustomBinding((IEnumerable<BindingElement>) bindingElementsInTopDownChannelStackOrder);
      encryptedTcpBinding.Name = "TcpUserNameBinding";
      encryptedTcpBinding.CloseTimeout = timeSpan;
      encryptedTcpBinding.OpenTimeout = timeSpan;
      encryptedTcpBinding.ReceiveTimeout = receiveTimeout;
      encryptedTcpBinding.SendTimeout = timeSpan;
      return encryptedTcpBinding;
    }

    public static NetTcpBinding CreateTcpBindingForLANAccess(TimeSpan receiveTimeout)
    {
      NetTcpBinding bindingForLanAccess = new NetTcpBinding();
      bindingForLanAccess.ReceiveTimeout = receiveTimeout;
      return bindingForLanAccess;
    }

    public static NetNamedPipeBinding CreateNetNamedPipeBinding()
    {
      return WCFBindings.CreateNetNamedPipeBinding(new TimeSpan(0, 10, 0));
    }

    public static NetNamedPipeBinding CreateNetNamedPipeBinding(TimeSpan receiveTimeout)
    {
      TimeSpan timeSpan = new TimeSpan(0, 1, 0);
      NetNamedPipeBinding namedPipeBinding = new NetNamedPipeBinding();
      namedPipeBinding.CloseTimeout = timeSpan;
      namedPipeBinding.OpenTimeout = timeSpan;
      namedPipeBinding.ReceiveTimeout = receiveTimeout;
      namedPipeBinding.SendTimeout = timeSpan;
      namedPipeBinding.TransactionFlow = false;
      namedPipeBinding.TransferMode = TransferMode.Buffered;
      namedPipeBinding.TransactionProtocol = TransactionProtocol.OleTransactions;
      namedPipeBinding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
      namedPipeBinding.MaxBufferPoolSize = 524288L;
      namedPipeBinding.MaxBufferSize = 65536;
      namedPipeBinding.MaxConnections = 10;
      namedPipeBinding.MaxReceivedMessageSize = 65536L;
      namedPipeBinding.ReaderQuotas = new XmlDictionaryReaderQuotas()
      {
        MaxDepth = 32,
        MaxStringContentLength = 65536,
        MaxArrayLength = 65536,
        MaxBytesPerRead = 65536,
        MaxNameTableCharCount = 65536
      };
      namedPipeBinding.Security.Mode = NetNamedPipeSecurityMode.Transport;
      namedPipeBinding.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;
      return namedPipeBinding;
    }

    public static NetNamedPipeBinding CreateNetNamedPipeBindingMax(TimeSpan receiveTimeout)
    {
      NetNamedPipeBinding namedPipeBinding = WCFBindings.CreateNetNamedPipeBinding(receiveTimeout);
      namedPipeBinding.MaxBufferPoolSize = 100000000L;
      namedPipeBinding.MaxBufferPoolSize = 100000000L;
      namedPipeBinding.MaxBufferSize = 100000000;
      namedPipeBinding.MaxReceivedMessageSize = 100000000L;
      namedPipeBinding.ReaderQuotas.MaxArrayLength = 100000000;
      namedPipeBinding.ReaderQuotas.MaxBytesPerRead = 100000000;
      namedPipeBinding.ReaderQuotas.MaxDepth = 100000000;
      namedPipeBinding.ReaderQuotas.MaxNameTableCharCount = 100000000;
      namedPipeBinding.ReaderQuotas.MaxStringContentLength = 100000000;
      return namedPipeBinding;
    }
  }
}
