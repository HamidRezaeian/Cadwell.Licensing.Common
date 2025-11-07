// Decompiled with JetBrains decompiler
// Type: Cadwell.Licensing.Common.EventLogLogger
// Assembly: Cadwell.Licensing.Common, Version=1.0.1.0, Culture=neutral, PublicKeyToken=3f9e0bcfc5b88807
// MVID: E0316D83-C586-4802-9D2B-173C2D8159AF
// Assembly location: C:\Program Files (x86)\NeuroGuide\CadwellAssemblies\Cadwell.Licensing.Common.dll

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Security;
using System.ServiceModel;
using System.Xml;

#nullable disable
namespace Cadwell.Licensing.Common
{
  public static class EventLogLogger
  {
    public const string ClsEventLogName = "FeatureLicensing";

    private static EventLog GetEventLog(string eventViewerLogName, string eventViewerSourceName)
    {
      EventLog eventLog = new EventLog();
      if (!EventLog.Exists(eventViewerLogName) || !EventLog.SourceExists(eventViewerSourceName))
        EventLog.CreateEventSource(eventViewerSourceName, eventViewerLogName);
      eventLog.Source = eventViewerSourceName;
      eventLog.Log = eventViewerLogName;
      eventLog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 0);
      return eventLog;
    }

    private static XmlElement CreateElementAndInitialize(XmlDocument xmlDocument, [Localizable(false)] string name)
    {
      XmlElement element = xmlDocument.CreateElement(name.Replace(" ", "_"));
      if (Assembly.GetEntryAssembly() != (Assembly) null)
      {
        element.AddAttribute("AssemblyVersion", Assembly.GetEntryAssembly().GetName().Version.ToString());
        element.AddAttribute("FileVersion", FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion);
      }
      xmlDocument.AppendChild((XmlNode) element);
      return element;
    }

    private static void FormatException(Exception exception, ref XmlElement exceptionElement)
    {
      if (exception == null)
        return;
      exceptionElement.AddAttribute("Type", exception.GetType().ToString());
      exceptionElement.AddAttribute("Message", exception.Message);
      exceptionElement.AddChildElement("Source", exception.Source);
      if (exception.TargetSite != (MethodBase) null)
      {
        if (exception.TargetSite.DeclaringType != (Type) null)
          exceptionElement.AddChildElement("Class", exception.TargetSite.DeclaringType.FullName);
        exceptionElement.AddChildElement("Method", exception.TargetSite.Name);
      }
      exceptionElement.AddChildElement("Stack Trace", exception.StackTrace);
      if (exception is FaultException<ExceptionDetail> faultException)
      {
        XmlElement exceptionElement1 = exceptionElement.AddChildElement("FaultDetails");
        EventLogLogger.RecordFaultDetails(faultException.Detail, ref exceptionElement1);
      }
      if (exception.InnerException == null)
        return;
      XmlElement exceptionElement2 = exceptionElement.AddChildElement("InnerException");
      EventLogLogger.FormatException(exception.InnerException, ref exceptionElement2);
    }

    private static void RecordFaultDetails(ExceptionDetail details, ref XmlElement exceptionElement)
    {
      exceptionElement.AddAttribute("Type", details.Type);
      exceptionElement.AddAttribute("Message", details.Message);
      exceptionElement.AddChildElement("Stack Trace", details.StackTrace);
      if (details.InnerException == null)
        return;
      XmlElement exceptionElement1 = exceptionElement.AddChildElement("InnerException");
      EventLogLogger.RecordFaultDetails(details.InnerException, ref exceptionElement1);
    }

    public static bool LogUnhandledException(
      string eventViewerLogName,
      string eventViewerSourceName,
      Exception exception)
    {
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement elementAndInitialize = EventLogLogger.CreateElementAndInitialize(xmlDocument, "Exception");
      EventLogLogger.FormatException(exception, ref elementAndInitialize);
      return EventLogLogger.LogMessage(eventViewerLogName, eventViewerSourceName, xmlDocument.OuterXml, EventLogEntryType.Error);
    }

    public static bool LogException(
      string eventViewerLogName,
      string eventViewerSourceName,
      Exception exception,
      string headerMessage)
    {
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement elementAndInitialize = EventLogLogger.CreateElementAndInitialize(xmlDocument, headerMessage);
      EventLogLogger.FormatException(exception, ref elementAndInitialize);
      return EventLogLogger.LogMessage(eventViewerLogName, eventViewerSourceName, xmlDocument.OuterXml, EventLogEntryType.Warning);
    }

    public static bool LogMessage(
      string eventViewerLogName,
      string eventViewerSourceName,
      string message,
      EventLogEntryType entryType = EventLogEntryType.Information)
    {
      try
      {
        using (EventLog eventLog = EventLogLogger.GetEventLog(eventViewerLogName, eventViewerSourceName))
        {
          eventLog.Source = eventViewerSourceName;
          eventLog.Log = eventViewerLogName;
          eventLog.WriteEntry(message, entryType);
        }
        return true;
      }
      catch (SecurityException ex)
      {
        return false;
      }
    }
  }
}
