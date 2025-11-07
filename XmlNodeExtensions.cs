// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.XmlNodeExtensions
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml;

#nullable disable
namespace Cadwell.Licensing.Common
{
  internal static class XmlNodeExtensions
  {
    public static XmlAttribute AddAttribute(this XmlNode node, [Localizable(false)] string name, string value)
    {
      XmlAttribute attribute = XmlNodeExtensions.GetOwnerDocument(node).CreateAttribute(name);
      attribute.Value = value;
      node.Attributes.Append(attribute);
      return attribute;
    }

    [Localizable(false)]
    public static XmlElement AddChildElement(this XmlNode node, [Localizable(false)] string name, string value)
    {
      name = name.Replace(" ", string.Empty);
      XmlElement element = XmlNodeExtensions.GetOwnerDocument(node).CreateElement(name);
      element.InnerText = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "\"{0}\"", (object) value);
      node.AppendChild((XmlNode) element);
      return element;
    }

    [Localizable(false)]
    public static XmlElement AddChildElement(this XmlNode node, [Localizable(false)] string name)
    {
      name = name.Replace(" ", string.Empty);
      XmlElement element = XmlNodeExtensions.GetOwnerDocument(node).CreateElement(name);
      node.AppendChild((XmlNode) element);
      return element;
    }

    private static XmlDocument GetOwnerDocument(XmlNode node)
    {
      return node is XmlDocument xmlDocument ? xmlDocument : node.OwnerDocument;
    }
  }
}
